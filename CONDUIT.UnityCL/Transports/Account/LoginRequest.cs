using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CONDUIT.UnityCL.Transports.Account
{
    [Serializable]
    public class LoginRequest
    {
        public string Username;
        public string Password;
    }
}
