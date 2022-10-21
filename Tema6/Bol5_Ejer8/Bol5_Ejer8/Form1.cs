using System.Diagnostics;
using System.IO;

namespace Bol5_Ejer8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AddPictureBox(Panel panel, Image[] images)
        {
            foreach (Image image in images)
            {
                panel.Controls.Add(CreatePictureBox(image));
            }
        }

        public PictureBox CreatePictureBox(Image image)
        {
            PictureBox p = new PictureBox();
            p.SizeMode = PictureBoxSizeMode.StretchImage;
            p.Size = new Size(100, 100);
            p.Image = image;
            p.Visible = true;
            return p;
        }
        public PictureBox CreatePictureBox(Image image, Point location)
        {
            PictureBox p = new PictureBox();
            p.SizeMode = PictureBoxSizeMode.StretchImage;
            p.Size = image.Size;
            p.Image = image;
            p.Location = location;
            p.Visible = true;
            return p;
        }

        private Image[] GetImages(string path)
        {
            if (!Directory.Exists(path))
            {
                return new Image[0];
            }
            List<Image> images = new List<Image>();
            FileInfo[] imagesPath = GetFiles(new DirectoryInfo(path), new string[] { ".png", ".jpg", ".jpeg" });
            if (imagesPath.Length == 0)
            {
                return new Image[0];
            }
            Array.ForEach(imagesPath, (imagePath) => images.Add(Image.FromFile(imagePath.FullName)));
            return images.ToArray();
        }

        private FileInfo[] GetFiles(DirectoryInfo directoryInfo, string[] extensions)
        {
            return Array.FindAll(directoryInfo.GetFiles(), (file) => extensions.Contains(file.Extension));
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            flowLayoutPanel1.Size = this.Size;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            AddPictureBox(flowLayoutPanel1, GetImages(folderBrowserDialog1.SelectedPath)); 
            flowLayoutPanel1.Size = this.Size;
            flowLayoutPanel1.Location = new Point(0, 0);
            new Form2(GetImages(folderBrowserDialog1.SelectedPath), this).ShowDialog();
        }
    }
}