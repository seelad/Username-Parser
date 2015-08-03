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

        public UserNameFinder()
        {
            InitializeComponent();
            this.Text = "Username Parser v0.00"; 
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

        private void toolBut_Load_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Opening a file will erase any unsaved data, continue?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
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

                indexStart += 1; //Adds one to account for the space after the time stamp.
                string username = string.Empty;
                string playerMsg = string.Empty;
                if (indexStart != 0 && indexEnd != -1)
                {
                    username = line.Substring(indexStart, (indexEnd - indexStart));
                    playerMsg = line.Substring(indexEnd);

                }
                User newUser = new User(username, playerMsg);
                bool passed = true; //I dislike this.
                foreach (User u in tempUsers)
                {
                    if (u.ToString() == newUser.ToString() || newUser.ToString() == "")
                    {
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

            label_Users.Text = "Users (" + listBox_Users.Items.Count + ")";

        }


    }
}
