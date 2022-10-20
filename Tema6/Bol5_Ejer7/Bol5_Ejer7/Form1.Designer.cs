namespace Bol5_Ejer7
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.studentCB = new System.Windows.Forms.ComboBox();
            this.subjectCB = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // studentCB
            // 
            this.studentCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.studentCB.FormattingEnabled = true;
            this.studentCB.Location = new System.Drawing.Point(12, 12);
            this.studentCB.Name = "studentCB";
            this.studentCB.Size = new System.Drawing.Size(191, 23);
            this.studentCB.TabIndex = 0;
            this.studentCB.SelectedIndexChanged += new System.EventHandler(this.studentCB_SelectedIndexChanged);
            // 
            // subjectCB
            // 
            this.subjectCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subjectCB.FormattingEnabled = true;
            this.subjectCB.Location = new System.Drawing.Point(209, 12);
            this.subjectCB.Name = "subjectCB";
            this.subjectCB.Size = new System.Drawing.Size(172, 23);
            this.subjectCB.TabIndex = 1;
            this.subjectCB.SelectedIndexChanged += new System.EventHandler(this.subjectCB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(387, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.subjectCB);
            this.Controls.Add(this.studentCB);
            this.Name = "Form1";
            this.Text = "Exercise 7";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox studentCB;
        private ComboBox subjectCB;
        private ToolTip toolTip1;
        private Label label1;
    }
}