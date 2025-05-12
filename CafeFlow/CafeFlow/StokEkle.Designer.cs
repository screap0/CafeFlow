namespace CafeFlow
{
    partial class StokEkle
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelUrunAdi = new System.Windows.Forms.Label();
            this.urunTxt = new System.Windows.Forms.TextBox();
            this.labelMiktar = new System.Windows.Forms.Label();
            this.miktarTxt = new System.Windows.Forms.TextBox();
            this.labelAciklama = new System.Windows.Forms.Label();
            this.aciklamaTxt = new System.Windows.Forms.TextBox();
            this.ekleBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelUrunAdi
            // 
            this.labelUrunAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelUrunAdi.ForeColor = System.Drawing.Color.White;
            this.labelUrunAdi.Location = new System.Drawing.Point(20, 20);
            this.labelUrunAdi.Name = "labelUrunAdi";
            this.labelUrunAdi.Size = new System.Drawing.Size(80, 20);
            this.labelUrunAdi.TabIndex = 0;
            this.labelUrunAdi.Text = "Ürün Adı";
            // 
            // urunTxt
            // 
            this.urunTxt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.urunTxt.ForeColor = System.Drawing.Color.White;
            this.urunTxt.Location = new System.Drawing.Point(20, 40);
            this.urunTxt.Name = "urunTxt";
            this.urunTxt.Size = new System.Drawing.Size(240, 20);
            this.urunTxt.TabIndex = 1;
            // 
            // labelMiktar
            // 
            this.labelMiktar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMiktar.ForeColor = System.Drawing.Color.White;
            this.labelMiktar.Location = new System.Drawing.Point(20, 70);
            this.labelMiktar.Name = "labelMiktar";
            this.labelMiktar.Size = new System.Drawing.Size(80, 20);
            this.labelMiktar.TabIndex = 2;
            this.labelMiktar.Text = "Miktar";
            // 
            // miktarTxt
            // 
            this.miktarTxt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.miktarTxt.ForeColor = System.Drawing.Color.White;
            this.miktarTxt.Location = new System.Drawing.Point(20, 90);
            this.miktarTxt.Name = "miktarTxt";
            this.miktarTxt.Size = new System.Drawing.Size(240, 20);
            this.miktarTxt.TabIndex = 3;
            // 
            // labelAciklama
            // 
            this.labelAciklama.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelAciklama.ForeColor = System.Drawing.Color.White;
            this.labelAciklama.Location = new System.Drawing.Point(20, 120);
            this.labelAciklama.Name = "labelAciklama";
            this.labelAciklama.Size = new System.Drawing.Size(80, 20);
            this.labelAciklama.TabIndex = 4;
            this.labelAciklama.Text = "Açıklama";
            // 
            // aciklamaTxt
            // 
            this.aciklamaTxt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.aciklamaTxt.ForeColor = System.Drawing.Color.White;
            this.aciklamaTxt.Location = new System.Drawing.Point(20, 140);
            this.aciklamaTxt.Multiline = true;
            this.aciklamaTxt.Name = "aciklamaTxt";
            this.aciklamaTxt.Size = new System.Drawing.Size(240, 60);
            this.aciklamaTxt.TabIndex = 5;
            // 
            // ekleBtn
            // 
            this.ekleBtn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ekleBtn.FlatAppearance.BorderSize = 0;
            this.ekleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ekleBtn.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ekleBtn.ForeColor = System.Drawing.Color.Black;
            this.ekleBtn.Location = new System.Drawing.Point(20, 220);
            this.ekleBtn.Name = "ekleBtn";
            this.ekleBtn.Size = new System.Drawing.Size(240, 40);
            this.ekleBtn.TabIndex = 6;
            this.ekleBtn.Text = "Stok Ekle";
            this.ekleBtn.UseVisualStyleBackColor = false;
            // 
            // StokEkle
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(284, 281);
            this.Controls.Add(this.labelUrunAdi);
            this.Controls.Add(this.urunTxt);
            this.Controls.Add(this.labelMiktar);
            this.Controls.Add(this.miktarTxt);
            this.Controls.Add(this.labelAciklama);
            this.Controls.Add(this.aciklamaTxt);
            this.Controls.Add(this.ekleBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "StokEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stok Ekle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label labelUrunAdi;
        private System.Windows.Forms.TextBox urunTxt;
        private System.Windows.Forms.Label labelMiktar;
        private System.Windows.Forms.TextBox miktarTxt;
        private System.Windows.Forms.Label labelAciklama;
        private System.Windows.Forms.TextBox aciklamaTxt;
        private System.Windows.Forms.Button ekleBtn;
    }
}
