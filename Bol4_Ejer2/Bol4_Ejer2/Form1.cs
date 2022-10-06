using System.ComponentModel;
using System.Diagnostics;

namespace Bol4_Ejer2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Font = new Font("Lucida Console", 9f);
            Process[] p = Process.GetProcesses();
            for (int i = 0; i < p.Length; i++)
            {
                textBox1.AppendText(string.Format($"PID: {p[i].Id,-10}Nombre: {CutName(p[i].ProcessName, 15),-20} {(p[i].MainWindowTitle.Length > 0 ? $"Titulo: {CutName(p[i].MainWindowTitle, 10),-11}" : "")}{Environment.NewLine}"));
            }
        }

        private string CutName(string name, int maxCharacters)
        {
            if (name.Length > maxCharacters)
            {
                return name.Substring(0, maxCharacters) + "...";
            }
            else
            {
                return name;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                int pid;
                pid = GetPid(textBox2.Text);

                Process? p = Array.Exists(Process.GetProcesses(), x => x.Id == pid) ? Process.GetProcessById(pid) : null;

                if (p != null)
                {
                    ProcessModuleCollection modules;
                    try
                    {
                        modules = p.Modules;
                    }
                    catch (Exception)
                    {
                        return;
                    }

                    ProcessThreadCollection subProcess = p.Threads;
                    textBox1.AppendText(String.Format($"Id: {p.Id} Modules: {modules.Count} Threads: {subProcess.Count}{Environment.NewLine}"));
                    textBox1.AppendText(string.Format($"Modules:{Environment.NewLine}"));

                    for (int i = 0; i < modules.Count; i++)
                    {
                        textBox1.AppendText(string.Format($"{modules[i]}{Environment.NewLine}"));
                    }

                    textBox1.AppendText(string.Format($"Subprocess:{Environment.NewLine}"));

                    for (int i = 0; i < subProcess.Count; i++)
                    {
                        textBox1.AppendText(string.Format($"Id: {subProcess[i].Id,-10} Init: {subProcess[i].StartTime,-20}{Environment.NewLine}"));
                    }
                }
                else
                {
                    MessageBox.Show("The PID typed doesnt exist");
                }
            }
            else
            {
                MessageBox.Show("No PID has been written");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                int pid;
                pid = GetPid(textBox2.Text);
                Process? processToClose = null;
                if (pid != -1)
                {
                    processToClose = Process.GetProcessById(pid);
                }


                if (processToClose != null)
                {
                    processToClose.CloseMainWindow();
                }
                else
                {
                    MessageBox.Show("No existe el pid puesto", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private int GetPid(string pidText)
        {
            textBox1.Text = "";
            int pid;
            bool flag;
            flag = int.TryParse(pidText.Trim(), out pid);

            return flag ? pid : -1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                int pid;
                pid = GetPid(textBox2.Text);
                Process processToKill = null;

                if (pid != -1)
                {
                    processToKill = Process.GetProcessById(pid);
                }

                if (processToKill != null)
                {
                    try
                    {
                        processToKill.Kill();
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No existe el pid puesto", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                string path = textBox2.Text.Trim();


                try
                {
                    Process.Start(path);
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
                catch (Win32Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
                catch
                {
                    Console.WriteLine("An error has ocurred");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                textBox1.Clear();
                Process[] p = Array.FindAll(Process.GetProcesses(), (p) => p.ProcessName.StartsWith(textBox2.Text.Trim()));

                for (int i = 0; i < p.Length; i++)
                {
                    textBox1.AppendText($"{p[i].ProcessName}{Environment.NewLine}");
                }
            }
        }
    }
}