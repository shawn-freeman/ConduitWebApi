using System;

namespace CONDUIT.UnityCL
{
    [Serializable]
    public class ChangePasswordRequest
    {
        public int UserId;
        public string CurrentPassword;
        public string NewPassword;
    }
}
