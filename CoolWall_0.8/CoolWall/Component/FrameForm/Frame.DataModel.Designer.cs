using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using CoolWall.Class;
using System.Drawing.Imaging;

namespace CoolWall.Component.FrameForm
{
    public partial class Frame
    {
        static int MaximumBorderWidth = 15;
        static double ImageMaximumFactor = 0.5;
        static Size ImageMinimumSize = new Size(50, 50);
        static Size ImageMaximumSize = new Size(Convert.ToInt32(System.Windows.Forms.Screen.AllScreens.Max(i => i.Bounds.Width) * ImageMaximumFactor), Convert.ToInt32(System.Windows.Forms.Screen.AllScreens.Max(i => i.Bounds.Height) * ImageMaximumFactor));
        
        #region Custom EventHandlers

        private event EventHandler ImageChanged;
        private event EventHandler FrameLocationChanged;
        private event EventHandler ImageSizeChanged;
        private event EventHandler OpacityChanged;
        private event EventHandler BorderColorChanged;
        private event EventHandler BorderWidthChanged;
        private new event EventHandler VisibleChanged;
        private event EventHandler TopMostChanged;
        private event EventHandler LockedChanged; 

        #endregion

        #region Custom Attributes

        public MainCtrl MainControl { get; set; }
        public FrameConfig FrameConfig
        {
            get
            {
                FrameConfig frameConfig = new FrameConfig(this.Image.ToImageString(),
                                                          this.Location,
                                                          this.MagnifyRate,
                                                          this.Opacity,
                                                          this.BorderColor,
                                                          this.BorderWidth,
                                                          this.Visible,
                                                          this.TopMost,
                                                          this.Locked);
                return frameConfig;
            }
            set
            {
                if (!this.Locked)
                {
                    this.Image = value.ImageString.ToImage();
                    this.MagnifyRate = value.MagnifyRate;
                    this.Location = value.FrameLocation;
                    this.Opacity = value.Opacity;
                    this.BorderColor = value.BorderColor;
                    this.BorderWidth = value.BorderWidth;
                    this.Visible = value.Visible;
                    this.TopMost = value.TopMost;
                    this.Locked = value.Locked;
                }
            }
        }

        /// <summary>
        /// Gets or sets the image that is displayed by System.Windows.Forms.PictureBox in CoolWall.Component.Frame.
        /// </summary>
        /// <Returns>
        /// The System.Drawing.Image to display.
        /// </Returns>
        public Image Image 
        {
            get { return this.PictureBox.Image; }
            set 
            {
                if (!this.Locked)
                {
                    string oldValue = this.PictureBox.Image.ToImageString();
                    this.PictureBox.Image = value;

                    if (oldValue != value.ToImageString())
                    {
                        double newMagRate = 1;
                        Size newSize = this.Image.Size.Zoom(newMagRate);
                        while (!newSize.SmallerThan(ImageMaximumSize))
                        {
                            newMagRate -= ZoomFactor;
                            newSize = this.Image.Size.Zoom(newMagRate);
                        }
                        while (!newSize.LargerThan(ImageMinimumSize))
                        {
                            newMagRate += ZoomFactor;
                            newSize = this.Image.Size.Zoom(newMagRate);
                        }

                        this.MagnifyRate = newMagRate;
                        this.ImageChanged(this, new EventArgs());
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the System.Drawing.Point that represents the upper-left corner
        /// of the System.Windows.Forms.Form in screen coordinates.
        /// </summary>
        /// <Returns>
        /// The System.Drawing.Point that represents the upper-left corner of the System.Windows.Forms.Form
        /// </Returns>
        public new Point Location
        {
            get { return base.Location; }
            set 
            {
                if (!this.Locked)
                {
                    Point oldValue = base.Location;
                    base.Location = value;
                    if (!oldValue.Equals(value))
                        this.FrameLocationChanged(this, new EventArgs());
                }
            }
        }

        private double _MagnifyRate;
        public double MagnifyRate
        {
            get { return _MagnifyRate; }
            set 
            {
                if (!this.Locked)
                {
                    //double oldValue = _MagnifyRate;
                    //Size oldSize=this.Image.Size;
                    //Size newSize = this.Image.Size.Zoom(value);

                    //if ((value > oldValue && newSize.SmallerThan(ImageMaximumSize)) || value < oldValue && newSize.LargerThan(ImageMinimumSize))
                    //{
                    //    _MagnifyRate = value;

                    //    if (oldValue != value)
                    //        this.ImageSizeChanged(this, new EventArgs());

                    //    //  Update UI
                    //    this.PictureBox.Size = this.Image.Size.Zoom(value);
                    //    double dx = (value - oldValue) * this.Image.Size.Width;
                    //    double dy = (value - oldValue) * this.Image.Size.Height;
                    //    this.Location = new Point(base.Location.X - Convert.ToInt32(dx / 2), base.Location.Y - Convert.ToInt32(dy / 2));
                    //}

                    //Version 2 using center point to align
                    double oldValue = _MagnifyRate;
                    Size oldSize = this.PictureBox.Size;
                    Size newSize = this.Image.Size.Zoom(value);

                    if ((value >= oldValue && newSize.SmallerThan(ImageMaximumSize)) || value <= oldValue && newSize.LargerThan(ImageMinimumSize))
                    {
                        _MagnifyRate = value;

                        if (oldValue != value)
                            this.ImageSizeChanged(this, new EventArgs());

                        //  Update UI
                        this.PictureBox.Size = this.Image.Size.Zoom(value);
                        Point Center = new Point(Convert.ToInt32(this.Location.X + oldSize.Width / 2), Convert.ToInt32(this.Location.Y + oldSize.Height / 2));
                        this.Location = new Point(Convert.ToInt32(Center.X - newSize.Width / 2), Convert.ToInt32(Center.Y - newSize.Height / 2));
                    }
                }                 
            }
        }

        static double minimumOpacity = 0.1;
        /// <summary>
        /// Gets or sets the opacity level of the Frame.
        /// </summary>
        /// <Returns>
        /// The level of opacity for the Frame. The default is 1.00.
        /// </Returns>
        public new double Opacity
        {
            get { return base.Opacity; }
            set
            {
                if (!this.Locked && value >= minimumOpacity)
                {
                    double oldValue = base.Opacity;
                    base.Opacity = value;
                    this.TransToolStripMatchesOpacity();
                    if (oldValue != value)
                        this.OpacityChanged(this, new EventArgs());
                }
            }
        }

        public Color BorderColor
        {
            get { return this.BorderPanel.BackColor; }
            set 
            {
                if (!this.Locked)
                {
                    Color oldValue = this.BorderPanel.BackColor;
                    this.BorderPanel.BackColor = value;
                    if (oldValue.ToArgb() != value.ToArgb())
                        this.BorderColorChanged(this, new EventArgs());
                }
            }
        }
        public int BorderWidth
        {
            get { return this.PictureBox.Margin.All; }
            set 
            {
                if (!this.Locked)
                {
                    int oldValue = this.PictureBox.Margin.All;
                    if (value <= MaximumBorderWidth)
                    {
                        this.PictureBox.Margin = new Padding(value, value, value, value);
                        this.PictureBox.Location = new Point(value, value);
                        if (oldValue != value)
                            this.BorderWidthChanged(this, new EventArgs());
                    }
                }
            }

        }

        /// <summary>
        /// Gets or sets a value indicating whether the control and all its child controls
        /// are displayed.
        /// </summary>
        /// <Returns>
        /// true if the control and all its child controls are displayed; otherwise,
        /// false. The default is true.
        /// </Returns>
        public new bool Visible
        {
            get { return base.Visible; }
            set
            {
                bool oldValue = base.Visible;
                base.Visible = value;
                if (oldValue != value)
                    this.VisibleChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the Frame should be displayed as a
        /// topmost form.
        /// </summary>
        /// <Returns>
        /// true to display the Frame as a topmost form; otherwise, false. The default
        /// is false.
        /// </Returns>
        public new bool TopMost
        {
            get { return base.TopMost; }
            set
            {
                if (!this.Locked)
                {
                    bool oldValue = base.TopMost;
                    base.TopMost = value;
                    stayOnTopToolStripMenuItem.Checked = value;
                    if (oldValue != value)
                        this.TopMostChanged(this, new EventArgs());
                }
            }
        }

        private bool _Locked;
        /// <summary>
        /// Gets or sets a value indicating whether the Frame could be change its configuration.
        /// </summary>
        /// <Returns>
        /// true to allowed the Frame Configuration to be changed; otherwise, false. The default
        /// is false.
        /// </Returns>
        public bool Locked
        {
            get { return this._Locked; }
            set
            {
                bool oldValue = this._Locked;
                this._Locked = value;
                lockPictureToolStripMenuItem.Checked = value;
                if (value)
                {
                    this.FrameMoving = false;
                    this.movePictureToolStripMenuItem.Checked = false;
                }
                if (oldValue != value)
                    this.LockedChanged(this, new EventArgs());
            }
        }

        #endregion

        #region Custom Event Handlers

        public void Frame_ImageChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("image changed");
        }
        public void Frame_LocationChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("location changed");
        }
        public void Image_SizeChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("size changed");
        }
        public void Frame_OpacityChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("opacity changed");
        }
        public void Frame_BorderColorChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("color changed");
        }
        public void Frame_BorderWidthChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("BorderWidth changed");
        }
        public void Frame_VisibleChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("visible changed");
        }
        public void Frame_TopMostChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("topmost changed");
        }
        public void Frame_LockedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("locked changed");
        }

        #endregion
    }
}
