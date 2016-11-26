using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CONDUIT.PCL.Handlers;
using CONDUIT.UnityCL.Helpers;
using CONDUIT.UnityCL.Transports.Account;
using Newtonsoft.Json;

namespace ApiTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            var test = new Test();
            while (true)
            {
                Console.WriteLine("Hit any key to run the test");
                var input = Console.ReadLine();
                Console.WriteLine("Running Test...");
                var result = test.TryTest();
                Console.WriteLine($"Test returned: {result.Result}");

            }
        }
    }

    public class Test
    {
        public async Task<bool> TryTest()
        {
            var request = new LoginRequest();
            request.Username = "shawn";
            request.Password = "guyver";

            //serialize
            var json = JsonConvert.SerializeObject(request);

            var baseHandler = new Base();
            var result = await baseHandler.GetAsync<byte[]>($"Login?obj={json}");

            var response = ObjectConverter.BytesToObject<UserInfo>(result);

            return true;
        }
    }
}
