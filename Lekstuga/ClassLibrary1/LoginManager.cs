using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreSolution
{
    public class LoginManager
    {
        private string _username;
        private string _password;
        public bool RegisterNewUser(string username, string password)
        {
            if (_username == username)
            {
                return false;
            }
            else
            {
                _username = username;
                _password = password;
                return true;
            }
        }

        public bool TryLogin(string username, string password)
        {
            bool usernameAndpasswordMatches = 
                username == _username && password == _password;
            return usernameAndpasswordMatches;
        }
    }
}
