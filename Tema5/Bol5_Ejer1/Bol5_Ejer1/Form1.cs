namespace Bol5_Ejer1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            if (sender is Button)
            {
                x += ((Button)sender).Location.X;
                y += ((Button)sender).Location.Y;
            }
            string coordinates = $"X:{x} Y:{y}";
            this.Text = coordinates;
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            this.Text = "Mouse Tester";
        }
    }
}