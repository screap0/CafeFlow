namespace CafeFlow
{
    partial class MenuEkle
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.resimsecbtn = new FontAwesome.Sharp.IconButton();
            this.eklebtn = new System.Windows.Forms.Button();
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
            this.minimizeBtn = new FontAwesome.Sharp.IconButton();
            this.exitBtn = new FontAwesome.Sharp.IconButton();
            this.maximizeBtn = new FontAwesome.Sharp.IconButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.resimsecbtn);
            this.panel1.Controls.Add(this.eklebtn);
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
            this.panel1.Location = new System.Drawing.Point(12, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(497, 648);
            this.panel1.TabIndex = 2;
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
            // eklebtn
            // 
            this.eklebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.eklebtn.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.eklebtn.ForeColor = System.Drawing.Color.White;
            this.eklebtn.Location = new System.Drawing.Point(208, 570);
            this.eklebtn.Name = "eklebtn";
            this.eklebtn.Size = new System.Drawing.Size(185, 67);
            this.eklebtn.TabIndex = 11;
            this.eklebtn.Text = "Ekle";
            this.eklebtn.UseVisualStyleBackColor = false;
            this.eklebtn.Click += new System.EventHandler(this.eklebtn_Click);
            // 
            // kategoricb
            // 
            this.kategoricb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.kategoricb.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kategoricb.ForeColor = System.Drawing.Color.White;
            this.kategoricb.FormattingEnabled = true;
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
            this.label7.Location = new System.Drawing.Point(76, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(250, 31);
            this.label7.TabIndex = 1;
            this.label7.Text = "Menüye Yeni Ürün Ekle";
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeBtn.FlatAppearance.BorderSize = 0;
            this.minimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeBtn.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.minimizeBtn.IconColor = System.Drawing.Color.Gainsboro;
            this.minimizeBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.minimizeBtn.IconSize = 15;
            this.minimizeBtn.Location = new System.Drawing.Point(430, 10);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(15, 20);
            this.minimizeBtn.TabIndex = 8;
            this.minimizeBtn.UseVisualStyleBackColor = true;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.IconChar = FontAwesome.Sharp.IconChar.X;
            this.exitBtn.IconColor = System.Drawing.Color.Gainsboro;
            this.exitBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.exitBtn.IconSize = 15;
            this.exitBtn.Location = new System.Drawing.Point(483, 10);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(15, 20);
            this.exitBtn.TabIndex = 6;
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // maximizeBtn
            // 
            this.maximizeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maximizeBtn.FlatAppearance.BorderSize = 0;
            this.maximizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximizeBtn.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.maximizeBtn.IconColor = System.Drawing.Color.Gainsboro;
            this.maximizeBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.maximizeBtn.IconSize = 15;
            this.maximizeBtn.Location = new System.Drawing.Point(454, 10);
            this.maximizeBtn.Name = "maximizeBtn";
            this.maximizeBtn.Size = new System.Drawing.Size(23, 20);
            this.maximizeBtn.TabIndex = 7;
            this.maximizeBtn.UseVisualStyleBackColor = true;
            this.maximizeBtn.Click += new System.EventHandler(this.maximizeBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MenuEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(521, 696);
            this.Controls.Add(this.minimizeBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.maximizeBtn);
            this.Controls.Add(this.exitBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuEkle";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton resimsecbtn;
        private System.Windows.Forms.Button eklebtn;
        private System.Windows.Forms.ComboBox kategoricb;
        private System.Windows.Forms.TextBox tutartxt;
        private System.Windows.Forms.TextBox aciklamatxt;
        private System.Windows.Forms.TextBox uruntxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private FontAwesome.Sharp.IconButton minimizeBtn;
        private FontAwesome.Sharp.IconButton exitBtn;
        private FontAwesome.Sharp.IconButton maximizeBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}