namespace Bol5_Ejer6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int x = 12;
        int y = 41;
        private void Form1_Load(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
            for (int i = 0; i < buttons.Length; i++)
            {
                Button b = new Button();
                b.Text = buttons[i];
                b.Location = new Point(x, y);
                if ((i + 1) % 3 == 0)
                {
                    y += 29;
                    x = 12;
                }
                else
                {
                    x += 81;
                }
                b.Size = new Size(75, 23);
                b.Visible = true;
                b.Click += new EventHandler(Click);
                b.MouseEnter += new EventHandler(MouseEnter);
                b.MouseLeave += new EventHandler(MouseLeave);
                this.Controls.Add(b);
            }
        }

        private void Click(object sender, EventArgs e)
        {
            textBox1.Text += ((Button)sender).Text;
            ((Button)sender).BackColor = Color.Red;
        }

        private void MouseEnter(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor != Color.Red)
            {
                ((Button)sender).BackColor = Color.Gray;
            }
        }
        private void MouseLeave(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor != Color.Red)
            {
                ((Button)sender).BackColor = Color.FromArgb(-986896);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        string[] buttons = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "*", "0", "#" };
    }
}