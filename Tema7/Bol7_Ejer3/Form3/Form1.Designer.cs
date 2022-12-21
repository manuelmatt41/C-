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
            this.multimediaDisplayButtons1 = new Bol7_Ejer3.MultimediaDisplayButtons();
            this.SuspendLayout();
            // 
            // multimediaDisplayButtons1
            // 
            this.multimediaDisplayButtons1.FirstText = "Play";
            this.multimediaDisplayButtons1.InformationButton = Bol7_Ejer3.InformationDisplay.TEXT;
            this.multimediaDisplayButtons1.Location = new System.Drawing.Point(195, 129);
            this.multimediaDisplayButtons1.Name = "multimediaDisplayButtons1";
            this.multimediaDisplayButtons1.SecondText = "Pause";
            this.multimediaDisplayButtons1.Size = new System.Drawing.Size(227, 79);
            this.multimediaDisplayButtons1.TabIndex = 0;
            this.multimediaDisplayButtons1.TimeFormat = "mm:ss";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.multimediaDisplayButtons1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Bol7_Ejer3.MultimediaDisplayButtons multimediaDisplayButtons1;
    }
}

