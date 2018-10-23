using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Util
{
    public partial class Comunicacao<T>
    {

        /// <summary>
        /// "api/usuario"
        /// </summary>
        /// <param name="metodo"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        public void Salvar(string metodo, T valor)
        {
            var myContent = JsonConvert.SerializeObject(valor);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = client.PostAsync(metodo, byteContent).Result;
        }

        public T Post(string metodo, T valor)
        {
            var myContent = JsonConvert.SerializeObject(valor);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return JsonConvert.DeserializeObject<T>(client.PostAsync(metodo, byteContent).Result.Content.ReadAsStringAsync().Result);
        }


    }
}
