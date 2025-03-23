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
            this.bnt_girisyap = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnk_kayitol = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_kullaniciadi = new System.Windows.Forms.TextBox();
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
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(86, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kullanıcı Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(143, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Şifre:";
            // 
            // txt_sifre
            // 
            this.txt_sifre.Location = new System.Drawing.Point(198, 72);
            this.txt_sifre.Name = "txt_sifre";
            this.txt_sifre.PasswordChar = '*';
            this.txt_sifre.Size = new System.Drawing.Size(146, 27);
            this.txt_sifre.TabIndex = 4;
            // 
            // bnt_girisyap
            // 
            this.bnt_girisyap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnt_girisyap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bnt_girisyap.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bnt_girisyap.IconChar = FontAwesome.Sharp.IconChar.SignInAlt;
            this.bnt_girisyap.IconColor = System.Drawing.Color.WhiteSmoke;
            this.bnt_girisyap.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.bnt_girisyap.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bnt_girisyap.Location = new System.Drawing.Point(184, 128);
            this.bnt_girisyap.Name = "bnt_girisyap";
            this.bnt_girisyap.Size = new System.Drawing.Size(160, 48);
            this.bnt_girisyap.TabIndex = 6;
            this.bnt_girisyap.Text = "Giriş Yap";
            this.bnt_girisyap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bnt_girisyap.UseVisualStyleBackColor = true;
            this.bnt_girisyap.Click += new System.EventHandler(this.ıconButton1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_kullaniciadi);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lnk_kayitol);
            this.panel1.Controls.Add(this.bnt_girisyap);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_sifre);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 152);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 260);
            this.panel1.TabIndex = 7;
            // 
            // lnk_kayitol
            // 
            this.lnk_kayitol.AutoSize = true;
            this.lnk_kayitol.LinkColor = System.Drawing.Color.AliceBlue;
            this.lnk_kayitol.Location = new System.Drawing.Point(359, 217);
            this.lnk_kayitol.Name = "lnk_kayitol";
            this.lnk_kayitol.Size = new System.Drawing.Size(68, 20);
            this.lnk_kayitol.TabIndex = 7;
            this.lnk_kayitol.TabStop = true;
            this.lnk_kayitol.Text = "Kayıt Ol";
            this.lnk_kayitol.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_kayitol_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(168, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Hala Kayıt Olmadın mı?";
            // 
            // txt_kullaniciadi
            // 
            this.txt_kullaniciadi.Location = new System.Drawing.Point(198, 23);
            this.txt_kullaniciadi.Name = "txt_kullaniciadi";
            this.txt_kullaniciadi.Size = new System.Drawing.Size(146, 27);
            this.txt_kullaniciadi.TabIndex = 9;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(481, 457);
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
        private FontAwesome.Sharp.IconButton bnt_girisyap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel lnk_kayitol;
        private System.Windows.Forms.TextBox txt_kullaniciadi;
    }
}