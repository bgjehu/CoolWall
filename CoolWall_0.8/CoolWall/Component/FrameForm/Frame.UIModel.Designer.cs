using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using CoolWall.Component;
using CoolWall.Class;

namespace CoolWall.Component.FrameForm
{
    public partial class Frame
    {
        static double ZoomFactor = 0.02;
        static double OpacityFactor = 0.1;  //  this cannot be set under 0.1 because the menustrips
        Point MouseDownPosition;
        Boolean FrameMoving;

        #region Mouse Events

        private void PictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Locked = !this.Locked;
        }
        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseDownPosition != Point.Empty)
            {
                if (e.Button == MouseButtons.Middle || (this.FrameMoving && e.Button == MouseButtons.Left))
                {
                    //  Drag and Move
                    int dx = e.X - MouseDownPosition.X;
                    int dy = e.Y - MouseDownPosition.Y;
                    this.Location = new Point(this.Left + dx, this.Top + dy);
                }
                else { /*  Do nothing  */ }
            }
        }
        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle || (this.FrameMoving && e.Button == MouseButtons.Left))
            {
                MouseDownPosition = e.Location;
            }
            else { /*  Do nothing  */ }
        }
        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            MouseDownPosition = Point.Empty;
        }
        private void PictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            Control ctrl = sender as Control;
            double wheelCount = (double)e.Delta / (double)120;

            if (ModifierKeys.HasFlag(Keys.Shift))   //  wheel + shift   changes opacity
            {
                double delta = wheelCount * OpacityFactor;
                if (ModifierKeys.HasFlag(Keys.Control))
                {
                    delta = wheelCount * OpacityFactor * 5;
                }
                this.Opacity += delta;
            }
            else if (ModifierKeys.HasFlag(Keys.Alt))    //  wheel + alt   changes borderColor
            {
                double delta = wheelCount;
                if (ModifierKeys.HasFlag(Keys.Control))
                {
                    delta = wheelCount * 5;
                }
                this.BorderWidth += Convert.ToInt32(Math.Ceiling(delta));
            }
            else //  wheel  changes size
            {
                double delta = wheelCount * ZoomFactor;
                if (ModifierKeys.HasFlag(Keys.Control))
                {
                    delta = wheelCount * ZoomFactor * 5;
                }
                this.MagnifyRate += delta;
            }
        }
        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            if (!ctrl.Focused) { ctrl.Focus(); }
        }
        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            if (ctrl.Focused) { LoseFocusLBL.Focus(); }
        }

        #endregion

        #region DragDrop

        private void Frame_DragOver(object sender, DragEventArgs e)
        {
            string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
            string[] validFileNames = fileNames.Where(i => i.IsImageFile() > 0).ToArray();

            if (validFileNames.Count() > 0)
            {
                switch (e.KeyState)
                {
                    case 0:
                        //  mac three fingers drag
                    case 1:
                        //  left drag
                        e.Effect = DragDropEffects.Link;
                        break;
                    case 8:
                    case 9:
                        e.Effect = DragDropEffects.Copy;
                        break;
                    default:
                        e.Effect = DragDropEffects.None;
                        break;
                }
            }
        }
        private void Frame_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
            string[] validFileNames = fileNames.Where(i => i.IsImageFile() > 0).ToArray();
            if (validFileNames.Count() > 0)
            {
                switch (e.KeyState)
                {
                    case 0:
                    //  mac three fingers drag
                    case 1:
                        //  left drag
                        Image target=validFileNames[0].GetImage();
                        if (target != null)
                        { this.Image = target; }
                        break;
                    case 8:             //  Need for debugging
                    case 9:
                        this.MainControl.AddFrame(validFileNames);
                        break;
                    default:
                        e.Effect = DragDropEffects.None;
                        break;
                }
            }
        }

        #endregion

        #region MenuStrips Events

        private void changePictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.Locked)
            {
                using (ChangeImageDialog cid = new ChangeImageDialog())
                {
                    if (cid.ShowDialog() == DialogResult.OK)
                    {
                        this.Image = cid.FileName.GetImage();
                    }
                }
            }
        }

        private void stayOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.Locked)
            {
                this.TopMost = !this.TopMost;
            }
        }

        private void movePictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.Locked)
            {
                this.FrameMoving = !this.FrameMoving;
                this.movePictureToolStripMenuItem.Checked = !this.movePictureToolStripMenuItem.Checked;
            }
        }

        private void lockPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Locked = !this.Locked;
        }

        private void hidePictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void changeConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deletePictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void changeBorderColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.Locked)
            {
                using (ColorDialog cd = new ColorDialog())
                {
                    if (cd.ShowDialog() == DialogResult.OK)
                    {
                        this.BorderColor = cd.Color;
                    }
                }
            }
        }

        #endregion

        #region Transparency MenuStrips Events

        private void transparency100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }

        private void transparency90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Opacity = .9;
        }

        private void transparency80ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Opacity = .8;
        }

        private void transparency70ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Opacity = .7;
        }

        private void transparency60ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Opacity = .6;
        }

        private void transparency50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Opacity = .5;
        }

        private void transparency40ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Opacity = .4;
        }

        private void transparency30ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Opacity = .3;
        }

        private void transparency20ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Opacity = .2;
        }

        private void transparency10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Opacity = .1;
        }

        #endregion
    }
}
