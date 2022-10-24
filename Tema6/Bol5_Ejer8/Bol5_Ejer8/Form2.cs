using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bol5_Ejer8
{
    public partial class Form2 : Form
    {
        public Form2(Image[] images, Form1 form1)
        {
            InitializeComponent();
            this.images = images;
            this.form1 = form1;
            if (images.Length > 0)
            {
                selectedImage = 0;
                pictureBox = form1.CreatePictureBox(images[selectedImage]);
                this.Controls.Add(pictureBox);
                Scale();
            }
        }

        public void ImageUpdate(bool flag)
        {
            if (!flag)
            {
                selectedImage = selectedImage >=  images.Length - 1 ? 0 : selectedImage + 1;
            }
            else
            {
                selectedImage = selectedImage <= 0 ? images.Length - 1 : selectedImage - 1;
            }
            pictureBox.Image = images[selectedImage];
            Scale();
        }

        public void Scale()
        {
            pictureBox.Size = pictureBox.Image.Size;
            if (640000 < (int)Math.Pow(pictureBox.Size.Width, 2))
            {
                this.Size = pictureBox.Size;
                pictureBox.Location = new Point(0, 0);
            }
            else
            {
                this.Size = new Size(800, 800);
                pictureBox.Location = new Point(this.Width / 2 - pictureBox.Width / 2, this.Height / 2 - pictureBox.Height / 2);
            }
        }

        Image[] images;
        public int selectedImage;
        public PictureBox pictureBox;
        Form1 form1;
    }
}
