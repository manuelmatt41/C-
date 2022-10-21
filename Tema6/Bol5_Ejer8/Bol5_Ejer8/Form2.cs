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
            if (selectedImage.Width > this.Width)
            {
                this.panel1.Size = selectedImage.Size;
                this.Size = panel1.Size;
            }
            else
            {
                this.panel1.Size = new Size(this.Width, this.Height - 100);
            }
            Point center = new Point((panel1.Width / 2) - (selectedImage.Width / 2), (panel1.Height / 2) - (selectedImage.Height / 2));
            panel1.Controls.Add(form1.CreatePictureBox(selectedImage, center));
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            ViewImage();
        }

        Image[] images;
        Image selectedImage;
        Form1 form1;
    }
}
