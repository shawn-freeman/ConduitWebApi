using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CONDUIT.PCL.Handlers
{
    public class Base
    {
        private readonly string _baseUrl;
        public string ErrorString;

        public Base(string baseURL = "http://localhost:57871/api/")
        {
            _baseUrl = baseURL;
        }

        private HttpClient GetHttpClient()
        {
            var handler = new HttpClientHandler();

            var client = new HttpClient(handler) { Timeout = TimeSpan.FromMinutes(20) };

            return client;
        }

        private string parseString(string urlArguments)
        {
            return urlArguments.Replace("=&", "=null&");
        }

        public T GetSync<T>(string urlArguments)
        {
            var url = String.Format(_baseUrl + "{0}", parseString(urlArguments));

            try
            {
                var client = GetHttpClient();

                var str = client.GetStringAsync(url).GetAwaiter().GetResult();

                return JsonConvert.DeserializeObject<T>(str);
            }
            catch (Exception ex)
            {
                ErrorString = url + "|" + ex.ToString();

                return default(T);
            }
        }
        public async Task<T> GetAsync<T>(string urlArguments)
        {
            try
            {
                var client = GetHttpClient();

                var str = await client.GetStringAsync(String.Format(_baseUrl + "{0}", urlArguments));

                return JsonConvert.DeserializeObject<T>(str);

            }
            catch (Exception ex)
            {
                string ext = ex.ToString();

                return default(T);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">The type being passed to this post request as the obj parameter</typeparam>
        /// <typeparam name="K">The type expecting back from the response</typeparam>
        /// <param name="urlArguments"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<K> Post<T, K>(string urlArguments, T obj)
        {
            var client = GetHttpClient();

            var content = new System.Net.Http.StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            var uri = String.Format(_baseUrl + "{0}", urlArguments);
            var response = await client.PostAsync(uri, content);

            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<K>(data);
        }
    }
}
