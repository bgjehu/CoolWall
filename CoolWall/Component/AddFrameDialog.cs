using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoolWall.Component
{
    public partial class AddFrameDialog : Form
    {
        public string[] FileNames { get { return FileNamesTB.Lines.Where(i => i != "").ToArray(); } }
        string LastLine { get { return FileNamesTB.Lines[FileNamesTB.Lines.Count() - 1]; } }
        public AddFrameDialog()
        {
            InitializeComponent();
        }

        private void AddBTN_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = true;
                ofd.Filter = @"Common Image File (*.jpg)(*.jpeg)(*.bmp)(*.png)|*.jpg; *.jpeg; *.bmp; *.png;
                              |JPEG Image (*.jpg)(*.jpeg)|*.jpg; *.jpeg;
                              |Bitmap File (*.bmp)|*.bmp;
                              |Portable Network Graphics (*.png)|*.png;
                              |All File (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileName in ofd.FileNames)
                    {
                        FileNamesTB.AppendText(fileName + "\r\n");
                    }
                }
                FileNamesTB.Focus();
            }
        }

        private void SubmitBTN_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FileNamesTB_TextChanged(object sender, EventArgs e)
        {
            if (FileNamesTB.Lines.Count() > 0)
            {
                if (LastLine.Length >= 5)
                {
                    string last4 = LastLine.Substring(LastLine.Length - 4).ToLower();
                    string last5 = LastLine.Substring(LastLine.Length - 5).ToLower();
                    if (last4 == ".jpg" || last4 == ".bmp" || last4 == ".png" || last5 == ".jpeg")
                    {
                        FileNamesTB.AppendText("\r\n");
                    }
                    else
                    {

                    }
                }
                else { }
            }
        }
    }
}
