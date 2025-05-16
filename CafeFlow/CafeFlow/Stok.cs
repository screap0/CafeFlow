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

            // Sayfa yüklendiğinde verileri getir
            StoklariYukle();
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
                    db.Log(txtform,"Error: "+ex,DateTime.Now,kullaniciadi);
                }
            }
        }

        private void YenileBtn_Click(object sender, EventArgs e)
        {
            StoklariYukle();
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
                    db.Log(txtform, "Stok güncellendi: " + "Ürün Adı:" + urun + " Ürün Miktarı: " + miktar + " Ürün Açıklaması: " + aciklama, DateTime.Now, kullaniciadi);
                    StoklariYukle();
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
                        db.Log(txtform, "Stok silindi: " + "Stok ID: " + seciliStokID, DateTime.Now, kullaniciadi);
                        StoklariYukle();
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
            stokEkleFormu.ShowDialog(); // Modal olarak açar, ana form kilitlenir
            StoklariYukle(); // Yeni stok eklenmişse listeyi yeniler
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
                    // Normal renk geri yükle (isteğe bağlı)
                    dataGridViewStok.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(34, 44, 52);
                    dataGridViewStok.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

    }
}
