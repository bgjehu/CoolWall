namespace CoolWall.Component
{
    partial class AddFrameDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFrameDialog));
            this.FileNamesTB = new System.Windows.Forms.TextBox();
            this.AddBTN = new System.Windows.Forms.Button();
            this.SubmitBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FileNamesTB
            // 
            resources.ApplyResources(this.FileNamesTB, "FileNamesTB");
            this.FileNamesTB.Name = "FileNamesTB";
            this.FileNamesTB.TextChanged += new System.EventHandler(this.FileNamesTB_TextChanged);
            // 
            // AddBTN
            // 
            resources.ApplyResources(this.AddBTN, "AddBTN");
            this.AddBTN.Name = "AddBTN";
            this.AddBTN.UseVisualStyleBackColor = true;
            this.AddBTN.Click += new System.EventHandler(this.AddBTN_Click);
            // 
            // SubmitBTN
            // 
            resources.ApplyResources(this.SubmitBTN, "SubmitBTN");
            this.SubmitBTN.Name = "SubmitBTN";
            this.SubmitBTN.UseVisualStyleBackColor = true;
            this.SubmitBTN.Click += new System.EventHandler(this.SubmitBTN_Click);
            // 
            // AddFrameDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SubmitBTN);
            this.Controls.Add(this.AddBTN);
            this.Controls.Add(this.FileNamesTB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AddFrameDialog";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FileNamesTB;
        private System.Windows.Forms.Button AddBTN;
        private System.Windows.Forms.Button SubmitBTN;


    }
}