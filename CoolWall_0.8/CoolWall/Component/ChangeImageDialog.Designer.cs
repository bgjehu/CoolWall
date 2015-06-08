namespace CoolWall.Component
{
    partial class ChangeImageDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeImageDialog));
            this.FileNameTB = new System.Windows.Forms.TextBox();
            this.BrowseBTN = new System.Windows.Forms.Button();
            this.ChangeBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FileNameTB
            // 
            resources.ApplyResources(this.FileNameTB, "FileNameTB");
            this.FileNameTB.Name = "FileNameTB";
            // 
            // BrowseBTN
            // 
            resources.ApplyResources(this.BrowseBTN, "BrowseBTN");
            this.BrowseBTN.Name = "BrowseBTN";
            this.BrowseBTN.UseVisualStyleBackColor = true;
            this.BrowseBTN.Click += new System.EventHandler(this.BrowseBTN_Click);
            // 
            // ChangeBTN
            // 
            resources.ApplyResources(this.ChangeBTN, "ChangeBTN");
            this.ChangeBTN.Name = "ChangeBTN";
            this.ChangeBTN.UseVisualStyleBackColor = true;
            this.ChangeBTN.Click += new System.EventHandler(this.ChangeBTN_Click);
            // 
            // ChangeImageDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ChangeBTN);
            this.Controls.Add(this.BrowseBTN);
            this.Controls.Add(this.FileNameTB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ChangeImageDialog";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FileNameTB;
        private System.Windows.Forms.Button BrowseBTN;
        private System.Windows.Forms.Button ChangeBTN;
    }
}