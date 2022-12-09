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
                Reposition();
                CambiaPosicion?.Invoke(this, EventArgs.Empty);

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
                Reposition();
                CambiaSeparacion?.Invoke(this, EventArgs.Empty);
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
                Reposition();
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
                TxtChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        [Category("La propiedad cambio")]
        [Description("Se lanza cuando la propiedad Posicion cambia")]
        public event EventHandler CambiaPosicion;
        public event EventHandler CambiaSeparacion;
        public event EventHandler TxtChanged;
        public LabelTextBox()
        {
            InitializeComponent();
            TxtLbl = this.Name;
            TextTxt = "";
            Reposition();
            txt.KeyUp += new KeyEventHandler(Txt_KeyUp);
        }

        private void Reposition()
        {
            switch (_position)
            {
                case Posicion.LEFT:
                    lbl.Location = new Point(0, 0);
                    txt.Location = new Point(lbl.Width + Separacion, 0);
                    txt.Width = this.Width - lbl.Width - Separacion;
                    break;
                case Posicion.RIGHT:
                    txt.Location = new Point(0, 0);
                    txt.Width = this.Width - lbl.Width - Separacion;
                    lbl.Location = new Point(txt.Width + Separacion, 0);
                    break;
            }
            this.Height = Math.Max(txt.Height, lbl.Height);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Reposition();
        }

        private void Txt_KeyUp(object sender, KeyEventArgs e)
        {
            this.OnKeyUp(e);
        }


        private void labelTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.Text = "Letra: " + e.KeyChar;
        }

    }
    public enum Posicion
    {
        LEFT, RIGHT
    }

}
