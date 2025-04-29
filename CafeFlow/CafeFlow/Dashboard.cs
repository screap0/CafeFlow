using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeFlow
{
    public partial class Dashboard : Form
    {

        

        public Dashboard()
        {
            InitializeComponent();


        }
        private DatabaseConnection db = new DatabaseConnection();

        private void Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                lbl_encoksiparis.Text = db.EnCokSiparisVerilenUrun();
                //lbl_ortsiparissuresi.Text = db.OrtalamaSiparisSuresi() + " dk";
                //lbl_ensadikmusteri.Text = db.EnSadikMusteri();
                decimal kazanc = db.AylikKazancGetir();
                int musteriSayisi = db.AylikMusteriSayisiGetir();
                lbl_kazanc.Text = kazanc.ToString("C2"); 
                lbl_musterisayisi.Text = musteriSayisi.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dashboard verileri çekilemedi: " + ex.Message);
            }
            List<DateTime> siparisTarihleri = db.SiparisTarihleriGetir();

            int[] saatlikSiparisSayilari = new int[24];

            foreach (var tarih in siparisTarihleri)
            {
                saatlikSiparisSayilari[tarih.Hour]++;
            }

            orderChart.Series = new SeriesCollection
    {
        new ColumnSeries
        {
            Title = "Sipariş Sayısı",
            Values = new ChartValues<int>(saatlikSiparisSayilari)
        }
    };

            orderChart.AxisX.Clear();
            orderChart.AxisX.Add(new Axis
            {
                Title = "Saat",
                Labels = Enumerable.Range(0, 24).Select(h => h.ToString("00:00")).ToArray()
            });

            orderChart.AxisY.Clear();
            orderChart.AxisY.Add(new Axis
            {
                Title = "Sipariş Adedi"
            });
        }

       
    }
}
