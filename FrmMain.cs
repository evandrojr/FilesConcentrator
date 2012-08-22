using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ShowLib;


namespace FilesConcentrator
{
    public partial class FrmMain : Form
    {
        public Dictionary<string, string> FileIdDic = null;
        public Dictionary<string, string> DoublesCopyDic = null;
        public Dictionary<string, string> DoublesMasterDic = null;
        public string Report = "";
        public string MasterFileDatabase = "";
        public List<string> FileMasterLst = null;
        public List<string> FileSourceLst = null;
        public List<string> SourceDirectoryList = null;

        public FrmMain()
        {
            InitializeComponent();
        }



        private void BtnCopyStart_Click(object sender, EventArgs e)
        {
            SourceDirectoryTextToDirectorySourceList();
            if (!validade())
                return; 
            copyWithNoDatabase();
        }

        private void copyWithNoDatabase()
        {
            FileIdDic = new Dictionary<string, string>();
            DoublesCopyDic = new Dictionary<string, string>();
            DoublesMasterDic = new Dictionary<string, string>();
            Report = "";
            MasterFileDatabase = "";
            string md5 = null;
            string filename = "";

            FileMasterLst = Fcn.DirectoryGetFilesRecursive(txtMasterDirectory.Text);
            for (int i = 0; i < FileMasterLst.Count; ++i)
            {
                try
                {
                    md5 = Fcn.MD5Hash(FileMasterLst[i]);
                }
                catch (Exception ex)
                {
                    Report += "Erro obtendo MD5 do arquivo " + FileMasterLst[i] + " " + ex + Environment.NewLine;
                    continue;
                }

                try
                {
                    FileIdDic.Add(md5, FileMasterLst[i]);
                    MasterFileDatabase += md5 + "*" + FileMasterLst[i] + '|' + Environment.NewLine;
                }
                catch
                {
                    if (md5 != "")
                    {
                        DoublesMasterDic.Add(FileMasterLst[i], FileIdDic[md5]);
                        Report += FileMasterLst[i] + " = " + FileIdDic[md5] + Environment.NewLine;
                    }
                    else
                    {
                        Report += FileMasterLst[i] + " = (no MD5!!!)"  + Environment.NewLine;
                    }
                }
            }

            for (int sourceDirIdx = 0; sourceDirIdx< SourceDirectoryList.Count; ++sourceDirIdx)
            {
                FileSourceLst = Fcn.DirectoryGetFilesRecursive(SourceDirectoryList[sourceDirIdx]);
                for (int i = 0; i < FileSourceLst.Count; ++i)
                {
                    md5 = "";
                    filename = txtMasterDirectory.Text + FileSourceLst[i].Substring(2, FileSourceLst[i].Length - 2);
                    try
                    {
                        md5 = Fcn.MD5Hash(FileSourceLst[i]);
                    }
                    catch (Exception ex)
                    {
                        if (!File.Exists(filename))
                        {
                            Directory.CreateDirectory(Fcn.FilePath(filename));
                            File.Copy(FileSourceLst[i], filename);
                        }
                        Report += "Erro obtendo MD5 do arquivo " + FileSourceLst[i] + " " + ex + Environment.NewLine;
                        continue;
                    }

                    try
                    {
                        // c:\
                        FileIdDic.Add(md5, filename);
                        if (File.Exists(filename))
                        {
                            Directory.CreateDirectory(Fcn.FilePath(filename));
                            File.Copy(FileSourceLst[i], filename + Fcn.TimestampToPath(DateTime.Now));
                            Report += FileSourceLst[i] + " copied to " + filename + Fcn.TimestampToPath(DateTime.Now) + Environment.NewLine;
                            MasterFileDatabase += md5 + "*" + filename + Fcn.TimestampToPath(DateTime.Now) + "|" + Environment.NewLine;
                        }
                        else
                        {
                            Directory.CreateDirectory(Fcn.FilePath(filename));
                            File.Copy(FileSourceLst[i], filename);
                            Report += FileSourceLst[i] + " copied to " + filename + Environment.NewLine;
                            MasterFileDatabase += md5 + "*" + filename + "|" + Environment.NewLine;
                        }
                    }
                    catch
                    {
                        if (md5 != "")
                        {
                            DoublesCopyDic.Add(FileSourceLst[i], FileIdDic[md5]);
                            Report += FileSourceLst[i] + " = " + FileIdDic[md5] + Environment.NewLine;
                        }
                        else
                        {
                            Report += FileSourceLst[i] + " = (no MD5!!!!!!!!) " + Environment.NewLine;
                        }
                    }
                }
            }
            File.WriteAllText("\\FilesConcentratorVer2_Report.txt", Report);
            File.WriteAllText("\\FilesConcentratorVer2_Database.txt", MasterFileDatabase, Encoding.Default);
            txtReport.Text = Report;
            MessageBox.Show("Copy finished!!!");
        }

        private void btnMasterSelect_Click(object sender, EventArgs e)
        {
            folderBrowserMaster.ShowDialog();
            txtMasterDirectory.Text = folderBrowserMaster.SelectedPath;
        }

        private void btnSourceSelect_Click(object sender, EventArgs e)
        {
            folderBrowserSource.ShowDialog();
            txtSourceDirectory.Text += folderBrowserSource.SelectedPath + Environment.NewLine;
        }

        private void SourceDirectoryTextToDirectorySourceList()
        {
            string s = txtSourceDirectory.Text;
            s=s.Replace(Environment.NewLine, "|");
            //Removes the last |
            if(s[s.Length - 1]=='|')
                s=s.Substring(0, s.Length - 1);
            string[] sAr = s.Split('|');
           

            SourceDirectoryList = new List<string>();
            foreach (string t in sAr)
            {
                SourceDirectoryList.Add(t);
            }
        }

        private bool validade()
        {
            if (txtMasterDirectory.Text == "" || txtSourceDirectory.Text == "")
            {
                MessageBox.Show("You must specify a source and output directory");
                return false;
            }
            if (!Directory.Exists(txtMasterDirectory.Text))
            {
                MessageBox.Show("The output directory " + txtMasterDirectory.Text + " does not exist");
                return false;
            }
            foreach (string s in SourceDirectoryList)
            {
                if (!Directory.Exists(s))
                {
                    MessageBox.Show("The source directory " + s + " does not exist");
                    return false;
                }
            }
            return true;
        }

        private void copyUsingFileDatabase()
        {
            SourceDirectoryTextToDirectorySourceList();
            if (!validade())
                return;

            if (!File.Exists("\\FilesConcentratorVer2_Database.txt"))
            {
                copyWithNoDatabase();
                return;
            }

            FileIdDic = new Dictionary<string, string>();
            DoublesCopyDic = new Dictionary<string, string>();
            DoublesMasterDic = new Dictionary<string, string>();
            Report = "";
            MasterFileDatabase = "";
            string md5 = null;

            string[] fileDatabaseAr;
            string[] fileDataAr;

            FileMasterLst = Fcn.DirectoryGetFilesRecursive(txtMasterDirectory.Text);
            MasterFileDatabase = File.ReadAllText("\\FilesConcentratorVer2_Database.txt", Encoding.Default);
            fileDatabaseAr = MasterFileDatabase.Split('|');
            string filename = "";

            for (int i = 0; i < fileDatabaseAr.Length - 1; ++i)
            {
                fileDataAr = fileDatabaseAr[i].Replace(Environment.NewLine, "").Split('*');
                FileIdDic.Add(fileDataAr[0], fileDataAr[1]);
            }

            for (int sourceDirIdx = 0; sourceDirIdx < SourceDirectoryList.Count; ++sourceDirIdx)
            {
                FileSourceLst = Fcn.DirectoryGetFilesRecursive(SourceDirectoryList[sourceDirIdx]);
                for (int i = 0; i < FileSourceLst.Count; ++i)
                {
                    md5 = "";
                    filename = txtMasterDirectory.Text + FileSourceLst[i].Substring(2, FileSourceLst[i].Length - 2);
                    try
                    {
                        md5 = Fcn.MD5Hash(FileSourceLst[i]);
                    }
                    catch (Exception ex)
                    {
                        if (!File.Exists(filename))
                        {
                            Directory.CreateDirectory(Fcn.FilePath(filename));
                            File.Copy(FileSourceLst[i], filename);
                        }
                        Report += "Erro obtendo MD5 do arquivo " + FileSourceLst[i] + " " + ex + Environment.NewLine;
                        continue;
                    }

                    try
                    {
                        // c:\
                        FileIdDic.Add(md5, filename);
                        if (File.Exists(filename))
                        {
                            Directory.CreateDirectory(Fcn.FilePath(filename));
                            File.Copy(FileSourceLst[i], filename + Fcn.TimestampToPath(DateTime.Now));
                            Report += FileSourceLst[i] + " copied to " + filename + Fcn.TimestampToPath(DateTime.Now) + Environment.NewLine;
                            MasterFileDatabase += md5 + "*" + filename + Fcn.TimestampToPath(DateTime.Now) + "|" + Environment.NewLine;                        
                        }
                        else
                        {
                            Directory.CreateDirectory(Fcn.FilePath(filename));
                            File.Copy(FileSourceLst[i], filename);
                            Report += FileSourceLst[i] + " copied to " + filename + Environment.NewLine;
                            MasterFileDatabase += md5 + "*" + filename + "|" + Environment.NewLine;
                        }
                    }
                    catch
                    {
                        if (md5 != "")
                        {
                            DoublesCopyDic.Add(FileSourceLst[i], FileIdDic[md5]);
                            Report += FileSourceLst[i] + " = " + FileIdDic[md5] + Environment.NewLine;
                        }
                        else
                        {
                            Report += FileSourceLst[i] + " = (no MD5!!!!!!!!) " + Environment.NewLine;
                        }
                    }
                }
            }

            File.WriteAllText("\\FilesConcentratorVer2_Database.txt", MasterFileDatabase, Encoding.Default);
            File.WriteAllText("\\FilesConcentratorVer2_Report.txt", Report);
            txtReport.Text = Report;
            MessageBox.Show("Copy finished!!!");
        }

        private void btnCopyUsingFileDatabaseStart_Click(object sender, EventArgs e)
        {
            copyUsingFileDatabase();

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //txtMasterDirectory.Text = @"d:\master";
            //txtSourceDirectory.Text = @"d:\temp";
            //txtMasterDirectory.Text = @"H:\out_test";
            //txtSourceDirectory.Text = @"H:\in_test" + Environment.NewLine;
        }

        private void btnSimpleCopy_Click(object sender, EventArgs e)
        {
            simpleCopy();
        }

        private void simpleCopy()
        {
            SourceDirectoryTextToDirectorySourceList();
            if (!validade())
                return;
            string filename = null;

            for (int sourceDirIdx = 0; sourceDirIdx < SourceDirectoryList.Count; ++sourceDirIdx)
            {
                FileSourceLst = Fcn.DirectoryGetFilesRecursive(SourceDirectoryList[sourceDirIdx]);
                for (int i = 0; i < FileSourceLst.Count; ++i)
                {
                    filename = txtMasterDirectory.Text + FileSourceLst[i].Substring(2, FileSourceLst[i].Length - 2);
                    Directory.CreateDirectory(Fcn.FilePath(filename));
                    File.Copy(FileSourceLst[i], filename, true);
                    Report += FileSourceLst[i] + " copied to " + filename + Environment.NewLine;
                }
            }
            File.WriteAllText("\\FilesConcentratorVer2_Report.txt", Report);
            txtReport.Text = Report;
            MessageBox.Show("Copy finished!!!");
        }
    }
}
