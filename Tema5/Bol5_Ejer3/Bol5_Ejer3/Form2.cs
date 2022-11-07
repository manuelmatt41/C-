using System;

public class Form2 : Form
{
    private OpenFileDialog openFileDialog1;
    private PictureBox pictureBox1;

    public Form2()
    {
        InitializeComponent();
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            try
            {
                pictureBox1.Image = Image.FromStream(openFileDialog1.OpenFile());
                this.Size = pictureBox1.Size;
                this.Text = openFileDialog1.SafeFileName;
            }
            catch (ArgumentException)
            {
                this.Text = "The file is not an image";
            }
        }
        else
        {
            this.Text = "Nothing has been selected";
        }
    }

    private void InitializeComponent()
    {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(285, 263);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Imagenes JPG|*.jpg|Imagenes PNG|*.png|Todos los archivos|*.*";
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

    }

}
