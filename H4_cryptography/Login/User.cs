using System;
using System.Collections.Generic;
using System.Text;

namespace H4_cryptography.Login
{
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool success { get; set; }
        public User()
        {
            Salt = null;
        }
    }
}
