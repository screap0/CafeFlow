using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MySql.Data.MySqlClient;
using CafeFlowApi.Hubs;
using Newtonsoft.Json;

namespace CafeFlowApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IHubContext<OrderHub> _hubContext;
        private readonly DatabaseConnection _dbConnection;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IHubContext<OrderHub> hubContext, DatabaseConnection dbConnection, ILogger<OrdersController> logger)
        {
            _hubContext = hubContext;
            _dbConnection = dbConnection;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] Order order)
        {
            Console.WriteLine("Bildirim alındı: " + order.Isim);
            _logger.LogInformation("Bildirim (SignalR): {Isim}, Masa No: {MasaNo}, Tutar: {ToplamTutar}, Tarih: {SiparisTarihi}, Durum: {Durum}",
                order.Isim, order.MasaNo, order.ToplamTutar, order.SiparisTarihi, order.Durum);

            if (order == null)
            {
                return BadRequest(new { message = "Veri eksik" });
            }

            try
            {
                int orderId;
                using (var connection = _dbConnection.GetConnection())
                {
                    await connection.OpenAsync();
                    string query = "INSERT INTO Siparisler (isim, masa_no, telefon, siparis_aciklamasi, toplam_tutar, siparis_tarihi, durum) VALUES (@isim, @masaNo, @telefon, @siparisAciklamasi, @toplamTutar, @siparisTarihi, @durum); SELECT LAST_INSERT_ID();";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@isim", order.Isim);
                        command.Parameters.AddWithValue("@masaNo", order.MasaNo);
                        command.Parameters.AddWithValue("@telefon", order.Telefon);
                        command.Parameters.AddWithValue("@siparisAciklamasi", order.SiparisAciklamasi);
                        command.Parameters.AddWithValue("@toplamTutar", order.ToplamTutar);
                        command.Parameters.AddWithValue("@siparisTarihi", order.SiparisTarihi);
                        command.Parameters.AddWithValue("@durum", order.Durum ?? "Ödeme Tamamlandı");

                        orderId = Convert.ToInt32(await command.ExecuteScalarAsync());
                    }
                }

                _logger.LogInformation("Gönderilen orderId: {OrderId}", orderId); // Log ekle

                await _hubContext.Clients.All.SendAsync("ReceiveOrderUpdate",
                    orderId,
                    order.Isim,
                    order.MasaNo,
                    order.Telefon,
                    order.SiparisAciklamasi,
                    order.ToplamTutar,
                    order.SiparisTarihi,
                    order.Durum ?? "Ödeme Tamamlandı");

                return Ok(new { message = "Sipariş eklendi ve bildirim gönderildi", orderId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Hata: " + ex.Message });
            }
        }

        public class Order
        {
            public string Isim { get; set; }
            public int MasaNo { get; set; }
            public string Telefon { get; set; }
            public string SiparisAciklamasi { get; set; }
            public decimal ToplamTutar { get; set; }
            public DateTime SiparisTarihi { get; set; }
            public string Durum { get; set; }
        }
    }
}