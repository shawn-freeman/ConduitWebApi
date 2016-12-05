using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CONDUIT.UnityCL.Transports.Account
{
    [Serializable]
    public class UserInfo
    {
        public int UserId;
        public string Username;
        public string Password;
        public string Email;
    }
}
