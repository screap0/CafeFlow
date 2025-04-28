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
                    string query = "INSERT INTO Siparisler (isim, masa_no, telefon, siparis_aciklamasi, toplam_tutar, siparis_tarihi, durum) " +
                                   "VALUES (@isim, @masaNo, @telefon, @aciklama, @toplamTutar, @siparisTarihi, @durum)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@isim", order.Isim);
                        command.Parameters.AddWithValue("@masaNo", order.MasaNo);
                        command.Parameters.AddWithValue("@telefon", order.Telefon ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@aciklama", order.SiparisAciklamasi);
                        command.Parameters.AddWithValue("@toplamTutar", order.ToplamTutar);
                        command.Parameters.AddWithValue("@siparisTarihi", order.SiparisTarihi);
                        command.Parameters.AddWithValue("@durum", order.Durum ?? "Ödeme Tamamlandı"); // Varsayılan değer
                        await command.ExecuteNonQueryAsync();

                        // Yeni eklenen siparişin ID'sini al
                        command.CommandText = "SELECT LAST_INSERT_ID()";
                        int orderId = Convert.ToInt32(await command.ExecuteScalarAsync());

                        // SignalR ile istemcilere bildir
                        await _hubContext.Clients.All.SendAsync("ReceiveOrderUpdate", orderId, order.Isim, order.MasaNo, order.Telefon, order.SiparisAciklamasi, order.ToplamTutar, order.SiparisTarihi, order.Durum ?? "Ödeme Tamamlandı");
                        Console.WriteLine($"Sipariş #{orderId} için bildirim gönderildi: {order.Isim}, {order.SiparisTarihi}, Durum: {order.Durum}");
                    }
                }
                return Ok(new { message = "Sipariş eklendi" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Hata: " + ex.Message });
            }
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateOrderStatus(int id, [FromBody] UpdateStatusRequest request)
        {
            try
            {
                using (var connection = _dbConnection.GetConnection())
                {
                    await connection.OpenAsync();
                    string query = "UPDATE Siparisler SET durum = @durum WHERE id = @id";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@durum", request.Durum);
                        command.Parameters.AddWithValue("@id", id);
                        int rowsAffected = await command.ExecuteNonQueryAsync();

                        if (rowsAffected == 0)
                        {
                            return NotFound(new { message = "Sipariş bulunamadı" });
                        }

                        // Güncellenen siparişin detaylarını al ve istemcilere bildir
                        query = "SELECT id, isim, masa_no, telefon, siparis_aciklamasi, toplam_tutar, siparis_tarihi, durum " +
                                "FROM Siparisler WHERE id = @id";
                        command.CommandText = query;
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                int orderId = reader.GetInt32(0);
                                string isim = reader.GetString(1);
                                int masaNo = reader.GetInt32(2);
                                string telefon = reader.IsDBNull(3) ? "Yok" : reader.GetString(3);
                                string aciklama = reader.GetString(4);
                                decimal toplamTutar = reader.GetDecimal(5);
                                DateTime siparisTarihi = reader.GetDateTime(6);
                                string durum = reader.GetString(7);

                                // SignalR ile istemcilere bildir
                                await _hubContext.Clients.All.SendAsync("ReceiveOrderUpdate", orderId, isim, masaNo, telefon, aciklama, toplamTutar, siparisTarihi, durum);
                            }
                        }
                    }
                }
                return Ok(new { message = "Sipariş durumu güncellendi" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Hata: " + ex.Message });
            }
        }

        public class UpdateStatusRequest
        {
            public string Durum { get; set; }
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