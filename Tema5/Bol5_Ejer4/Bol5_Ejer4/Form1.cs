namespace Bol5_Ejer4
{
    public partial class Form1 : Form
    {
        int n1;
        int n2;
        public Form1()
        {
            InitializeComponent();
            executions = new Dictionary<string, Operator>();
            executions.Add(radioButton1.Text, (n1, n2) => label2.Text = (n1 + n2).ToString());
            executions.Add(radioButton2.Text, (n1, n2) => label2.Text = (n1 - n2).ToString());
            executions.Add(radioButton3.Text, (n1, n2) => label2.Text = (n1 * n2).ToString());
            executions.Add(radioButton4.Text, (n1, n2) =>
            {
                if (n2 != 0)
                {
                    label2.Text = (n1 / n2).ToString();
                }
                else
                {
                    MessageBox.Show("Yo cant divide 0", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            });
            option = "+";
            minutes = 0;
            seconds = 0;
            this.Text = $"{minutes:00}:{seconds:00}";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            option = ((RadioButton)sender).Text;
            label1.Text = option;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out n1) && int.TryParse(textBox2.Text, out n2))
            {
                executions[option].Invoke(n1, n2);
            }
        }

        private void TextChange(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = int.TryParse(((TextBox)sender).Text, out int a) ? Color.White : Color.Red;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds++;
            if (seconds == 60)
            {
                minutes += 1;
                seconds = 0;
            }
            this.Text = $"{minutes:00}:{seconds:00}";
        }

        delegate void Operator(int n1, int n2);
        Dictionary<string, Operator> executions;
        private string option;
        private int seconds;
        private int minutes;
    }
}