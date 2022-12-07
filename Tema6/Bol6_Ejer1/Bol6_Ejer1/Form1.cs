using System.Diagnostics;
using System.Security;

namespace Bol6_Ejer1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string? directory = textBox1.Text.Trim();
            if (directory.Length > 1)
            {
                if (directory.StartsWith("%") && directory.EndsWith("%"))
                {
                    directory = directory.Remove(0, 1);
                    directory = directory.Remove(directory.Length - 1, 1);
                    directory = Environment.GetEnvironmentVariable(directory);
                    directoryInfo = directory != null ? new DirectoryInfo(directory) : null;
                }
                else
                {
                    if (Directory.Exists(directory))
                    {
                        directoryInfo = new DirectoryInfo(directory);
                    }
                    else
                    {
                        directoryInfo = null;
                    }
                }
                UpdateDirectoryInfo();
            }
        }

        private void UpdateDirectoryInfo()
        {
            if (directoryInfo != null)
            {
                lblError.Text = "";
                string[] directories;
                try
                {
                    directories = Directory.GetDirectories(directoryInfo.FullName);
                }
                catch (Exception e) when (e is IOException || e is UnauthorizedAccessException)
                {
                    return;
                }
                if (directories.Length >= 0)
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add("..");
                    foreach (string directory in directories)
                    {
                        listBox1.Items.Add(directory);
                    }
                    UpdateFileInfo();
                }
            }
            else
            {
                lblError.Text = "Directory not found";
            }
        }

        private void UpdateFileInfo()
        {
            string[] files;
            try
            {
                files = Directory.GetFiles(directoryInfo.FullName);
                listBox2.Items.Clear();
            }
            catch (Exception e) when (e is IOException || e is UnauthorizedAccessException)
            {
                return;
            }
            foreach (string file in files)
            {
                listBox2.Items.Add(file);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {

                if (listBox1.SelectedItem == "..")
                {
                    if (directoryInfo.Parent != null)
                    {
                        textBox1.Text = directoryInfo.Parent.FullName;
                        button1.PerformClick();
                    }
                }
                else
                {
                    textBox1.Text = (string)listBox1.SelectedItem;
                    button1.PerformClick();
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                FileInfo? fileInfo = new FileInfo((string)listBox2.SelectedItem);
                if (fileInfo != null)
                {
                    switch (fileInfo.Length)
                    {
                        case < 1024:
                            label1.Text = $"{fileInfo.Length} Bytes";
                            break;
                        case < 1000000:
                            label1.Text = $"{fileInfo.Length / 1024} MB";
                            break;
                        default:
                            label1.Text = $"{(fileInfo.Length / 1024) / 1024} GB";
                            break;
                    }
                    if (fileInfo.Extension == ".txt")
                    {
                        new Form2(File.ReadAllText(fileInfo.FullName), fileInfo.FullName).Show();
                    }
                }
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        DirectoryInfo? directoryInfo;
    }
}