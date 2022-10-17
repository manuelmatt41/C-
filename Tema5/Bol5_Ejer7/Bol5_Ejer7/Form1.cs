namespace Bol5_Ejer7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Size = this.Size;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            textBox1.Size = this.Size;
        }
    }
}