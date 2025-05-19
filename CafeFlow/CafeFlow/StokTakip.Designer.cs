namespace CafeFlow
{
    partial class StokTakip
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flowPanelStokAnaliz;
        private System.Windows.Forms.Label lblStokAnalizBaslik;

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
            this.flowPanelStokAnaliz = new System.Windows.Forms.FlowLayoutPanel();
            this.lblStokAnalizBaslik = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblStokAnalizBaslik
            // 
            this.lblStokAnalizBaslik.Text = "Stok Analiz Paneli";
            this.lblStokAnalizBaslik.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblStokAnalizBaslik.ForeColor = System.Drawing.Color.White;
            this.lblStokAnalizBaslik.AutoSize = true;
            this.lblStokAnalizBaslik.Location = new System.Drawing.Point(30, 20);
            this.lblStokAnalizBaslik.Name = "lblStokAnalizBaslik";
            this.lblStokAnalizBaslik.TabIndex = 1;
            // 
            // flowPanelStokAnaliz
            // 
            this.flowPanelStokAnaliz.BackColor = System.Drawing.Color.FromArgb(40, 40, 60);
            this.flowPanelStokAnaliz.Location = new System.Drawing.Point(0, 110);
            this.flowPanelStokAnaliz.Name = "flowPanelStokAnaliz";
            this.flowPanelStokAnaliz.Size = new System.Drawing.Size(1012, 509);
            this.flowPanelStokAnaliz.TabIndex = 0;
            this.flowPanelStokAnaliz.AutoScroll = true;
            this.flowPanelStokAnaliz.Padding = new System.Windows.Forms.Padding(10);
            this.flowPanelStokAnaliz.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flowPanelStokAnaliz.WrapContents = true;
            this.flowPanelStokAnaliz.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
                | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            // 
            // StokTakip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(1012, 619);
            this.Controls.Add(this.lblStokAnalizBaslik);
            this.Controls.Add(this.flowPanelStokAnaliz);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "StokTakip";
            this.Text = "Stok Takip";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
}