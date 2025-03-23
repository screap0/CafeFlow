using Mysqlx;
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
        }

        private void ıconButton1_Click(object sender, EventArgs e)
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
                MessageBox.Show("Kullancı Bilgileri Hatalı");
            }
        }

        private void lnk_kayitol_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Register register=new Register();
            this.Hide();
            register.Show();

        }

     
    }
}
