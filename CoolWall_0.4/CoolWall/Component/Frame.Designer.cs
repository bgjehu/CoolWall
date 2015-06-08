namespace CoolWall.Component
{
    partial class Frame
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
            this.components = new System.ComponentModel.Container();
            this.PicturePB = new System.Windows.Forms.PictureBox();
            this.PictureBoxMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stayOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hidePictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletePictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoseFocusLBL = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PicturePB)).BeginInit();
            this.PictureBoxMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // PicturePB
            // 
            this.PicturePB.ContextMenuStrip = this.PictureBoxMenuStrip;
            this.PicturePB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicturePB.Location = new System.Drawing.Point(0, 0);
            this.PicturePB.Margin = new System.Windows.Forms.Padding(0);
            this.PicturePB.Name = "PicturePB";
            this.PicturePB.Size = new System.Drawing.Size(300, 300);
            this.PicturePB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicturePB.TabIndex = 0;
            this.PicturePB.TabStop = false;
            this.PicturePB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicturePB_MouseDown);
            this.PicturePB.MouseEnter += new System.EventHandler(this.PicturePB_MouseEnter);
            this.PicturePB.MouseLeave += new System.EventHandler(this.PicturePB_MouseLeave);
            this.PicturePB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicturePB_MouseMove);
            this.PicturePB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicturePB_MouseUp);
            this.PicturePB.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.PicturePB_MouseWheel);
            // 
            // PictureBoxMenuStrip
            // 
            this.PictureBoxMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stayOnTopToolStripMenuItem,
            this.changePictureToolStripMenuItem,
            this.hidePictureToolStripMenuItem,
            this.deletePictureToolStripMenuItem});
            this.PictureBoxMenuStrip.Name = "PictureBoxMenuStrip";
            this.PictureBoxMenuStrip.Size = new System.Drawing.Size(164, 92);
            // 
            // stayOnTopToolStripMenuItem
            // 
            this.stayOnTopToolStripMenuItem.CheckOnClick = true;
            this.stayOnTopToolStripMenuItem.Name = "stayOnTopToolStripMenuItem";
            this.stayOnTopToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.stayOnTopToolStripMenuItem.Text = "Stay On Top";
            this.stayOnTopToolStripMenuItem.Click += new System.EventHandler(this.stayOnTopToolStripMenuItem_Click);
            // 
            // changePictureToolStripMenuItem
            // 
            this.changePictureToolStripMenuItem.Name = "changePictureToolStripMenuItem";
            this.changePictureToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.changePictureToolStripMenuItem.Text = "Change Picture";
            this.changePictureToolStripMenuItem.Click += new System.EventHandler(this.changePictureToolStripMenuItem_Click);
            // 
            // hidePictureToolStripMenuItem
            // 
            this.hidePictureToolStripMenuItem.Name = "hidePictureToolStripMenuItem";
            this.hidePictureToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.hidePictureToolStripMenuItem.Text = "Hide Picture";
            this.hidePictureToolStripMenuItem.Click += new System.EventHandler(this.hidePictureToolStripMenuItem_Click);
            // 
            // deletePictureToolStripMenuItem
            // 
            this.deletePictureToolStripMenuItem.Name = "deletePictureToolStripMenuItem";
            this.deletePictureToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.deletePictureToolStripMenuItem.Text = "Delete Picture";
            this.deletePictureToolStripMenuItem.Click += new System.EventHandler(this.deletePictureToolStripMenuItem_Click);
            // 
            // LoseFocusLBL
            // 
            this.LoseFocusLBL.AutoSize = true;
            this.LoseFocusLBL.Location = new System.Drawing.Point(247, 279);
            this.LoseFocusLBL.Name = "LoseFocusLBL";
            this.LoseFocusLBL.Size = new System.Drawing.Size(0, 12);
            this.LoseFocusLBL.TabIndex = 1;
            // 
            // Frame
            // 
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Frame_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.Frame_DragOver);
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.LoseFocusLBL);
            this.Controls.Add(this.PicturePB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frame";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Frame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frame_Closing);
            this.Resize += new System.EventHandler(this.Frame_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.PicturePB)).EndInit();
            this.PictureBoxMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicturePB;
        private System.Windows.Forms.ContextMenuStrip PictureBoxMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem changePictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hidePictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletePictureToolStripMenuItem;
        private System.Windows.Forms.Label LoseFocusLBL;
        private System.Windows.Forms.ToolStripMenuItem stayOnTopToolStripMenuItem;

    }
}