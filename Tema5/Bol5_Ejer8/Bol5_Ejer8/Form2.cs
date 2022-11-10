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
        public Form2(Form1 form1)
        {
            InitializeComponent();
            pictureBox1.Size = this.Size;
            this.form1 = form1;
            siguienteToolStripMenuItem.Click += new EventHandler((sender, e) => ((Button)form1.Controls.Find("button3", false)[0]).PerformClick());
            anteriorToolStripMenuItem.Click += new EventHandler((sender, e) => ((Button)form1.Controls.Find("button2", false)[0]).PerformClick());
            cerrarToolStripMenuItem.Click += new EventHandler((sender, e) => form1.CloseImageView(sender, e));
        }

        public void UpdatePictureBox(Image image, string imageName)
        {
            pictureBox1.SizeMode = image.Size.Width > this.Size.Width ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage;
            pictureBox1.Image = image;
            this.Text = imageName;
        }

        Form1 form1;
    }
}
