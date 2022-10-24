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
        public Form2()
        {
            InitializeComponent();
            pictureBox1.Size = this.Size;
        }

        public void UpdatePictureBox(Image image)
        {
            pictureBox1.SizeMode = image.Size.Width > this.Size.Width ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage;
            pictureBox1.Image = image;
        }

    }
}
