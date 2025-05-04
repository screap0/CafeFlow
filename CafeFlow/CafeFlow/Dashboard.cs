using System.Windows.Forms;
using System;
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
            //Toplam ve tamamlanan sipariş score card
            int totalOrders = db.GetTotalOrderCount();
            ordersNumberLbl.Text = totalOrders.ToString();

            int completeOrders = db.GetCompletedOrderCount();
            completedOrderNumLbl.Text = completeOrders.ToString();

            //En çok sipariş edilen ürün score card
            string mostOrderedProduct = db.GetMostOrderedProduct();
            mostOrderedProdLbl.Text = mostOrderedProduct;

            //En az sipariş edilen ürün score card
            string leastOrderedProduct = db.GetLeastOrderedProduct();
            leastOrderedProdLbl.Text = leastOrderedProduct;

            //En çok satış yapılan gün score card
            string mostSaleDayOfWeek = db.GetMostSaleDayOfWeek();
            mostSaleDayLbl.Text = mostSaleDayOfWeek;

            //En çok satan ürünlerin grafiği
            try
            {
                var topFiveProducts = db.GetTopFiveProducts();

                mostSaleProdctsChart.Series.Clear();
                mostSaleProdctsChart.ChartAreas.Clear();

                ChartArea chartArea = new ChartArea
                {
                    BackColor = System.Drawing.Color.WhiteSmoke,
                    AxisY = { Title = "Satış Sayısı", TitleForeColor = System.Drawing.Color.Black, LabelStyle = { Format = "{0:N0}" } }
                };
                mostSaleProdctsChart.ChartAreas.Add(chartArea);

                Series series = new Series
                {
                    Name = "En Çok Satan Ürünler",
                    ChartType = SeriesChartType.Column,
                    BorderWidth = 1,
                };

                foreach (var product in topFiveProducts)
                {
                    series.Points.AddXY(product.Key, product.Value);
                }

                mostSaleProdctsChart.Series.Add(series);

                Legend legend = new Legend
                {
                    Docking = Docking.Top,
                    Alignment = System.Drawing.StringAlignment.Center,
                    BackColor = System.Drawing.Color.Transparent
                };
                mostSaleProdctsChart.Legends.Add(legend);
                series.Legend = legend.Name;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while setting up the chart: " + ex.Message);
            }

            //Günlere göre satış dağılımı grafiği
            try
            {
                var salesByDay = db.GetSalesByDayOfWeek();

                amountSaleDayChart.Series.Clear();
                amountSaleDayChart.ChartAreas.Clear();
                amountSaleDayChart.Legends.Clear();

                ChartArea chartArea = new ChartArea();
                amountSaleDayChart.ChartAreas.Add(chartArea);

                Series series = new Series
                {
                    Name = "Sales By Day",
                    ChartType = SeriesChartType.Pie
                };

                string[] weekDays = { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar" };
                foreach (string day in weekDays)
                {
                    if (salesByDay.ContainsKey(day))
                    {
                        DataPoint point = new DataPoint();
                        point.SetValueXY(day, salesByDay[day]);
                        point.LegendText = day;
                        point.Label = "#PERCENT{P0}";
                        series.Points.Add(point);
                    }
                    else
                    {
                        DataPoint point = new DataPoint();
                        point.SetValueXY(day, 0);
                        point.LegendText = day;
                        point.Label = "0%";
                        series.Points.Add(point);
                    }
                }

                series.IsValueShownAsLabel = true;

                Legend legend = new Legend
                {
                    Docking = Docking.Right,
                    Alignment = System.Drawing.StringAlignment.Near
                };
                amountSaleDayChart.Legends.Add(legend);
                series.Legend = legend.Name;

                amountSaleDayChart.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while setting up the chart: " + ex.Message);
            }

            //Son 7 günlük ciro grafiği
            try
            {
                var profits = db.GetLast7DaysProfits();

                profitsChart.Series.Clear();
                profitsChart.ChartAreas.Clear();

                ChartArea chartArea = new ChartArea
                {
                    BackColor = System.Drawing.Color.WhiteSmoke,
                    AxisX = { Title = "Tarih", TitleForeColor = System.Drawing.Color.Black, Interval = 1 },
                    AxisY = { Title = "Hasılat", TitleForeColor = System.Drawing.Color.Black, LabelStyle = { Format = "{0:N0}" } }
                };
                profitsChart.ChartAreas.Add(chartArea);

                Series series = new Series
                {
                    Name = "Son 7 Günlük Kazanç",
                    ChartType = SeriesChartType.Line,
                    Color = System.Drawing.Color.Black,
                    BorderWidth = 2,
                    MarkerStyle = MarkerStyle.Circle,
                    MarkerSize = 6,
                    MarkerColor = System.Drawing.Color.DarkBlue
                };

                DateTime endDate = DateTime.Now;
                DateTime startDate = endDate.AddDays(-6);
                for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    decimal revenue = profits.ContainsKey(date.Date) ? profits[date.Date] : 0;
                    series.Points.AddXY(date.ToString("dd/MM"), revenue);
                }

                profitsChart.Series.Add(series);

                Legend legend = new Legend
                {
                    Docking = Docking.Bottom,
                    Alignment = System.Drawing.StringAlignment.Center,
                    BackColor = System.Drawing.Color.Transparent
                };
                profitsChart.Legends.Add(legend);
                series.Legend = legend.Name;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while setting up the chart: " + ex.Message);
            }

            //Stoğu biten ürün grafiği
            try
            {
                var lowStockProducts = db.GetLowStockProducts();

                stockChart.Series.Clear();
                stockChart.ChartAreas.Clear();

                ChartArea chartArea = new ChartArea
                {
                    BackColor = System.Drawing.Color.WhiteSmoke,
                    AxisY = { Title = "Stok Miktarı", TitleForeColor = System.Drawing.Color.Black, LabelStyle = { Format = "{0:N0}" } }
                };
                stockChart.ChartAreas.Add(chartArea);

                Series series = new Series
                {
                    Name = "Düşük Stoklu Ürünler",
                    ChartType = SeriesChartType.Column,
                    Color = System.Drawing.Color.Coral,
                    BorderWidth = 1,
                    BorderColor = System.Drawing.Color.DarkOrange
                };

                foreach (var product in lowStockProducts)
                {
                    series.Points.AddXY(product.Key, product.Value);
                }

                stockChart.Series.Add(series);

                Legend legend = new Legend
                {
                    Docking = Docking.Top,
                    Alignment = System.Drawing.StringAlignment.Center,
                    BackColor = System.Drawing.Color.Transparent
                };
                stockChart.Legends.Add(legend);
                series.Legend = legend.Name;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while setting up the chart: " + ex.Message);
            }
        }
    }
}