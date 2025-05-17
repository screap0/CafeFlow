using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CafeFlow
{
    public partial class Stok : Form
    {
        DatabaseConnection db = new DatabaseConnection();
        int seciliStokID = -1;
        string kullaniciadi;
        string txtform;

        public Stok(string kullaniciadi)
        {
            InitializeComponent();
            this.kullaniciadi = kullaniciadi;
            txtform = "Stok";

            // Butonlara olay bağlama
            yenileBtn.Click += YenileBtn_Click;
            silBtn.Click += SilBtn_Click;
            guncelleBtn.Click += GuncelleBtn_Click;
            dataGridViewStok.CellClick += DataGridViewStok_CellClick;
            ekleBtn.Click += ekleBtn_Click;
            dataGridViewStok.RowPrePaint += dataGridViewStok_RowPrePaint;
            tahminiBtn.Click += TahminiBtn_Click;

            // Sayfa yüklendiğinde verileri getir
            StoklariYukle();
            TahminleriYukle();
        }

        private void StoklariYukle()
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Stok ORDER BY SonGuncelleme DESC";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewStok.DataSource = table;
                    dataGridViewStok.Refresh();
                    dataGridViewStok.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Stoklar yüklenirken hata: " + ex.Message);
                    db.Log(txtform, "Error: " + ex, DateTime.Now, kullaniciadi);
                }
            }
        }

        private void TahminleriYukle()
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            s.StokID, 
                            s.UrunAdi, 
                            s.Miktar, 
                            s.Aciklama,
                            AVG(sh.Miktar) as OrtalamaTuketim,
                            (s.Miktar / NULLIF(AVG(sh.Miktar), 0)) as TahminiGun
                        FROM Stok s
                        LEFT JOIN StokHareket sh ON s.StokID = sh.StokID
                        WHERE sh.HareketTuru = 'Güncelle' AND sh.Tarih >= DATE_SUB(NOW(), INTERVAL 30 DAY)
                        GROUP BY s.StokID, s.UrunAdi, s.Miktar, s.Aciklama
                        HAVING TahminiGun <= 30 OR s.Miktar <= 10";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewTahmin.DataSource = table;
                    dataGridViewTahmin.Refresh();
                    dataGridViewTahmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tahminler yüklenirken hata: " + ex.Message);
                    db.Log(txtform, "Error: " + ex, DateTime.Now, kullaniciadi);
                }
            }
        }

        private void LogStokHareket(int stokID, string urunAdi, int miktar, string hareketTuru, string aciklama)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO StokHareket (StokID, UrunAdi, Miktar, HareketTuru, Aciklama, Tarih, KullaniciAdi) " +
                                   "VALUES (@stokID, @urunAdi, @miktar, @hareketTuru, @aciklama, NOW(), @kullaniciAdi)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@stokID", stokID);
                        cmd.Parameters.AddWithValue("@urunAdi", urunAdi);
                        cmd.Parameters.AddWithValue("@miktar", miktar);
                        cmd.Parameters.AddWithValue("@hareketTuru", hareketTuru);
                        cmd.Parameters.AddWithValue("@aciklama", aciklama);
                        cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciadi);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    db.Log(txtform, "Stok hareket loglama hatası: " + ex, DateTime.Now, kullaniciadi);
                }
            }
        }

        private void YenileBtn_Click(object sender, EventArgs e)
        {
            StoklariYukle();
            TahminleriYukle();
            Temizle();
        }

        private void DataGridViewStok_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewStok.Rows.Count > e.RowIndex)
            {
                DataGridViewRow row = dataGridViewStok.Rows[e.RowIndex];
                seciliStokID = Convert.ToInt32(row.Cells["StokID"].Value);
                urunTxt.Text = row.Cells["UrunAdi"].Value.ToString();
                miktarTxt.Text = row.Cells["Miktar"].Value.ToString();
                aciklamaTxt.Text = row.Cells["Aciklama"].Value.ToString();
            }
        }

        private void GuncelleBtn_Click(object sender, EventArgs e)
        {
            if (seciliStokID == -1)
            {
                MessageBox.Show("Lütfen güncellemek için bir stok seçin.");
                return;
            }

            string urun = urunTxt.Text.Trim();
            string aciklama = aciklamaTxt.Text.Trim();
            if (!int.TryParse(miktarTxt.Text.Trim(), out int miktar))
            {
                MessageBox.Show("Miktar sayısal bir değer olmalıdır.");
                return;
            }

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Stok SET UrunAdi=@urun, Miktar=@miktar, Aciklama=@aciklama, SonGuncelleme=NOW() WHERE StokID=@id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@urun", urun);
                        cmd.Parameters.AddWithValue("@miktar", miktar);
                        cmd.Parameters.AddWithValue("@aciklama", aciklama);
                        cmd.Parameters.AddWithValue("@id", seciliStokID);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Stok başarıyla güncellendi.");
                    LogStokHareket(seciliStokID, urun, miktar, "Güncelle", aciklama);
                    db.Log(txtform, "Stok güncellendi: " + "Ürün Adı:" + urun + " Ürün Miktarı: " + miktar + " Ürün Açıklaması: " + aciklama, DateTime.Now, kullaniciadi);
                    StoklariYukle();
                    TahminleriYukle();
                    Temizle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme sırasında hata: " + ex.Message);
                    db.Log(txtform, "Error: " + ex, DateTime.Now, kullaniciadi);
                }
            }
        }

        private void SilBtn_Click(object sender, EventArgs e)
        {
            if (seciliStokID == -1)
            {
                MessageBox.Show("Lütfen silmek için bir stok seçin.");
                return;
            }

            DialogResult result = MessageBox.Show("Seçilen stok silinsin mi?", "Onay", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM Stok WHERE StokID=@id";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", seciliStokID);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Stok başarıyla silindi.");
                        LogStokHareket(seciliStokID, urunTxt.Text, Convert.ToInt32(miktarTxt.Text), "Sil", aciklamaTxt.Text);
                        db.Log(txtform, "Stok silindi: " + "Stok ID: " + seciliStokID, DateTime.Now, kullaniciadi);
                        StoklariYukle();
                        TahminleriYukle();
                        Temizle();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Silme sırasında hata: " + ex.Message);
                        db.Log(txtform, "Error: " + ex, DateTime.Now, kullaniciadi);
                    }
                }
            }
        }

        private void Temizle()
        {
            urunTxt.Text = "";
            miktarTxt.Text = "";
            aciklamaTxt.Text = "";
            seciliStokID = -1;
        }

        private void ekleBtn_Click(object sender, EventArgs e)
        {
            StokEkle stokEkleFormu = new StokEkle(kullaniciadi);
            stokEkleFormu.FormClosed += (s, args) =>
            {
                StoklariYukle();
                TahminleriYukle();
            };
            stokEkleFormu.ShowDialog();
        }

        private void TahminiBtn_Click(object sender, EventArgs e)
        {
            TahminleriYukle();
            MessageBox.Show("Stok tahminleri güncellendi.");
        }

        private void dataGridViewStok_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dataGridViewStok.Rows[e.RowIndex].Cells["Miktar"].Value != null)
            {
                int miktar = Convert.ToInt32(dataGridViewStok.Rows[e.RowIndex].Cells["Miktar"].Value);
                if (miktar <= 10)
                {
                    dataGridViewStok.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkRed;
                    dataGridViewStok.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    dataGridViewStok.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(34, 44, 52);
                    dataGridViewStok.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        private void RaporBtn_Click(object sender, EventArgs e)
        {
            if (seciliStokID == -1)
            {
                MessageBox.Show("Lütfen rapor için bir stok seçin.");
                return;
            }

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            s.UrunAdi,
                            s.Miktar as MevcutStok,
                            COALESCE(SUM(CASE 
                                WHEN sh.HareketTuru = 'Güncelle' 
                                AND sh.Tarih >= DATE_SUB(NOW(), INTERVAL 30 DAY)
                                THEN sh.Miktar 
                                ELSE 0 
                            END), 0) as Son30GunSatis,
                            CASE 
                                WHEN s.Miktar < COALESCE(SUM(CASE 
                                    WHEN sh.HareketTuru = 'Güncelle' 
                                    AND sh.Tarih >= DATE_SUB(NOW(), INTERVAL 30 DAY)
                                    THEN sh.Miktar 
                                    ELSE 0 
                                END), 0) THEN 'UYARI: Stok miktarı son 30 günlük satıştan az!'
                                ELSE 'Stok yeterli'
                            END as Durum
                        FROM Stok s
                        LEFT JOIN StokHareket sh ON s.StokID = sh.StokID
                        WHERE s.StokID = @stokID
                        GROUP BY s.StokID, s.UrunAdi, s.Miktar";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@stokID", seciliStokID);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string rapor = $"Stok Raporu\n\n" +
                                             $"Ürün Adı: {reader["UrunAdi"]}\n" +
                                             $"Mevcut Stok: {reader["MevcutStok"]}\n" +
                                             $"Son 30 Günlük Satış: {reader["Son30GunSatis"]}\n" +
                                             $"Durum: {reader["Durum"]}";

                                MessageBox.Show(rapor, "Stok Raporu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Rapor oluşturulurken hata: " + ex.Message);
                    db.Log(txtform, "Error: " + ex, DateTime.Now, kullaniciadi);
                }
            }
        }
    }
}