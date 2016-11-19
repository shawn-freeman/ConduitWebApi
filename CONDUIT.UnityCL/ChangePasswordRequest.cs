using System;

namespace CONDUIT.UnityCL
{
    [Serializable]
    public class ChangePasswordRequest
    {
        public int UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
