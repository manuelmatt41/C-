namespace Ejercicio5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult a = MessageBox.Show(string.Format("¿Quieres poner \"{0}\" como título?", textBox1.Text), "Cambiar titulo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (a == DialogResult.Yes)
            {
                this.Text = textBox1.Text;
            }
        }
    }
}