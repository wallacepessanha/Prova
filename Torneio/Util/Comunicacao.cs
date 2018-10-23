using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Util
{
    public partial class Comunicacao<T>
    {
        static HttpClient client;
        public Uri usuarioUri;

        public Comunicacao(string url)
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }


        }
    }
}
