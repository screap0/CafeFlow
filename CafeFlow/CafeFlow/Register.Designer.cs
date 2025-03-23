namespace CafeFlow
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
            this.txt_sifretekrar = new System.Windows.Forms.TextBox();
            this.txt_sifre = new System.Windows.Forms.TextBox();
            this.txt_soyad = new System.Windows.Forms.TextBox();
            this.txt_ad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_kayitol = new FontAwesome.Sharp.IconButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
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
            this.panel1.Size = new System.Drawing.Size(481, 292);
            this.panel1.TabIndex = 9;
            // 
            // txt_sifretekrar
            // 
            this.txt_sifretekrar.Location = new System.Drawing.Point(189, 161);
            this.txt_sifretekrar.Name = "txt_sifretekrar";
            this.txt_sifretekrar.PasswordChar = '*';
            this.txt_sifretekrar.Size = new System.Drawing.Size(146, 27);
            this.txt_sifretekrar.TabIndex = 16;
            // 
            // txt_sifre
            // 
            this.txt_sifre.Location = new System.Drawing.Point(189, 128);
            this.txt_sifre.Name = "txt_sifre";
            this.txt_sifre.PasswordChar = '*';
            this.txt_sifre.Size = new System.Drawing.Size(146, 27);
            this.txt_sifre.TabIndex = 15;
            // 
            // txt_soyad
            // 
            this.txt_soyad.Location = new System.Drawing.Point(189, 62);
            this.txt_soyad.Name = "txt_soyad";
            this.txt_soyad.Size = new System.Drawing.Size(146, 27);
            this.txt_soyad.TabIndex = 13;
            // 
            // txt_ad
            // 
            this.txt_ad.Location = new System.Drawing.Point(189, 29);
            this.txt_ad.Name = "txt_ad";
            this.txt_ad.Size = new System.Drawing.Size(146, 27);
            this.txt_ad.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(30, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Şifrenizi Onaylayın:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(134, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Şifre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(77, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Kullanıcı Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(123, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Soyad:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(149, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ad:";
            // 
            // btn_kayitol
            // 
            this.btn_kayitol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_kayitol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_kayitol.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_kayitol.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
            this.btn_kayitol.IconColor = System.Drawing.Color.WhiteSmoke;
            this.btn_kayitol.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_kayitol.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_kayitol.Location = new System.Drawing.Point(186, 214);
            this.btn_kayitol.Margin = new System.Windows.Forms.Padding(4);
            this.btn_kayitol.Name = "btn_kayitol";
            this.btn_kayitol.Size = new System.Drawing.Size(149, 60);
            this.btn_kayitol.TabIndex = 6;
            this.btn_kayitol.Text = "Kayıt Ol";
            this.btn_kayitol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_kayitol.UseVisualStyleBackColor = true;
            this.btn_kayitol.Click += new System.EventHandler(this.btn_kayitol_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(481, 152);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(189, 95);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(146, 27);
            this.textBox1.TabIndex = 17;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(481, 457);
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
        private FontAwesome.Sharp.IconButton btn_kayitol;
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
        private System.Windows.Forms.TextBox textBox1;
    }
}