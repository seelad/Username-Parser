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
        private int messageStartIndex;

        public List<string> UserChatMessages
        {
            get { return msgs; }
        }

        public User(string username, int messageStartIndex)
        {
            this.username = username;
            this.messageStartIndex = messageStartIndex;
            msgs = new List<string>();
        }

        public bool MessagesContains(string str, bool lowerCase)
        {
            bool containsExact = false;
            if (str[0] == '*')
            {
                str = str.Remove(0,1);
                containsExact = true;
            }

            if (lowerCase)
                str = str.ToLower(); //Gets a lowercase copy of the string.

            foreach (string s in msgs)
            {
                string sLow = s.Substring(messageStartIndex);
                if (lowerCase)
                    sLow = sLow.ToLower();
                if (sLow.IndexOf(str) != -1)
                {
                    if (containsExact)
                    {
                        int strIndex = sLow.IndexOf(str);
                        string acceptableChars = " .?:;!()[]{},^-+=_#@$"; //List of chars which can be at the beginning and end of the desired filter and not be considered part of it.
                        if (strIndex == 0 || acceptableChars.Contains(sLow[strIndex - 1]))
                        {
                            if (strIndex + str.Length - 1 == sLow.Length - 1)
                                return true;
                            else if (acceptableChars.Contains(sLow[strIndex + str.Length]))
                                return true;
                        }
                    }
                    else
                        return true;
                }
            }
            return false;
        }

        public void RemoveMessage(int index)
        {
            msgs.RemoveAt(index);
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
