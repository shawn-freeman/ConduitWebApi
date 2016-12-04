using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CONDUIT.UnityCL.Transports.Account
{
    [Serializable]
    public class CreateAccountRequest
    {
        public string Username;
        public string Password;
        public string Email;
        public bool TestCreation = false;
    }
}
