namespace Form3
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btSelectDirectory = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbTimeInterval = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.multimediaDisplayButtons1 = new Bol7_Ejer3.MultimediaDisplayButtons();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btSelectDirectory
            // 
            this.btSelectDirectory.Location = new System.Drawing.Point(12, 415);
            this.btSelectDirectory.Name = "btSelectDirectory";
            this.btSelectDirectory.Size = new System.Drawing.Size(104, 23);
            this.btSelectDirectory.TabIndex = 1;
            this.btSelectDirectory.Text = "Select directory";
            this.btSelectDirectory.UseVisualStyleBackColor = true;
            this.btSelectDirectory.Click += new System.EventHandler(this.SelectDirectory);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 378);
            this.panel1.TabIndex = 2;
            // 
            // cbTimeInterval
            // 
            this.cbTimeInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimeInterval.FormattingEnabled = true;
            this.cbTimeInterval.Location = new System.Drawing.Point(122, 417);
            this.cbTimeInterval.Name = "cbTimeInterval";
            this.cbTimeInterval.Size = new System.Drawing.Size(121, 21);
            this.cbTimeInterval.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.ChangeImage);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(252, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 218);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // multimediaDisplayButtons1
            // 
            this.multimediaDisplayButtons1.Enabled = false;
            this.multimediaDisplayButtons1.Location = new System.Drawing.Point(291, 384);
            this.multimediaDisplayButtons1.Name = "multimediaDisplayButtons1";
            this.multimediaDisplayButtons1.ShowImages = false;
            this.multimediaDisplayButtons1.Size = new System.Drawing.Size(152, 63);
            this.multimediaDisplayButtons1.TabIndex = 2;
            this.multimediaDisplayButtons1.PlayClick += new System.EventHandler(this.Pause);
            this.multimediaDisplayButtons1.DesbordaTiempo += new System.EventHandler(this.AddMinutes);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbTimeInterval);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btSelectDirectory);
            this.Controls.Add(this.multimediaDisplayButtons1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bol7_Ejer3.MultimediaDisplayButtons multimediaDisplayButtons1;
        private System.Windows.Forms.Button btSelectDirectory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbTimeInterval;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

