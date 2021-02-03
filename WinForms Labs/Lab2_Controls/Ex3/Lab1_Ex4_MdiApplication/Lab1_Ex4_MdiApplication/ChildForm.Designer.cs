
namespace Lab1_Ex4_MdiApplication
{
    partial class ChildForm
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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.ChildTextBox = new System.Windows.Forms.RichTextBox();
            this.ChildWindowMenu = new System.Windows.Forms.MenuStrip();
            this.FormatMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToggleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.ChildWindowMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(626, 216);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 0;
            // 
            // ChildTextBox
            // 
            this.ChildTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChildTextBox.Location = new System.Drawing.Point(0, 24);
            this.ChildTextBox.Name = "ChildTextBox";
            this.ChildTextBox.Size = new System.Drawing.Size(800, 426);
            this.ChildTextBox.TabIndex = 1;
            this.ChildTextBox.Text = "";
            // 
            // ChildWindowMenu
            // 
            this.ChildWindowMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FormatMenuItem});
            this.ChildWindowMenu.Location = new System.Drawing.Point(0, 0);
            this.ChildWindowMenu.Name = "ChildWindowMenu";
            this.ChildWindowMenu.Size = new System.Drawing.Size(800, 24);
            this.ChildWindowMenu.TabIndex = 2;
            this.ChildWindowMenu.Text = "menuStrip1";
            // 
            // FormatMenuItem
            // 
            this.FormatMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToggleMenuItem});
            this.FormatMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.FormatMenuItem.Name = "FormatMenuItem";
            this.FormatMenuItem.Size = new System.Drawing.Size(57, 20);
            this.FormatMenuItem.Text = "F&ormat";

            // 
            // ToggleMenuItem
            // 
            this.ToggleMenuItem.Name = "ToggleMenuItem";
            this.ToggleMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ToggleMenuItem.Text = "&Toggle Foreground";
            this.ToggleMenuItem.Click += new System.EventHandler(this.ToggleMenuItem_Click);
            // 
            // ChildForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ChildTextBox);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.ChildWindowMenu);
            this.MainMenuStrip = this.ChildWindowMenu;
            this.Name = "ChildForm";
            this.Text = "Child Form";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ChildWindowMenu.ResumeLayout(false);
            this.ChildWindowMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.RichTextBox ChildTextBox;
        private System.Windows.Forms.MenuStrip ChildWindowMenu;
        private System.Windows.Forms.ToolStripMenuItem FormatMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToggleMenuItem;
    }
}