namespace Bol5_Ejer8
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.previousBt = new System.Windows.Forms.Button();
            this.nextBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 213);
            this.panel1.TabIndex = 0;
            // 
            // previousBt
            // 
            this.previousBt.Location = new System.Drawing.Point(12, 902);
            this.previousBt.Name = "previousBt";
            this.previousBt.Size = new System.Drawing.Size(150, 46);
            this.previousBt.TabIndex = 1;
            this.previousBt.Text = "<";
            this.previousBt.UseVisualStyleBackColor = true;
            this.previousBt.Click += new System.EventHandler(this.PreviousImage);
            // 
            // nextBt
            // 
            this.nextBt.Location = new System.Drawing.Point(168, 902);
            this.nextBt.Name = "nextBt";
            this.nextBt.Size = new System.Drawing.Size(150, 46);
            this.nextBt.TabIndex = 2;
            this.nextBt.Text = ">";
            this.nextBt.UseVisualStyleBackColor = true;
            this.nextBt.Click += new System.EventHandler(this.NextImage);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1486, 960);
            this.Controls.Add(this.nextBt);
            this.Controls.Add(this.previousBt);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Resize += new System.EventHandler(this.Form2_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button previousBt;
        private Button nextBt;
    }
}