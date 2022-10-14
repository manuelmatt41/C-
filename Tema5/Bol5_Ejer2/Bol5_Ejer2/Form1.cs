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
            int red;
            int green;
            int blue;
            if (!int.TryParse(textBox1.Text, out red))
            {
                MessageBox.Show("Only numbers are allowed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                textBox1.SelectAll();
                return;
            }
            if (!int.TryParse(textBox2.Text, out green))
            {
                MessageBox.Show("Only numbers are allowed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                textBox2.SelectAll();
                return;
            }
            if (!int.TryParse(textBox3.Text, out blue))
            {
                MessageBox.Show("Only numbers are allowed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                textBox3.SelectAll();
                return;
            }
            if (red < 0 || red > 255)
            {
                MessageBox.Show("Only number between 0 and 255", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                textBox1.SelectAll();
                return;
            }
            if (green < 0 || green > 255)
            {
                MessageBox.Show("Only number between 0 and 255", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                textBox2.SelectAll();
                return;
            }
            if (blue < 0 || blue > 255)
            {
                MessageBox.Show("Only number between 0 and 255", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                textBox3.SelectAll();
                return;
            }
            label1.Image = null;
            label1.BackColor = Color.FromArgb(red, green, blue);
            label1.Update();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Focused || textBox2.Focused || textBox3.Focused)
                {
                    button2.PerformClick();
                }
                if (textBox4.Focused)
                {
                    button3.PerformClick();
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                button1.PerformClick();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = textBox4.Text.Trim();
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
                this.Close();
            }
        }
    }
}