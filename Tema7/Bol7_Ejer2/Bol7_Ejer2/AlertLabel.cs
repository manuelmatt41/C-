using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bol7_Ejer2
{
    public partial class AlertLabel : UserControl
    {
        private Mark _mark = Mark.NOTHING;
        public Mark Mark
        {
            get => _mark;
            set
            {
                _mark = value;
                Refresh();
            }
        }
        public AlertLabel()
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

            switch (Mark)
            {
                case Mark.MARK:
                    grosor = 3;
                    Pen pen = new Pen(Color.Red, grosor);
                    g.DrawLine(pen, grosor, grosor, h, h);
                    g.DrawLine(pen, h, grosor, grosor, h);
                    offsetX = h + grosor;
                    offsetY = 0;
                    pen.Dispose();
                    break;
                case Mark.CIRCLE:
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

    public enum Mark
    {
        NOTHING, MARK, CIRCLE
    }
}
