using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NuevosComponentes;

namespace Bol7_Ejer1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ClickChangePosition(object sender, EventArgs e)
        {
            labelTextBox1.Position = labelTextBox1.Position == Posicion.LEFT ? Posicion.RIGHT : Posicion.LEFT;
        }

        private void ClickAddSeparation(object sender, EventArgs e)
        {
            labelTextBox1.Separacion++;
        }

        private void CambiaPosicionChangeTitle(object sender, EventArgs e)
        {
            this.Text = labelTextBox1.Position.ToString();
        }

        private void CambiaSeparacionShowSeparation(object sender, EventArgs e)
        {
            labelTextBox1.TxtLbl = labelTextBox1.Separacion.ToString();
        }

        private void KeyUpChangeTitle(object sender, KeyEventArgs e)
        {
            //this.Text = e.KeyData.ToString();
        }

        private void TextChangeChangeTitle(object sender, EventArgs e)
        {
            this.Text = labelTextBox1.TextTxt;
        }
    }
}
