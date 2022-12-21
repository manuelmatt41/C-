using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary1
{
    [DefaultProperty("Mark")]
    [DefaultEvent("ClickEnMarca")]
    public partial class AlertLabel : Control
    {
        public event MouseEventHandler ClickInMark;

        private Mark _mark = Mark.NOTHING;
        [Category("Design")]
        [Description("A component wih text and an image with differnts options")]
        public Mark Mark
        {
            get => _mark;
            set
            {
                _mark = value;
                Refresh();
            }
        }

        private Rectangle _markHitBox;

        private bool _backGradient = false;
        [Category("Design")]
        [Description("if it is true it activates the background gradient otherwise it deactivates it")]
        public bool BackGradient
        {
            get => _backGradient;
            set
            {
                _backGradient = value;
                Refresh();
            }
        }

        private Color _firstGradientColor = Color.Blue;
        [Category("Design")]
        [Description("Set the first color of the gradient")]
        public Color FirstGradientColor
        {
            get => _firstGradientColor;
            set
            {
                _firstGradientColor = value;
                Refresh();
            }
        }

        private Color _secondGradientColor = Color.Red;
        [Category("Design")]
        [Description("Set the second color of the gradient")]
        public Color SecondGradientColor
        {
            get => _secondGradientColor;
            set
            {
                _secondGradientColor = value;
                Refresh();
            }
        }

        private Image _markImage;
        public Image MarkImage
        {
            get => _markImage;
            set
            {
                _markImage = value;
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
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Size stringSize = graphics.MeasureString(this.Text, this.Font).ToSize();
            int grosor = 0;
            int offsetX = 0;
            int offsetY = 0;

            switch (Mark)
            {
                case Mark.MARK:
                    grosor = 3;
                    offsetX = stringSize.Height + grosor;
                    offsetY = grosor / 2;
                    break;
                case Mark.CIRCLE:
                    grosor = 15;
                    offsetX = stringSize.Height + grosor;
                    offsetY = grosor;
                    break;
                case Mark.IMAGE:
                    if (MarkImage != null)
                    {
                        grosor = stringSize.Height;
                        offsetX = grosor / 2;
                        offsetY = grosor / 2;
                    }
                    break;
            }

            this.Size = new Size(stringSize.Width + offsetX + grosor, stringSize.Height + offsetY * 2);

            if (BackGradient)
            {
                Point initialPoint = new Point(0, 0);
                Point finalPoint = new Point(this.Size.Width, 0);
                LinearGradientBrush linearGradientBrush = new LinearGradientBrush(initialPoint, finalPoint, FirstGradientColor, SecondGradientColor);
                Pen penGradient = new Pen(linearGradientBrush, this.Size.Height * 2);
                graphics.DrawLine(penGradient, initialPoint, finalPoint);

                penGradient.Dispose();
                linearGradientBrush.Dispose();
            }

            switch (Mark)
            {
                case Mark.MARK:
                    Pen penMark = new Pen(Color.Red, grosor);
                    graphics.DrawLine(penMark, grosor, grosor, stringSize.Height, stringSize.Height);
                    graphics.DrawLine(penMark, stringSize.Height, grosor, grosor, stringSize.Height);
                    penMark.Dispose();
                    break;
                case Mark.CIRCLE:
                    Pen penCircle = new Pen(Color.Green, grosor);
                    _markHitBox = new Rectangle(grosor, grosor, stringSize.Height, stringSize.Height);
                    graphics.DrawEllipse(penCircle, _markHitBox);
                    penCircle.Dispose();
                    break;
                case Mark.IMAGE:
                    if (MarkImage != null)
                    {
                        _markHitBox = new Rectangle(new Point(offsetX, offsetY), new Size(stringSize.Height, stringSize.Height));
                        graphics.DrawImage(MarkImage, _markHitBox);
                    }
                    break;
            }

            SolidBrush solidBrush = new SolidBrush(this.ForeColor);
            graphics.DrawString(this.Text, this.Font, solidBrush, offsetX + grosor, offsetY);
            solidBrush.Dispose();

        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Refresh();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e == null) return;

            if (Mark == Mark.NOTHING) return;

            if (IsClickOnMark(e.Location))
            {
                base.OnMouseClick(e);
                ClickInMark?.Invoke(this, e);
            }
        }

        private bool IsClickOnMark(Point p)
        {
            return p.X >= _markHitBox.X && p.X <= _markHitBox.X + _markHitBox.Width && p.Y >= _markHitBox.Y && p.Y <= _markHitBox.Y + _markHitBox.Height;
        }
    }

    public enum Mark
    {
        NOTHING, MARK, CIRCLE, IMAGE
    }
}
