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
        private List<string> msgs;

        public List<string> UserChatMessages
        {
            get { return msgs; }
        }

        public User(string username)
        {
            this.username = username;
            msgs = new List<string>();
        }

        public void AddMessage(string message)
        {
            msgs.Add(message);
        }

        public override string ToString()
        {
            return username;
        }

    }
}
