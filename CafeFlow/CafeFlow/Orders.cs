using System;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CafeFlow
{
    public partial class Orders : Form
    {
        private HubConnection hubConnection;
        private DatabaseConnection dbConnection;

        public Orders()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            SetupSignalR();
            LoadInitialOrders(); // Form açıldığında mevcut siparişleri yükle
        }

        private async void SetupSignalR()
        {
            // SignalR Hub bağlantısını kur
            hubConnection = new HubConnectionBuilder()
                .WithUrl("https://www.cafeflow.com.tr/orderHub") // Sunucu adresin (test için localhost kullanıyorsan: https://localhost:5001/orderHub)
                .Build();

            // Yeni sipariş bildirimi alındığında çalışacak metod
            hubConnection.On<int, string, int, string, string, decimal, DateTime>("ReceiveOrderUpdate", (orderId, isim, masaNo, telefon, aciklama, toplamTutar, siparisTarihi) =>
            {
                this.Invoke((Action)(() =>
                {
                    AddOrderToPanel(orderId, isim, masaNo, telefon, aciklama, toplamTutar, siparisTarihi);
                }));
            });

            try
            {
                await hubConnection.StartAsync();
                MessageBox.Show("SignalR bağlantısı kuruldu.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("SignalR bağlantı hatası: " + ex.Message);
            }
        }

        private async Task LoadInitialOrders()
        {
            try
            {
                using (var connection = dbConnection.GetConnection())
                {
                    await connection.OpenAsync();
                    string query = "SELECT id, isim, masa_no, telefon, siparis_aciklamasi, toplam_tutar, siparis_tarihi " +
                                  "FROM Siparisler ORDER BY siparis_tarihi DESC LIMIT 50";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                int orderId = reader.GetInt32(0); // id
                                string isim = reader.GetString(1); // isim
                                int masaNo = reader.GetInt32(2); // masa_no (int olarak güncellendi)
                                string telefon = reader.IsDBNull(3) ? "Yok" : reader.GetString(3); // telefon (NULL olabilir)
                                string aciklama = reader.GetString(4); // siparis_aciklamasi
                                decimal toplamTutar = reader.GetDecimal(5); // toplam_tutar
                                DateTime siparisTarihi = reader.GetDateTime(6); // siparis_tarihi

                                AddOrderToPanel(orderId, isim, masaNo, telefon, aciklama, toplamTutar, siparisTarihi);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Başlangıç siparişleri yüklenirken hata: " + ex.Message);
            }
        }

        private void AddOrderToPanel(int orderId, string isim, int masaNo, string telefon, string aciklama, decimal toplamTutar, DateTime siparisTarihi)
        {
            Panel orderPanel = new Panel
            {
                Size = new System.Drawing.Size(200, 120), // Telefon için daha fazla yer ayırdık
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            Label lblIsim = new Label
            {
                Text = $"İsim: {isim}",
                Location = new System.Drawing.Point(5, 5),
                AutoSize = true
            };
            Label lblMasaNo = new Label
            {
                Text = $"Masa: {masaNo}",
                Location = new System.Drawing.Point(5, 25),
                AutoSize = true
            };
            Label lblTelefon = new Label
            {
                Text = $"Telefon: {telefon}",
                Location = new System.Drawing.Point(5, 45),
                AutoSize = true
            };
            Label lblAciklama = new Label
            {
                Text = $"Açıklama: {aciklama}",
                Location = new System.Drawing.Point(5, 65),
                AutoSize = true
            };
            Label lblTutar = new Label
            {
                Text = $"Tutar: {toplamTutar} TL",
                Location = new System.Drawing.Point(5, 85),
                AutoSize = true
            };
            Label lblTarih = new Label
            {
                Text = $"Tarih: {siparisTarihi.ToString("dd/MM/yyyy HH:mm")}",
                Location = new System.Drawing.Point(5, 105),
                AutoSize = true
            };

            orderPanel.Controls.Add(lblIsim);
            orderPanel.Controls.Add(lblMasaNo);
            orderPanel.Controls.Add(lblTelefon);
            orderPanel.Controls.Add(lblAciklama);
            orderPanel.Controls.Add(lblTutar);
            orderPanel.Controls.Add(lblTarih);

            orderLayoutPanel.Controls.Add(orderPanel);
        }

        // Form kapatıldığında SignalR bağlantısını kapat
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            hubConnection?.StopAsync().Wait();
            base.OnFormClosing(e);
        }
    }
}