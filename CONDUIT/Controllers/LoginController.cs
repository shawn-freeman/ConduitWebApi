using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

using CONDUIT.DataLayer;
using CONDUIT.UnityCL;

namespace CONDUIT.Controllers
{
    public class LoginController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        public int Get(string username, string password)
        {
            using (var entities = new CONDUIT_Entities())
            {
                var result = entities.checkLoginSP(username, password).FirstOrDefault();

                if (result.HasValue) return result.Value;
                else return -1;
            }
        }

        // POST api/<controller>
        [HttpPost]
        public bool Post(string obj)
        {
            using (var entities = new CONDUIT_Entities())
            {
                try
                {
                    var changeRequest = JsonConvert.DeserializeObject<ChangePasswordRequest>(obj);
                    entities.changePasswordSP(changeRequest.UserId, changeRequest.CurrentPassword, changeRequest.NewPassword);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}