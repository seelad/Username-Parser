//Created by Seelad in memory of Rawr RIP 2015-2015

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsernameScannerThingy
{
    public partial class UserNameFinder : Form
    {
        private UserLookUp lookUpForm;

        private const string extensionName = "Text";
        private const string extension = ".txt";


        public UserNameFinder()
        {
            InitializeComponent();

            this.Text = "Username Parser v0.27";
            OpenFileDialog.Filter = extensionName + " files (*" + extension + ")|*" + extension;
            saveFileDialog_Export.Filter = extensionName + " files (*" + extension + ")|*" + extension;

        }

        private string CheckDialog()
        {
            DialogResult result = OpenFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                return "";
            }
            else
                return null;
        }

        /// <summary>
        /// Opens and checks the save dialog for the user's input.
        /// </summary>
        /// <returns>Returns null if the player cancels, otherwise a string of ""</returns>
        private string CheckDialog_Save()
        {
            DialogResult result = saveFileDialog_Export.ShowDialog();
            if (result == DialogResult.OK)
            {
                return "";
            }
            else
                return null;
        }

        private void toolBut_Load_Click(object sender, EventArgs e)
        {
                string tempResult = CheckDialog();
                if (tempResult != null)
                {
                    List<string> lineList = new List<string>();

                    using (StreamReader stream = new StreamReader(OpenFileDialog.FileName))
                    {
                        while (stream.EndOfStream == false) //Checks to make sure the streamreader is not at the end.
                        {
                            string line = stream.ReadLine();
                            lineList.Add(line);
                        }
                        
                    }

                    PopulateListBox(lineList.ToArray());
                     
                }
               
        }

        private void button_GetUsers_Click(object sender, EventArgs e)
        {
            PopulateListBox(textBox_Raw.Lines);
        }

        private void PopulateListBox(string[] lines)
        {
            listBox_Users.Items.Clear(); //Removes what was previous in the list box.

            List<User> tempUsers = new List<User>();

            foreach (string line in lines)
            {
                int indexStart = line.IndexOf(']');
                int indexEnd = line.IndexOf(':');
                indexEnd = line.IndexOf(':', indexEnd + 1);
                indexStart += 2; //Adds one to account for the bracket, and another for the space after the time stamp.

                string username = string.Empty;
                if (indexStart != 0 && indexEnd != -1)
                {
                    username = line.Substring(indexStart, (indexEnd - indexStart));
                }
                User newUser = new User(username);
                newUser.AddMessage(line);
                bool passed = true; //I dislike this.
                if (newUser.ToString() != "")
                {
                    foreach (User u in tempUsers)
                    {
                        if (u.ToString() == newUser.ToString())
                        {
                            u.AddMessage(newUser.UserChatMessages[0]);
                            passed = false;
                            break;
                        }
                    }
                    if (passed)
                    {
                        tempUsers.Add(newUser); //Add it to tempusers so I don't have to parse the listBox one from type object.
                        listBox_Users.Items.Add(newUser);
                    }
                }
            }

            label_Users.Text = "Users (" + listBox_Users.Items.Count + ")";

        }

        private void listBox_Users_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                listBox_Users.SelectedIndices.Clear();
                listBox_Users.SelectedIndex = listBox_Users.IndexFromPoint(e.Location);
                if (listBox_Users.SelectedIndex != -1)
                {
                    contextMenu_UserList.Show(Cursor.Position);
                }
            }
        }

        private void but_Info_Click(object sender, EventArgs e)
        {
            User u = (User)listBox_Users.SelectedItem;
            lookUpForm = new UserLookUp(u.UserChatMessages, u.ToString()); //Creates the lookUpForm.
            lookUpForm.StartPosition = FormStartPosition.CenterParent; //Centers the lookUpForm to the parent.
            lookUpForm.ShowDialog(this); //Shows the form.
        }

        private void listBox_Users_DoubleClick(object sender, EventArgs e)
        {
            if (listBox_Users.SelectedIndex != -1)
            {
                User u = (User)listBox_Users.SelectedItem;
                lookUpForm = new UserLookUp(u.UserChatMessages, u.ToString()); //Creates the lookUpForm.
                lookUpForm.StartPosition = FormStartPosition.CenterParent; //Centers the lookUpForm to the parent.
                lookUpForm.ShowDialog(this); //Shows the form.
            }
        }

        private void but_Remove_Click(object sender, EventArgs e)
        {
            if (listBox_Users.SelectedIndex != -1)
            {
                listBox_Users.Items.RemoveAt(listBox_Users.SelectedIndex);
                label_Users.Text = "Users (" + listBox_Users.Items.Count + ")";
            }
        }

        private void but_ExportUserList_Click(object sender, EventArgs e)
        {
            string tempResult = CheckDialog_Save();
            if (tempResult != null)
            {
                using (StreamWriter stream = new StreamWriter(@saveFileDialog_Export.FileName))
                {
                    for (int i = 0; i < listBox_Users.Items.Count; i++)
                    {
                        stream.WriteLine(listBox_Users.Items[i].ToString()); //Writes the ToString of the user.
                    }
                }

            }
        }

        private void but_ExportRawText_Click(object sender, EventArgs e)
        {
            string tempResult = CheckDialog_Save();
            if (tempResult != null)
            {
                using (StreamWriter stream = new StreamWriter(@saveFileDialog_Export.FileName))
                {
                    for (int i = 0; i < textBox_Raw.Lines.Length; i++)
                    {
                        stream.WriteLine(textBox_Raw.Lines[i]); //Writes the specific line of the text box.
                    }
                }

            }
        }


    }
}
