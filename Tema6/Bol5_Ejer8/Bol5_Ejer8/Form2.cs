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
            this.selectedImage = images[0];
            ViewImage();
        }

        private void ViewImage()
        {
            panel1.Controls.Clear();
            ReScale();
            panel1.Controls.Add(form1.CreatePictureBox(selectedImage, GetCenter()));
        }

        private void ReScale()
        {
            if (selectedImage.Width > this.Width)
            {
                panel1.Size = selectedImage.Size;
                this.Size = panel1.Size;
                this.Height += 200;
            }
            else
            {
                panel1.Size = new Size(this.Width, this.Height - 300);
            }
        }

        private Point GetCenter()
        {
            return new Point((panel1.Width / 2) - (selectedImage.Width / 2), (panel1.Height / 2) - (selectedImage.Height / 2));
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            if (panel1.Controls.Count > 0)
            {
                ReScale();
                ((PictureBox)panel1.Controls[0]).Location = GetCenter();
            }
        }

        private void NextImage(object sender, EventArgs e)
        {
            int index = Array.FindIndex(images, (image) => image == selectedImage);
            index++;
            index = images.Length == index ? 0 : index;
            selectedImage = images[index];
            ViewImage();
        }
        private void PreviousImage(object sender, EventArgs e)
        {
            int index = Array.FindIndex(images, (image) => image == selectedImage);
            index--;
            index = index == -1 ? images.Length - 1 : index;
            selectedImage = images[index];
            ViewImage();
        }

        Image[] images;
        Image selectedImage;
        Form1 form1;
    }
}
