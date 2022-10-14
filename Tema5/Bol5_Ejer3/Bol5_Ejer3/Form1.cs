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
    }
}