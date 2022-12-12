using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NuevosComponentes
{
    public partial class EtiquetaAviso : Control
    {
        private Marca _marca = Marca.NOTHING;
        public Marca Marca
        {
            get => _marca;
            set
            {
                _marca = value;
                Refresh();
            }
        }
        public EtiquetaAviso()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            int grosor = 0;
            int offsetX = 0;
            int offsetY = 0;
            int h = this.Font.Height;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            switch (Marca)
            {
                case Marca.MARK:
                    grosor = 3;
                    Pen pen = new Pen(Color.Red, grosor);
                    g.DrawLine(pen, grosor, grosor,h, h);
                    g.DrawLine(pen, h, grosor, grosor, h);
                    offsetX = h + grosor;
                    offsetY = 0;
                    pen.Dispose();
                    break;
                case Marca.CIRCLE:
                    grosor = 3;
                    g.DrawEllipse(new Pen(Color.Green, grosor), grosor, grosor, h, h);
                    offsetX = h + grosor;
                    offsetY = 0;
                    break;
            }
            Font font = new Font(this.Font.FontFamily, 12);
            SolidBrush solidBrush = new SolidBrush(this.ForeColor);
            g.DrawString(this.Text, font, solidBrush, offsetX + grosor, offsetY);
            Size s = g.MeasureString(this.Text, font).ToSize();
            this.Size = new Size(s.Width + offsetX + grosor, s.Height + offsetY * 2);
            solidBrush.Dispose();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Refresh();
        }
    }

    public enum Marca
    {
        NOTHING,MARK,CIRCLE
    }
}
