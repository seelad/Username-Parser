using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsernameScannerThingy
{
    public partial class UserLookUp : Form
    {
        private string username;
        private List<string> messages;
        private string filter;
        private bool filterCaseSensitive;

        public UserLookUp(List<string> messages, string username, string filter, bool filterCaseSensitive)
        {
            InitializeComponent();

            this.messages = messages;
            this.username = username;
            this.filter = filter;
            this.filterCaseSensitive = filterCaseSensitive;

            Label_Name.Text = username;
            
        }

        private void UserLookUp_Load(object sender, EventArgs e)
        {
            if (messages != null)
                textBox_Msg.Lines = messages.ToArray();

            if (filter != "")
            {
                toolTip_FilterChats.SetToolTip(textBox_MsgFilter, "This message box contains the message(s) which contain \"" + filter + "\"");
                List<string> matchedMessages = new List<string>();

                foreach (string m in messages)
                {
                    if (MessageContains(m,filter, !filterCaseSensitive))
                        matchedMessages.Add(m);
                }

                textBox_MsgFilter.Lines = matchedMessages.ToArray();

            }
            else
                toolTip_FilterChats.SetToolTip(textBox_MsgFilter, "This message box would contain the message(s) which contain the specified filter.");
                
        }

        private bool MessageContains(string msg, string str, bool lowerCase)
        {
            bool containsExact = false;
            if (str[0] == '*')
            {
                str = str.Remove(0, 1);
                containsExact = true;
            }

            if (lowerCase)
                str = str.ToLower(); //Gets a lowercase copy of the string.

            string sLow = msg.Substring(8 + username.Length);
            if (lowerCase)
                sLow = sLow.ToLower();
            if (sLow.IndexOf(str) != -1)
            {
                if (containsExact)
                {
                    int strIndex = sLow.IndexOf(str);

                    if (strIndex == 0 || sLow[strIndex - 1] == ' ')
                    {
                        if (strIndex + str.Length - 1 == sLow.Length - 1)
                            return true;
                        else if (sLow[strIndex + str.Length] == ' ')
                            return true;
                    }
                }
                else
                    return true;
                    
            }

            return false;
        }

        private void textBox_Msg_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
