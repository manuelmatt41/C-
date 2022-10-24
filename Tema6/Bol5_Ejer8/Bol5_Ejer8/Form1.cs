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
            p.Anchor = AnchorStyles.None;
            p.Visible = true;
            p.Click += new EventHandler(OpenGallery);
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
            imagesFiles = imagesPath;
            return images.ToArray();
        }

        private FileInfo[] GetFiles(DirectoryInfo directoryInfo, string[] extensions)
        {
            return Array.FindAll(directoryInfo.GetFiles(), (file) => extensions.Contains(file.Extension));
        }

        private void OpenGallery(object sender, EventArgs e)
        {
            if (sender == button1)
            {
                images = GetImages(folderBrowserDialog1.SelectedPath);
                form2 = new Form2(images, this);
                form2.Show();
                form2.Text = imagesFiles[form2.selectedImage].Name;
            }
            else
            {
                for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
                {
                    if (sender == flowLayoutPanel1.Controls[i])
                    {
                        form2.pictureBox.Image = ((PictureBox)flowLayoutPanel1.Controls[i]).Image;
                        form2.selectedImage = i;
                        form2.Scale();
                        form2.Text = imagesFiles[form2.selectedImage].Name;
                    }
                }
            }
        }

        private void SelectImageFile(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            AddPictureBox(flowLayoutPanel1, GetImages(folderBrowserDialog1.SelectedPath));
            flowLayoutPanel1.Size = new Size(this.Size.Width, this.Height - 40);
            flowLayoutPanel1.Location = new Point(0, 40);
            OpenGallery(sender, e);
        }

        private void ChangeImage(object sender, EventArgs e)
        {
            if (form2 != null)
            {
                if (sender == button2)
                {
                    form2.ImageUpdate(true);
                }
                else
                {
                    form2.ImageUpdate(false);
                }
                form2.Text = imagesFiles[form2.selectedImage].Name;
            }
        }

        private void ChangeImage(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                button2.PerformClick();
            }
            if (e.KeyCode == Keys.Right)
            {
                button2.PerformClick();
            }
        }

        private void ScaleGallery(object sender, EventArgs e)
        {
            if (flowLayoutPanel1 != null)
            {
                flowLayoutPanel1.Size = new Size(this.Size.Width, this.Height - 40);
            }
        }

        Form2 form2;
        FileInfo[] imagesFiles;
        Image[] images;
    }
}