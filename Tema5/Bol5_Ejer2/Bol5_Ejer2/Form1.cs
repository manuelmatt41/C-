namespace Bol5_Ejer2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte red;
            byte green;
            byte blue;
            if (!byte.TryParse(textBox1.Text, out red))
            {
                MessageBox.Show("Only numbers are allowed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                textBox1.SelectAll();
                return;
            }
            if (!byte.TryParse(textBox2.Text, out green))
            {
                MessageBox.Show("Only numbers are allowed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                textBox2.SelectAll();
                return;
            }
            if (!byte.TryParse(textBox3.Text, out blue))
            {
                MessageBox.Show("Only numbers are allowed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                textBox3.SelectAll();
                return;
            }
            label1.Image = null;
            label1.BackColor = Color.FromArgb(red, green, blue);
            label1.Update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = textBox4.Text.Trim();
            if (path == "")
            {
                MessageBox.Show("Nothing has been written", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                label1.Image = Image.FromFile(path);
            }
            catch (IOException)
            {
                MessageBox.Show("The file not found", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want close the form?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void Enter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Blue;
        }

        private void Exit(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Button.DefaultBackColor;
        }

        private void ChangeAcceptButton(object sender, EventArgs e)
        {
            if (sender == textBox4)
            {
                this.AcceptButton = button3;
            }
            else
            {
                this.AcceptButton = button2;
            }
        }
    }
}