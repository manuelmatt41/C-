namespace Bol5_Ejer5._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            toolTip1.SetToolTip(this.listBox2, $"{listBox2.Items.Count}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Trim();
            if (textBox1.Text == "")
            {
                MessageBox.Show("The text is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            listBox1.Items.Add(textBox1.Text);
            UpdateLabel();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RemoveSelectedItems(listBox1, "There are no values to remove");
            RemoveSelectedItems(listBox2, "There are no values to remove");
            UpdateLabel();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TransferData(listBox1, listBox2, "There are no values to tansfer");
            UpdateLabel();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TransferData(listBox2, listBox1, "There are no values to tansfer");
            UpdateLabel();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLabelList();
        }

        private void RemoveSelectedItems(ListBox listBox, string errorMessage)
        {
            if (listBox.Items.Count > 0)
            {
                if (listBox.SelectedIndices.Count == 0)
                {
                    MessageBox.Show(errorMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                for (int i = listBox.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    listBox.Items.RemoveAt(i);
                }
                listBox.ClearSelected();
            }
        }

        private void TransferData(ListBox mainListBox, ListBox secondListBox, string errorMessage)
        {
            if (mainListBox.Items.Count > 0)
            {
                if (mainListBox.SelectedItems.Count == 0)
                {
                    MessageBox.Show(errorMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                for (int i = mainListBox.SelectedItems.Count - 1; i >= 0; i--)
                {
                    secondListBox.Items.Insert(0, mainListBox.SelectedItems[i]);
                }
                button2.PerformClick();
            }
        }

        private void UpdateLabel()
        {
            label1.Text = listBox1.Items.Count.ToString();
            toolTip1.SetToolTip(this.listBox2, $"{listBox2.Items.Count}");
        }
        private void UpdateLabelList()
        {
            string list = "";
            for (int i = 0; i < listBox1.SelectedIndices.Count; i++)
            {
                list += $"Selected: {listBox1.SelectedIndices[i]} {listBox1.Items[listBox1.SelectedIndices[i]]}{Environment.NewLine}";
            }
            label2.Text = list;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Text.Length < Properties.Resources.Title.Length)
            {
                this.Text = Properties.Resources.Title[(Properties.Resources.Title.Length - 1) - this.Text.Length] + this.Text;
                this.Icon = this.Text.Length % 2 == 0 ? Properties.Resources.favicon : Properties.Resources.favicon2;
            }
            else
            {
                this.Text = "";
            }
        }
    }
}