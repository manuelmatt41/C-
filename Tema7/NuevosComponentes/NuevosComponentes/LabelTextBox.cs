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

namespace NuevosComponentes
{
    public partial class LabelTextBox : UserControl
    {
        private Posicion _position = Posicion.LEFT;
        [Category("Appearance")]
        [Description("Indica si la label se coloca a la IZQUIERDA o DERECHA del TextBox")]
        public Posicion Position
        {
            get => _position;
            set
            {
                if (!Enum.IsDefined(typeof(Posicion), value)) throw new InvalidEnumArgumentException();
                _position = value;
                CambiaPosicion?.Invoke(this, EventArgs.Empty);
                Refresh();
            }
        }
        private int _separation = 0;
        [Category("Design")]
        [Description("Pixels de separacion entre el Label y el TextBox")]
        public int Separacion
        {
            get => _separation;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException();
                _separation = value;
                CambiaSeparacion?.Invoke(this, EventArgs.Empty);
                Refresh();
            }
        }
        [Category("Appearance")]
        [Description("Texto asociado al Label del control")]
        public string TxtLbl
        {
            get => lbl.Text;
            set
            {
                lbl.Text = value;
            }
        }
        [Category("Appearance")]
        [Description("Texto asociado al Texbox del control")]
        public string TextTxt
        {
            get => txt.Text;
            set
            {
                txt.Text = value;
            }
        }
        [Category("Appearance")]
        [Description("Caracter usado para ocultar el texto")]
        public char PswChr
        {
            get => txt.PasswordChar;
            set => txt.PasswordChar = value;

        }
        [Category("La propiedad cambió")]
        [Description("Se lanza cuando la propiedad Posicion cambia")]
        public event EventHandler CambiaPosicion;
        [Category("La propiedad cambió")]
        [Description("Se lanza cuando se cambia la separacion")]
        public event EventHandler CambiaSeparacion;
        [Category("La propiedad cambió")]
        [Description("Se lanza cuando se escribe en el textbox del componente")]
        public event EventHandler TxtChanged;
        public LabelTextBox()
        {
            InitializeComponent();
            TxtLbl = this.Name;
            TextTxt = "";
            txt.KeyUp += new KeyEventHandler(Txt_KeyUp);
            txt.TextChanged += new EventHandler((sender, e) => TxtChanged?.Invoke(this, EventArgs.Empty));
        }

        private void Reposition()
        {
            switch (_position)
            {
                case Posicion.LEFT:
                    lbl.Location = new Point(0, 0);
                    txt.Location = new Point(lbl.Width + Separacion, 0);
                    break;
                case Posicion.RIGHT:
                    txt.Location = new Point(0, 0);
                    lbl.Location = new Point(txt.Width + Separacion, 0);
                    break;
            }
            this.Width = lbl.Width + Separacion + txt.Width;
            this.Height = Math.Max(txt.Height, lbl.Height);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }

        private void Txt_KeyUp(object sender, KeyEventArgs e)
        {
            this.OnKeyUp(e);
        }


        private void labelTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.Text = "Letra: " + e.KeyChar;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Reposition();
            e.Graphics.DrawLine(new Pen(Color.BlueViolet), lbl.Left, this.Height - 1, lbl.Left + lbl.Width, this.Height - 1);
        }

    }
    public enum Posicion
    {
        LEFT, RIGHT
    }

}
