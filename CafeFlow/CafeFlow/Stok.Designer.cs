namespace CafeFlow
{
    partial class Stok
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewStok = new System.Windows.Forms.DataGridView();
            this.panelSag = new System.Windows.Forms.Panel();
            this.labelBaslik = new System.Windows.Forms.Label();
            this.labelUrun = new System.Windows.Forms.Label();
            this.urunTxt = new System.Windows.Forms.TextBox();
            this.labelMiktar = new System.Windows.Forms.Label();
            this.miktarTxt = new System.Windows.Forms.TextBox();
            this.labelAciklama = new System.Windows.Forms.Label();
            this.aciklamaTxt = new System.Windows.Forms.TextBox();
            this.ekleBtn = new System.Windows.Forms.Button();
            this.guncelleBtn = new System.Windows.Forms.Button();
            this.silBtn = new System.Windows.Forms.Button();
            this.yenileBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStok)).BeginInit();
            this.panelSag.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewStok
            // 
            this.dataGridViewStok.AllowUserToAddRows = false;
            this.dataGridViewStok.AllowUserToDeleteRows = false;
            this.dataGridViewStok.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.dataGridViewStok.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewStok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewStok.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewStok.Location = new System.Drawing.Point(10, 20);
            this.dataGridViewStok.MultiSelect = false;
            this.dataGridViewStok.Name = "dataGridViewStok";
            this.dataGridViewStok.ReadOnly = true;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.dataGridViewStok.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewStok.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStok.Size = new System.Drawing.Size(678, 493);
            this.dataGridViewStok.TabIndex = 0;
            // 
            // panelSag
            // 
            this.panelSag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            this.panelSag.Controls.Add(this.labelBaslik);
            this.panelSag.Controls.Add(this.labelUrun);
            this.panelSag.Controls.Add(this.urunTxt);
            this.panelSag.Controls.Add(this.labelMiktar);
            this.panelSag.Controls.Add(this.miktarTxt);
            this.panelSag.Controls.Add(this.labelAciklama);
            this.panelSag.Controls.Add(this.aciklamaTxt);
            this.panelSag.Controls.Add(this.ekleBtn);
            this.panelSag.Controls.Add(this.guncelleBtn);
            this.panelSag.Controls.Add(this.silBtn);
            this.panelSag.Controls.Add(this.yenileBtn);
            this.panelSag.Location = new System.Drawing.Point(694, 20);
            this.panelSag.Name = "panelSag";
            this.panelSag.Size = new System.Drawing.Size(180, 493);
            this.panelSag.TabIndex = 1;
            // 
            // labelBaslik
            // 
            this.labelBaslik.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelBaslik.ForeColor = System.Drawing.Color.White;
            this.labelBaslik.Location = new System.Drawing.Point(10, 10);
            this.labelBaslik.Name = "labelBaslik";
            this.labelBaslik.Size = new System.Drawing.Size(160, 30);
            this.labelBaslik.TabIndex = 0;
            this.labelBaslik.Text = "Stok Yönetimi";
            // 
            // labelUrun
            // 
            this.labelUrun.ForeColor = System.Drawing.Color.White;
            this.labelUrun.Location = new System.Drawing.Point(10, 50);
            this.labelUrun.Name = "labelUrun";
            this.labelUrun.Size = new System.Drawing.Size(50, 20);
            this.labelUrun.TabIndex = 1;
            this.labelUrun.Text = "Ürün:";
            // 
            // urunTxt
            // 
            this.urunTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.urunTxt.ForeColor = System.Drawing.Color.White;
            this.urunTxt.Location = new System.Drawing.Point(10, 70);
            this.urunTxt.Name = "urunTxt";
            this.urunTxt.Size = new System.Drawing.Size(160, 20);
            this.urunTxt.TabIndex = 2;
            this.urunTxt.TextChanged += new System.EventHandler(this.urunTxt_TextChanged);
            // 
            // labelMiktar
            // 
            this.labelMiktar.ForeColor = System.Drawing.Color.White;
            this.labelMiktar.Location = new System.Drawing.Point(10, 110);
            this.labelMiktar.Name = "labelMiktar";
            this.labelMiktar.Size = new System.Drawing.Size(50, 20);
            this.labelMiktar.TabIndex = 3;
            this.labelMiktar.Text = "Miktar:";
            // 
            // miktarTxt
            // 
            this.miktarTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.miktarTxt.ForeColor = System.Drawing.Color.White;
            this.miktarTxt.Location = new System.Drawing.Point(10, 130);
            this.miktarTxt.Name = "miktarTxt";
            this.miktarTxt.Size = new System.Drawing.Size(160, 20);
            this.miktarTxt.TabIndex = 4;
            // 
            // labelAciklama
            // 
            this.labelAciklama.ForeColor = System.Drawing.Color.White;
            this.labelAciklama.Location = new System.Drawing.Point(10, 170);
            this.labelAciklama.Name = "labelAciklama";
            this.labelAciklama.Size = new System.Drawing.Size(70, 20);
            this.labelAciklama.TabIndex = 5;
            this.labelAciklama.Text = "Açıklama:";
            // 
            // aciklamaTxt
            // 
            this.aciklamaTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.aciklamaTxt.ForeColor = System.Drawing.Color.White;
            this.aciklamaTxt.Location = new System.Drawing.Point(10, 190);
            this.aciklamaTxt.Name = "aciklamaTxt";
            this.aciklamaTxt.Size = new System.Drawing.Size(160, 20);
            this.aciklamaTxt.TabIndex = 6;
            // 
            // ekleBtn
            // 
            this.ekleBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ekleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ekleBtn.ForeColor = System.Drawing.Color.White;
            this.ekleBtn.Location = new System.Drawing.Point(10, 300);
            this.ekleBtn.Name = "ekleBtn";
            this.ekleBtn.Size = new System.Drawing.Size(70, 40);
            this.ekleBtn.TabIndex = 7;
            this.ekleBtn.Text = "Ekle";
            this.ekleBtn.UseVisualStyleBackColor = false;
            this.ekleBtn.Click += new System.EventHandler(this.ekleBtn_Click);
            // 
            // guncelleBtn
            // 
            this.guncelleBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.guncelleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guncelleBtn.ForeColor = System.Drawing.Color.White;
            this.guncelleBtn.Location = new System.Drawing.Point(90, 300);
            this.guncelleBtn.Name = "guncelleBtn";
            this.guncelleBtn.Size = new System.Drawing.Size(80, 40);
            this.guncelleBtn.TabIndex = 8;
            this.guncelleBtn.Text = "Güncelle";
            this.guncelleBtn.UseVisualStyleBackColor = false;
            // 
            // silBtn
            // 
            this.silBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.silBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.silBtn.ForeColor = System.Drawing.Color.White;
            this.silBtn.Location = new System.Drawing.Point(90, 350);
            this.silBtn.Name = "silBtn";
            this.silBtn.Size = new System.Drawing.Size(80, 40);
            this.silBtn.TabIndex = 9;
            this.silBtn.Text = "Sil";
            this.silBtn.UseVisualStyleBackColor = false;
            // 
            // yenileBtn
            // 
            this.yenileBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.yenileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yenileBtn.ForeColor = System.Drawing.Color.White;
            this.yenileBtn.Location = new System.Drawing.Point(10, 350);
            this.yenileBtn.Name = "yenileBtn";
            this.yenileBtn.Size = new System.Drawing.Size(70, 40);
            this.yenileBtn.TabIndex = 10;
            this.yenileBtn.Text = "Yenile";
            this.yenileBtn.UseVisualStyleBackColor = false;
            // 
            // Stok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(962, 598);
            this.Controls.Add(this.dataGridViewStok);
            this.Controls.Add(this.panelSag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Stok";
            this.Text = "Stok Takip";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStok)).EndInit();
            this.panelSag.ResumeLayout(false);
            this.panelSag.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.DataGridView dataGridViewStok;
        private System.Windows.Forms.Panel panelSag;
        private System.Windows.Forms.Label labelBaslik;
        private System.Windows.Forms.Label labelUrun;
        private System.Windows.Forms.TextBox urunTxt;
        private System.Windows.Forms.Label labelMiktar;
        private System.Windows.Forms.TextBox miktarTxt;
        private System.Windows.Forms.Label labelAciklama;
        private System.Windows.Forms.TextBox aciklamaTxt;
        private System.Windows.Forms.Button ekleBtn;
        private System.Windows.Forms.Button guncelleBtn;
        private System.Windows.Forms.Button silBtn;
        private System.Windows.Forms.Button yenileBtn;

        // Filtreleme için olay (boş bırakıldı, backend kodunda doldurulacak)
        private void urunTxt_TextChanged(object sender, System.EventArgs e)
        {
        }
    }
}