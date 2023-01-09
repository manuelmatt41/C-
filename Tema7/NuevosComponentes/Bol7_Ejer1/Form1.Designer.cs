namespace Bol7_Ejer1
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
            this.btChangePosition = new System.Windows.Forms.Button();
            this.btAddSeparation = new System.Windows.Forms.Button();
            this.btCheck = new System.Windows.Forms.Button();
            this.etiquetaAviso1 = new NuevosComponentes.EtiquetaAviso();
            this.labelTextBox1 = new NuevosComponentes.LabelTextBox();
            this.SuspendLayout();
            // 
            // btChangePosition
            // 
            this.btChangePosition.Location = new System.Drawing.Point(77, 113);
            this.btChangePosition.Name = "btChangePosition";
            this.btChangePosition.Size = new System.Drawing.Size(113, 23);
            this.btChangePosition.TabIndex = 1;
            this.btChangePosition.Text = "Change position";
            this.btChangePosition.UseVisualStyleBackColor = true;
            this.btChangePosition.Click += new System.EventHandler(this.ClickChangePosition);
            // 
            // btAddSeparation
            // 
            this.btAddSeparation.Location = new System.Drawing.Point(196, 113);
            this.btAddSeparation.Name = "btAddSeparation";
            this.btAddSeparation.Size = new System.Drawing.Size(92, 23);
            this.btAddSeparation.TabIndex = 2;
            this.btAddSeparation.Text = "Add separation";
            this.btAddSeparation.UseVisualStyleBackColor = true;
            this.btAddSeparation.Click += new System.EventHandler(this.ClickAddSeparation);
            // 
            // btCheck
            // 
            this.btCheck.Location = new System.Drawing.Point(249, 179);
            this.btCheck.Name = "btCheck";
            this.btCheck.Size = new System.Drawing.Size(75, 23);
            this.btCheck.TabIndex = 4;
            this.btCheck.Text = "Mark";
            this.btCheck.UseVisualStyleBackColor = true;
            this.btCheck.Click += new System.EventHandler(this.ClickMarkEtiquetaAvisp);
            // 
            // etiquetaAviso1
            // 
            this.etiquetaAviso1.Location = new System.Drawing.Point(77, 176);
            this.etiquetaAviso1.Marca = NuevosComponentes.Marca.NOTHING;
            this.etiquetaAviso1.Name = "etiquetaAviso1";
            this.etiquetaAviso1.Size = new System.Drawing.Size(113, 20);
            this.etiquetaAviso1.TabIndex = 3;
            this.etiquetaAviso1.Text = "etiquetaAviso1";
            // 
            // labelTextBox1
            // 
            this.labelTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTextBox1.Location = new System.Drawing.Point(106, 60);
            this.labelTextBox1.Name = "labelTextBox1";
            this.labelTextBox1.Position = NuevosComponentes.Posicion.LEFT;
            this.labelTextBox1.PswChr = '\0';
            this.labelTextBox1.Separacion = 0;
            this.labelTextBox1.Size = new System.Drawing.Size(172, 20);
            this.labelTextBox1.TabIndex = 0;
            this.labelTextBox1.TextTxt = "";
            this.labelTextBox1.TxtLbl = "LabelTextBox";
            this.labelTextBox1.CambiaPosicion += new System.EventHandler(this.CambiaPosicionChangeTitle);
            this.labelTextBox1.CambiaSeparacion += new System.EventHandler(this.CambiaSeparacionShowSeparation);
            this.labelTextBox1.TxtChanged += new System.EventHandler(this.TextChangeChangeTitle);
            this.labelTextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUpChangeTitle);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btCheck);
            this.Controls.Add(this.etiquetaAviso1);
            this.Controls.Add(this.btAddSeparation);
            this.Controls.Add(this.btChangePosition);
            this.Controls.Add(this.labelTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private NuevosComponentes.LabelTextBox labelTextBox1;
        private System.Windows.Forms.Button btChangePosition;
        private System.Windows.Forms.Button btAddSeparation;
        private NuevosComponentes.EtiquetaAviso etiquetaAviso1;
        private System.Windows.Forms.Button btCheck;
    }
}

