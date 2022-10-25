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
            f = new Form2();
            f.Show();
            f.UpdatePictureBox(images[selectedImage], imagesFiles[selectedImage].Name);
            UpdateImageInfo(imagesFiles[selectedImage].Name, imagesFiles[selectedImage].Length, images[selectedImage].Size);
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
            pictureBox.Click += new EventHandler(SelectImage);
            pictureBox.ContextMenuStrip = contextMenuStrip1;
            return pictureBox;
        }

        private void UpdateImageInfo(string imageName, long imageByteSize, Size resolution)
        {
            string byteSizeExpression = imageByteSize < 1000000 ? $"{imageByteSize / 1024}KB" : $"{(imageByteSize / 1024) / 1024}MB";
            label2.Text = $"Name: {imageName} | Byte size: {byteSizeExpression} | Resolution: {resolution}";
        }

        private void UpdateData(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            imagesFiles = GetImagesFiles(folderBrowserDialog1.SelectedPath, ".png", ".jpg", ".jpeg", ".gif");
            images = GetImagesFromFiles(imagesFiles);
            label1.Text = folderBrowserDialog1.SelectedPath;
            selectedImage = 0;
            if (images.Length > 0)
            {
                flowLayoutPanel1.Controls.Clear();
                OpenGalleryList();
                OpenGalleryView();
            }
        }

        private void Next(object sender, EventArgs e)
        {
            if (f != null)
            {
                selectedImage = selectedImage < images.Length - 1 ? selectedImage + 1 : 0;
                f.UpdatePictureBox(images[selectedImage], imagesFiles[selectedImage].Name);
                UpdateImageInfo(imagesFiles[selectedImage].Name, imagesFiles[selectedImage].Length, images[selectedImage].Size);
            }
        }

        private void Previous(object sender, EventArgs e)
        {
            if (f != null)
            {
                selectedImage = selectedImage > 0 ? selectedImage - 1 : images.Length - 1;
                f.UpdatePictureBox(images[selectedImage], imagesFiles[selectedImage].Name);
                UpdateImageInfo(imagesFiles[selectedImage].Name, imagesFiles[selectedImage].Length, images[selectedImage].Size);
            }
        }

        private void SelectImage(object sender, EventArgs e)
        {
            for (int i = 0; i < images.Length; i++)
            {
                if (images[i] == ((PictureBox)sender).Image)
                {
                    selectedImage = i;
                    f.UpdatePictureBox(images[selectedImage], imagesFiles[selectedImage].Name);
                    UpdateImageInfo(imagesFiles[selectedImage].Name, imagesFiles[selectedImage].Length, images[selectedImage].Size);
                }
            }
        }

        private void KeyEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                button2.PerformClick();
            }
            if (e.KeyCode == Keys.D)
            {
                button3.PerformClick();
            }
        }

        private void Close(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are yo sure to close de application", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (f != null)
                {
                    f.Close();
                }
                this.Dispose();
            }
            e.Cancel = true;
        }

        private void CloseImageView(object sender, EventArgs e)
        {
            if (f != null)
            {
                f.Close();
            }
            flowLayoutPanel1.Controls.Clear();
            label1.Text = "";
            label2.Text = "";
        }

        FileInfo[] imagesFiles;
        Image[] images;
        int selectedImage;
        Form2 f;

    }
}