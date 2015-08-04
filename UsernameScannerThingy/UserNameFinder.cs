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

        private List<User> users = new List<User>();
        private User meChats;

        public UserNameFinder()
        {
            InitializeComponent();

            this.Text = "Username Parser v0.39";
            OpenFileDialog.Filter = extensionName + " files (*" + extension + ")|*" + extension;
            saveFileDialog_Export.Filter = extensionName + " files (*" + extension + ")|*" + extension;

            meChats = new User("Unknown /me Chat Posts", 0);
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
                    for (int i = OpenFileDialog.FileNames.Length - 1; i >= 0; i--)
                    {
                        using (StreamReader stream = new StreamReader(OpenFileDialog.FileNames[i]))
                        {
                            while (stream.EndOfStream == false) //Checks to make sure the streamreader is not at the end.
                            {
                                string line = stream.ReadLine();
                                lineList.Add(line);
                            }

                        }
                    }

                    textBox_Raw.Lines = lineList.ToArray();
                    ParseUsers(textBox_Raw.Lines);
                    PopulateListBox(); //Populates the user list.
                }
               
        }

        private void button_GetUsers_Click(object sender, EventArgs e)
        {
            ParseUsers(textBox_Raw.Lines);
            PopulateListBox();
        }

        public void ParseUsers(string[] lines)
        {
            listBox_Users.Items.Clear(); //Removes what was previous in the list box.
            users.Clear(); //Removes the entries in the user list.
            meChats = new User("Unknown /me Chat Posts", 0); // Recreates meChats which also removes any previous chat messages.
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
                User newUser = new User(username, indexEnd);
                newUser.AddMessage(line);
                bool passed = true; //I dislike this.
                if (newUser.ToString() != "") // /me posts end up having no defined username and thus are "".
                {
                    foreach (User u in users)
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
                        users.Add(newUser); //Adds it to the users list.
                    }
                }
                else
                {
                    meChats.AddMessage(line); //Add the /me post to the meChats user.
                }
            }

            List<string> tempMeChatList = meChats.UserChatMessages;
            for (int j = 0; j < users.Count; j++)
            {
                for (int i = tempMeChatList.Count - 1; i >= 0; i--) //Now it loops back through all the meChats and assigns the /me post to a known user.
                {
                    if (tempMeChatList[i].IndexOf(users[j].ToString()) == 8)
                    {
                        users[j].AddMessage(tempMeChatList[i]);
                        meChats.RemoveMessage(i);
                    }
                }
            }
        }

        private void PopulateListBox()
        {
            if (textBox_UserFilter.Text == "")
            {
                foreach (User u in users)
                    listBox_Users.Items.Add(u);
            }
            else
            {
                foreach (User u in users)
                {
                    if (u.MessagesContains(textBox_UserFilter.Text, !tools_ButCaseSensitive.Checked))
                        listBox_Users.Items.Add(u);
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
            lookUpForm = new UserLookUp(u.UserChatMessages, u.ToString() , textBox_UserFilter.Text, tools_ButCaseSensitive.Checked); //Creates the lookUpForm.
            lookUpForm.StartPosition = FormStartPosition.CenterParent; //Centers the lookUpForm to the parent.
            lookUpForm.ShowDialog(this); //Shows the form.
        }

        private void listBox_Users_DoubleClick(object sender, EventArgs e)
        {
            if (listBox_Users.SelectedIndex != -1)
            {
                User u = (User)listBox_Users.SelectedItem;
                lookUpForm = new UserLookUp(u.UserChatMessages, u.ToString(), textBox_UserFilter.Text, tools_ButCaseSensitive.Checked); //Creates the lookUpForm.
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
            saveFileDialog_Export.FileName = "User_List.txt";
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
            saveFileDialog_Export.FileName = "Raw_Text.txt";
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

        private void tools_ButManualUpdate_Click(object sender, EventArgs e)
        {
            if (!tools_ButManualUpdate.Checked)
            {
                tools_ButRealTimeUpdate.Checked = tools_ButManualUpdate.Checked;
                tools_ButManualUpdate.Checked = !tools_ButManualUpdate.Checked;
            }
        }

        private void tools_ButRealTimeUpdate_Click(object sender, EventArgs e)
        {
            if (!tools_ButRealTimeUpdate.Checked)
            {
                tools_ButRealTimeUpdate.Checked = tools_ButManualUpdate.Checked;
                tools_ButManualUpdate.Checked = !tools_ButManualUpdate.Checked;
            }
        }

        private void textBox_UserFilter_TextChanged(object sender, EventArgs e)
        {
            if (tools_ButRealTimeUpdate.Checked)
            {
                listBox_Users.Items.Clear(); // Clears the items...
                PopulateListBox(); //Re-populates the box. Note: This may cause problems b/c that's pretty intensive task.
            }
        }

        private void tools_ButCaseSensitive_Click(object sender, EventArgs e)
        {
            tools_ButCaseSensitive.Checked = !tools_ButCaseSensitive.Checked;
            listBox_Users.Items.Clear(); // Clears the items...
            PopulateListBox(); //Re-populates the box. Note: This may cause problems b/c that's pretty intensive task.
        }

        private void viewMeChatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lookUpForm = new UserLookUp(meChats.UserChatMessages, meChats.ToString(), textBox_UserFilter.Text, tools_ButCaseSensitive.Checked); //Creates the lookUpForm.
            lookUpForm.StartPosition = FormStartPosition.CenterParent; //Centers the lookUpForm to the parent.
            lookUpForm.ShowDialog(this); //Shows the form.
        }


    }
}
