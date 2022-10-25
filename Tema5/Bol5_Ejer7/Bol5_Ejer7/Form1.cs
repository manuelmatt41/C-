namespace Bol5_Ejer7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            aula = new Aula(File.ReadAllText($"{Environment.GetEnvironmentVariable("userprofile")}\\student.txt"));
            studentCB.Items.AddRange(aula.Students.ToArray());
            subjectCB.Items.AddRange(aula.SubjectsNames);
            CreateTable();

        }

        private void CreateTable()
        {
            int x = 12;
            int y = 90;
            Size size = new Size(120, 30);
            x += 120;
            for (int i = 0; i < subjectCB.Items.Count; i++)
            {
                AddLabel(new Point(x, y), size, subjectCB.Items[i].ToString(), Color.Black, "", false);
                x += 120;
            }
            y += 30;
            x = 12;
            for (int i = 0; i < studentCB.Items.Count; i++)
            {
                AddLabel(new Point(x, y), size, studentCB.Items[i].ToString(), Color.Black, "", false);
                x += 120;
                for (int j = 0; j < subjectCB.Items.Count; j++)
                {
                    AddLabel(new Point(x, y), size, aula[i, j].ToString(), aula[i, j] < 5 ? Color.Red : Color.Green, $"{aula.Students[i]}-{aula.SubjectsNames[j]}", true);
                    x += 120;
                }
                x = 12;
                y += 30;
            }
        }

        private void AddLabel(Point point, Size size, string text, Color foregoundColor, string toolTipText, bool eventFlag)
        {
            Label lb = new Label();
            lb.Text = text;
            lb.Size = size;
            lb.Location = point;
            lb.AutoSize = false;
            lb.Visible = true;
            lb.BackColor = Color.White;
            lb.ForeColor = foregoundColor;
            lb.BorderStyle = BorderStyle.FixedSingle;
            lb.TextAlign = ContentAlignment.MiddleCenter;
            toolTip1.SetToolTip(lb, toolTipText);
            if (eventFlag)
            {
                lb.MouseEnter += new EventHandler((sender, e) => ((Label)sender).BackColor = Color.Yellow);
                lb.MouseLeave += new EventHandler((sender, e) => ((Label)sender).BackColor = Color.White);
            }
            this.Controls.Add(lb);
        }

        private void UpdateInfo(double averageResults, double averageStudentResult, double averageSubjectResult)
        {
            label1.Text = $"Nota media general: {averageResults}{Environment.NewLine}";
            if (averageStudentResult > 0)
            {
                label1.Text += $"Nota media de {studentCB.SelectedItem} es {averageStudentResult}{Environment.NewLine}";
                int max;
                int min;
                aula.MaxAndMinResults(out max, out min, studentCB.SelectedIndex);
                label1.Text += $"La nota máxima {studentCB.SelectedItem} es {max} y la mínima es {min}{Environment.NewLine}";
            }
            if (averageSubjectResult > 0)
            {
                label1.Text += $"Nota media de {subjectCB.SelectedItem} es {averageSubjectResult}{Environment.NewLine}";
            }
        }

        private void studentCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateInfo(aula.AllAverageResults(), studentCB.SelectedIndex, subjectCB.SelectedItem != null ? subjectCB.SelectedIndex : -1);
        }
        private Aula aula;

        private void subjectCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateInfo(aula.AllAverageResults(), studentCB.SelectedItem != null ? studentCB.SelectedIndex : -1, subjectCB.SelectedIndex);
        }
    }
}