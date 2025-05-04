namespace CafeFlow
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_sifre = new System.Windows.Forms.TextBox();
            this.btn_girisyap = new RoundedButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_hata = new System.Windows.Forms.Label();
            this.txt_kullaniciadi = new System.Windows.Forms.TextBox();
            this.lnk_kayitol = new System.Windows.Forms.LinkLabel();
            this.exitBtn = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(481, 152);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(195, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kullanıcı Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(222, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Şifre";
            // 
            // txt_sifre
            // 
            this.txt_sifre.Location = new System.Drawing.Point(168, 102);
            this.txt_sifre.Name = "txt_sifre";
            this.txt_sifre.PasswordChar = '*';
            this.txt_sifre.Size = new System.Drawing.Size(146, 23);
            this.txt_sifre.TabIndex = 9;
            this.txt_sifre.Click += new System.EventHandler(this.txt_sifre_Click);
            // 
            // btn_girisyap
            // 
            this.btn_girisyap.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_girisyap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_girisyap.FlatAppearance.BorderColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_girisyap.FlatAppearance.BorderSize = 0;
            this.btn_girisyap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_girisyap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_girisyap.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_girisyap.IconChar = FontAwesome.Sharp.IconChar.SignInAlt;
            this.btn_girisyap.IconColor = System.Drawing.Color.WhiteSmoke;
            this.btn_girisyap.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_girisyap.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_girisyap.Location = new System.Drawing.Point(183, 161);
            this.btn_girisyap.Name = "btn_girisyap";
            this.btn_girisyap.Size = new System.Drawing.Size(120, 44);
            this.btn_girisyap.TabIndex = 10;
            this.btn_girisyap.Text = "Giriş Yap";
            this.btn_girisyap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_girisyap.UseVisualStyleBackColor = false;
            this.btn_girisyap.Click += new System.EventHandler(this.btn_girisyap_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_hata);
            this.panel1.Controls.Add(this.txt_kullaniciadi);
            this.panel1.Controls.Add(this.lnk_kayitol);
            this.panel1.Controls.Add(this.btn_girisyap);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_sifre);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 152);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 260);
            this.panel1.TabIndex = 7;
            // 
            // lbl_hata
            // 
            this.lbl_hata.AutoSize = true;
            this.lbl_hata.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_hata.Location = new System.Drawing.Point(168, 137);
            this.lbl_hata.Name = "lbl_hata";
            this.lbl_hata.Size = new System.Drawing.Size(0, 17);
            this.lbl_hata.TabIndex = 13;
            this.lbl_hata.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_kullaniciadi
            // 
            this.txt_kullaniciadi.Location = new System.Drawing.Point(168, 41);
            this.txt_kullaniciadi.Name = "txt_kullaniciadi";
            this.txt_kullaniciadi.Size = new System.Drawing.Size(146, 23);
            this.txt_kullaniciadi.TabIndex = 4;
            this.txt_kullaniciadi.Click += new System.EventHandler(this.txt_kullaniciadi_Click);
            // 
            // lnk_kayitol
            // 
            this.lnk_kayitol.AutoSize = true;
            this.lnk_kayitol.LinkColor = System.Drawing.Color.AliceBlue;
            this.lnk_kayitol.Location = new System.Drawing.Point(218, 235);
            this.lnk_kayitol.Name = "lnk_kayitol";
            this.lnk_kayitol.Size = new System.Drawing.Size(57, 17);
            this.lnk_kayitol.TabIndex = 11;
            this.lnk_kayitol.TabStop = true;
            this.lnk_kayitol.Text = "Kayıt Ol";
            this.lnk_kayitol.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_kayitol_LinkClicked);
            // 
            // exitBtn
            // 
            this.exitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.IconChar = FontAwesome.Sharp.IconChar.X;
            this.exitBtn.IconColor = System.Drawing.Color.Gainsboro;
            this.exitBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.exitBtn.IconSize = 15;
            this.exitBtn.Location = new System.Drawing.Point(453, 12);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(15, 20);
            this.exitBtn.TabIndex = 8;
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // Login
            // 
            this.AcceptButton = this.btn_girisyap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(481, 457);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_sifre;
        private RoundedButton btn_girisyap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel lnk_kayitol;
        private System.Windows.Forms.TextBox txt_kullaniciadi;
        private System.Windows.Forms.Label lbl_hata;
        private FontAwesome.Sharp.IconButton exitBtn;
    }
}