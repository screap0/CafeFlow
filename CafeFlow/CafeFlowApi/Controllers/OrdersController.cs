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
                // Veritabanına kayıt yapılmıyor!
                // Sadece istemcilere SignalR ile bildirim gönderiliyor.
                await _hubContext.Clients.All.SendAsync("ReceiveOrderUpdate",
                    0, // ID bilinmediğinden 0 gönderiliyor veya hiç gönderme
                    order.Isim,
                    order.MasaNo,
                    order.Telefon,
                    order.SiparisAciklamasi,
                    order.ToplamTutar,
                    order.SiparisTarihi,
                    order.Durum ?? "Ödeme Tamamlandı");

                return Ok(new { message = "Bildirim gönderildi" });
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