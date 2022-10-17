using System;

public class Form2 : Form
{
    private TextBox textBox1;

    public Form2()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // textBox1
        // 
        this.textBox1.Location = new System.Drawing.Point(12, 12);
        this.textBox1.MaxLength = 4;
        this.textBox1.Name = "textBox1";
        this.textBox1.PasswordChar = '*';
        this.textBox1.PlaceholderText = "Wirte your PIN";
        this.textBox1.Size = new System.Drawing.Size(218, 23);
        this.textBox1.TabIndex = 0;
        this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyUp);
        // 
        // Form2
        // 
        this.ClientSize = new System.Drawing.Size(242, 45);
        this.Controls.Add(this.textBox1);
        this.Name = "Form2";
        this.Text = "Write the PIN";
        this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
        this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyUp);
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    private void Form2_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            int pin;
            if (int.TryParse(textBox1.Text, out pin))
            {
                if (pin == password)
                {
                    MessageBox.Show("Correct", "", MessageBoxButtons.OK);
                    this.Hide();
                }
                else
                {
                    attemps--;
                    MessageBox.Show($"Incorrect Pin. Attemps:{attemps}", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (attemps == 0)
                {
                    Environment.Exit(0);
                }
            }
            textBox1.Clear();
        }
    }

    int password = 1234;
    int attemps = 3;

    private void Form2_FormClosed(object sender, FormClosedEventArgs e)
    {
        Environment.Exit(0);


    }
}
