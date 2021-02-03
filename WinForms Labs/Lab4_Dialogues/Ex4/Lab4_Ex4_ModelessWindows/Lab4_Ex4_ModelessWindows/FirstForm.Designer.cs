
namespace Lab4_Ex4_ModelessWindows
{
    partial class FirstForm
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
            this.textBoxF1 = new System.Windows.Forms.TextBox();
            this.buttonF1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxF1
            // 
            this.textBoxF1.Location = new System.Drawing.Point(118, 42);
            this.textBoxF1.Name = "textBoxF1";
            this.textBoxF1.Size = new System.Drawing.Size(100, 20);
            this.textBoxF1.TabIndex = 0;
            // 
            // buttonF1
            // 
            this.buttonF1.Location = new System.Drawing.Point(130, 117);
            this.buttonF1.Name = "buttonF1";
            this.buttonF1.Size = new System.Drawing.Size(75, 41);
            this.buttonF1.TabIndex = 1;
            this.buttonF1.Text = "to Second Form";
            this.buttonF1.UseVisualStyleBackColor = true;
            this.buttonF1.Click += new System.EventHandler(this.buttonF1_Click);
            // 
            // FirstForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonF1);
            this.Controls.Add(this.textBoxF1);
            this.Name = "FirstForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxF1;
        private System.Windows.Forms.Button buttonF1;
    }
}

