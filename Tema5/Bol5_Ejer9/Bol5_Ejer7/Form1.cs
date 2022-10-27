using Bol5_Ejer9;
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
            LoadConfig();
            this.Text = "SinTitulo.txt";
        }

        private void InitializeEvents()
        {
            //
            // Resize event
            //
            this.Resize += new EventHandler((sender, e) => textBox1.Size = GetFormWhiteSpace());
            //
            // Edit Menu Events
            //
            undoMenu.Click += new EventHandler((sender, e) => textBox1.Undo());
            copyMenu.Click += new EventHandler((sender, e) => textBox1.Copy());
            cutMenu.Click += new EventHandler((sender, e) => textBox1.Cut());
            pasteMenu.Click += new EventHandler((sender, e) => textBox1.Paste());
            selectAllMenu.Click += new EventHandler((sender, e) => textBox1.SelectAll());
            //
            // Tools Menu Events
            //
            wordWrapMenu.Click += new EventHandler((sender, e) => textBox1.WordWrap = ((ToolStripMenuItem)sender).Checked);
            uppercaseToolStripMenuItem.Click += new EventHandler((sender, e) => ChangeCheckWriteMode(writeModeMenu.DropDownItems, (ToolStripMenuItem)sender));
            lowercaseToolStripMenuItem.Click += new EventHandler((sender, e) => ChangeCheckWriteMode(writeModeMenu.DropDownItems, (ToolStripMenuItem)sender));
            normalToolStripMenuItem.Click += new EventHandler((sender, e) => ChangeCheckWriteMode(writeModeMenu.DropDownItems, (ToolStripMenuItem)sender));
            uppercaseToolStripMenuItem.CheckedChanged += new EventHandler(ChangeWriteMode);
            lowercaseToolStripMenuItem.CheckedChanged += new EventHandler(ChangeWriteMode);
            normalToolStripMenuItem.CheckedChanged += new EventHandler(ChangeWriteMode);
            textColorMenu.Click += new EventHandler(ChangeColor);
            backgroundColorMenu.Click += new EventHandler(ChangeColor);
            //
            // TextChange Event
            //
            textBox1.TextChanged += new EventHandler((sender, e) => saved = false);
        }

        private void LoadConfig()
        {
            try
            {
                using (BinaryReaderConfiguration b = new BinaryReaderConfiguration(new FileStream(saveDirectory.FullName, FileMode.Open)))
                {
                    configuration = b.Read();
                }
            }
            catch (Exception e) when (e is IOException || e is FileNotFoundException || e is DirectoryNotFoundException)
            {
                configuration = new Configuration();
            }
            InitializeDocumentConfig();
        }
        private void InitializeDocumentConfig()
        {
            //
            // WordWrap
            //
            wordWrapMenu.Checked = configuration.wordWrap;
            textBox1.WordWrap = configuration.wordWrap;
            //
            // CharacterCasing
            //
            textBox1.CharacterCasing = configuration.characterCasing;
            uppercaseToolStripMenuItem.Tag = CharacterCasing.Upper;
            lowercaseToolStripMenuItem.Tag = CharacterCasing.Lower;
            normalToolStripMenuItem.Tag = CharacterCasing.Normal;
            ChangeCheckWriteMode(configuration.characterCasing);
            //
            // ForeColor
            //
            textColorMenu.Tag = configuration.foreColor;
            textColorMenu.ForeColor = configuration.foreColor;
            textBox1.ForeColor = configuration.foreColor;
            //
            // BackColor
            //
            backgroundColorMenu.Tag = configuration.backColor;
            backgroundColorMenu.ForeColor = configuration.backColor; //TODO Hacer un creador de imagenes para los selectores de colores
            textBox1.BackColor = configuration.backColor;
        }

        private ToolStripMenuItem GetWriteMode()
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

        private void ChangeCheckWriteMode(ToolStripItemCollection items, ToolStripMenuItem itemChecked)
        {
            foreach (ToolStripMenuItem menuItem in items)
            {
                menuItem.Checked = false;
            }
            itemChecked.Checked = true;
        }

        private void ChangeCheckWriteMode(CharacterCasing characterCasing)
        {
            switch (characterCasing)
            {
                case CharacterCasing.Normal:
                    normalToolStripMenuItem.Checked = true;
                    break;
                case CharacterCasing.Upper:
                    uppercaseToolStripMenuItem.Checked = true;
                    break;
                case CharacterCasing.Lower:
                    lowercaseToolStripMenuItem.Checked = true;
                    break;
                default:
                    break;
            }
        }

        private void ChangeWriteMode(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Checked)
            {
                textBox1.CharacterCasing = (CharacterCasing)((ToolStripMenuItem)sender).Tag;
            }
        }

        private void ChangeColor(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            c.ShowDialog();
            ((ToolStripMenuItem)sender).Tag = c.Color;
            ((ToolStripMenuItem)sender).BackColor = c.Color;
            if ((ToolStripMenuItem)sender == textColorMenu)
            {
                textBox1.ForeColor = (Color)((ToolStripMenuItem)sender).Tag;
            }
            if ((ToolStripMenuItem)sender == backgroundColorMenu)
            {
                textBox1.BackColor = (Color)((ToolStripMenuItem)sender).Tag;
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

        private void SaveConfiguration()
        {
            if (!saved)
            {
                saveFileMenu.PerformClick();
            }
            configuration.wordWrap = wordWrapMenu.Checked;
            configuration.characterCasing = (CharacterCasing)GetWriteMode().Tag;
            configuration.foreColor = textBox1.ForeColor;
            configuration.backColor = textBox1.BackColor;

            try
            {
                using (BinaryWriterConfiguration b = new BinaryWriterConfiguration(new FileStream(saveDirectory.FullName, FileMode.OpenOrCreate)))
                {
                    b.Write(configuration);
                }
            }
            catch (Exception e) when (e is IOException || e is FileNotFoundException || e is DirectoryNotFoundException)
            {

            }
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfiguration();
        }

        Configuration configuration;
        public bool saved;
        public DirectoryInfo saveDirectory = new DirectoryInfo($"{Environment.GetEnvironmentVariable("appdata")}\\ejer9");
    }
}
