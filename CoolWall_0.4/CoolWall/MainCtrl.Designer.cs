namespace CoolWall
{
    partial class MainCtrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainCtrl));
            this.NotifyIconMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addPicturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllPicutresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideAllPicturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllPicturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyIconMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // NotifyIconMenuStrip
            // 
            this.NotifyIconMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPicturesToolStripMenuItem,
            this.showAllPicutresToolStripMenuItem,
            this.hideAllPicturesToolStripMenuItem,
            this.deleteAllPicturesToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.NotifyIconMenuStrip.Name = "NotifyIconMenuStrip";
            this.NotifyIconMenuStrip.Size = new System.Drawing.Size(181, 114);
            // 
            // addPicturesToolStripMenuItem
            // 
            this.addPicturesToolStripMenuItem.Name = "addPicturesToolStripMenuItem";
            this.addPicturesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addPicturesToolStripMenuItem.Text = "Add Pictures";
            this.addPicturesToolStripMenuItem.Click += new System.EventHandler(this.addPicturesToolStripMenuItem_Click);
            // 
            // showAllPicutresToolStripMenuItem
            // 
            this.showAllPicutresToolStripMenuItem.Name = "showAllPicutresToolStripMenuItem";
            this.showAllPicutresToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showAllPicutresToolStripMenuItem.Text = "Show All Picutres";
            this.showAllPicutresToolStripMenuItem.Click += new System.EventHandler(this.showAllPicutresToolStripMenuItem_Click);
            // 
            // hideAllPicturesToolStripMenuItem
            // 
            this.hideAllPicturesToolStripMenuItem.Name = "hideAllPicturesToolStripMenuItem";
            this.hideAllPicturesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.hideAllPicturesToolStripMenuItem.Text = "Hide All Pictures";
            this.hideAllPicturesToolStripMenuItem.Click += new System.EventHandler(this.hideAllPicturesToolStripMenuItem_Click);
            // 
            // deleteAllPicturesToolStripMenuItem
            // 
            this.deleteAllPicturesToolStripMenuItem.Name = "deleteAllPicturesToolStripMenuItem";
            this.deleteAllPicturesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteAllPicturesToolStripMenuItem.Text = "Delete All Pictures";
            this.deleteAllPicturesToolStripMenuItem.Click += new System.EventHandler(this.deleteAllPicturesToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.ContextMenuStrip = this.NotifyIconMenuStrip;
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // MainCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Crimson;
            this.ClientSize = new System.Drawing.Size(10, 10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainCtrl";
            this.ShowInTaskbar = false;
            this.Text = "Main";
            this.TransparencyKey = System.Drawing.Color.Crimson;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainCtrl_Closing);
            this.Load += new System.EventHandler(this.MainCtrl_Load);
            this.NotifyIconMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip NotifyIconMenuStrip;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem addPicturesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllPicutresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideAllPicturesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAllPicturesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

