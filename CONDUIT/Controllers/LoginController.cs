using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

using CONDUIT.DataLayer;
using CONDUIT.UnityCL.Transports.Account;
using CONDUIT.UnityCL.Transports.ErrorHandling;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using CONDUIT.UnityCL.Helpers;

namespace CONDUIT.Controllers
{
    public class LoginController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        public string Get(string obj)
        {
            ReturnResult<UserInfo> retResult;
            string retJson;
            using (var entities = new CONDUIT_Entities())
            {
                
                try
                {
                    var loginRequest = JsonConvert.DeserializeObject<LoginRequest>(obj);
                    var result = entities.checkLoginSP(loginRequest.Username, loginRequest.Password).FirstOrDefault();

                    if (result != null)
                    {
                        var userInfo = new UserInfo()
                        {
                            UserId = result.ID,
                            Username = result.Username,
                            Password = result.Password,
                            Email = result.Email

                        };

                        retResult = new ReturnResult<UserInfo>(userInfo);
                        retJson = JsonConvert.SerializeObject(retResult);
                    }
                    else
                    {

                        retResult = new ReturnResult<UserInfo>(null, "Could not find user.");
                        retJson = JsonConvert.SerializeObject(retResult);
                    };
                }
                catch (Exception ex)
                {

                    retResult = new ReturnResult<UserInfo>(null, ex.ToString());
                    retJson = JsonConvert.SerializeObject(retResult);
                }

                return retJson;
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