using System;

partial class Form2
{
    private void InitializeComponent()
    {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 1);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 0;
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(532, 428);
            this.Controls.Add(this.textBox1);
            this.Name = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Resize += new System.EventHandler(this.Form2_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private TextBox textBox1;
}
