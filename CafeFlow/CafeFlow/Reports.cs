using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CafeFlow
{
    public partial class Reports : Form
    {
        DatabaseConnection db = new DatabaseConnection();

        public Reports()
        {
            InitializeComponent();
            LoadOrderCards();
            LoadTurnoverCards();
        }

        private void LoadOrderCards()
        {
            orderReportPnl.AutoScroll = true;
            orderReportPnl.FlowDirection = FlowDirection.TopDown;
            orderReportPnl.WrapContents = false;

            orderReportPnl.HorizontalScroll.Enabled = false;
            orderReportPnl.HorizontalScroll.Visible = false;
            orderReportPnl.HorizontalScroll.Maximum = 0;
            orderReportPnl.AutoScrollMinSize = new Size(0, 0);

            // this.Resize += (s, e) =>
            // {
                // orderReportPnl.Location = new Point(orderReportPnl.Location.Y);
                // orderReportPnl.Height = this.ClientSize.Height - 30;
            // };

            using (MySqlConnection connection = db.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Siparisler ORDER BY siparis_tarihi DESC LIMIT 50";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Panel card = new Panel
                            {
                                Width = orderReportPnl.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 10,
                                Height = 170,
                                BorderStyle = BorderStyle.FixedSingle,
                                Margin = new Padding(10),
                                BackColor = Color.White
                            };

                            card.Width = orderReportPnl.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 10;

                            Label lblName = new Label
                            {
                                Text = "Name: " + reader["isim"].ToString(),
                                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                                Location = new Point(10, 10),
                                AutoSize = true
                            };

                            Label lblTable = new Label
                            {
                                Text = "Table No: " + reader["masa_no"].ToString(),
                                Location = new Point(10, 35),
                                AutoSize = true
                            };

                            Label lblPhone = new Label
                            {
                                Text = "Phone: " + reader["telefon"].ToString(),
                                Location = new Point(10, 55),
                                AutoSize = true
                            };

                            Label lblOrder = new Label
                            {
                                Text = "Order: " + reader["siparis_aciklamasi"].ToString(),
                                Location = new Point(10, 75),
                                AutoSize = true
                            };

                            Label lblTotal = new Label
                            {
                                Text = "Total: ₺" + Convert.ToDecimal(reader["toplam_tutar"]).ToString("N2"),
                                Location = new Point(10, 95),
                                AutoSize = true
                            };

                            Label lblDate = new Label
                            {
                                Text = "Date: " + Convert.ToDateTime(reader["siparis_tarihi"]).ToString("g"),
                                Location = new Point(10, 115),
                                AutoSize = true
                            };

                            Label lblStatus = new Label
                            {
                                Text = "Status: " + reader["durum"].ToString(),
                                Location = new Point(10, 135),
                                AutoSize = true
                            };

                            card.Controls.Add(lblName);
                            card.Controls.Add(lblTable);
                            card.Controls.Add(lblPhone);
                            card.Controls.Add(lblOrder);
                            card.Controls.Add(lblTotal);
                            card.Controls.Add(lblDate);
                            card.Controls.Add(lblStatus);

                            orderReportPnl.Controls.Add(card);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while loading order cards: " + ex.Message);
                }
            }

            orderReportPnl.ClientSizeChanged += (s, e) =>
            {
                foreach (Control ctrl in orderReportPnl.Controls)
                {
                    if (ctrl is Panel card)
                    {
                        card.Width = orderReportPnl.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 10;
                    }
                }
            };
        }

        private void LoadTurnoverCards()
        {
            dailyTurnoverPnl.AutoScroll = true;
            dailyTurnoverPnl.FlowDirection = FlowDirection.TopDown;
            dailyTurnoverPnl.WrapContents = false;

            dailyTurnoverPnl.HorizontalScroll.Enabled = false;
            dailyTurnoverPnl.HorizontalScroll.Visible = false;
            dailyTurnoverPnl.HorizontalScroll.Maximum = 0;
            dailyTurnoverPnl.AutoScrollMinSize = new Size(0, 0);

            // this.Resize += (s, e) =>
            // {
                // dailyTurnoverPnl.Width = this.ClientSize.Width - 300;
            // };

            using (MySqlConnection connection = db.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = @"
                SELECT 
                    DATE(siparis_tarihi) AS siparis_gunu, 
                    SUM(toplam_tutar) AS gunluk_ciro 
                FROM Siparisler 
                GROUP BY DATE(siparis_tarihi) 
                ORDER BY siparis_gunu DESC 
                LIMIT 30";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Panel card = new Panel
                            {
                                Width = dailyTurnoverPnl.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 10,
                                Height = 80,
                                BorderStyle = BorderStyle.FixedSingle,
                                Margin = new Padding(10),
                                BackColor = Color.LightGoldenrodYellow
                            };

                            Label lblDate = new Label
                            {
                                Text = "Date: " + Convert.ToDateTime(reader["siparis_gunu"]).ToString("D"),
                                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                                Location = new Point(10, 10),
                                AutoSize = true
                            };

                            Label lblTurnover = new Label
                            {
                                Text = "Total Turnover: ₺" + Convert.ToDecimal(reader["gunluk_ciro"]).ToString("N2"),
                                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                                Location = new Point(10, 35),
                                AutoSize = true
                            };

                            card.Controls.Add(lblDate);
                            card.Controls.Add(lblTurnover);

                            dailyTurnoverPnl.Controls.Add(card);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while loading turnover cards: " + ex.Message);
                }
            }

            dailyTurnoverPnl.ClientSizeChanged += (s, e) =>
            {
                foreach (Control ctrl in dailyTurnoverPnl.Controls)
                {
                    if (ctrl is Panel card)
                    {
                        card.Width = dailyTurnoverPnl.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 10;
                    }
                }
            };
        }

        private void refreshReportsBtn_Click(object sender, EventArgs e)
        {
            RefreshReports();
        }

        private void RefreshReports()
        {
            LoadOrderCards();
            LoadTurnoverCards();
        }
    }
}