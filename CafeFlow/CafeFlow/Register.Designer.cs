﻿namespace CafeFlow
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lbl_bosbirakilamaz = new System.Windows.Forms.Label();
            this.lbl_sifrehata = new System.Windows.Forms.Label();
            this.txt_kullaniciadi = new System.Windows.Forms.TextBox();
            this.btn_kayitol = new RoundedButton();
            this.txt_sifretekrar = new System.Windows.Forms.TextBox();
            this.txt_sifre = new System.Windows.Forms.TextBox();
            this.txt_soyad = new System.Windows.Forms.TextBox();
            this.txt_ad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.lbl_bosbirakilamaz);
            this.panel1.Controls.Add(this.lbl_sifrehata);
            this.panel1.Controls.Add(this.txt_kullaniciadi);
            this.panel1.Controls.Add(this.btn_kayitol);
            this.panel1.Controls.Add(this.txt_sifretekrar);
            this.panel1.Controls.Add(this.txt_sifre);
            this.panel1.Controls.Add(this.txt_soyad);
            this.panel1.Controls.Add(this.txt_ad);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 152);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(515, 324);
            this.panel1.TabIndex = 9;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel1.LinkColor = System.Drawing.Color.AliceBlue;
            this.linkLabel1.Location = new System.Drawing.Point(227, 298);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(81, 17);
            this.linkLabel1.TabIndex = 20;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Giriş Ekranı";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lbl_bosbirakilamaz
            // 
            this.lbl_bosbirakilamaz.AutoSize = true;
            this.lbl_bosbirakilamaz.ForeColor = System.Drawing.Color.Red;
            this.lbl_bosbirakilamaz.Location = new System.Drawing.Point(179, 214);
            this.lbl_bosbirakilamaz.Name = "lbl_bosbirakilamaz";
            this.lbl_bosbirakilamaz.Size = new System.Drawing.Size(32, 17);
            this.lbl_bosbirakilamaz.TabIndex = 19;
            this.lbl_bosbirakilamaz.Text = "      ";
            // 
            // lbl_sifrehata
            // 
            this.lbl_sifrehata.AutoSize = true;
            this.lbl_sifrehata.ForeColor = System.Drawing.Color.Red;
            this.lbl_sifrehata.Location = new System.Drawing.Point(205, 214);
            this.lbl_sifrehata.Name = "lbl_sifrehata";
            this.lbl_sifrehata.Size = new System.Drawing.Size(32, 17);
            this.lbl_sifrehata.TabIndex = 18;
            this.lbl_sifrehata.Text = "      ";
            // 
            // txt_kullaniciadi
            // 
            this.txt_kullaniciadi.Location = new System.Drawing.Point(270, 100);
            this.txt_kullaniciadi.Name = "txt_kullaniciadi";
            this.txt_kullaniciadi.Size = new System.Drawing.Size(146, 23);
            this.txt_kullaniciadi.TabIndex = 17;
            this.txt_kullaniciadi.Click += new System.EventHandler(this.txt_kullaniciadi_Click);
            // 
            // btn_kayitol
            // 
            this.btn_kayitol.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_kayitol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_kayitol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_kayitol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_kayitol.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_kayitol.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
            this.btn_kayitol.IconColor = System.Drawing.Color.WhiteSmoke;
            this.btn_kayitol.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_kayitol.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_kayitol.Location = new System.Drawing.Point(205, 242);
            this.btn_kayitol.Margin = new System.Windows.Forms.Padding(4);
            this.btn_kayitol.Name = "btn_kayitol";
            this.btn_kayitol.Size = new System.Drawing.Size(120, 44);
            this.btn_kayitol.TabIndex = 6;
            this.btn_kayitol.Text = "Kayıt Ol";
            this.btn_kayitol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_kayitol.UseVisualStyleBackColor = true;
            this.btn_kayitol.Click += new System.EventHandler(this.btn_kayitol_Click);
            // 
            // txt_sifretekrar
            // 
            this.txt_sifretekrar.Location = new System.Drawing.Point(270, 179);
            this.txt_sifretekrar.Name = "txt_sifretekrar";
            this.txt_sifretekrar.PasswordChar = '*';
            this.txt_sifretekrar.Size = new System.Drawing.Size(146, 23);
            this.txt_sifretekrar.TabIndex = 16;
            this.txt_sifretekrar.Click += new System.EventHandler(this.txt_sifretekrar_Click);
            // 
            // txt_sifre
            // 
            this.txt_sifre.Location = new System.Drawing.Point(270, 140);
            this.txt_sifre.Name = "txt_sifre";
            this.txt_sifre.PasswordChar = '*';
            this.txt_sifre.Size = new System.Drawing.Size(146, 23);
            this.txt_sifre.TabIndex = 15;
            this.txt_sifre.Click += new System.EventHandler(this.txt_sifre_Click);
            // 
            // txt_soyad
            // 
            this.txt_soyad.Location = new System.Drawing.Point(270, 63);
            this.txt_soyad.Name = "txt_soyad";
            this.txt_soyad.Size = new System.Drawing.Size(146, 23);
            this.txt_soyad.TabIndex = 13;
            this.txt_soyad.Click += new System.EventHandler(this.txt_soyad_Click);
            // 
            // txt_ad
            // 
            this.txt_ad.Location = new System.Drawing.Point(270, 24);
            this.txt_ad.Name = "txt_ad";
            this.txt_ad.Size = new System.Drawing.Size(146, 23);
            this.txt_ad.TabIndex = 12;
            this.txt_ad.Click += new System.EventHandler(this.txt_ad_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(127, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Şifrenizi Onaylayın";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(127, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Şifre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(127, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Kullanıcı Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(127, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Soyad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(127, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ad";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(515, 152);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(515, 477);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private RoundedButton btn_kayitol;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txt_sifretekrar;
        private System.Windows.Forms.TextBox txt_sifre;
        private System.Windows.Forms.TextBox txt_soyad;
        private System.Windows.Forms.TextBox txt_ad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_kullaniciadi;
        private System.Windows.Forms.Label lbl_bosbirakilamaz;
        private System.Windows.Forms.Label lbl_sifrehata;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}