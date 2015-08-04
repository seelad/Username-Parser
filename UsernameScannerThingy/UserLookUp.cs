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

        public UserLookUp(List<string> messages, string username)
        {
            InitializeComponent();

            this.messages = messages;
            this.username = username;

            Label_Name.Text = username;
            if (messages != null)
                textBox_Msg.Lines = messages.ToArray();
        }

        private void textBox_Msg_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserLookUp_Load(object sender, EventArgs e)
        {

        }
    }
}
