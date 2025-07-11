﻿namespace CafeFlow
{
    partial class Home
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        /////
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.beeperBtn = new FontAwesome.Sharp.IconButton();
            this.ıconButton5 = new FontAwesome.Sharp.IconButton();
            this.menuBtn = new FontAwesome.Sharp.IconButton();
            this.reportBtn = new FontAwesome.Sharp.IconButton();
            this.dashboardBtn = new FontAwesome.Sharp.IconButton();
            this.orderBtn = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.btnLogo = new System.Windows.Forms.PictureBox();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.minimizeBtn = new FontAwesome.Sharp.IconButton();
            this.maximizeBtn = new FontAwesome.Sharp.IconButton();
            this.exitBtn = new FontAwesome.Sharp.IconButton();
            this.navLbl = new System.Windows.Forms.Label();
            this.lblTitleChildForm = new System.Windows.Forms.Label();
            this.iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.panelShadow = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.stokanalizBtn = new FontAwesome.Sharp.IconButton();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogo)).BeginInit();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).BeginInit();
            this.panelDesktop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panelMenu.Controls.Add(this.stokanalizBtn);
            this.panelMenu.Controls.Add(this.beeperBtn);
            this.panelMenu.Controls.Add(this.ıconButton5);
            this.panelMenu.Controls.Add(this.menuBtn);
            this.panelMenu.Controls.Add(this.reportBtn);
            this.panelMenu.Controls.Add(this.dashboardBtn);
            this.panelMenu.Controls.Add(this.orderBtn);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 750);
            this.panelMenu.TabIndex = 0;
            // 
            // beeperBtn
            // 
            this.beeperBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.beeperBtn.FlatAppearance.BorderSize = 0;
            this.beeperBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.beeperBtn.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beeperBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.beeperBtn.IconChar = FontAwesome.Sharp.IconChar.Lock;
            this.beeperBtn.IconColor = System.Drawing.Color.Gainsboro;
            this.beeperBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.beeperBtn.IconSize = 40;
            this.beeperBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.beeperBtn.Location = new System.Drawing.Point(0, 440);
            this.beeperBtn.Name = "beeperBtn";
            this.beeperBtn.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.beeperBtn.Size = new System.Drawing.Size(220, 60);
            this.beeperBtn.TabIndex = 6;
            this.beeperBtn.Text = "Beeper";
            this.beeperBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.beeperBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.beeperBtn.UseVisualStyleBackColor = true;
            this.beeperBtn.Click += new System.EventHandler(this.beeperBtn_Click);
            // 
            // ıconButton5
            // 
            this.ıconButton5.Dock = System.Windows.Forms.DockStyle.Top;
            this.ıconButton5.FlatAppearance.BorderSize = 0;
            this.ıconButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ıconButton5.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ıconButton5.ForeColor = System.Drawing.Color.Gainsboro;
            this.ıconButton5.IconChar = FontAwesome.Sharp.IconChar.Warehouse;
            this.ıconButton5.IconColor = System.Drawing.Color.Gainsboro;
            this.ıconButton5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ıconButton5.IconSize = 40;
            this.ıconButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ıconButton5.Location = new System.Drawing.Point(0, 380);
            this.ıconButton5.Name = "ıconButton5";
            this.ıconButton5.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.ıconButton5.Size = new System.Drawing.Size(220, 60);
            this.ıconButton5.TabIndex = 5;
            this.ıconButton5.Text = "Stok";
            this.ıconButton5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ıconButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ıconButton5.UseVisualStyleBackColor = true;
            this.ıconButton5.Click += new System.EventHandler(this.ıconButton5_Click);
            // 
            // menuBtn
            // 
            this.menuBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuBtn.FlatAppearance.BorderSize = 0;
            this.menuBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuBtn.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.menuBtn.IconChar = FontAwesome.Sharp.IconChar.Receipt;
            this.menuBtn.IconColor = System.Drawing.Color.Gainsboro;
            this.menuBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuBtn.IconSize = 40;
            this.menuBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuBtn.Location = new System.Drawing.Point(0, 320);
            this.menuBtn.Name = "menuBtn";
            this.menuBtn.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.menuBtn.Size = new System.Drawing.Size(220, 60);
            this.menuBtn.TabIndex = 4;
            this.menuBtn.Text = "Menu";
            this.menuBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuBtn.UseVisualStyleBackColor = true;
            this.menuBtn.Click += new System.EventHandler(this.menuBtn_Click);
            // 
            // reportBtn
            // 
            this.reportBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.reportBtn.FlatAppearance.BorderSize = 0;
            this.reportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportBtn.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.reportBtn.IconChar = FontAwesome.Sharp.IconChar.ChartLine;
            this.reportBtn.IconColor = System.Drawing.Color.Gainsboro;
            this.reportBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.reportBtn.IconSize = 40;
            this.reportBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reportBtn.Location = new System.Drawing.Point(0, 260);
            this.reportBtn.Name = "reportBtn";
            this.reportBtn.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.reportBtn.Size = new System.Drawing.Size(220, 60);
            this.reportBtn.TabIndex = 3;
            this.reportBtn.Text = "Reports";
            this.reportBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reportBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.reportBtn.UseVisualStyleBackColor = true;
            this.reportBtn.Click += new System.EventHandler(this.reportBtn_Click);
            // 
            // dashboardBtn
            // 
            this.dashboardBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.dashboardBtn.FlatAppearance.BorderSize = 0;
            this.dashboardBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardBtn.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.dashboardBtn.IconChar = FontAwesome.Sharp.IconChar.ChartColumn;
            this.dashboardBtn.IconColor = System.Drawing.Color.Gainsboro;
            this.dashboardBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.dashboardBtn.IconSize = 40;
            this.dashboardBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboardBtn.Location = new System.Drawing.Point(0, 200);
            this.dashboardBtn.Name = "dashboardBtn";
            this.dashboardBtn.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.dashboardBtn.Size = new System.Drawing.Size(220, 60);
            this.dashboardBtn.TabIndex = 2;
            this.dashboardBtn.Text = "Dashboard";
            this.dashboardBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboardBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.dashboardBtn.UseVisualStyleBackColor = true;
            this.dashboardBtn.Click += new System.EventHandler(this.dashboardBtn_Click);
            // 
            // orderBtn
            // 
            this.orderBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.orderBtn.FlatAppearance.BorderSize = 0;
            this.orderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.orderBtn.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.orderBtn.IconChar = FontAwesome.Sharp.IconChar.CartShopping;
            this.orderBtn.IconColor = System.Drawing.Color.Gainsboro;
            this.orderBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.orderBtn.IconSize = 40;
            this.orderBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.orderBtn.Location = new System.Drawing.Point(0, 140);
            this.orderBtn.Name = "orderBtn";
            this.orderBtn.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.orderBtn.Size = new System.Drawing.Size(220, 60);
            this.orderBtn.TabIndex = 1;
            this.orderBtn.Text = "Orders";
            this.orderBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.orderBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.orderBtn.UseVisualStyleBackColor = true;
            this.orderBtn.Click += new System.EventHandler(this.orderBtn_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.btnLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 140);
            this.panelLogo.TabIndex = 0;
            // 
            // btnLogo
            // 
            this.btnLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogo.Image = global::CafeFlow.Properties.Resources.CafeFlow_Logo;
            this.btnLogo.Location = new System.Drawing.Point(0, 0);
            this.btnLogo.Name = "btnLogo";
            this.btnLogo.Size = new System.Drawing.Size(220, 140);
            this.btnLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnLogo.TabIndex = 0;
            this.btnLogo.TabStop = false;
            this.btnLogo.Click += new System.EventHandler(this.btnLogo_Click);
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.panelTitleBar.Controls.Add(this.minimizeBtn);
            this.panelTitleBar.Controls.Add(this.maximizeBtn);
            this.panelTitleBar.Controls.Add(this.exitBtn);
            this.panelTitleBar.Controls.Add(this.navLbl);
            this.panelTitleBar.Controls.Add(this.lblTitleChildForm);
            this.panelTitleBar.Controls.Add(this.iconCurrentChildForm);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(220, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1030, 75);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
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
            this.minimizeBtn.Location = new System.Drawing.Point(960, 8);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(15, 20);
            this.minimizeBtn.TabIndex = 5;
            this.minimizeBtn.UseVisualStyleBackColor = true;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
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
            this.maximizeBtn.Location = new System.Drawing.Point(982, 8);
            this.maximizeBtn.Name = "maximizeBtn";
            this.maximizeBtn.Size = new System.Drawing.Size(15, 20);
            this.maximizeBtn.TabIndex = 4;
            this.maximizeBtn.UseVisualStyleBackColor = true;
            this.maximizeBtn.Click += new System.EventHandler(this.maximizeBtn_Click);
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
            this.exitBtn.Location = new System.Drawing.Point(1005, 8);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(15, 20);
            this.exitBtn.TabIndex = 3;
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // navLbl
            // 
            this.navLbl.AutoSize = true;
            this.navLbl.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navLbl.ForeColor = System.Drawing.Color.Gainsboro;
            this.navLbl.Location = new System.Drawing.Point(55, 30);
            this.navLbl.Name = "navLbl";
            this.navLbl.Size = new System.Drawing.Size(17, 17);
            this.navLbl.TabIndex = 2;
            this.navLbl.Text = ">";
            // 
            // lblTitleChildForm
            // 
            this.lblTitleChildForm.AutoSize = true;
            this.lblTitleChildForm.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleChildForm.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTitleChildForm.Location = new System.Drawing.Point(76, 31);
            this.lblTitleChildForm.Name = "lblTitleChildForm";
            this.lblTitleChildForm.Size = new System.Drawing.Size(45, 17);
            this.lblTitleChildForm.TabIndex = 1;
            this.lblTitleChildForm.Text = "Home";
            // 
            // iconCurrentChildForm
            // 
            this.iconCurrentChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.iconCurrentChildForm.ForeColor = System.Drawing.SystemColors.Control;
            this.iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.House;
            this.iconCurrentChildForm.IconColor = System.Drawing.SystemColors.Control;
            this.iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCurrentChildForm.IconSize = 35;
            this.iconCurrentChildForm.Location = new System.Drawing.Point(6, 23);
            this.iconCurrentChildForm.Name = "iconCurrentChildForm";
            this.iconCurrentChildForm.Size = new System.Drawing.Size(43, 35);
            this.iconCurrentChildForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconCurrentChildForm.TabIndex = 0;
            this.iconCurrentChildForm.TabStop = false;
            // 
            // panelShadow
            // 
            this.panelShadow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(58)))));
            this.panelShadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelShadow.Location = new System.Drawing.Point(220, 75);
            this.panelShadow.Name = "panelShadow";
            this.panelShadow.Size = new System.Drawing.Size(1030, 9);
            this.panelShadow.TabIndex = 2;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panelDesktop.Controls.Add(this.pictureBox1);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(220, 84);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1030, 666);
            this.panelDesktop.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::CafeFlow.Properties.Resources.CafeFlow_Logo;
            this.pictureBox1.Location = new System.Drawing.Point(198, 120);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(615, 399);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // stokanalizBtn
            // 
            this.stokanalizBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.stokanalizBtn.FlatAppearance.BorderSize = 0;
            this.stokanalizBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stokanalizBtn.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stokanalizBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.stokanalizBtn.IconChar = FontAwesome.Sharp.IconChar.ChartSimple;
            this.stokanalizBtn.IconColor = System.Drawing.Color.Gainsboro;
            this.stokanalizBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.stokanalizBtn.IconSize = 40;
            this.stokanalizBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.stokanalizBtn.Location = new System.Drawing.Point(0, 500);
            this.stokanalizBtn.Name = "stokanalizBtn";
            this.stokanalizBtn.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.stokanalizBtn.Size = new System.Drawing.Size(220, 60);
            this.stokanalizBtn.TabIndex = 7;
            this.stokanalizBtn.Text = "Stok Analiz";
            this.stokanalizBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.stokanalizBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.stokanalizBtn.UseVisualStyleBackColor = true;
            this.stokanalizBtn.Click += new System.EventHandler(this.ıconButton1_Click);
            // 
            // Home
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1250, 750);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelShadow);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnLogo)).EndInit();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).EndInit();
            this.panelDesktop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private FontAwesome.Sharp.IconButton orderBtn;
        private FontAwesome.Sharp.IconButton beeperBtn;
        private FontAwesome.Sharp.IconButton ıconButton5;
        private FontAwesome.Sharp.IconButton menuBtn;
        private FontAwesome.Sharp.IconButton reportBtn;
        private FontAwesome.Sharp.IconButton dashboardBtn;
        private System.Windows.Forms.PictureBox btnLogo;
        private System.Windows.Forms.Panel panelTitleBar;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private System.Windows.Forms.Label lblTitleChildForm;
        private System.Windows.Forms.Panel panelShadow;
        private System.Windows.Forms.Label navLbl;
        private FontAwesome.Sharp.IconButton exitBtn;
        private FontAwesome.Sharp.IconButton minimizeBtn;
        private FontAwesome.Sharp.IconButton maximizeBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelDesktop;
        private FontAwesome.Sharp.IconButton stokanalizBtn;
    }
}