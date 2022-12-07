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
                if (!Enum.IsDefined(typeof(Posicion), value))
                {
                    throw new InvalidEnumArgumentException();
                }
                _position = value;
                Reposition();
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
        public string TextTxt { get => txt.Text; set => txt.Text = value; }
        public LabelTextBox()
        {
            InitializeComponent();
        }

        private void Reposition() 
        { 
            switch(_position)
            {
                case Posicion.LEFT:

                    break;
            }
        }
    }
    public enum Posicion
    {
        LEFT, RIGHT
    }

}
