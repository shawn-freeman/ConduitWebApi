using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityCL
{
    [Serializable]
    public class ChangePasswordRequest
    {
        public int UserId { get; set; }
        public int CurrentPassword { get; set; }
        public int NewPassword { get; set; }
    }
}
