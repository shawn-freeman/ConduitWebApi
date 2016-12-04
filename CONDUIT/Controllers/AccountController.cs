using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


using CONDUIT.DataLayer;
using CONDUIT.UnityCL.Transports.Account;
using CONDUIT.UnityCL.Transports.ErrorHandling;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace CONDUIT.Controllers
{
    public class AccountController : ApiController
    {
        [HttpGet]
        public string GetAccount()
        {
            return "GetAccountInfo()";
        }

        [HttpPost]
        public string Post(string obj)
        {
            string retJson;
            ReturnResult<bool> retResult;
            
            using (var entities = new CONDUIT_Entities())
            {
                try
                {
                    var accountRequest = JsonConvert.DeserializeObject<CreateAccountRequest>(obj);

                    var numUsers = entities.checkUserExists(accountRequest.Username, accountRequest.Email).FirstOrDefault();
                    if (numUsers.Value <= 0)
                    {
                        var paramUsername = new SqlParameter("@Username", accountRequest.Username);
                        var paramPassword = new SqlParameter("@Password", accountRequest.Password);
                        var paramEmail = new SqlParameter("@Email", accountRequest.Email);
                        var paramTest = new SqlParameter("@TestCreation", accountRequest.TestCreation);

                        entities.Database.ExecuteSqlCommand("createUserSP @Username, @Password, @Email, @TestCreation", paramUsername, paramPassword, paramEmail, paramTest);

                        //success
                        retResult = new ReturnResult<bool>(true);
                        retJson = JsonConvert.SerializeObject(retResult);
                    }else
                    {
                        retResult = new ReturnResult<bool>(false, "Username/Email has already been used.");
                        retJson = JsonConvert.SerializeObject(retResult);
                    }
                }
                catch (Exception ex)
                {
                    retResult = new ReturnResult<bool>(false, ex.ToString());
                    retJson = JsonConvert.SerializeObject(retResult); 
                }
                
            }

            return retJson;
        }

        [HttpPut]
        public bool UpdateAccount(string obj)
        {
            return true;
        }
    }
}