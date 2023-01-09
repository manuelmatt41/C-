using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form3
{
    public partial class Form1 : Form
    {
        private const int MAX_TIME_INTERVAL = 20;
        private List<Image> showImages = new List<Image>();
        public Form1()
        {
            InitializeComponent();
            StartCbTimeInterval();
        }

        private void StartCbTimeInterval()
        {
            for (int i = 1; i <= MAX_TIME_INTERVAL; i++)
            {
                cbTimeInterval.Items.Add(i);
            }

            cbTimeInterval.SelectedItem = MAX_TIME_INTERVAL / 2;
        }

        private void SelectDirectory(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                showImages.Clear();
                FileInfo[] imagesFiles = GetImageFromDirectory(new DirectoryInfo(folderBrowserDialog1.SelectedPath), ".png", ".jpg");

                Array.ForEach(imagesFiles, image => showImages.Add(Image.FromFile(image.FullName)));
                Trace.WriteLine(string.Join(",", showImages));
            }
        }

        private FileInfo[] GetImageFromDirectory(DirectoryInfo directory, params string[] extensions)
        {
            FileInfo[] files = directory.GetFiles();
            return Array.FindAll(files, file => extensions.Contains(file.Extension));
        }
    }
}
