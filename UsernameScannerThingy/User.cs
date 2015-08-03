using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsernameScannerThingy
{
    class User
    {
        private string username;
        private string userChatMsg;

        public string UserChatMessage
        {
            get { return userChatMsg; }
        }

        public User(string username, string userChatMsg)
        {
            this.username = username;
            this.userChatMsg = userChatMsg;
        }

        public override string ToString()
        {
            return username;
        }

    }
}
