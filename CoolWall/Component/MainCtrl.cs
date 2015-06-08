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
using CoolWall.Component.FrameForm;
using System.IO;
using System.IO.Compression;
using Newtonsoft.Json;
using Microsoft.Win32;
using System.Threading;

namespace CoolWall.Component
{
    public partial class MainCtrl : Form
    {
        //  Environment Variables
        static string LocalApplicationData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CoolWall");
        static string DataFile = Path.Combine(LocalApplicationData, "db");
        static string ConfigFile = Path.Combine(LocalApplicationData, "config");
        static string TempFolder = Path.Combine(LocalApplicationData, "tmp");
        static string TempFile = Path.Combine(TempFolder, "tmp");
        static string AppName = "CoolWall";
        static string Version = "0.8";
        static RegistryKey AutoStartRegKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);


        private bool _AutoStart;
        public bool AutoStart 
        {
            get { return _AutoStart; }
            set 
            {
                _AutoStart = value;
                autoStartToolStripMenuItem.Checked = value;
                if (value)
                {
                    AutoStartRegKey.SetValue("CoolWall", Application.ExecutablePath.ToString());
                }
                else
                {
                    AutoStartRegKey.SetValue("CoolWall", false);
                }
            }
        }
        private int _OpenCount;
        public int OpenCount 
        {
            get { return _OpenCount; }
            set { _OpenCount = value; }
        }
        private AppConfig AppConfig 
        {
            get 
            {
                return new AppConfig(this.OpenCount, this.AutoStart);
            }
            set 
            {
                this.OpenCount = value.OpenCount;
                this.AutoStart = value.AutoStart;
            }
        }

        List<Frame> FrameList = new List<Frame>();
        Frame[] AvailableFrames { get { return FrameList.Where(i => !i.IsDisposed).ToArray(); } }
        public MainCtrl()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            InitializeComponent();
            this.Visible = false;
        }
        #region IO Utilities
        private void MainCtrl_Load(object sender, EventArgs e)
        {
            this.LoadData();
            this.OpenCount++;
            if (AvailableFrames.Count() == 0) { ShowAddFrameDialog(); }
        }

        private void MainCtrl_Closing(object sender, CancelEventArgs e)
        {
            this.SaveData();
        }

        private void SaveData() { SaveFrameData(); SaveAppConfig(); }
        private void LoadData() { LoadAppConfig(); LoadFrameData(); }
        private void SaveFrameData()
        {
            //  If there is DatabaseFile, delete to avoid exception
            if (File.Exists(DataFile)) { File.Delete(DataFile); }

            //  If there is not TempFolder, create
            if (!Directory.Exists(TempFolder)) { Directory.CreateDirectory(TempFolder); }

            //  Write Data to TempFile under TempFolder
            File.WriteAllText(TempFile, JsonConvert.SerializeObject(AvailableFrames.Select(i => i.FrameConfig).ToArray()));

            //  Zip the TempFolder to DatabaseFile
            ZipFile.CreateFromDirectory(TempFolder, DataFile);

            //  Delete All files under Tempfolder
            foreach (string fileName in Directory.GetFiles(TempFolder)) { File.Delete(fileName); }

            //  Delete Tempfolder
            if (Directory.Exists(TempFolder)) { Directory.Delete(TempFolder); }
        }
        private void LoadFrameData()
        {
            //  IF there is DatabaseFile, load in
            if (File.Exists(DataFile))
            {
                //  If there is not TempFolder, create
                if (!Directory.Exists(TempFolder)) { Directory.CreateDirectory(TempFolder); }

                //  If there is TempFile under TempFolder
                if (File.Exists(TempFile)) { File.Delete(TempFile); }

                //  Upzip DatabaseFile to TempFolder
                ZipFile.ExtractToDirectory(DataFile, TempFolder);

                //  Read Data from TempFile to App
                FrameList.AddRange(JsonConvert.DeserializeObject<List<FrameConfig>>(File.ReadAllText(TempFile)).Select(i => i.ToFrame()).ToArray());
                BindParent();

                //  Delete All files under Tempfolder
                foreach (string fileName in Directory.GetFiles(TempFolder)) { File.Delete(fileName); }

                //  Delete Tempfolder
                if (Directory.Exists(TempFolder)) { Directory.Delete(TempFolder); }
            }
        }
        private void SaveAppConfig()
        {
            //  If there is ConfigFile, delete to avoid exception
            if (File.Exists(ConfigFile)) { File.Delete(ConfigFile); }

            //  If there is not TempFolder, create
            if (!Directory.Exists(TempFolder)) { Directory.CreateDirectory(TempFolder); }

            //  Write Data to TempFile under TempFolder
            File.WriteAllText(TempFile, JsonConvert.SerializeObject(this.AppConfig));

            //  Zip the TempFolder to ConfigFile
            ZipFile.CreateFromDirectory(TempFolder, ConfigFile);

            //  Delete All files under Tempfolder
            foreach (string fileName in Directory.GetFiles(TempFolder)) { File.Delete(fileName); }

            //  Delete Tempfolder
            if (Directory.Exists(TempFolder)) { Directory.Delete(TempFolder); }
        }
        private void LoadAppConfig()
        {
            //  IF there is ConfigFile, load in
            if (File.Exists(ConfigFile))
            {
                //  If there is not TempFolder, create
                if (!Directory.Exists(TempFolder)) { Directory.CreateDirectory(TempFolder); }

                //  If there is TempFile under TempFolder
                if (File.Exists(TempFile)) { File.Delete(TempFile); }

                //  Upzip ConfigFile to TempFolder
                ZipFile.ExtractToDirectory(ConfigFile, TempFolder);

                //  Read Data from TempFile to App
                this.AppConfig = JsonConvert.DeserializeObject<AppConfig>(File.ReadAllText(TempFile));
                //  Delete All files under Tempfolder
                foreach (string fileName in Directory.GetFiles(TempFolder)) { File.Delete(fileName); }

                //  Delete Tempfolder
                if (Directory.Exists(TempFolder)) { Directory.Delete(TempFolder); }
            }
        }
        #endregion

        #region UI Utilities
        private void ShowAddFrameDialog()
        {
            using (AddFrameDialog afd = new AddFrameDialog())
            {
                if (afd.ShowDialog() == DialogResult.OK)
                {
                    this.AddFrame(afd.FileNames);
                }
            }
        }
        private void ShowAllFrames()
        {
            if (AvailableFrames.Count() == 0) { ShowAddFrameDialog(); }
            else
            {
                foreach (Frame frame in AvailableFrames)
                {
                    frame.Show();
                }
            }
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAddFrameDialog();
        }




        private void showAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAllFrames();
        }

        private void hideAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Frame frame in AvailableFrames)
            {
                frame.Hide();
            }
        }

        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Frame frame in AvailableFrames)
            {
                frame.Close();
            }
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowAllFrames();
        }

        private void autoStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AutoStart = !this.AutoStart;
        }

        #endregion

        #region Data Utilities

        public void AddFrame(params string[] fileNames)
        {
            this.FrameList.AddRange(fileNames.Select(i => new Frame(i.GetImage())));
            BindParent();
        }

        #endregion


        public void BindParent()
        {
            foreach (Frame frame in AvailableFrames)
            {
                frame.MainControl = this;
            }
        }




    }
}