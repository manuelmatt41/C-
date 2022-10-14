namespace Bol5_Ejer4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            executions = new Dictionary<string, execution>();
            executions.Add(radioButton1.Text, () => Operation(Operators.PLUS));
            executions.Add(radioButton2.Text, () => Operation(Operators.SUBSTRAC));
            executions.Add(radioButton3.Text, () => Operation(Operators.MULTIPLY));
            executions.Add(radioButton4.Text, () => Operation(Operators.SPLIT));
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

        private void Operation(Operators operators)
        {
            int n1;
            int n2;
            if (int.TryParse(textBox1.Text, out n1) && int.TryParse(textBox2.Text, out n2))
            {
                switch (operators)
                {
                    case Operators.PLUS:
                        label2.Text = (n1 + n2).ToString();
                        break;
                    case Operators.SUBSTRAC:
                        label2.Text = (n1 - n2).ToString();
                        break;
                    case Operators.MULTIPLY:
                        label2.Text = (n1 * n2).ToString();
                        break;
                    case Operators.SPLIT:
                        if (n2 != 0)
                        {
                            label2.Text = (n1 / n2).ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            executions[option].Invoke();
        }

        enum Operators
        {
            PLUS,
            SUBSTRAC,
            MULTIPLY,
            SPLIT
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
        private delegate void execution();
        Dictionary<string, execution> executions;
        private string option;
        private int seconds;
        private int minutes;

    }
}