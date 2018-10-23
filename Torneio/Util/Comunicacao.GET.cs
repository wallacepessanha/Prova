using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Util
{
    public partial class Comunicacao<T>
    {     /// <summary>
          /// "api/usuario"
          /// </summary>
          /// <param name="metodo"></param>
          /// <returns></returns>
        public T Carregar(string metodo)
        {


            System.Net.Http.HttpResponseMessage response = client.GetAsync(metodo).Result;
            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
                usuarioUri = response.Headers.Location;
                var objeto = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(objeto);
            }
            return JsonConvert.DeserializeObject<T>(null);


        }

        public List<T> Listar(string metodo)
        {


            System.Net.Http.HttpResponseMessage response = client.GetAsync(metodo).Result;
            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
                var objeto = response.Content.ReadAsStringAsync().Result;
                var reto = JsonConvert.DeserializeObject<List<T>>(objeto);

                return reto;
            }
            return JsonConvert.DeserializeObject<List<T>>(null);
        }

    }
}
