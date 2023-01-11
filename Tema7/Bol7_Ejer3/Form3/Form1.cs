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

                multimediaDisplayButtons1.Enabled = showImages.Count > 0;

                Trace.WriteLine("Images:");
                Array.ForEach(showImages.ToArray(), image => Trace.Write($"{image},"));
            }
        }

        private FileInfo[] GetImageFromDirectory(DirectoryInfo directory, params string[] extensions)
        {
            FileInfo[] files = directory.GetFiles();
            return Array.FindAll(files, file => extensions.Contains(file.Extension));
        }

        private void Pause(object sender, EventArgs e)
        {
            timer1.Enabled = !multimediaDisplayButtons1.IsPause;
            if (timer1.Enabled)
            {
                timer1.Interval = ((int)cbTimeInterval.SelectedItem) * 1000;
                Trace.WriteLine($"Selected time: {(int)cbTimeInterval.SelectedItem}");
                Trace.WriteLine($"Interval : {timer1.Interval}");
            }
        }

        private void ChangeImage(object sender, EventArgs e)
        {
            if (showImages.Count == 0)
            {
                return;
            }
            if (pictureBox1.Image == null && showImages.Count > 0)
            {
                pictureBox1.Image = showImages.First();
                return;
            }

            if (pictureBox1.Image == showImages.Last())
            {
                pictureBox1.Image = showImages.First();
                return;
            }

            pictureBox1.Image = showImages[showImages.FindIndex(image => image == pictureBox1.Image) + 1];
            //pictureBox1.Size = pictureBox1.Image.Size;
        }

        private void AddMinutes(object sender, EventArgs e)
        {
            multimediaDisplayButtons1.AddMinutes();
            Trace.WriteLine("Minute added");
        }
    }
}
