using Logic.Handlers;
using Logic.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace WebApiTSM.Controllers
{
    public class PartidaController : ApiController
    {
        private PartidaHandlers _servico;

        public PartidaController()
        {
            if (_servico == null)
            {
                _servico = new PartidaHandlers();
            }
        }
        // GET api/values
        [HttpGet]
        [Route("api/Partida/Listar/{id}")]
        public IEnumerable<PartidaModel> GetByTorneio(int Id)
        {
            var model = _servico.Listar(Id);
            return model;
        }
       
        // GET api/values/5
        [HttpGet]
        [Route("api/Partida/{id}")]
        public PartidaModel Get(int id)
        {
            return _servico.Carregar(id);
        }

      
        // POST api/values
        [HttpPost]
        [Route("api/Partida/Salvar")]
        public string Post([FromBody]PartidaModel value)
        {

            if (value.Id != 0)
            {
                return _servico.Update(value);
            }
            return _servico.Salvar(value);
        }

    }
}
