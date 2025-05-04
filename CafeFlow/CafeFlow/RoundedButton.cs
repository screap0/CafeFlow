using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FontAwesome.Sharp;

public class RoundedButton : IconButton
{
    private int borderRadius = 20; // Köşe yuvarlaklık derecesi
    private Color borderColor = Color.MediumSeaGreen; // Kenarlık rengi
    private float borderThickness = 2f; // Kenarlık kalınlığı
    private Color hoverBackColor; // Hover için geçici arka plan rengi

    public RoundedButton()
    {
        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderSize = 0; // Varsayılan kenarlığı kaldır
        this.BackColor = Color.MediumSeaGreen; // Arka plan rengi
        this.ForeColor = Color.White; // Yazı rengi
        this.Size = new Size(120, 40); // Hap şekli için uygun boyut
        this.hoverBackColor = ControlPaint.Light(this.BackColor); // Hover rengini belirle
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        this.BackColor = this.hoverBackColor; // Hover sırasında arka plan rengini değiştir
        this.Invalidate(); // Butonu yeniden çiz
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        this.BackColor = Color.MediumSeaGreen; // Hoverdan çıkınca orijinal renge dön
        this.Invalidate(); // Butonu yeniden çiz
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        GraphicsPath graphicsPath = new GraphicsPath();
        Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
        int diameter = borderRadius * 2; // Yuvarlaklık çapı
        graphicsPath.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90); // Sol üst köşe
        graphicsPath.AddArc(rect.Width - diameter, rect.Y, diameter, diameter, 270, 90); // Sağ üst köşe
        graphicsPath.AddArc(rect.Width - diameter, rect.Height - diameter, diameter, diameter, 0, 90); // Sağ alt köşe
        graphicsPath.AddArc(rect.X, rect.Height - diameter, diameter, diameter, 90, 90); // Sol alt köşe
        graphicsPath.CloseFigure();

        this.Region = new Region(graphicsPath);

        // Arka planı çiz
        using (SolidBrush brush = new SolidBrush(this.BackColor))
        {
            e.Graphics.FillPath(brush, graphicsPath);
        }

        // Kenarlığı çiz
        using (Pen pen = new Pen(borderColor, borderThickness))
        {
            e.Graphics.DrawPath(pen, graphicsPath);
        }

        // Metni çiz
        using (StringFormat stringFormat = new StringFormat())
        {
            stringFormat.Alignment = StringAlignment.Center; // Yatayda ortala
            stringFormat.LineAlignment = StringAlignment.Center; // Dikeyde ortala
            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), rect, stringFormat);
        }
    }
}