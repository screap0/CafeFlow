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
            this.resimsecbtn = new FontAwesome.Sharp.IconButton();
            this.kategoricb = new System.Windows.Forms.ComboBox();
            this.tutartxt = new System.Windows.Forms.TextBox();
            this.aciklamatxt = new System.Windows.Forms.TextBox();
            this.uruntxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.exitBtn = new FontAwesome.Sharp.IconButton();
            this.eklebtn = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // resimsecbtn
            // 
            this.resimsecbtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.resimsecbtn.IconChar = FontAwesome.Sharp.IconChar.Image;
            this.resimsecbtn.IconColor = System.Drawing.Color.Black;
            this.resimsecbtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.resimsecbtn.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.resimsecbtn.Location = new System.Drawing.Point(175, 589);
            this.resimsecbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resimsecbtn.Name = "resimsecbtn";
            this.resimsecbtn.Padding = new System.Windows.Forms.Padding(5);
            this.resimsecbtn.Size = new System.Drawing.Size(172, 57);
            this.resimsecbtn.TabIndex = 12;
            this.resimsecbtn.Text = "Resim Seç";
            this.resimsecbtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.resimsecbtn.UseVisualStyleBackColor = true;
            this.resimsecbtn.Click += new System.EventHandler(this.resimsecbtn_Click);
            // 
            // kategoricb
            // 
            this.kategoricb.BackColor = System.Drawing.Color.White;
            this.kategoricb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kategoricb.ForeColor = System.Drawing.Color.Black;
            this.kategoricb.FormattingEnabled = true;
            this.kategoricb.Location = new System.Drawing.Point(93, 539);
            this.kategoricb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kategoricb.Name = "kategoricb";
            this.kategoricb.Size = new System.Drawing.Size(335, 32);
            this.kategoricb.TabIndex = 10;
            this.kategoricb.Text = "Kategori Seçiniz...";
            // 
            // tutartxt
            // 
            this.tutartxt.BackColor = System.Drawing.Color.White;
            this.tutartxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tutartxt.ForeColor = System.Drawing.Color.Black;
            this.tutartxt.Location = new System.Drawing.Point(93, 453);
            this.tutartxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tutartxt.Multiline = true;
            this.tutartxt.Name = "tutartxt";
            this.tutartxt.Size = new System.Drawing.Size(335, 50);
            this.tutartxt.TabIndex = 9;
            // 
            // aciklamatxt
            // 
            this.aciklamatxt.BackColor = System.Drawing.Color.White;
            this.aciklamatxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.aciklamatxt.ForeColor = System.Drawing.Color.Black;
            this.aciklamatxt.Location = new System.Drawing.Point(93, 295);
            this.aciklamatxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.aciklamatxt.Multiline = true;
            this.aciklamatxt.Name = "aciklamatxt";
            this.aciklamatxt.Size = new System.Drawing.Size(335, 107);
            this.aciklamatxt.TabIndex = 8;
            // 
            // uruntxt
            // 
            this.uruntxt.BackColor = System.Drawing.Color.White;
            this.uruntxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.uruntxt.ForeColor = System.Drawing.Color.Black;
            this.uruntxt.Location = new System.Drawing.Point(93, 204);
            this.uruntxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uruntxt.Multiline = true;
            this.uruntxt.Name = "uruntxt";
            this.uruntxt.Size = new System.Drawing.Size(335, 45);
            this.uruntxt.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(88, 421);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tutar:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(88, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Açıklama:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(88, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ürün:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(127, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(250, 31);
            this.label7.TabIndex = 1;
            this.label7.Text = "Menüye Yeni Ürün Ekle";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panel2.Controls.Add(this.exitBtn);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(521, 123);
            this.panel2.TabIndex = 3;
            // 
            // exitBtn
            // 
            this.exitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.ForeColor = System.Drawing.Color.Black;
            this.exitBtn.IconChar = FontAwesome.Sharp.IconChar.X;
            this.exitBtn.IconColor = System.Drawing.Color.Gainsboro;
            this.exitBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.exitBtn.IconSize = 15;
            this.exitBtn.Location = new System.Drawing.Point(492, 10);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(15, 20);
            this.exitBtn.TabIndex = 6;
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // eklebtn
            // 
            this.eklebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.eklebtn.FlatAppearance.BorderSize = 0;
            this.eklebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eklebtn.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.eklebtn.ForeColor = System.Drawing.Color.White;
            this.eklebtn.Location = new System.Drawing.Point(175, 665);
            this.eklebtn.Name = "eklebtn";
            this.eklebtn.Size = new System.Drawing.Size(171, 42);
            this.eklebtn.TabIndex = 13;
            this.eklebtn.Text = "Ekle";
            this.eklebtn.UseVisualStyleBackColor = false;
            this.eklebtn.Click += new System.EventHandler(this.eklebtn_Click);
            // 
            // MenuEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(521, 731);
            this.Controls.Add(this.eklebtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resimsecbtn);
            this.Controls.Add(this.uruntxt);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.kategoricb);
            this.Controls.Add(this.aciklamatxt);
            this.Controls.Add(this.tutartxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MenuEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuEkle";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FontAwesome.Sharp.IconButton resimsecbtn;
        private System.Windows.Forms.ComboBox kategoricb;
        private System.Windows.Forms.TextBox tutartxt;
        private System.Windows.Forms.TextBox aciklamatxt;
        private System.Windows.Forms.TextBox uruntxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton exitBtn;
        private System.Windows.Forms.Button eklebtn;
    }
}