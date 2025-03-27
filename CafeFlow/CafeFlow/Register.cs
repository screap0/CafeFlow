using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeFlow
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        DatabaseConnection databaseConnection = new DatabaseConnection();


        private void btn_kayitol_Click(object sender, EventArgs e)
        {
            string ad, soyad, kullaniciadi, sifre,tekrar_sifre;
            ad=txt_ad.Text;
            soyad=txt_soyad.Text;
            kullaniciadi=txt_kullaniciadi.Text;
            sifre=txt_sifre.Text;
            tekrar_sifre=txt_sifretekrar.Text;

            if (string.IsNullOrWhiteSpace(ad) || string.IsNullOrWhiteSpace(soyad) || string.IsNullOrWhiteSpace(kullaniciadi) || string.IsNullOrWhiteSpace(sifre) || string.IsNullOrWhiteSpace(tekrar_sifre))
            {
                lbl_bosbirakilamaz.Text = "Lütfen tüm alanları doldurun!";
            }
            else if (sifre!=tekrar_sifre)
            {
                lbl_sifrehata.Text = "Şifreler aynı değil!";

            }
            else
            {
                databaseConnection.KullaniciKayit(ad, soyad, kullaniciadi, sifre);
                Login login = new Login();
                login.Show();
                this.Close();
            }
           
            

            




        }

        private void txt_sifretekrar_Click(object sender, EventArgs e)
        {
            lbl_sifrehata.Text = "";
            lbl_bosbirakilamaz.Text = "";

        }

        private void txt_sifre_Click(object sender, EventArgs e)
        {
            lbl_sifrehata.Text = "";
            lbl_bosbirakilamaz.Text = "";

        }

        private void txt_ad_Click(object sender, EventArgs e)
        {
            lbl_bosbirakilamaz.Text = "";

        }

        private void txt_soyad_Click(object sender, EventArgs e)
        {
            lbl_bosbirakilamaz.Text = "";

        }

        private void txt_kullaniciadi_Click(object sender, EventArgs e)
        {
            lbl_bosbirakilamaz.Text = "";

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
