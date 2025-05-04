using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CafeFlow
{
    public partial class Login : Form
    {
        public Login()
        {

            InitializeComponent();

            btn_girisyap.Text = "Giriş Yap";
            btn_girisyap.BackColor = Color.MediumSeaGreen;
            btn_girisyap.ForeColor = Color.White;
        }

        private void btn_girisyap_Click(object sender, EventArgs e)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            bool gecerli = dbConnection.KullaniciBilgileriniKontrolEt(txt_kullaniciadi.Text, txt_sifre.Text);
            if (gecerli)
            {
                Home home= new Home();
                this.Hide();
                home.Show();
            }
            else
            {
                lbl_hata.Text = "Kullancı Bilgileri Hatalı!";
            }
        }

        private void lnk_kayitol_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Register register=new Register();
            this.Hide();
            register.Show();

        }

        private void txt_kullaniciadi_Click(object sender, EventArgs e)
        {
            lbl_hata.Text = "";
        }

        private void txt_sifre_Click(object sender, EventArgs e)
        {
            lbl_hata.Text = "";

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void maximizeBtn_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
