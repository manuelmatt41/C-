using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bol7_Ejer4
{
    public partial class DibujoAhorcado : UserControl
    {
        private readonly int MIN_ERRORS = 0;
        private readonly int MAX_ERRORS = 7;

        private int error;
        public int Error
        {
            get => error;

            set
            {
                if (value < 0 || value > MAX_ERRORS)
                {
                    throw new ArgumentException($"Number of errors: '{value}' < 0 or '{value}'>= {MAX_ERRORS}");
                }

                error = value;
                Refresh();
                if (error < MAX_ERRORS)
                {
                    OnErrorChanged(this, EventArgs.Empty);
                }
                else
                {
                    OnHanged(this, EventArgs.Empty);
                }
            }
        }

        public event EventHandler ErrorChanged;
        public event EventHandler Hanged;

        public DibujoAhorcado()
        {
            InitializeComponent();

            Error = MIN_ERRORS;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            float penSize = 3f;
            Pen pen = new Pen(Color.Black, penSize);

            float x1 = (100f + penSize + (40f / 2));
            float y1 = 0f;
            float x2 = 0f;
            float y2 = 0f;

            int width = (int)(250f + penSize);
            this.Size = new Size(width, width);

            for (int i = (int)HangedPart.BUILD; i <= Error; i++) //TODO mejorar legibilidad
            {
                switch ((HangedPart)i)
                {
                    case HangedPart.BUILD:
                        x1 = 1f;
                        y1 = 200f;

                        g.DrawRectangle(pen, x1, y1, 250f, 50f);

                        x2 = x1;
                        y2 = y1 - 240f;
                        g.DrawLine(pen, x1, y1, x2, y2);

                        x1 = 1f;
                        y1 = 1f;
                        x2 = x1 + 125f;
                        y2 = 1f;
                        g.DrawLine(pen, x1, y1, x2, y2);

                        x1 = x2;
                        x2 = x1;
                        y2 = y1 + 30f;
                        g.DrawLine(pen, x1, y1, x2, y2);

                        break;
                    case HangedPart.HEAD:
                        float headSize = 40f;

                        g.DrawEllipse(pen, 100f + 5f, 30f, headSize, headSize);

                        break;
                    case HangedPart.BODY:
                        y1 = 30f + 40f;
                        x2 = x1;
                        y2 = (40f + penSize) * 3f;

                        g.DrawLine(pen, x1, y1, x2, y2);

                        break;
                    case HangedPart.LEFT_ARM:
                        y1 = 40f + penSize + 30f;
                        x2 = x1 - 60f;
                        y2 = y1 + 40f;

                        g.DrawLine(pen, x1, y1, x2, y2);

                        break;
                    case HangedPart.RIGHT_ARM:
                        y1 = 40f + penSize + 30f;
                        x2 = x1 + 60f;
                        y2 = y1 + 40f;

                        g.DrawLine(pen, x1, y1, x2, y2);

                        break;
                    case HangedPart.LEFT_LEG:
                        y1 = (40f + penSize) * 3f;
                        x2 = x1 - 60f;
                        y2 = y1 + 40f;

                        g.DrawLine(pen, x1, y1, x2, y2);

                        break;
                    case HangedPart.RIGHT_LEG:
                        y1 = (40f + penSize) * 3f;
                        x2 = x1 + 60f;
                        y2 = y1 + 40f;

                        g.DrawLine(pen, x1, y1, x2, y2);

                        break;
                }
            }

            pen.Dispose();
        }

        protected void OnErrorChanged(object sender, EventArgs e)
        {
            ErrorChanged?.Invoke(sender, e);
            Refresh();
        }

        protected void OnHanged(object sender, EventArgs e)
        {
            Hanged?.Invoke(sender, e);
            Refresh();
        }
    }

    public enum HangedPart
    {
        BUILD = 1, HEAD, BODY, LEFT_ARM, RIGHT_ARM, LEFT_LEG, RIGHT_LEG
    }
}