#define FLAG
using System.Diagnostics;
using System.Windows.Forms;

namespace Bol5_Ejer1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            if (sender is Button)
            {
                x += ((Button)sender).Location.X;
                y += ((Button)sender).Location.Y;
            }
            string coordinates = $"X:{x} Y:{y}";
            this.Text = coordinates;
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            this.Text = "Mouse Tester";

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                button1.BackColor = Color.Red;
            }
            if (e.Button == MouseButtons.Right)
            {
                button2.BackColor = Color.Blue;
            }
            if (e.Button == MouseButtons.Middle)
            {
                button1.BackColor = Color.Red;
                button2.BackColor = Color.Blue;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                button1.BackColor = Color.FromArgb(-986896);  //0xFF0D34
            }
            if (e.Button == MouseButtons.Right)
            {
                button2.BackColor = Color.FromArgb(-986896);
            }
            if (e.Button == MouseButtons.Middle)
            {
                button1.BackColor = Color.FromArgb(-986896);
                button2.BackColor = Color.FromArgb(-986896);
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
#if FLAG
            if (e.KeyCode != Keys.Escape)
            {
                this.Text = e.KeyCode.ToString();
            }
            else
            {
                this.Text = "Mouse Tester";
            }
#endif
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
#if !FLAG
            this.Text = e.KeyChar.ToString();
#endif
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are yo sure to close the app?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                this.Dispose();
            }
            e.Cancel = true;
        }
    }
}