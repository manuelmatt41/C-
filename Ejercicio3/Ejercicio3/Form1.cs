//#define RESTA
namespace Ejercicio3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "";

            if (Convert.ToInt16(label1.Text) > 1)
            {
                label1.Text = (Convert.ToInt16(label1.Text) - 2).ToString();

                textBox1.Text = new Random().Next(1, 8).ToString();
                textBox2.Text = new Random().Next(1, 8).ToString();
                textBox3.Text = new Random().Next(1, 8).ToString();

                if (textBox1.Text == textBox2.Text && textBox1.Text == textBox3.Text
                    && textBox2.Text == textBox3.Text)
                {
                    label1.Text = (Convert.ToInt16(label1.Text) + 20).ToString();
                    label2.Text = "Primer premio!!!";
                }
                else
                {
                    if (textBox1.Text == textBox2.Text || textBox1.Text == textBox3.Text
                        || textBox2.Text == textBox3.Text)
                    {
#if RESTA
                        label1.Text = (Convert.ToInt16(label1.Text) - 5).ToString();
#else
                        label1.Text = (Convert.ToInt16(label1.Text) + 5).ToString();
#endif
                        label2.Text = "Segundo premio!!!";
                    }
                }
            }
            else
            {
                button1.Enabled = false;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = (Convert.ToInt16(label1.Text) + 10).ToString();
            button1.Enabled = true;

        }
    }
}