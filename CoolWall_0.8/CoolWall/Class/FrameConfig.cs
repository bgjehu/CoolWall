using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Newtonsoft.Json;
using CoolWall.Component.FrameForm;

namespace CoolWall.Class
{
    public class FrameConfig
    {
        public string ImageString { get; set; }
        public Point FrameLocation { get; set; }
        public double MagnifyRate { get; set; }
        public double Opacity { get; set; }
        public Color BorderColor { get; set; }
        public int BorderWidth { get; set; }
        public bool Visible { get; set; }
        public bool TopMost { get; set; }
        public bool Locked { get; set; }
        public FrameConfig()
        {
            this.ImageString = ExtensionMethods.NullImage.ToImageString();
            this.FrameLocation = new Point(0, 0);
            this.MagnifyRate = 1;
            this.Opacity = 1;
            this.BorderColor = Color.White;
            this.Visible = true;
            this.TopMost = false;
            this.Locked = false;
        }
        public FrameConfig(string imgStr, Point frameLoc, double magRate, double opacity, Color color, int borderWidth, bool visible, bool topMost, bool locked)
        {
            this.ImageString = imgStr;
            this.FrameLocation = frameLoc;
            this.MagnifyRate = magRate;
            this.Opacity = opacity;
            this.BorderColor = color;
            this.BorderWidth = borderWidth;
            this.Visible = visible;
            this.TopMost = topMost;
            this.Locked = locked;
        }
        public string ToJson()
        {
            string jsonStr = JsonConvert.SerializeObject(this);
            return jsonStr;
        }
        public Frame ToFrame()
        {
            Frame frame = new Frame(this);
            return frame;
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(FrameConfig)) { return false; }
            else 
            {
                FrameConfig FcObj = obj as FrameConfig;
                bool equalImgStr = this.ImageString == FcObj.ImageString;
                bool equalLoc = this.FrameLocation.Equals(FcObj.FrameLocation);
                bool equalSize = this.MagnifyRate == FcObj.MagnifyRate;
                bool equalOpa = this.Opacity == FcObj.Opacity;
                bool equalBC = this.BorderColor.ToArgb() == FcObj.BorderColor.ToArgb();
                bool equalBW = this.BorderWidth == FcObj.BorderWidth;
                bool equalVis = this.Visible == FcObj.Visible;
                bool equalTop = this.TopMost == FcObj.TopMost;
                bool equalLck = this.Locked == FcObj.Locked;
                bool equalObj = equalImgStr & equalLoc & equalSize & equalOpa & equalBC & equalBW & equalVis & equalTop & equalLck;
                return equalObj;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
