namespace CafeFlow
{
    partial class Reports
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
            this.orderReportPnl = new System.Windows.Forms.FlowLayoutPanel();
            this.dailyTurnoverPnl = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // orderReportPnl
            // 
            this.orderReportPnl.Location = new System.Drawing.Point(12, 12);
            this.orderReportPnl.Name = "orderReportPnl";
            this.orderReportPnl.Size = new System.Drawing.Size(357, 426);
            this.orderReportPnl.TabIndex = 0;
            // 
            // dailyTurnoverPnl
            // 
            this.dailyTurnoverPnl.Location = new System.Drawing.Point(375, 12);
            this.dailyTurnoverPnl.Name = "dailyTurnoverPnl";
            this.dailyTurnoverPnl.Size = new System.Drawing.Size(413, 283);
            this.dailyTurnoverPnl.TabIndex = 1;
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dailyTurnoverPnl);
            this.Controls.Add(this.orderReportPnl);
            this.Name = "Reports";
            this.Text = "Reports";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel orderReportPnl;
        private System.Windows.Forms.FlowLayoutPanel dailyTurnoverPnl;
    }
}