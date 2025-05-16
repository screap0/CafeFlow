using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition.Primitives;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
namespace CafeFlow
{
    public partial class ArduinoController : Form
    {
        private string ipAddress;
        private int port ;
        string kullaniciadi;
        string txtform;
       DatabaseConnection sql=new DatabaseConnection();

        public ArduinoController(string kullaniciadi)
        {
            InitializeComponent();
            txtIPAddress.Text = "192.168.202.231"; 
            txtPort.Text = port.ToString();
            kullaniciadi = this.kullaniciadi;
            txtform = "ArduinoController";


            btnStartCallSystem.Click += new EventHandler(btnStartCallSystem_Click);
            btnStopCallSystem.Click += new EventHandler(btnStopCallSystem_Click);
            btnConnect.Click += new EventHandler(btnConnect_Click);
            btnTestConnection.Click += new EventHandler(btnTestConnection_Click);
            btnClearLog.Click += new EventHandler(btnClearLog_Click);

            this.Load += new EventHandler(ArdunioController_Load);
        }

        private void ArdunioController_Load(object sender, EventArgs e)
        {
            MakeLedStatusCircular();
        }

        public void MasaNo(int MasaNo)
        {
            if (MasaNo == 1)
            {
            port = 12345;
            txtPort.Text = port.ToString();
                SendTcpCommand("ON");
               
            }
            
            
        }

        private void SendTcpCommand(string command)
        {
            
            ipAddress = txtIPAddress.Text.Trim();
            port = int.Parse(txtPort.Text);

            try
            {
                AddToLog($"Komut gönderiliyor: {command} --> {ipAddress}:{port}");

                using (TcpClient client = new TcpClient(ipAddress, port))
                using (NetworkStream stream = client.GetStream())
                using (StreamReader reader = new StreamReader(stream))
                using (StreamWriter writer = new StreamWriter(stream) { AutoFlush = true })
                {
                    writer.WriteLine(command);
                    string response = reader.ReadLine();

                    AddToLog($"ESP Cevabı: {response}");
                    toolStripStatusLabel.Text = $"Komut başarıyla gönderildi: {command}, Cevap: {response}";
                    sql.Log(txtform,"Esp Komutu Başarıyla Gönderildi", DateTime.Now, kullaniciadi);


                    UpdateConnectionStatus(true);
                }
            }
            catch (Exception ex)
            {
                string errorMessage = $"Hata: {ex.Message}";
                AddToLog(errorMessage);
                toolStripStatusLabel.Text = "Bağlantı hatası!";
                MessageBox.Show(errorMessage, "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sql.Log(txtform, "Esp Bağlantı Hatası: "+errorMessage, DateTime.Now, kullaniciadi);

                UpdateConnectionStatus(false);
            }
        }

        private void UpdateConnectionStatus(bool isConnected)
        {
            
            ledStatus.BackColor = isConnected ? System.Drawing.Color.LimeGreen : System.Drawing.Color.Red;
            if (isConnected)
            {
                lblStatus.Text = "Arduino Kontrolcü Paneli - Bağlı";
            }
            else
            {
                lblStatus.Text = "Arduino Kontrolcü Paneli - Bağlantı Yok";
            }
        }

        private void AddToLog(string message)
        {
           
            logTextBox.AppendText($"[{DateTime.Now.ToString("HH:mm:ss")}] {message}{Environment.NewLine}");

            
            logTextBox.SelectionStart = logTextBox.Text.Length;
            logTextBox.ScrollToCaret();
        }

        private void btnStartCallSystem_Click(object sender, EventArgs e)
        {
            SendTcpCommand("ON");
        }

        private void btnStopCallSystem_Click(object sender, EventArgs e)
        {
            SendTcpCommand("OFF");
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                ipAddress = txtIPAddress.Text.Trim();
                port = int.Parse(txtPort.Text);

                AddToLog($"Bağlantı kuruluyor: {ipAddress}:{port}");

                using (TcpClient client = new TcpClient())
                {
                    client.Connect(ipAddress, port);
                    if (client.Connected)
                    {
                        UpdateConnectionStatus(true);
                        AddToLog("Bağlantı başarılı!");
                        toolStripStatusLabel.Text = "Arduino'ya bağlantı kuruldu";
                        MessageBox.Show("Arduino'ya başarıyla bağlandı!", "Bağlantı Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sql.Log(txtform, "Arduino'ya başarıyla bağlandı!", DateTime.Now, kullaniciadi);
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateConnectionStatus(false);
                string errorMessage = $"Bağlantı hatası: {ex.Message}";
                AddToLog(errorMessage);
                toolStripStatusLabel.Text = "Bağlantı başarısız!";
                MessageBox.Show(errorMessage, "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sql.Log(txtform, " Bağlantı Hatası: " + errorMessage, DateTime.Now, kullaniciadi);

            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            btnConnect_Click(sender, e);
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            logTextBox.Clear();
            AddToLog("Log temizlendi");
        }

        private void MakeLedStatusCircular()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, ledStatus.Width, ledStatus.Height);
            ledStatus.Region = new Region(path);
        }

    }
}




