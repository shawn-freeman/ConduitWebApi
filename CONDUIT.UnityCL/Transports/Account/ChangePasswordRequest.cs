using System;

namespace CONDUIT.UnityCL.Transports.Account
{
    [Serializable]
    public class ChangePasswordRequest
    {
        public int UserId;
        public string CurrentPassword;
        public string NewPassword;
    }
}
