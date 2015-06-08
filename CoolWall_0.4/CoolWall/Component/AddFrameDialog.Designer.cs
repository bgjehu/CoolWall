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
            this.FileNamesTB.Location = new System.Drawing.Point(12, 13);
            this.FileNamesTB.Multiline = true;
            this.FileNamesTB.Name = "FileNamesTB";
            this.FileNamesTB.Size = new System.Drawing.Size(590, 255);
            this.FileNamesTB.TabIndex = 0;
            this.FileNamesTB.TextChanged += new System.EventHandler(this.FileNamesTB_TextChanged);
            // 
            // AddBTN
            // 
            this.AddBTN.Location = new System.Drawing.Point(446, 275);
            this.AddBTN.Name = "AddBTN";
            this.AddBTN.Size = new System.Drawing.Size(75, 25);
            this.AddBTN.TabIndex = 1;
            this.AddBTN.Text = "Add";
            this.AddBTN.UseVisualStyleBackColor = true;
            this.AddBTN.Click += new System.EventHandler(this.AddBTN_Click);
            // 
            // SubmitBTN
            // 
            this.SubmitBTN.Location = new System.Drawing.Point(527, 275);
            this.SubmitBTN.Name = "SubmitBTN";
            this.SubmitBTN.Size = new System.Drawing.Size(75, 25);
            this.SubmitBTN.TabIndex = 2;
            this.SubmitBTN.Text = "Submit";
            this.SubmitBTN.UseVisualStyleBackColor = true;
            this.SubmitBTN.Click += new System.EventHandler(this.SubmitBTN_Click);
            // 
            // AddFrameDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 306);
            this.Controls.Add(this.SubmitBTN);
            this.Controls.Add(this.AddBTN);
            this.Controls.Add(this.FileNamesTB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddFrameDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add More Pictures";
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