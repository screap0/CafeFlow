using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using System.Windows.Forms;
using System;

namespace CafeFlow
{
    public partial class Dashboard : Form
    {
        LiveCharts.WinForms.CartesianChart orderChart;

        public Dashboard()
        {
            InitializeComponent();

           
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Yeni bir WPF CartesianChart nesnesi oluşturuyoruz
            var cartesianChart = new LiveCharts.Wpf.CartesianChart();

            // Saatler ve sipariş sayılarını örnek verilerle ayarlıyoruz
            cartesianChart.Series = new SeriesCollection
    {
        new ColumnSeries
        {
            Title = "Siparişler",
            Values = new ChartValues<int> { 12, 18, 5, 9, 15, 22,6,13,45,64,12,35,43,23 } // burada kendi verilerini koyacaksın
        }
    };

            cartesianChart.AxisX.Add(new Axis
            {
                Title = "Saat",
                Labels = new[] { "10:00", "11:00", "12:00", "13:00", "14:00", "15:00","16:00","17:00","18:00", "19:00","20:00","21:00","22:00","22.00"}
            });

            cartesianChart.AxisY.Add(new Axis
            {
                Title = "Sipariş Sayısı",
                LabelFormatter = value => value.ToString()
            });

            // ElementHost'un içine bu cartesian chart'ı yerleştiriyoruz
            if (elementHost1 != null)
            {
                elementHost1.Child = cartesianChart;
            }
            else
            {
                MessageBox.Show("ElementHost başlatılamadı!");
            }
        }
    }
}
