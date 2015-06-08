namespace CoolWall.Component.FrameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frame));
            this.BorderPanel = new System.Windows.Forms.Panel();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.PictureBoxMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stayOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movePictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lockPictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparency100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparency90ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparency80ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparency70ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparency60ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparency50ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparency40ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparency30ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparency20ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparency10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.changePictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeBorderColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hidePictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletePictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoseFocusLBL = new System.Windows.Forms.Label();
            this.BorderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.PictureBoxMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // BorderPanel
            // 
            resources.ApplyResources(this.BorderPanel, "BorderPanel");
            this.BorderPanel.AllowDrop = true;
            this.BorderPanel.BackColor = System.Drawing.Color.White;
            this.BorderPanel.Controls.Add(this.PictureBox);
            this.BorderPanel.Name = "BorderPanel";
            // 
            // PictureBox
            // 
            resources.ApplyResources(this.PictureBox, "PictureBox");
            this.PictureBox.BackColor = System.Drawing.Color.White;
            this.PictureBox.ContextMenuStrip = this.PictureBoxMenuStrip;
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.TabStop = false;
            // 
            // PictureBoxMenuStrip
            // 
            resources.ApplyResources(this.PictureBoxMenuStrip, "PictureBoxMenuStrip");
            this.PictureBoxMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stayOnTopToolStripMenuItem,
            this.movePictureToolStripMenuItem,
            this.lockPictureToolStripMenuItem,
            this.transparencyToolStripMenuItem,
            this.changeConfigToolStripMenuItem,
            this.toolStripSeparator1,
            this.changePictureToolStripMenuItem,
            this.changeBorderColorToolStripMenuItem,
            this.hidePictureToolStripMenuItem,
            this.deletePictureToolStripMenuItem});
            this.PictureBoxMenuStrip.Name = "PictureBoxMenuStrip";
            this.PictureBoxMenuStrip.ShowCheckMargin = true;
            this.PictureBoxMenuStrip.ShowImageMargin = false;
            // 
            // stayOnTopToolStripMenuItem
            // 
            resources.ApplyResources(this.stayOnTopToolStripMenuItem, "stayOnTopToolStripMenuItem");
            this.stayOnTopToolStripMenuItem.Name = "stayOnTopToolStripMenuItem";
            this.stayOnTopToolStripMenuItem.Click += new System.EventHandler(this.stayOnTopToolStripMenuItem_Click);
            // 
            // movePictureToolStripMenuItem
            // 
            resources.ApplyResources(this.movePictureToolStripMenuItem, "movePictureToolStripMenuItem");
            this.movePictureToolStripMenuItem.Name = "movePictureToolStripMenuItem";
            this.movePictureToolStripMenuItem.Click += new System.EventHandler(this.movePictureToolStripMenuItem_Click);
            // 
            // lockPictureToolStripMenuItem
            // 
            resources.ApplyResources(this.lockPictureToolStripMenuItem, "lockPictureToolStripMenuItem");
            this.lockPictureToolStripMenuItem.CheckOnClick = true;
            this.lockPictureToolStripMenuItem.Name = "lockPictureToolStripMenuItem";
            this.lockPictureToolStripMenuItem.Click += new System.EventHandler(this.lockPictureToolStripMenuItem_Click);
            // 
            // transparencyToolStripMenuItem
            // 
            resources.ApplyResources(this.transparencyToolStripMenuItem, "transparencyToolStripMenuItem");
            this.transparencyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transparency100ToolStripMenuItem,
            this.transparency90ToolStripMenuItem,
            this.transparency80ToolStripMenuItem,
            this.transparency70ToolStripMenuItem,
            this.transparency60ToolStripMenuItem,
            this.transparency50ToolStripMenuItem,
            this.transparency40ToolStripMenuItem,
            this.transparency30ToolStripMenuItem,
            this.transparency20ToolStripMenuItem,
            this.transparency10ToolStripMenuItem});
            this.transparencyToolStripMenuItem.Name = "transparencyToolStripMenuItem";
            this.transparencyToolStripMenuItem.Tag = "";
            // 
            // transparency100ToolStripMenuItem
            // 
            resources.ApplyResources(this.transparency100ToolStripMenuItem, "transparency100ToolStripMenuItem");
            this.transparency100ToolStripMenuItem.Name = "transparency100ToolStripMenuItem";
            this.transparency100ToolStripMenuItem.Click += new System.EventHandler(this.transparency100ToolStripMenuItem_Click);
            // 
            // transparency90ToolStripMenuItem
            // 
            resources.ApplyResources(this.transparency90ToolStripMenuItem, "transparency90ToolStripMenuItem");
            this.transparency90ToolStripMenuItem.Name = "transparency90ToolStripMenuItem";
            this.transparency90ToolStripMenuItem.Click += new System.EventHandler(this.transparency90ToolStripMenuItem_Click);
            // 
            // transparency80ToolStripMenuItem
            // 
            resources.ApplyResources(this.transparency80ToolStripMenuItem, "transparency80ToolStripMenuItem");
            this.transparency80ToolStripMenuItem.Name = "transparency80ToolStripMenuItem";
            this.transparency80ToolStripMenuItem.Click += new System.EventHandler(this.transparency80ToolStripMenuItem_Click);
            // 
            // transparency70ToolStripMenuItem
            // 
            resources.ApplyResources(this.transparency70ToolStripMenuItem, "transparency70ToolStripMenuItem");
            this.transparency70ToolStripMenuItem.Name = "transparency70ToolStripMenuItem";
            this.transparency70ToolStripMenuItem.Click += new System.EventHandler(this.transparency70ToolStripMenuItem_Click);
            // 
            // transparency60ToolStripMenuItem
            // 
            resources.ApplyResources(this.transparency60ToolStripMenuItem, "transparency60ToolStripMenuItem");
            this.transparency60ToolStripMenuItem.Name = "transparency60ToolStripMenuItem";
            this.transparency60ToolStripMenuItem.Click += new System.EventHandler(this.transparency60ToolStripMenuItem_Click);
            // 
            // transparency50ToolStripMenuItem
            // 
            resources.ApplyResources(this.transparency50ToolStripMenuItem, "transparency50ToolStripMenuItem");
            this.transparency50ToolStripMenuItem.Name = "transparency50ToolStripMenuItem";
            this.transparency50ToolStripMenuItem.Click += new System.EventHandler(this.transparency50ToolStripMenuItem_Click);
            // 
            // transparency40ToolStripMenuItem
            // 
            resources.ApplyResources(this.transparency40ToolStripMenuItem, "transparency40ToolStripMenuItem");
            this.transparency40ToolStripMenuItem.Name = "transparency40ToolStripMenuItem";
            this.transparency40ToolStripMenuItem.Click += new System.EventHandler(this.transparency40ToolStripMenuItem_Click);
            // 
            // transparency30ToolStripMenuItem
            // 
            resources.ApplyResources(this.transparency30ToolStripMenuItem, "transparency30ToolStripMenuItem");
            this.transparency30ToolStripMenuItem.Name = "transparency30ToolStripMenuItem";
            this.transparency30ToolStripMenuItem.Click += new System.EventHandler(this.transparency30ToolStripMenuItem_Click);
            // 
            // transparency20ToolStripMenuItem
            // 
            resources.ApplyResources(this.transparency20ToolStripMenuItem, "transparency20ToolStripMenuItem");
            this.transparency20ToolStripMenuItem.Name = "transparency20ToolStripMenuItem";
            this.transparency20ToolStripMenuItem.Click += new System.EventHandler(this.transparency20ToolStripMenuItem_Click);
            // 
            // transparency10ToolStripMenuItem
            // 
            resources.ApplyResources(this.transparency10ToolStripMenuItem, "transparency10ToolStripMenuItem");
            this.transparency10ToolStripMenuItem.Name = "transparency10ToolStripMenuItem";
            this.transparency10ToolStripMenuItem.Click += new System.EventHandler(this.transparency10ToolStripMenuItem_Click);
            // 
            // changeConfigToolStripMenuItem
            // 
            resources.ApplyResources(this.changeConfigToolStripMenuItem, "changeConfigToolStripMenuItem");
            this.changeConfigToolStripMenuItem.Name = "changeConfigToolStripMenuItem";
            this.changeConfigToolStripMenuItem.Click += new System.EventHandler(this.changeConfigToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // changePictureToolStripMenuItem
            // 
            resources.ApplyResources(this.changePictureToolStripMenuItem, "changePictureToolStripMenuItem");
            this.changePictureToolStripMenuItem.Name = "changePictureToolStripMenuItem";
            this.changePictureToolStripMenuItem.Click += new System.EventHandler(this.changePictureToolStripMenuItem_Click);
            // 
            // changeBorderColorToolStripMenuItem
            // 
            resources.ApplyResources(this.changeBorderColorToolStripMenuItem, "changeBorderColorToolStripMenuItem");
            this.changeBorderColorToolStripMenuItem.Name = "changeBorderColorToolStripMenuItem";
            this.changeBorderColorToolStripMenuItem.Click += new System.EventHandler(this.changeBorderColorToolStripMenuItem_Click);
            // 
            // hidePictureToolStripMenuItem
            // 
            resources.ApplyResources(this.hidePictureToolStripMenuItem, "hidePictureToolStripMenuItem");
            this.hidePictureToolStripMenuItem.Name = "hidePictureToolStripMenuItem";
            this.hidePictureToolStripMenuItem.Click += new System.EventHandler(this.hidePictureToolStripMenuItem_Click);
            // 
            // deletePictureToolStripMenuItem
            // 
            resources.ApplyResources(this.deletePictureToolStripMenuItem, "deletePictureToolStripMenuItem");
            this.deletePictureToolStripMenuItem.Name = "deletePictureToolStripMenuItem";
            this.deletePictureToolStripMenuItem.Click += new System.EventHandler(this.deletePictureToolStripMenuItem_Click);
            // 
            // LoseFocusLBL
            // 
            resources.ApplyResources(this.LoseFocusLBL, "LoseFocusLBL");
            this.LoseFocusLBL.BackColor = System.Drawing.Color.Crimson;
            this.LoseFocusLBL.Name = "LoseFocusLBL";
            // 
            // Frame
            // 
            resources.ApplyResources(this, "$this");
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Crimson;
            this.ControlBox = false;
            this.Controls.Add(this.LoseFocusLBL);
            this.Controls.Add(this.BorderPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frame";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.TransparencyKey = System.Drawing.Color.Crimson;
            this.BorderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.PictureBoxMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel BorderPanel;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.Label LoseFocusLBL;
        private System.Windows.Forms.ContextMenuStrip PictureBoxMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem changePictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movePictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lockPictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hidePictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stayOnTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem transparencyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transparency100ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transparency90ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transparency80ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transparency70ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transparency60ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transparency50ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transparency40ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transparency30ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transparency20ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transparency10ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletePictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeBorderColorToolStripMenuItem;

    }
}