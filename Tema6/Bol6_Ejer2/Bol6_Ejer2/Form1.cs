namespace Bol6_Ejer2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(textBox1.Text))
            {
                textBox3.Clear();
                string[] files;
                try
                {
                    files = Directory.GetFiles(textBox1.Text, "*.txt");
                }
                catch (Exception)
                {
                    return;
                }
                foreach (string file in files)
                {
                    new Thread(() =>
                    {
                        Delega d = new Delega(AppendText);
                        this.Invoke(d, file, CountWords(file), textBox3);
                    }).Start();
                }
            }
        }

        private int CountWords(string path)
        {
            return Array.FindAll(File.ReadAllText(path).Replace('\n', ' ').Replace('\r', ' ').Replace('\t', ' ').Split(' '), (word) => word == textBox2.Text).Length;
        }

        private void AppendText(string path, int countWords, TextBox textBox)
        {
            textBox.AppendText($"{path}: {countWords} words{Environment.NewLine}");
        }

        delegate void Delega(string path, int countWords, TextBox textBox);
    }
}