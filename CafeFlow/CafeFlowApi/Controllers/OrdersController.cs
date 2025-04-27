using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MySql.Data.MySqlClient;
using CafeFlowApi.Hubs;

namespace CafeFlowApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IHubContext<OrderHub> _hubContext;
        private readonly DatabaseConnection _dbConnection;

        public OrdersController(IHubContext<OrderHub> hubContext, DatabaseConnection dbConnection)
        {
            _hubContext = hubContext;
            _dbConnection = dbConnection;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] Order order)
        {
            try
            {
                using (var connection = _dbConnection.GetConnection())
                {
                    await connection.OpenAsync();
                    string query = "INSERT INTO Siparisler (isim, masa_no, telefon, siparis_aciklamasi, toplam_tutar, siparis_tarihi) " +
                                   "VALUES (@isim, @masaNo, @telefon, @aciklama, @toplamTutar, @siparisTarihi)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@isim", order.Isim);
                        command.Parameters.AddWithValue("@masaNo", order.MasaNo);
                        command.Parameters.AddWithValue("@telefon", order.Telefon ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@aciklama", order.SiparisAciklamasi);
                        command.Parameters.AddWithValue("@toplamTutar", order.ToplamTutar);
                        command.Parameters.AddWithValue("@siparisTarihi", order.SiparisTarihi);
                        await command.ExecuteNonQueryAsync();

                        // Yeni eklenen siparişin ID'sini al
                        command.CommandText = "SELECT LAST_INSERT_ID()";
                        int orderId = Convert.ToInt32(await command.ExecuteScalarAsync());

                        // SignalR ile istemcilere bildir
                        await _hubContext.Clients.All.SendAsync("ReceiveOrderUpdate", orderId, order.Isim, order.MasaNo, order.Telefon, order.SiparisAciklamasi, order.ToplamTutar, order.SiparisTarihi);
                        Console.WriteLine($"Sipariş #{orderId} için bildirim gönderildi: {order.Isim}, {order.SiparisTarihi}"); // Log ekle
                    }
                }
                return Ok(new { message = "Sipariş eklendi" });
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
          
        }
    }
}