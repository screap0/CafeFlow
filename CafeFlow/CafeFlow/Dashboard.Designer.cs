namespace CafeFlow
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ordersPnl = new System.Windows.Forms.Panel();
            this.ordersHeadLbl = new System.Windows.Forms.Label();
            this.ordersNumberLbl = new System.Windows.Forms.Label();
            this.completedOrderLbl = new System.Windows.Forms.Label();
            this.completedOrderNumLbl = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.mostOrderedProdLbl = new System.Windows.Forms.Label();
            this.mostOrderedProdHeadLbl = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.leastOrderedProdLbl = new System.Windows.Forms.Label();
            this.leastOrderedProdHeadLbl = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.mostSaleDayLbl = new System.Windows.Forms.Label();
            this.mostSaleDayHeadLbl = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.mostSaleProdctsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.amountSaleDayChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.stockChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.profitsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.ordersPnl.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mostSaleProdctsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountSaleDayChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profitsChart)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(999, 611);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.panel5, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ordersPnl, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(979, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ordersPnl
            // 
            this.ordersPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ordersPnl.Controls.Add(this.completedOrderLbl);
            this.ordersPnl.Controls.Add(this.ordersNumberLbl);
            this.ordersPnl.Controls.Add(this.ordersHeadLbl);
            this.ordersPnl.Controls.Add(this.completedOrderNumLbl);
            this.ordersPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ordersPnl.Location = new System.Drawing.Point(0, 0);
            this.ordersPnl.Margin = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.ordersPnl.Name = "ordersPnl";
            this.ordersPnl.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ordersPnl.Size = new System.Drawing.Size(234, 90);
            this.ordersPnl.TabIndex = 0;
            // 
            // ordersHeadLbl
            // 
            this.ordersHeadLbl.AutoSize = true;
            this.ordersHeadLbl.Font = new System.Drawing.Font("Nirmala UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ordersHeadLbl.ForeColor = System.Drawing.Color.White;
            this.ordersHeadLbl.Location = new System.Drawing.Point(5, 5);
            this.ordersHeadLbl.Name = "ordersHeadLbl";
            this.ordersHeadLbl.Size = new System.Drawing.Size(155, 20);
            this.ordersHeadLbl.TabIndex = 0;
            this.ordersHeadLbl.Text = "Toplam Sipariş Sayısı";
            // 
            // ordersNumberLbl
            // 
            this.ordersNumberLbl.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ordersNumberLbl.ForeColor = System.Drawing.Color.White;
            this.ordersNumberLbl.Location = new System.Drawing.Point(6, 35);
            this.ordersNumberLbl.Name = "ordersNumberLbl";
            this.ordersNumberLbl.Size = new System.Drawing.Size(170, 20);
            this.ordersNumberLbl.TabIndex = 1;
            this.ordersNumberLbl.Text = "12312353";
            this.ordersNumberLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // completedOrderLbl
            // 
            this.completedOrderLbl.AutoSize = true;
            this.completedOrderLbl.Font = new System.Drawing.Font("Nirmala UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completedOrderLbl.ForeColor = System.Drawing.Color.White;
            this.completedOrderLbl.Location = new System.Drawing.Point(5, 69);
            this.completedOrderLbl.Name = "completedOrderLbl";
            this.completedOrderLbl.Size = new System.Drawing.Size(73, 13);
            this.completedOrderLbl.TabIndex = 2;
            this.completedOrderLbl.Text = "Tamamlanan";
            // 
            // completedOrderNumLbl
            // 
            this.completedOrderNumLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.completedOrderNumLbl.Font = new System.Drawing.Font("Nirmala UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completedOrderNumLbl.ForeColor = System.Drawing.Color.White;
            this.completedOrderNumLbl.Location = new System.Drawing.Point(144, 64);
            this.completedOrderNumLbl.Name = "completedOrderNumLbl";
            this.completedOrderNumLbl.Size = new System.Drawing.Size(88, 20);
            this.completedOrderNumLbl.TabIndex = 3;
            this.completedOrderNumLbl.Text = "3456";
            this.completedOrderNumLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel3.Controls.Add(this.mostOrderedProdLbl);
            this.panel3.Controls.Add(this.mostOrderedProdHeadLbl);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(244, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.panel3.Size = new System.Drawing.Size(234, 90);
            this.panel3.TabIndex = 1;
            // 
            // mostOrderedProdLbl
            // 
            this.mostOrderedProdLbl.Font = new System.Drawing.Font("Nirmala UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mostOrderedProdLbl.ForeColor = System.Drawing.Color.White;
            this.mostOrderedProdLbl.Location = new System.Drawing.Point(3, 41);
            this.mostOrderedProdLbl.Name = "mostOrderedProdLbl";
            this.mostOrderedProdLbl.Size = new System.Drawing.Size(229, 20);
            this.mostOrderedProdLbl.TabIndex = 1;
            this.mostOrderedProdLbl.Text = "Buble Tea";
            this.mostOrderedProdLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mostOrderedProdHeadLbl
            // 
            this.mostOrderedProdHeadLbl.AutoSize = true;
            this.mostOrderedProdHeadLbl.Font = new System.Drawing.Font("Nirmala UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mostOrderedProdHeadLbl.ForeColor = System.Drawing.Color.White;
            this.mostOrderedProdHeadLbl.Location = new System.Drawing.Point(5, 5);
            this.mostOrderedProdHeadLbl.Name = "mostOrderedProdHeadLbl";
            this.mostOrderedProdHeadLbl.Size = new System.Drawing.Size(138, 20);
            this.mostOrderedProdHeadLbl.TabIndex = 0;
            this.mostOrderedProdHeadLbl.Text = "En Çok Satan Ürün";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gray;
            this.panel4.Controls.Add(this.leastOrderedProdLbl);
            this.panel4.Controls.Add(this.leastOrderedProdHeadLbl);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(488, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.panel4.Size = new System.Drawing.Size(234, 90);
            this.panel4.TabIndex = 2;
            // 
            // leastOrderedProdLbl
            // 
            this.leastOrderedProdLbl.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leastOrderedProdLbl.ForeColor = System.Drawing.Color.White;
            this.leastOrderedProdLbl.Location = new System.Drawing.Point(7, 41);
            this.leastOrderedProdLbl.Name = "leastOrderedProdLbl";
            this.leastOrderedProdLbl.Size = new System.Drawing.Size(170, 20);
            this.leastOrderedProdLbl.TabIndex = 1;
            this.leastOrderedProdLbl.Text = "Americano";
            this.leastOrderedProdLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // leastOrderedProdHeadLbl
            // 
            this.leastOrderedProdHeadLbl.AutoSize = true;
            this.leastOrderedProdHeadLbl.Font = new System.Drawing.Font("Nirmala UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leastOrderedProdHeadLbl.ForeColor = System.Drawing.Color.White;
            this.leastOrderedProdHeadLbl.Location = new System.Drawing.Point(5, 5);
            this.leastOrderedProdHeadLbl.Name = "leastOrderedProdHeadLbl";
            this.leastOrderedProdHeadLbl.Size = new System.Drawing.Size(130, 20);
            this.leastOrderedProdHeadLbl.TabIndex = 0;
            this.leastOrderedProdHeadLbl.Text = "En Az Satan Ürün";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel5.Controls.Add(this.mostSaleDayLbl);
            this.panel5.Controls.Add(this.mostSaleDayHeadLbl);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(732, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.panel5.Size = new System.Drawing.Size(247, 90);
            this.panel5.TabIndex = 3;
            // 
            // mostSaleDayLbl
            // 
            this.mostSaleDayLbl.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mostSaleDayLbl.ForeColor = System.Drawing.Color.White;
            this.mostSaleDayLbl.Location = new System.Drawing.Point(5, 41);
            this.mostSaleDayLbl.Name = "mostSaleDayLbl";
            this.mostSaleDayLbl.Size = new System.Drawing.Size(170, 20);
            this.mostSaleDayLbl.TabIndex = 1;
            this.mostSaleDayLbl.Text = "Pazar";
            this.mostSaleDayLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mostSaleDayHeadLbl
            // 
            this.mostSaleDayHeadLbl.AutoSize = true;
            this.mostSaleDayHeadLbl.Font = new System.Drawing.Font("Nirmala UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mostSaleDayHeadLbl.ForeColor = System.Drawing.Color.White;
            this.mostSaleDayHeadLbl.Location = new System.Drawing.Point(5, 5);
            this.mostSaleDayHeadLbl.Name = "mostSaleDayHeadLbl";
            this.mostSaleDayHeadLbl.Size = new System.Drawing.Size(182, 20);
            this.mostSaleDayHeadLbl.TabIndex = 0;
            this.mostSaleDayHeadLbl.Text = "En Çok Satış Yapılan Gün";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(10, 110);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(979, 0);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.tableLayoutPanel3);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(10, 110);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(979, 491);
            this.panel7.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.mostSaleProdctsChart, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.amountSaleDayChart, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.stockChart, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.profitsChart, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(979, 491);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // mostSaleProdctsChart
            // 
            this.mostSaleProdctsChart.BackSecondaryColor = System.Drawing.Color.White;
            this.mostSaleProdctsChart.BorderSkin.BackColor = System.Drawing.Color.IndianRed;
            this.mostSaleProdctsChart.BorderSkin.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center;
            this.mostSaleProdctsChart.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea1.Name = "ChartArea1";
            this.mostSaleProdctsChart.ChartAreas.Add(chartArea1);
            this.mostSaleProdctsChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.mostSaleProdctsChart.Legends.Add(legend1);
            this.mostSaleProdctsChart.Location = new System.Drawing.Point(0, 10);
            this.mostSaleProdctsChart.Margin = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.mostSaleProdctsChart.Name = "mostSaleProdctsChart";
            this.mostSaleProdctsChart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.mostSaleProdctsChart.Series.Add(series1);
            this.mostSaleProdctsChart.Size = new System.Drawing.Size(479, 225);
            this.mostSaleProdctsChart.TabIndex = 0;
            this.mostSaleProdctsChart.Text = "chart1";
            // 
            // amountSaleDayChart
            // 
            this.amountSaleDayChart.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea2.Name = "ChartArea1";
            this.amountSaleDayChart.ChartAreas.Add(chartArea2);
            this.amountSaleDayChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.amountSaleDayChart.Legends.Add(legend2);
            this.amountSaleDayChart.Location = new System.Drawing.Point(499, 10);
            this.amountSaleDayChart.Margin = new System.Windows.Forms.Padding(10, 0, 0, 10);
            this.amountSaleDayChart.Name = "amountSaleDayChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.amountSaleDayChart.Series.Add(series2);
            this.amountSaleDayChart.Size = new System.Drawing.Size(480, 225);
            this.amountSaleDayChart.TabIndex = 1;
            this.amountSaleDayChart.Text = "chart2";
            // 
            // stockChart
            // 
            this.stockChart.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea3.Name = "ChartArea1";
            this.stockChart.ChartAreas.Add(chartArea3);
            this.stockChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.stockChart.Legends.Add(legend3);
            this.stockChart.Location = new System.Drawing.Point(0, 255);
            this.stockChart.Margin = new System.Windows.Forms.Padding(0, 10, 10, 0);
            this.stockChart.Name = "stockChart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.stockChart.Series.Add(series3);
            this.stockChart.Size = new System.Drawing.Size(479, 226);
            this.stockChart.TabIndex = 2;
            this.stockChart.Text = "chart3";
            // 
            // profitsChart
            // 
            this.profitsChart.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea4.Name = "ChartArea1";
            this.profitsChart.ChartAreas.Add(chartArea4);
            this.profitsChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Name = "Legend1";
            this.profitsChart.Legends.Add(legend4);
            this.profitsChart.Location = new System.Drawing.Point(499, 255);
            this.profitsChart.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.profitsChart.Name = "profitsChart";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.profitsChart.Series.Add(series4);
            this.profitsChart.Size = new System.Drawing.Size(480, 226);
            this.profitsChart.TabIndex = 3;
            this.profitsChart.Text = "chart4";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(999, 611);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ordersPnl.ResumeLayout(false);
            this.ordersPnl.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mostSaleProdctsChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountSaleDayChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profitsChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label ordersHeadLbl;
        private System.Windows.Forms.Panel ordersPnl;
        private System.Windows.Forms.Label completedOrderLbl;
        private System.Windows.Forms.Label ordersNumberLbl;
        private System.Windows.Forms.Label completedOrderNumLbl;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label mostSaleDayLbl;
        private System.Windows.Forms.Label mostSaleDayHeadLbl;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label leastOrderedProdLbl;
        private System.Windows.Forms.Label leastOrderedProdHeadLbl;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label mostOrderedProdLbl;
        private System.Windows.Forms.Label mostOrderedProdHeadLbl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart mostSaleProdctsChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart amountSaleDayChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart stockChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart profitsChart;
    }
}