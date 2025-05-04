using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CafeFlow
{
    public partial class Reports : Form
    {
        private DatabaseConnection db = new DatabaseConnection();
        public Reports()
        {
            InitializeComponent();

            this.Load += new EventHandler(Reports_Load);
            btnRefresh.Click += new EventHandler(btnRefresh_Click);
          
            startDatePicker.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            startDatePicker.ForeColor = Color.DarkSlateGray;
            startDatePicker.Width = 200;
            startDatePicker.Height = 30;
            
            endDatePicker.ShowUpDown = false;
            endDatePicker.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            endDatePicker.ForeColor = Color.DarkSlateGray;
            endDatePicker.Width = 200;
            endDatePicker.Height = 30;
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            startDatePicker.Value = DateTime.Now.AddDays(-30);
            endDatePicker.Value = DateTime.Now;

            LoadEarningAnalysisChart(startDatePicker.Value, endDatePicker.Value);
            LoadSalePerHourChart(startDatePicker.Value, endDatePicker.Value);
            LoadCategoryPerformanceChart(startDatePicker.Value, endDatePicker.Value);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (endDatePicker.Value < startDatePicker.Value)
            {
                MessageBox.Show("Bitiş tarihi, başlangıç tarihinden önce olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // MessageBox.Show($"Başlangıç: {startDatePicker.Value:dd MMMM yyyy}\nBitiş: {endDatePicker.Value:dd MMMM yyyy}");

            LoadEarningAnalysisChart(startDatePicker.Value, endDatePicker.Value);
            LoadSalePerHourChart(startDatePicker.Value, endDatePicker.Value);
            LoadCategoryPerformanceChart(startDatePicker.Value, endDatePicker.Value);
        }

        private void LoadEarningAnalysisChart(DateTime startDate, DateTime endDate)
        {
            try
            {
                var monthlyProfits = db.GetMonthlyProfits(startDate, endDate);

                earningAnalysisChart.Series.Clear();
                earningAnalysisChart.ChartAreas.Clear();
                earningAnalysisChart.Legends.Clear();

                ChartArea chartArea = new ChartArea
                {
                    BackColor = System.Drawing.Color.WhiteSmoke,
                    AxisY = { Title = "Gelir", TitleForeColor = Color.Black, LabelStyle = { Format = "{0:N0}" } },
                };
                earningAnalysisChart.ChartAreas.Add(chartArea);

                Series series = new Series
                {
                    Name = "Aylık Gelir",
                    ChartType = SeriesChartType.Line,
                    Color = Color.DodgerBlue,
                    BorderWidth = 2,
                    MarkerStyle = MarkerStyle.Circle,
                    MarkerSize = 6,
                    MarkerColor = Color.DarkBlue
                };

                foreach (var month in monthlyProfits)
                {
                    series.Points.AddXY(month.Key.ToString("MMM yyyy"), month.Value);
                }

                earningAnalysisChart.Series.Add(series);

                Legend legend = new Legend
                {
                    Docking = Docking.Bottom,
                    Alignment = StringAlignment.Center,
                    BackColor = Color.Transparent,
                    IsDockedInsideChartArea = false
                };
                earningAnalysisChart.Legends.Add(legend);
                series.Legend = legend.Name;
                earningAnalysisChart.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while setting up the chart: " + ex.Message);
            }
        }

        private void LoadSalePerHourChart(DateTime startDate, DateTime endDate)
        {
            try
            {
                var hourlySales = db.GetSalesPerHour(startDate, endDate);

                salePerHourChart.Series.Clear();
                salePerHourChart.ChartAreas.Clear();
                salePerHourChart.Legends.Clear();

                ChartArea chartArea = new ChartArea
                {
                    BackColor = System.Drawing.Color.WhiteSmoke,
                    AxisY = { Title = "Gelir", TitleForeColor = Color.DarkSlateGray, LabelStyle = { Format = "{0:N0}" }, Minimum = 0 }
                };
                salePerHourChart.ChartAreas.Add(chartArea);

                Series series = new Series
                {
                    Name = "Saatlik Satışlar",
                    ChartType = SeriesChartType.Column,
                    Color = Color.Coral,
                    BorderWidth = 1,
                    BorderColor = Color.DarkOrange
                };

                foreach (var hour in hourlySales.OrderBy(h => h.Key))
                {
                    int hourValue = hour.Key;
                    DateTime formattedHour = new DateTime(2000, 1, 1, hourValue, 0, 0);
                    series.Points.AddXY(formattedHour.ToString("hh:mm tt"), hour.Value);
                }

                salePerHourChart.Series.Add(series);

                Legend legend = new Legend
                {
                    Docking = Docking.Bottom,
                    Alignment = StringAlignment.Center,
                    BackColor = Color.Transparent,
                    IsDockedInsideChartArea = false
                };
                salePerHourChart.Legends.Add(legend);
                series.Legend = legend.Name;

                salePerHourChart.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while setting up the chart: " + ex.Message);
            }
        }

        private void LoadCategoryPerformanceChart(DateTime startDate, DateTime endDate)
        {
            try
            {
                var categoryStats = db.GetSalesByCategory(startDate, endDate);

                categoryPerformanceChart.Series.Clear();
                categoryPerformanceChart.ChartAreas.Clear();
                categoryPerformanceChart.Legends.Clear();
                categoryPerformanceChart.Annotations.Clear();

                ChartArea chartArea = new ChartArea
                {
                    AxisX = { Title = "Kategori", TitleForeColor = Color.DarkSlateGray },
                    AxisY = { Title = "Toplam Satış (TL)", TitleForeColor = Color.DarkSlateGray, LabelStyle = { Format = "{0:N0}" }, Minimum = 0 }
                };
                categoryPerformanceChart.ChartAreas.Add(chartArea);

                Series series = new Series
                {
                    Name = "Category Sales",
                    ChartType = SeriesChartType.Pie,
                    IsValueShownAsLabel = true,
                    LabelFormat = "{0:N0} TL",
                    Font = new System.Drawing.Font("Arial", 8),
                };

                if (categoryStats.Any())
                {
                    foreach (var category in categoryStats)
                    {
                        series.Points.AddXY(category.Key, category.Value.Item2);
                    }

                    categoryPerformanceChart.Series.Add(series);

                    Legend legend = new Legend
                    {
                        Docking = Docking.Right,
                        Alignment = StringAlignment.Center,
                        BackColor = Color.Transparent,
                        IsDockedInsideChartArea = false
                    };
                    categoryPerformanceChart.Legends.Add(legend);
                    series.Legend = legend.Name;
                }
                else
                {
                    var noDataText = new TextAnnotation
                    {
                        Text = "Veri Yok",
                        Alignment = ContentAlignment.MiddleCenter,
                        Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold),
                        AxisX = chartArea.AxisX,
                        AxisY = chartArea.AxisY,
                        IsSizeAlwaysRelative = false
                    };
                    categoryPerformanceChart.Annotations.Add(noDataText);
                }

                categoryPerformanceChart.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while setting up the category performance chart: " + ex.Message);
            }
        }
    }
}