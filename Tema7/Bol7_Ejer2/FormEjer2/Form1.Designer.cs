namespace FormEjer2
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.alertLabel2 = new WindowsFormsControlLibrary1.AlertLabel();
            this.SuspendLayout();
            // 
            // alertLabel2
            // 
            this.alertLabel2.BackGradient = false;
            this.alertLabel2.FirstGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.alertLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.alertLabel2.Location = new System.Drawing.Point(256, 117);
            this.alertLabel2.Mark = WindowsFormsControlLibrary1.Mark.CIRCLE;
            this.alertLabel2.MarkImage = null;
            this.alertLabel2.Name = "alertLabel2";
            this.alertLabel2.SecondGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.alertLabel2.Size = new System.Drawing.Size(137, 50);
            this.alertLabel2.TabIndex = 1;
            this.alertLabel2.Text = "alertLabel2";
            this.alertLabel2.ClickInMark += new System.Windows.Forms.MouseEventHandler(this.TestEvent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.alertLabel2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private WindowsFormsControlLibrary1.AlertLabel alertLabel2;
    }
}

