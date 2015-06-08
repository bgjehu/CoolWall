using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoolWall.Class;

namespace CoolWall.Component.FrameForm
{
    public partial class Frame : Form
    {
        
        public Frame()
        {
            InitializeComponent();
            InitializeDataModelComponent();
            //  Default Setting
            this.Image = ExtensionMethods.ErrorImage;
            MoveToScreenCenter();
            this.MagnifyRate = 1;
            this.Opacity = 1;
            this.BorderColor = Color.White;
            this.Visible = true;
            this.TopMost = false;
            this.Locked = false;
        }
        public Frame(Image image)
        {
            InitializeComponent();
            InitializeDataModelComponent();
            if (image != null) 
            {
                this.Image = image;
            }
            else
            {
                this.Image = ExtensionMethods.ErrorImage;
            }
            this.MagnifyRate = 1;
            MoveToScreenCenter();
            this.Opacity = 1;
            this.BorderColor = Color.White;
            this.Visible = true;
            this.TopMost = false;
            this.Locked = false;
        }
        public Frame(FrameConfig frameConfig)
        {
            InitializeComponent();
            InitializeDataModelComponent();
            //  Defined Setting
            this.FrameConfig = frameConfig;
        }

        #region Private Utilities Function

        private void MoveToScreenCenter()
        {
            int left = Convert.ToInt32((System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - this.Width) / 2);
            int top = Convert.ToInt32((System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
            this.Location = new Point(left, top);
        }

        #region Custom InitializeComponent()

        private ToolStripMenuItem[] transparencyToolStripMenuItems = new ToolStripMenuItem[10];
        private void InitializeDataModelComponent()
        {
            //  Custom Events
            this.ImageChanged += new EventHandler(this.Frame_ImageChanged);
            this.FrameLocationChanged += new EventHandler(this.Frame_LocationChanged);
            this.ImageSizeChanged += new EventHandler(this.Image_SizeChanged);
            this.OpacityChanged += new EventHandler(this.Frame_OpacityChanged);
            this.BorderColorChanged += new EventHandler(this.Frame_BorderColorChanged);
            this.BorderWidthChanged += new EventHandler(this.Frame_BorderWidthChanged);
            this.VisibleChanged += new EventHandler(this.Frame_VisibleChanged);
            this.TopMostChanged += new EventHandler(this.Frame_TopMostChanged);
            this.LockedChanged += new EventHandler(this.Frame_LockedChanged);
            this.PictureBox.MouseDown += new MouseEventHandler(this.PictureBox_MouseDown);
            this.PictureBox.MouseUp += new MouseEventHandler(this.PictureBox_MouseUp);
            this.PictureBox.MouseMove += new MouseEventHandler(this.PictureBox_MouseMove);
            this.PictureBox.MouseEnter += new EventHandler(this.PictureBox_MouseEnter);
            this.PictureBox.MouseLeave += new EventHandler(this.PictureBox_MouseLeave);
            this.PictureBox.MouseWheel += new MouseEventHandler(this.PictureBox_MouseWheel);
            this.PictureBox.MouseDoubleClick += new MouseEventHandler(this.PictureBox_MouseDoubleClick);
            this.BorderPanel.DragDrop += new DragEventHandler(this.Frame_DragDrop);
            this.BorderPanel.DragOver += new DragEventHandler(this.Frame_DragOver);

            //  Transparency ToolStripMenuItems
            this.transparencyToolStripMenuItems[0] = transparency10ToolStripMenuItem;
            this.transparencyToolStripMenuItems[1] = transparency20ToolStripMenuItem;
            this.transparencyToolStripMenuItems[2] = transparency30ToolStripMenuItem;
            this.transparencyToolStripMenuItems[3] = transparency40ToolStripMenuItem;
            this.transparencyToolStripMenuItems[4] = transparency50ToolStripMenuItem;
            this.transparencyToolStripMenuItems[5] = transparency60ToolStripMenuItem;
            this.transparencyToolStripMenuItems[6] = transparency70ToolStripMenuItem;
            this.transparencyToolStripMenuItems[7] = transparency80ToolStripMenuItem;
            this.transparencyToolStripMenuItems[8] = transparency90ToolStripMenuItem;
            this.transparencyToolStripMenuItems[9] = transparency100ToolStripMenuItem;
        }

        private void TransToolStripMatchesOpacity()
        {
            foreach (ToolStripMenuItem item in this.transparencyToolStripMenuItems) { item.Checked = false; }
            int index = (int)(this.Opacity * 10) - 1;
            this.transparencyToolStripMenuItems[index].Checked = true;
        }

        #endregion



        #endregion

        #region Public Utilities Function

        public new void Hide()
        {
            this.Visible = false;
        }
        public new void Show()
        {
            this.Visible = true;
        }
        public void RestoreDefaultCofig()
        {
            this.Image = ExtensionMethods.NullImage;

            int left = Convert.ToInt32((System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - this.Width) / 2);
            int top = Convert.ToInt32((System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
            this.Location = new Point(left, top);

            this.MagnifyRate = 1;
            this.Opacity = 1;
            this.Visible = true;
            this.TopMost = false;
            this.Locked = false;
        }

        #endregion



        



        
        
        
    }
}
