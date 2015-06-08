using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoolWall.Component;
using CoolWall.Class;
using System.IO;

namespace CoolWall
{
    public partial class MainCtrl : Form
    {
        //  MainCtrl is the main form for overall control of all the picture frames
        //      the controls are mostly on the notifyicon and its menustrip


        #region Elements

        //  _FrameInfoList is the list the contains all the data models as well as the control for picture frame
        List<FrameInfo> _FrameInfoList = new List<FrameInfo>();

        //  _AvailableFrames only contains the data models which are not disposed
        FrameInfo[] _AvailableFrames { get { return _FrameInfoList.Where(i => i.Disposed == false).ToArray(); } }

        #endregion


        #region Environment Variable

        //  The physical path of the data folder that contains the pictures
        static String _DataFolder = Path.Combine(Directory.GetCurrentDirectory(), "Data");

        //  The physical path of the text file in csv format that contains the information about the picture frame such as
        //      file name of the picture, size, location, opacity and form state of the frame
        static String _DatabaseFile = Path.Combine(_DataFolder, "db.csv");

        #endregion


        #region Constructor

        public MainCtrl()
        {
            InitializeComponent();
        }

        #endregion


        #region Event Handlers

        //  When the form is loaded
        private void MainCtrl_Load(object sender, EventArgs e)
        {
            //  open db.csv and load in records
            this.Open();

            //  After load in records, if the frame list is still empty, auto show the add picture dialog
            //      (if _FrameInfoList is empty, show addframe dialong)
            if (_AvailableFrames.Count() == 0) { ShowAddFrameDialog(); }
        }

        #endregion


        #region Data Model Related Functions

        /// <summary>
        /// Show picture frames, with given IDs or all if no ID is given
        /// </summary>
        /// <param name="IDs">0 based ID. Ex: the 3th in the list, ID would be 2</param>
        private void ShowFrame(params int[] IDs)
        {
            //  IDs is given
            if (IDs.Count() > 0)
            {
                //  Show frames for IDs
                //  Loop thru 1st input to the Nth input
                for (int i = 0; i < IDs.Count(); i++)
                {
                    //  if this input is valid for the frame list
                    if (i < _FrameInfoList.Count)
                    {
                        //  and the frame of this id is not disposed
                        if (!_FrameInfoList[IDs[i]].Disposed)
                        {
                            //  show the frame
                            _FrameInfoList[IDs[i]].ShowFrame();
                        }
                    }
                }
            }
            else
            {
                //  Show All Frames
                //  Frame showed counter
                int FrameShowed = 0;
                //  For each frame that is not disposed
                foreach (FrameInfo fi in _AvailableFrames)
                {
                    //  show the frame
                    fi.ShowFrame();
                    //  counter +1
                    FrameShowed++;
                }
                //  If no frame is showed, meaning the list is empty, prompt add frame dialog to user
                if (FrameShowed == 0) { ShowAddFrameDialog(); }
            }
        }

        /// <summary>
        /// Hide(minimized) picture frames, with given IDs or all if no ID is given
        /// </summary>
        /// <param name="IDs">0 based ID. Ex: the 3th in the list, ID would be 2</param>
        private void HideFrame(params int[] IDs)
        {
            //  IDs is given
            if (IDs.Count() > 0)
            {
                //  Hide frames for IDs
                //  Loop thru 1st input to the Nth input
                for (int i = 0; i < IDs.Count(); i++)
                {
                    //  if this input is valid for the frame list
                    if (i < _FrameInfoList.Count)
                    {
                        //  and the frame of this id is not disposed
                        if (!_FrameInfoList[IDs[i]].Disposed)
                        {
                            //  Hide the frame
                            _FrameInfoList[IDs[i]].HideFrame(); 
                        }
                    }
                }
            }
            else
            {
                // Hide All Frames
                foreach (FrameInfo fi in _AvailableFrames)
                {
                    fi.HideFrame();
                }
            }
        }

        /// <summary>
        /// Delete picture frames, with given IDs or all if no ID is given
        /// </summary>
        /// <param name="IDs">0 based ID. Ex: the 3th in the list, ID would be 2</param>
        private void DeleteFrame(params int[] IDs)
        {
            //  IDs is given
            if (IDs.Count() > 0)
            {
                //  Delete frames for IDs
                //  Loop thru 1st input to the Nth input
                for (int i = 0; i < IDs.Count(); i++)
                {
                    //  if this input is valid for the frame list
                    if (i < _FrameInfoList.Count)
                    {
                        //  and the frame of this id is not disposed
                        if (!_FrameInfoList[IDs[i]].Disposed)
                        {
                            //  Dispose the frame
                            //  Dispose() not only dispose the data model so it wont be use again
                            //      during execute that inside the data model, the frame would be closed as well
                            _FrameInfoList[IDs[i]].Dispose();
                        }
                    }
                }
            }
            else
            {
                // Delete All Frames
                foreach (FrameInfo fi in _AvailableFrames)
                {
                    fi.Dispose();
                }
            }
        }

        /// <summary>
        /// Add Frame by the filename
        /// </summary>
        /// <param name="fileName">filename of the picture to be added</param>
        private void AddFrame(string fileName)
        {
            //  Try to constructor frameinfo instance with fileName, show msg upon catching exception
            try { _FrameInfoList.Add(new FrameInfo(fileName)); }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        /// <summary>
        /// Add Frame by the filename followed by other configuration such as location, size...
        /// </summary>
        /// <param name="fileName">filename of the picture to be added</param>
        /// <param name="info">location, size, opacity, frame state</param>
        private void AddFrame(string fileName, params object[] info)
        {
            //  Try to constructor frameinfo instance with fileName, show msg upon catching exception
            try { _FrameInfoList.Add(new FrameInfo(fileName, info)); }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        /// <summary>
        /// Add Frames by the fileNmaes
        /// </summary>
        /// <param name="fileNames">fileName of the pictures</param>
        private void AddFrames(string[] fileNames)
        {
            //  Try to constructor frameinfo instance with fileName, show msg upon catching exception
            foreach (string fileName in fileNames)
            {
                this.AddFrame(fileName);
            }
        }

        #endregion


        #region IO Related

        /// <summary>
        /// Open and read db file and turn db records back to frames
        /// </summary>
        private void Open()
        {
            //  if db file existed
            if (File.Exists(_DatabaseFile))
            {
                //  read in all csv records
                string[] dbRecords = File.ReadAllLines(_DatabaseFile);
                foreach (string record in dbRecords)
                {
                    //  for each records, get values
                    string[] values = record.Split(',');
                    //  if more than one value, which is supposed to be the fileName
                    if (values.Length > 1)
                    {
                        //  add frame by filename, followed by other info
                        string fileName = values[0];
                        string[] info = values.SubItems(1);
                        this.AddFrame(fileName, info);
                    }
                }
            }
            else 
            {
                //  if db file not exist
                //  do nothing
            }
        } 

        /// <summary>
        /// Save up all the undisposed frameinfo in to local db file, mostly commonly call upon this form closing
        /// </summary>
        private void Save()
        {
            //  create a list of string to store lines of csv record which will be store into db file
            List<string> dbRecords = new List<string>();

            //  create data folder and db file
            if (!Directory.Exists(_DataFolder)) { Directory.CreateDirectory(_DataFolder); }
            foreach (string fileName in Directory.GetFiles(_DataFolder))
            {
                if (fileName.Length >= 4)
                {
                    //  deleting all the old pictures to avoid conflict
                    if (fileName.Substring(fileName.Length - 4).ToLower() == ".png")
                    {
                        File.Delete(fileName);
                    }
                }
            }

            //  for all the undisposed frames
            for (int i = 0; i < _AvailableFrames.Count(); i++)
            {
                //  set fileName
                string fileName = Path.Combine(_DataFolder, string.Format("{0:d3}.png", i));

                // save image
                try
                {
                    //  try save image
                    _AvailableFrames[i].Image.Save(fileName);
                }
                catch (Exception)
                {
                    //  if save() doesn't work, try SafeSave()
                    _AvailableFrames[i].Image.SafeSave(fileName);
                }

                //add record to db
                dbRecords.Add(fileName + "," + _AvailableFrames[i].GetInfoString());
            }

            //  delete old db file to avoid conflict
            if (File.Exists(_DatabaseFile)) { File.Delete(_DatabaseFile); }
            //  create and write in records to new db file
            File.WriteAllLines(_DatabaseFile, dbRecords);
        }
        
        #endregion


        #region UI Actions

        /// <summary>
        /// Show AddFrameDialog and add frames with returned filenames
        /// </summary>
        private void ShowAddFrameDialog()
        {
            using (AddFrameDialog afd = new AddFrameDialog())
            {
                if (afd.ShowDialog() == DialogResult.OK)
                {
                    AddFrames(afd.FileNames);
                }
            }
        } 

        #endregion


        #region Event Handler

        private void addPicturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAddFrameDialog();
        }

        private void showAllPicutresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFrame();
        }

        private void hideAllPicturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideFrame();
        }

        private void deleteAllPicturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteFrame();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowFrame();
        }

        private void MainCtrl_Closing(object sender, CancelEventArgs e)
        {
            this.Save();
        } 

        #endregion
    }
}
