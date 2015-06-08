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

namespace CoolWall.Component
{
    public partial class Frame : Form
    {
        public FrameInfo FrameInfo { get { return _FrameInfo; } }
        FrameInfo _FrameInfo;
        public int PictureLeft { get { return this.Left + (int)(this._BorderWidth / 2); } }
        public int PictureTop { get { return this.Top + (int)(this._BorderHeight / 2); } }
        public int PictureWidth { get { return this.Width - this._BorderWidth; } }
        public int PictureHeight { get { return this.Height - this._BorderHeight; } }

        public double ImageRatio { get { return (double)this._FrameInfo.Image.Width / (double)this._FrameInfo.Image.Height; } }
        //public int BorderWidth { get { return _BorderWidth; } }
        int _BorderWidth;
        //public int BorderHeight { get { return _BorderHeight; } }
        int _BorderHeight;
        static double _MinimunMultiplier = 0.05;
        static double _MaximunMultiplier = 0.8;
        static int _MinimunWidth = (int)(Screen.PrimaryScreen.Bounds.Width * _MinimunMultiplier);
        static int _MinimunHeight = (int)(Screen.PrimaryScreen.Bounds.Height * _MinimunMultiplier);
        static int _MaximunWidth = (int)(Screen.PrimaryScreen.Bounds.Width * _MaximunMultiplier);
        static int _MaximunHeight = (int)(Screen.PrimaryScreen.Bounds.Height * _MaximunMultiplier);
        static double _ZoomMultipler = 0.1;

        Point _MouseDownPosition;
        //Size _FrameOldSize;

        public Frame(FrameInfo fi)
        {
            _FrameInfo = fi;

            InitializeComponent();
            GetBorderInfo();


            //  Load Image to picture box
            PicturePB.Image = _FrameInfo.Image;

            //  Show/Hide
            if (_FrameInfo.Visible) { this.Show(); }
            else { this.Hide(); }

            //  Adjust Location
            int left = _FrameInfo.Location.X - (int)(_BorderWidth / 2);
            int top = _FrameInfo.Location.Y - (int)(_BorderHeight / 2);
            this.Location = new Point(left, top);

            //  Adjust Size
            int width = _FrameInfo.Size.Width + _BorderWidth;
            int height = _FrameInfo.Size.Height + _BorderHeight;
            this.Size = new Size(width, height);

            //  Adjuct Opacity
            this.Opacity = _FrameInfo.Opacity;

            //  Adjust TopMost
            this.TopMost = _FrameInfo.TopMost;
            ChangeTopMostState(this.TopMost);
        }

        public void ChangePicture(Image image)
        {
            this.PicturePB.Image = image;
        }
        private void GetBorderInfo()
        {
            _BorderWidth = this.Width - PicturePB.Width;
            _BorderHeight = this.Height - PicturePB.Height;
        }

        

        private void Frame_Closing(object sender, CancelEventArgs e)
        {
            this._FrameInfo.Dispose();
        }
        private void PicturePB_MouseMove(object sender, MouseEventArgs e)
        {
            if (_MouseDownPosition != Point.Empty)
            {                
                if (e.Button == MouseButtons.Middle)
                {
                    //  Drag and Move
                    int dx = e.X - _MouseDownPosition.X;
                    int dy = e.Y - _MouseDownPosition.Y;
                    this.Location = new Point(this.Left + dx, this.Top + dy);
                }
                else
                {
                    //  Do nothing
                }
            }
        }
        private void PicturePB_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle || e.Button == MouseButtons.Right)
            {
                _MouseDownPosition = e.Location;
            }
        }
        private void PicturePB_MouseUp(object sender, MouseEventArgs e)
        {
            _MouseDownPosition = Point.Empty;
        }
        private void PicturePB_MouseWheel(object sender, MouseEventArgs e)
        {
            //  Change for mac
            Control ctrl = sender as Control;

            double wheelCount = (double)e.Delta / (double)120;
            double delta = wheelCount * _ZoomMultipler;
            double coefficient = 1 + delta;

            if ((wheelCount > 0 && (this.Width == _MaximunWidth || this.Height == _MaximunHeight))
                || (wheelCount < 0 && (this.Width == _MinimunWidth || this.Height == _MinimunHeight)))
            {
                // Wheel Up While Max Out or Wheel Down While Min Out
            }
            else 
            {
                this.Size = new Size((int)(this.Width * coefficient), (int)(this.Height * coefficient));
                this.Location = new Point(this.Left - (int)(e.X * delta), this.Top - (int)(e.Y * delta));
            }
            
            
            
        }
        private void PicturePB_MouseEnter(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            if (!ctrl.Focused) { ctrl.Focus(); }
        }
        private void PicturePB_MouseLeave(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            if (ctrl.Focused) { LoseFocusLBL.Focus(); }
        }
        private void Frame_DragOver(object sender, DragEventArgs e)
        {
            if (IsOverPictureBox(e.X, e.Y))
            {
                if (e.KeyState == 1)
                {
                    e.Effect = DragDropEffects.Link;
                }
                else if (e.KeyState == (1 + 8))
                {
                    //  left drap + ctrl
                    e.Effect = DragDropEffects.Copy;
                }
                else 
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else 
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void Frame_DragDrop(object sender, DragEventArgs e)
        {
            if (e.KeyState == 0)
            {
                //  replace picture
                string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (fileNames.Count() == 1)
                {
                    this._FrameInfo.ChangePicture(fileNames[0]);
                }
                else 
                {
                    MessageBox.Show("You can only replace with ONE picture.");
                }
            }
            else if (e.KeyState == (1 + 8))
            {
                //  Add new frames
            }
            else
            {
                //  Do nothing
            }
        }
        private void Frame_Resize(object sender, EventArgs e)
        {
            if (this.Width > _MaximunWidth)
            {
                this.Size = new Size(_MaximunWidth, (int)(_MaximunWidth / ImageRatio));
            }

            if (this.Height > _MaximunHeight)
            {
                this.Size = new Size((int)(_MaximunHeight * ImageRatio), _MaximunHeight);
            }

            if (this.Width < _MinimunWidth)
            {
                this.Size = new Size(_MinimunWidth, (int)(_MinimunWidth / ImageRatio));
            }

            if (this.Height < _MinimunHeight)
            {
                this.Size = new Size((int)(_MinimunHeight * ImageRatio), _MinimunHeight);
            }
        }

        

        private void hidePictureToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            this._FrameInfo.HideFrame();
        }

        private void deletePictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._FrameInfo.Dispose();
        }

        private void changePictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._FrameInfo.ShowChangePictureDialog();
        }

        private void stayOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeTopMostState();
        }
        private void ChangeTopMostState(bool chked)
        {
            this.TopMost = chked;
            this.stayOnTopToolStripMenuItem.Checked = chked;
        }
        private void ChangeTopMostState()
        {
            bool chked = this.TopMost;
            ChangeTopMostState(!chked);
        }
        private bool IsOverPictureBox(int x, int y)
        {
            int startX = this.Left + PicturePB.Left;
            int endX = this.Left + PicturePB.Left + PicturePB.Width;
            int startY = this.Top + PicturePB.Top;
            int endY = this.Top + PicturePB.Top + PicturePB.Height;
            if (x >= startX && x <= endX && y >= startY && y <= endY)
            {
                return true;
            }
            else { return false; }
        }
    }
}
