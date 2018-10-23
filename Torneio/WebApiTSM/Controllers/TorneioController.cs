using Logic.Handlers;
using Logic.Handlers;
using Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiTSM.Controllers
{
    public class TorneioController : ApiController
    {
        private TorneioHandlers _servico;

        public TorneioController()
        {
            if (_servico == null)
            {
                _servico = new TorneioHandlers();
            }
        }

        // GET api/values
        [HttpGet]
        [Route("api/torneio/Listar")]
        public IEnumerable<TorneioModel> Get()
        {
            var model = _servico.Listar();
            return model;
        }

        // GET api/values/5
        [HttpGet]
        [Route("api/torneio/{id}")]
        public TorneioModel Get(int id)
        {
            return _servico.Carregar(id);
        }

        // POST api/values
        [HttpPost]
        [Route("api/torneio/Salvar")]
        public string Post([FromBody]TorneioModel value)
        {

            if (value.Id != 0)
            {
                return _servico.Update(value);
            }


            return _servico.Salvar(value);


        }

    }
}
