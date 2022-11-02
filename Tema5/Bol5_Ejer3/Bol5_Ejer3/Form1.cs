using System.ComponentModel;

namespace Bol5_Ejer3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            if (checkBox1.Checked)
            {
                f.ShowDialog();
            }
            else
            {
                f.Show();
            }
        }

        private void ChangeColor(object sender, EventArgs e)
        {
            checkBox1.ForeColor = checkBox1.Checked ? Color.Red : Color.Black;
        }

        private void Closing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to close the program?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}