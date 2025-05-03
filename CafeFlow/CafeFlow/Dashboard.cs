using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace CafeFlow
{
    public partial class Dashboard : Form
    {
        private DatabaseConnection db = new DatabaseConnection();

        public Dashboard()
        {
            InitializeComponent();
            this.Load += new EventHandler(Dashboard_Load);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            int totalOrders = db.GetTotalOrderCount();
            ordersNumberLbl.Text = totalOrders.ToString();

            int completeOrders = db.GetCompletedOrderCount();
            completedOrderNumLbl.Text = completeOrders.ToString();

            string mostOrderedProduct = db.GetMostOrderedProduct();
            mostOrderedProdLbl.Text = mostOrderedProduct;

            string leastOrderedProduct = db.GetLeastOrderedProduct();
            leastOrderedProdLbl.Text = leastOrderedProduct;

            string mostSaleDayOfWeek = db.GetMostSaleDayOfWeek();
            mostSaleDayLbl.Text = mostSaleDayOfWeek;

            try
            {
                var topFiveProducts = db.GetTopFiveProducts();

                mostSaleProdctsChart.Series.Clear();
                mostSaleProdctsChart.ChartAreas.Clear();

                ChartArea chartArea = new ChartArea();
                mostSaleProdctsChart.ChartAreas.Add(chartArea);

                System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series
                {
                    Name = "En Çok Satan Ürünler",
                    ChartType = SeriesChartType.Column
                };

                // Verileri ekle
                foreach (var product in topFiveProducts)
                {
                    series.Points.AddXY(product.Key, product.Value);
                }

                mostSaleProdctsChart.Series.Add(series);

                // Ekseni özelleştir
                mostSaleProdctsChart.ChartAreas[0].AxisY.Title = "Satış Sayısı";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while setting up the chart: " + ex.Message);
            }
        }
    }
}