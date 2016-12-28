using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//ToDo:
// 1) Decipher Security Language and distill in to human readable format
// 2) Learn how and get Elevated Token for execution
//


namespace SecurityDescriptorInspector
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        //Form1_Load
        private void Form1_Load(object sender, EventArgs e)
        {
            List<TreeNode> lstDriveNodes = CFileSystem.RetrieveDriveList(trvFolders);

            foreach (TreeNode tnDrive in lstDriveNodes)
            {
                CFileSystem.RetrieveFolderList(tnDrive.FullPath, trvFolders, tnDrive);
            }
        }

        //trvFolders_AfterSelect
        private void trvFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CFileSystem.RetrieveFileList(trvFolders.SelectedNode.FullPath, livFiles);
        }

        //trvFolders_BeforeExpand
        private void trvFolders_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            List<TreeNode> lstPaths;
            List<TreeNode> lstSubPaths;

            //Clear the child nodes out (to refresh / update information)
            e.Node.Nodes.Clear();

            lstPaths = CFileSystem.RetrieveFolderList(e.Node.FullPath, trvFolders, e.Node);

            foreach (TreeNode tnPath in lstPaths)
            {
                lstSubPaths = CFileSystem.RetrieveFolderList(tnPath.FullPath, trvFolders, tnPath);

                //Go down a second level for knowing which folders can expand
                if (lstSubPaths != null)
                {
                    foreach (TreeNode tnSubPath in lstSubPaths)
                    {
                        CFileSystem.RetrieveFolderList(tnSubPath.FullPath, trvFolders, tnSubPath);
                    }
                }
            }
        }//end of trvFolders_BeforeExpand

        private void livFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strFilePath = "";

            if (livFiles.SelectedItems.Count > 0)
            {
                strFilePath = CFileSystem.RetrieveFileSecuritySDDL(trvFolders.SelectedNode.FullPath + "\\" + livFiles.SelectedItems[0].Text, txtSecurity);

                if (strFilePath == null)
                {
                    txtSecurity.Text = "Error Retrieving Security SDDL for: " + strFilePath;
                }
            }
        }
    }


    public static class CFileSystem
    {
        public static List<TreeNode> RetrieveDriveList(TreeView trvListDrives)
        {
            List<TreeNode> AddedNodeList;
            TreeNode AddedNode;

            System.IO.DriveInfo[] diLogicalList = System.IO.DriveInfo.GetDrives();

            AddedNodeList = new List<TreeNode>();

            foreach (System.IO.DriveInfo diLogical in diLogicalList)
            {
                AddedNode = trvListDrives.Nodes.Add(diLogical.Name);
                AddedNodeList.Add(AddedNode);
            }

            return AddedNodeList;
        }

        public static List<TreeNode> RetrieveFolderList(string strEnumeratePath, TreeView trvListFolders, TreeNode tnParentNode = null)
        {
            IEnumerable<string> ienumDirectoryString;
            List<TreeNode> AddedNodeList;
            TreeNode AddedNode;
            string strCleanPath;

            try
            {
                ienumDirectoryString = System.IO.Directory.EnumerateDirectories(strEnumeratePath);
            }
            catch (UnauthorizedAccessException eUnauthorized)
            {
                Console.WriteLine(eUnauthorized.Data.ToString());
                return null;
            }
            catch (Exception eFailure)
            {
                Console.WriteLine(eFailure.Data.ToString());
                return null;
            }

            AddedNodeList = new List<TreeNode>();

            foreach (string strPath in ienumDirectoryString)
            {
                //Create a string from just the last part of the path
                strCleanPath = strPath.Substring(strPath.LastIndexOf('\\')+1);

                //Add only top level nodes if iParentIdx == -1
                if (tnParentNode == null)
                {
                    AddedNode = trvListFolders.Nodes.Add(strCleanPath);
                }
                else
                {
                    AddedNode = tnParentNode.Nodes.Add(strCleanPath);
                }

                AddedNodeList.Add(AddedNode);
            }

            return AddedNodeList;
        }

        public static void RetrieveFileList(string strSystemPath, ListView livListFiles)
        {
            IEnumerable<string> ienumFiles;
            string strCleanFileName;

            //Clear out the previously listed files
            livListFiles.Items.Clear();

            try
            {
                ienumFiles = System.IO.Directory.EnumerateFiles(strSystemPath);
            }
            catch (UnauthorizedAccessException eUnauthorized)
            {
                Console.WriteLine(eUnauthorized.Data.ToString());
                return;
            }
            catch (Exception eFailure)
            {
                Console.WriteLine(eFailure.Data.ToString());
                return;
            }


            foreach (string strFile in ienumFiles)
            {
                //Create a string from just the last part of the file path (filename only)
                strCleanFileName = strFile.Substring(strFile.LastIndexOf('\\') + 1);

                livListFiles.Items.Add(strCleanFileName);
            }
        }

        //Returns the filename if successfull otherwise null
        public static string RetrieveFileSecuritySDDL(string strFilePath, TextBox tbSecurityInfo)
        {
            string strFullFileName = strFilePath;

            try
            {
                System.IO.FileInfo fiSelectedFile = new System.IO.FileInfo(strFullFileName);

                System.Security.AccessControl.FileSecurity fsSelectedFile = fiSelectedFile.GetAccessControl();

                tbSecurityInfo.Text = fiSelectedFile.FullName + "\r\n";
                tbSecurityInfo.Text += fsSelectedFile.GetSecurityDescriptorSddlForm(System.Security.AccessControl.AccessControlSections.All);
            }
            catch (Exception eFailure)
            {
                Console.WriteLine(eFailure.Data.ToString());
                return null;
            }


            return strFullFileName;
        }

    }
}
