using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Bol5_Ejer8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public FileInfo[] GetImagesFiles(string path, params string[] extensions)
        {
            if (!Directory.Exists(path))
            {
                return new FileInfo[0];
            }
            DirectoryInfo directory = new DirectoryInfo(path);
            return Array.FindAll(directory.GetFiles(), (f) => extensions.Contains(f.Extension));
        }

        public Image[] GetImagesFromFiles(FileInfo[] imagesFiles)
        {
            List<Image> images = new List<Image>();
            Array.ForEach(imagesFiles, (f) => images.Add(Image.FromFile(f.FullName)));
            return images.ToArray();
        }

        private void OpenGalleryView()
        {
            Form2 f = new Form2();
            f.Show();
            f.UpdatePictureBox(images[0]);
        }

        private void OpenGalleryList()
        {
            Array.Reverse(images);
            Array.ForEach(images, (i) => flowLayoutPanel1.Controls.Add(CreatePictureBox(i)));
        }

        public PictureBox CreatePictureBox(Image image)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.Size = new Size(100, 100);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            return pictureBox;
        }

        private void UpdateData(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            imagesFiles = GetImagesFiles(folderBrowserDialog1.SelectedPath, ".png", ".jpg", ".jpeg", ".gif");
            images = GetImagesFromFiles(imagesFiles);
            OpenGalleryList();
            OpenGalleryView();
        }

        FileInfo[] imagesFiles;
        Image[] images;
    }
}