using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form3
{
    public partial class Form1 : Form
    {
        FileInfo[] imagesFiles;

        public Form1()
        {
            InitializeComponent();
        }

        private void ChooseDirectory(object senderm, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                imagesFiles = GetImagesFiles(folderBrowserDialog1.SelectedPath, new string[] { ".png", ".jpg", ".jpeg" });
            }
        }

        private FileInfo[] GetImagesFiles(string path, string[] extensions)
        {
            Trace.WriteLine(path);
            FileInfo[] images = new DirectoryInfo(path).GetFiles();
            return Array.FindAll(images, (image) => extensions.Contains(image.Extension));
        }
    }
}
