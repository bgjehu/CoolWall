using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net;
using System.IO;
using System.Windows.Forms;
using CoolWall.Component;

namespace CoolWall.Class
{
    public class FrameInfo
    {
        public Image Image { get { return _Image; } }
        Image _Image;
        public Point Location { get { return _Location; } }
        Point _Location;
        public Size Size { get { return _Size; } }
        Size _Size;
        public Double Opacity { get { return _Opacity; } }
        Double _Opacity;
        public Boolean Visible { get { return _Visible; } }
        Boolean _Visible;
        public Boolean TopMost { get { return _TopMost; } }
        Boolean _TopMost;
        public Frame Frame { get { return _Frame; } }
        Frame _Frame;

        public bool Disposed { get { return _Disposed; } }
        bool _Disposed = false;
        
        public FrameInfo(String fileName, params object[] info)
        {
            //  Create Image instance
            Image image = fileName.GetImage();
            

            if (image == null) 
            {
                //  Image not found
                throw new Exception("Image Not Found."); 
            }
            else 
            {
                DefautlFrameInfo(image);
                LoadFrameInfo(info);
                _Frame = new Frame(this);
            }
        }

        private void DefautlFrameInfo(Image image)
        {
            //  Image loaded in
            _Image = image;

            //  Default Setting
            int x = (int)((System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - image.Width) / 2);
            int y = (int)((System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - image.Height) / 2);
            int width = _Image.Width;
            int height = _Image.Height;
            _Location = new Point(x, y);
            _Size = new Size(width, height);
            _Opacity = 100;
            _Visible = true;
            _TopMost = false;
        }
        private void LoadFrameInfo(params object[] info)
        {
            //  User Defined Setting
            for (int i = 0; i < info.Count(); i++)
            {
                if (info[i].GetType() == typeof(Point))
                {
                    _Location = (Point)info[i];
                }
                else if (info[i].GetType() == typeof(Size))
                {
                    _Size = (Size)info[i];
                }
                else if (info[i].GetType() == typeof(Double))
                {
                    _Opacity = (Double)info[i];
                }
                else if (info[i].GetType() == typeof(Boolean))
                {
                    _Visible = (Boolean)info[i];
                }
                else if (info[i].GetType() == typeof(String))
                {
                    //  input is string from dbrecord
                    //  i must from 0-5
                    switch (i)
                    {
                        case 0:
                            try
                            {
                                _Location.X = Convert.ToInt32(info[i]);
                            }
                            catch (Exception) { throw new Exception("Invalid X Coordinate."); }
                            break;
                        case 1:
                            try
                            {
                                _Location.Y = Convert.ToInt32(info[i]);
                            }
                            catch (Exception) { throw new Exception("Invalid Y Coordinate."); }
                            break;
                        case 2:
                            try
                            {
                                _Size.Width = Convert.ToInt32(info[i]);
                            }
                            catch (Exception) { throw new Exception("Invalid Picture Width."); }
                            break;
                        case 3:
                            try
                            {
                                _Size.Height = Convert.ToInt32(info[i]);
                            }
                            catch (Exception) { throw new Exception("Invalid Picture Height."); }
                            break;
                        case 4:
                            try
                            {
                                _Opacity = Convert.ToDouble(info[i]);
                            }
                            catch (Exception) { throw new Exception("Invalid Opacity."); }
                            break;
                        case 5:
                            try
                            {
                                _Visible = Convert.ToBoolean(info[i]);
                            }
                            catch (Exception) { throw new Exception("Invalid Frame State (Visibal)."); }
                            break;
                        case 6:
                            try
                            {
                                _TopMost = Convert.ToBoolean(info[i]);
                            }
                            catch (Exception) { throw new Exception("Invalid Frame State (TopMost)."); }
                            break;
                    }
                }
                else
                {
                    //  Unrecognize type, no action
                }
            }
        }

        public void ShowFrame() 
        {
            _Frame.Show();
        }
        public void HideFrame() 
        {
            if (_Frame != null) { _Frame.Hide(); }
        }
        public void ChangePicture(string fileName)
        {
            Image image = fileName.GetImage();
            if (image != null)
            {
                DefautlFrameInfo(image);
                _Frame.Close();
                _Disposed = false;
                _Frame = new Frame(this);
            }
            else
            {
                MessageBox.Show("Error: Image Not Found.");
            }
        }
        public void ShowChangePictureDialog()
        {
            using (ChangePictureDialog cpd = new ChangePictureDialog())
            {
                if (cpd.ShowDialog() == DialogResult.OK)
                {
                    ChangePicture(cpd.FileName);
                }
                else { }
            }
        }


        public void UpdateFrameInfo()
        {
            //  Update Location
            _Location = new Point(_Frame.PictureLeft, _Frame.PictureTop);
            
            //  Update Size
            _Size = new Size(_Frame.PictureWidth, _Frame.PictureHeight);

            //  Update Opcaity
            _Opacity = _Frame.Opacity;

            //  Update Visible
            _Visible = _Frame.Visible;

            //  Update TopMost
            _TopMost = _Frame.TopMost;
        }
        public string GetInfoString()
        {
            UpdateFrameInfo();
            return string.Format("{0},{1},{2},{3},{4},{5},{6}", _Location.X, _Location.Y, _Size.Width, _Size.Height, _Opacity, _Visible, _TopMost);
        }
        
        public void Dispose()
        {
            if (_Frame != null) { _Frame.Hide(); }
            _Disposed = true;
        }
    }
}
