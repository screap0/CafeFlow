namespace CafeFlow
{
    partial class Menu
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuguncellebtn = new System.Windows.Forms.Button();
            this.kategoricb = new System.Windows.Forms.ComboBox();
            this.tutartxt = new System.Windows.Forms.TextBox();
            this.aciklamatxt = new System.Windows.Forms.TextBox();
            this.uruntxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.menuItem = new System.Windows.Forms.Panel();
            this.tutarLabel = new System.Windows.Forms.Label();
            this.kategoriLabel = new System.Windows.Forms.Label();
            this.aciklamaLabel = new System.Windows.Forms.Label();
            this.urunIsmiLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.resimsecbtn = new FontAwesome.Sharp.IconButton();
            this.picturebox = new System.Windows.Forms.PictureBox();
            this.silBtn = new System.Windows.Forms.Button();
            this.yenilebtn = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            this.flowLayoutPanel1.Controls.Add(this.menuItem);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(525, 648);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.yenilebtn);
            this.panel1.Controls.Add(this.silBtn);
            this.panel1.Controls.Add(this.resimsecbtn);
            this.panel1.Controls.Add(this.menuguncellebtn);
            this.panel1.Controls.Add(this.kategoricb);
            this.panel1.Controls.Add(this.tutartxt);
            this.panel1.Controls.Add(this.aciklamatxt);
            this.panel1.Controls.Add(this.uruntxt);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(554, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(497, 648);
            this.panel1.TabIndex = 1;
            // 
            // menuguncellebtn
            // 
            this.menuguncellebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.menuguncellebtn.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.menuguncellebtn.ForeColor = System.Drawing.Color.White;
            this.menuguncellebtn.Location = new System.Drawing.Point(199, 562);
            this.menuguncellebtn.Name = "menuguncellebtn";
            this.menuguncellebtn.Size = new System.Drawing.Size(185, 67);
            this.menuguncellebtn.TabIndex = 11;
            this.menuguncellebtn.Text = "Güncelle";
            this.menuguncellebtn.UseVisualStyleBackColor = false;
            this.menuguncellebtn.Click += new System.EventHandler(this.menuguncellebtn_Click);
            // 
            // kategoricb
            // 
            this.kategoricb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.kategoricb.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kategoricb.ForeColor = System.Drawing.Color.White;
            this.kategoricb.FormattingEnabled = true;
            this.kategoricb.Items.AddRange(new object[] {
            "Sıcak İçecekler",
            "Soğuk İçecekler",
            "Özel Seçim"});
            this.kategoricb.Location = new System.Drawing.Point(140, 420);
            this.kategoricb.Name = "kategoricb";
            this.kategoricb.Size = new System.Drawing.Size(334, 45);
            this.kategoricb.TabIndex = 10;
            this.kategoricb.Text = "Kategori Seçiniz...";
            // 
            // tutartxt
            // 
            this.tutartxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.tutartxt.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tutartxt.ForeColor = System.Drawing.Color.White;
            this.tutartxt.Location = new System.Drawing.Point(140, 349);
            this.tutartxt.Multiline = true;
            this.tutartxt.Name = "tutartxt";
            this.tutartxt.Size = new System.Drawing.Size(334, 50);
            this.tutartxt.TabIndex = 9;
            // 
            // aciklamatxt
            // 
            this.aciklamatxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.aciklamatxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.aciklamatxt.ForeColor = System.Drawing.Color.White;
            this.aciklamatxt.Location = new System.Drawing.Point(140, 210);
            this.aciklamatxt.Multiline = true;
            this.aciklamatxt.Name = "aciklamatxt";
            this.aciklamatxt.Size = new System.Drawing.Size(334, 107);
            this.aciklamatxt.TabIndex = 8;
            // 
            // uruntxt
            // 
            this.uruntxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.uruntxt.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.uruntxt.ForeColor = System.Drawing.Color.White;
            this.uruntxt.Location = new System.Drawing.Point(140, 136);
            this.uruntxt.Multiline = true;
            this.uruntxt.Name = "uruntxt";
            this.uruntxt.Size = new System.Drawing.Size(334, 45);
            this.uruntxt.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(40, 502);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 28);
            this.label5.TabIndex = 6;
            this.label5.Text = "Resim:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(10, 428);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 28);
            this.label4.TabIndex = 5;
            this.label4.Text = "Kategori:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(37, 360);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tutar:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(3, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Açıklama:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ürün:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(148, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(193, 31);
            this.label7.TabIndex = 1;
            this.label7.Text = "Menüyü Güncelle";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(1059, 180);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(216, 306);
            this.panel2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(100)))));
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(24, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 86);
            this.button1.TabIndex = 12;
            this.button1.Text = "Göster";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(70, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 31);
            this.label6.TabIndex = 2;
            this.label6.Text = "Ekle";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // menuItem
            // 
            this.menuItem.BackColor = System.Drawing.Color.Transparent;
            this.menuItem.Controls.Add(this.tutarLabel);
            this.menuItem.Controls.Add(this.kategoriLabel);
            this.menuItem.Controls.Add(this.aciklamaLabel);
            this.menuItem.Controls.Add(this.urunIsmiLabel);
            this.menuItem.Controls.Add(this.picturebox);
            this.menuItem.Location = new System.Drawing.Point(3, 3);
            this.menuItem.Name = "menuItem";
            this.menuItem.Size = new System.Drawing.Size(491, 178);
            this.menuItem.TabIndex = 0;
            this.menuItem.Visible = false;
            // 
            // tutarLabel
            // 
            this.tutarLabel.AutoSize = true;
            this.tutarLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tutarLabel.ForeColor = System.Drawing.Color.Gold;
            this.tutarLabel.Location = new System.Drawing.Point(374, 65);
            this.tutarLabel.Name = "tutarLabel";
            this.tutarLabel.Size = new System.Drawing.Size(103, 23);
            this.tutarLabel.TabIndex = 4;
            this.tutarLabel.Text = "Tutar: 120₺";
            // 
            // kategoriLabel
            // 
            this.kategoriLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kategoriLabel.ForeColor = System.Drawing.Color.SaddleBrown;
            this.kategoriLabel.Location = new System.Drawing.Point(112, 56);
            this.kategoriLabel.Name = "kategoriLabel";
            this.kategoriLabel.Size = new System.Drawing.Size(236, 23);
            this.kategoriLabel.TabIndex = 3;
            this.kategoriLabel.Text = "Sıcak İçecekler";
            // 
            // aciklamaLabel
            // 
            this.aciklamaLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.aciklamaLabel.ForeColor = System.Drawing.Color.White;
            this.aciklamaLabel.Location = new System.Drawing.Point(112, 83);
            this.aciklamaLabel.Name = "aciklamaLabel";
            this.aciklamaLabel.Size = new System.Drawing.Size(256, 78);
            this.aciklamaLabel.TabIndex = 2;
            this.aciklamaLabel.Text = "Açıklama: Fincan Çay";
            // 
            // urunIsmiLabel
            // 
            this.urunIsmiLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.urunIsmiLabel.ForeColor = System.Drawing.Color.LightCoral;
            this.urunIsmiLabel.Location = new System.Drawing.Point(110, 25);
            this.urunIsmiLabel.Name = "urunIsmiLabel";
            this.urunIsmiLabel.Size = new System.Drawing.Size(265, 38);
            this.urunIsmiLabel.TabIndex = 1;
            this.urunIsmiLabel.Text = "Çay";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CafeFlow.Properties.Resources.icons8_refresh_80;
            this.pictureBox1.Location = new System.Drawing.Point(40, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(141, 117);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // resimsecbtn
            // 
            this.resimsecbtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.resimsecbtn.IconChar = FontAwesome.Sharp.IconChar.Image;
            this.resimsecbtn.IconColor = System.Drawing.Color.Black;
            this.resimsecbtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.resimsecbtn.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.resimsecbtn.Location = new System.Drawing.Point(154, 490);
            this.resimsecbtn.Name = "resimsecbtn";
            this.resimsecbtn.Size = new System.Drawing.Size(172, 56);
            this.resimsecbtn.TabIndex = 12;
            this.resimsecbtn.Text = "Resim Seç";
            this.resimsecbtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.resimsecbtn.UseVisualStyleBackColor = true;
            this.resimsecbtn.Click += new System.EventHandler(this.resimsecbtn_Click);
            // 
            // picturebox
            // 
            this.picturebox.Location = new System.Drawing.Point(9, 36);
            this.picturebox.Name = "picturebox";
            this.picturebox.Size = new System.Drawing.Size(95, 89);
            this.picturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturebox.TabIndex = 0;
            this.picturebox.TabStop = false;
            // 
            // silBtn
            // 
            this.silBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.silBtn.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.silBtn.ForeColor = System.Drawing.Color.White;
            this.silBtn.Location = new System.Drawing.Point(390, 562);
            this.silBtn.Name = "silBtn";
            this.silBtn.Size = new System.Drawing.Size(88, 67);
            this.silBtn.TabIndex = 13;
            this.silBtn.Text = "Sil";
            this.silBtn.UseVisualStyleBackColor = false;
            this.silBtn.Click += new System.EventHandler(this.silBtn_Click);
            // 
            // yenilebtn
            // 
            this.yenilebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.yenilebtn.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yenilebtn.ForeColor = System.Drawing.Color.White;
            this.yenilebtn.Location = new System.Drawing.Point(107, 562);
            this.yenilebtn.Name = "yenilebtn";
            this.yenilebtn.Size = new System.Drawing.Size(86, 67);
            this.yenilebtn.TabIndex = 14;
            this.yenilebtn.Text = "Yenile";
            this.yenilebtn.UseVisualStyleBackColor = false;
            this.yenilebtn.Click += new System.EventHandler(this.yenilebtn_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(1287, 660);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuItem.ResumeLayout(false);
            this.menuItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tutartxt;
        private System.Windows.Forms.TextBox aciklamatxt;
        private System.Windows.Forms.TextBox uruntxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox kategoricb;
        private System.Windows.Forms.Button menuguncellebtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private FontAwesome.Sharp.IconButton resimsecbtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel menuItem;
        private System.Windows.Forms.Label urunIsmiLabel;
        private System.Windows.Forms.PictureBox picturebox;
        private System.Windows.Forms.Label kategoriLabel;
        private System.Windows.Forms.Label aciklamaLabel;
        private System.Windows.Forms.Label tutarLabel;
        private System.Windows.Forms.Button silBtn;
        private System.Windows.Forms.Button yenilebtn;
    }
}