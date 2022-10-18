using System;
using System.Diagnostics;

public partial class Form2 : Form
{
    public Form2(string text, string path)
    {
        InitializeComponent();
        originalText = text;
        this.path = path;
        textBox1.Size = this.Size;
        textBox1.Text = originalText;
    }

    private void Form2_Resize(object sender, EventArgs e)
    {
        textBox1.Size = this.Size;
    }

    private void Form2_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (textBox1.Text != originalText)
        {
            if (MessageBox.Show("Do you want save the file?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.Write(textBox1.Text);
                    }
                }
                catch (Exception ex) when (ex is IOException || ex is DirectoryNotFoundException)
                {
                    Trace.WriteLine(ex.Message);
                }
            }
        }
    }

    string originalText;
    string path;
}
