using System.Diagnostics;

namespace Bol5_Ejer7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Size = GetFormWhiteSpace();
            InitializeEvents();
            InitializeTags();
            this.Text = "SinTitulo.txt";
        }

        private void InitializeEvents()
        {
            this.Resize += new EventHandler((sender, e) => textBox1.Size = GetFormWhiteSpace());
            undoMenu.Click += new EventHandler((sender, e) => textBox1.Undo());
            copyMenu.Click += new EventHandler((sender, e) => textBox1.Copy());
            cutMenu.Click += new EventHandler((sender, e) => textBox1.Cut());
            pasteMenu.Click += new EventHandler((sender, e) => textBox1.Paste());
            selectAllMenu.Click += new EventHandler((sender, e) => textBox1.SelectAll());
            uppercaseToolStripMenuItem.Click += new EventHandler((sender, e) => CheckItem(writeModeMenu.DropDownItems, (ToolStripMenuItem)sender));
            uppercaseToolStripMenuItem.CheckedChanged += new EventHandler(ChangeWriteMode);
            lowercaseToolStripMenuItem.CheckedChanged += new EventHandler(ChangeWriteMode);
            normalToolStripMenuItem.CheckedChanged += new EventHandler(ChangeWriteMode);
            lowercaseToolStripMenuItem.Click += new EventHandler((sender, e) => CheckItem(writeModeMenu.DropDownItems, (ToolStripMenuItem)sender));
            normalToolStripMenuItem.Click += new EventHandler((sender, e) => CheckItem(writeModeMenu.DropDownItems, (ToolStripMenuItem)sender));
            textBox1.TextChanged += new EventHandler((sender, e) => saved = false);
        }

        private void InitializeTags()
        {
            uppercaseToolStripMenuItem.Tag = CharacterCasing.Upper;
            lowercaseToolStripMenuItem.Tag = CharacterCasing.Lower;
            normalToolStripMenuItem.Tag = CharacterCasing.Normal;
        }

        private void InitializeDocumentConfig()
        {
            textBox1.WordWrap = wordWrapMenu.Checked;
            textBox1.CharacterCasing = (CharacterCasing)WriteMode().Tag;
        }

        private ToolStripMenuItem WriteMode()
        {
            foreach (ToolStripMenuItem item in writeModeMenu.DropDownItems)
            {
                if (item.Checked)
                {
                    return item;
                }
            }
            return null;
        }

        private void CheckItem(ToolStripItemCollection items, ToolStripMenuItem itemChecked)
        {
            foreach (ToolStripMenuItem menuItem in items)
            {
                menuItem.Checked = false;
            }
            itemChecked.Checked = true;
        }

        private void ChangeWriteMode(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Checked)
            {
                textBox1.CharacterCasing = (CharacterCasing)((ToolStripMenuItem)sender).Tag;
            }
        }

        public Size GetFormWhiteSpace()
        {
            return new Size(this.Width, this.Height - menuStrip1.Height - toolStrip1.Height);
        }

        private void NewDocument(object sender, EventArgs e)
        {
            saveFileMenu.PerformClick();
            textBox1.Text = "";
            this.Text = "SinTitulo.txt";
        }

        private void SaveDocument(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = this.Text;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
                    saved = true;
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("The file was not found", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    saved = false;
                }
                catch (DirectoryNotFoundException)
                {
                    MessageBox.Show("The directory was not found", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    saved = false;
                }
                catch (IOException)
                {
                    MessageBox.Show("The file could not be opened", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    saved = false;
                }
                this.Text = saved ? new FileInfo(saveFileDialog1.FileName).Name : "SinTitulo.txt";
            }
        }

        private void OpenDocument(object sender, EventArgs e)
        {
            saveFileMenu.PerformClick();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    textBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("The file was not found", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (DirectoryNotFoundException)
                {
                    MessageBox.Show("The directory was not found", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (IOException)
                {
                    MessageBox.Show("The file could not be opened", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public bool saved;
    }
}
