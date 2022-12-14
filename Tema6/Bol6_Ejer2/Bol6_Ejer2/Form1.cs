using System.IO;
using System.Text.RegularExpressions;

namespace Bol6_Ejer2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox4.Text = GetExtensions();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Nothing has been written");
                return;
            }
            if (Directory.Exists(textBox1.Text))
            {
                textBox3.Clear();
                string[] files;
                try
                {
                    files = Directory.GetFiles(textBox1.Text, textBox4.Text == "" ? "*.txt" : textBox4.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("The file has no access");
                    return;
                }
                foreach (string file in files)
                {
                    new Thread(() =>
                    {
                        Delega d = new Delega(AppendText);
                        this.Invoke(d, file, CountWords(File.ReadAllText(file), textBox2.Text), textBox3);
                    }).Start();
                }
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.WriteAllText($"{Environment.GetEnvironmentVariable("userprofile")}\\extension.txt", textBox4.Text == "" ? "*.txt" : textBox4.Text);
        }

        private string GetExtensions()
        {
            string path = $"{Environment.GetEnvironmentVariable("userprofile")}\\extension.txt";
            return File.Exists(path) ? File.ReadAllText(path) : "*.txt";
        }

        private int CountWords(string text, string word)
        {
            return Regex.Matches(text, word, checkBox1.Checked ? RegexOptions.None : RegexOptions.IgnoreCase).Count();
        }

        private void AppendText(string path, int countWords, TextBox textBox)
        {
            textBox.AppendText($"{path}: {countWords} words{Environment.NewLine}");
        }


        delegate void Delega(string path, int countWords, TextBox textBox);

    }
}