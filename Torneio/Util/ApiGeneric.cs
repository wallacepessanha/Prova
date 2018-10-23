using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class ApiGeneric<T>
    {
        HttpClient client = new HttpClient();
        public async Task<List<T>> Get(string url)
        {
            try
            {
                var response = await client.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<List<T>>(response);
                return produtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async void Post(T t, string uri)
        {
            try
            {

                var jsoninString = JsonExtensions.ToJson<T>(t);

                using (var client = new HttpClient())
                {

                    await client.PostAsync(uri, new StringContent(jsoninString.ToString(), Encoding.UTF8, "application/json"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
