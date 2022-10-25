namespace Bol5_Ejer7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Size = GetFormWhiteSpace();
        }

        public Size GetFormWhiteSpace()
        {
            return new Size(this.Width, this.Height - menuStrip1.Height - toolStrip1.Height);
        }

        private void SaveDocument(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("The file was not found", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (DirectoryNotFoundException)
                {
                    MessageBox.Show("The directory was not found", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (IOException)
                {
                    MessageBox.Show("The file could not be opened", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void OpenDocument(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    textBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("The file was not found", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (DirectoryNotFoundException)
                {
                    MessageBox.Show("The directory was not found", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (IOException)
                {
                    MessageBox.Show("The file could not be opened", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void Cut(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void ResizeDocument(object sender, EventArgs e)
        {
            textBox1.Size = GetFormWhiteSpace();
        }
    }
}