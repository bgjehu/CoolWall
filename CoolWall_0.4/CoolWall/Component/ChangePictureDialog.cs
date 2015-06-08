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
    public partial class ChangePictureDialog : Form
    {
        public string FileName { get { return FileNameTB.Text; } }
        public ChangePictureDialog()
        {
            InitializeComponent();
        }

        private void BrowseBTN_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = @"Common Image File (*.jpg)(*.jpeg)(*.bmp)(*.png)|*.jpg; *.jpeg; *.bmp; *.png;
                              |JPEG Image (*.jpg)(*.jpeg)|*.jpg; *.jpeg;
                              |Bitmap File (*.bmp)|*.bmp;
                              |Portable Network Graphics (*.png)|*.png;
                              |All File (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileNameTB.Text = ofd.FileName;
                }
            }
        }

        private void ChangeBTN_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
