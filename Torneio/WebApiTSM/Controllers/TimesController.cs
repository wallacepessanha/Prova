using Logic.Handlers;
using Logic.Model;
using System.Collections.Generic;
using System.Web.Http;

namespace WebApiTSM.Controllers
{
    public class TimesController : ApiController
    {
        private TimeHandlers _servico;

        public TimesController()
        {
            if (_servico == null)
            {
                _servico = new TimeHandlers();
            }
        }

        // GET api/values
        [HttpGet]
        [Route("api/times/Listar")]
        public IEnumerable<TimeModel> Get()
        {
            var model = _servico.Listar();
            return model;
        }

        // GET api/values/5
        [HttpGet]
        [Route("api/times/{id}")]
        public TimeModel Get(int id)
        {
            return _servico.Carregar(id);
        }
       
        // POST api/values
        [HttpPost]
        [Route("api/times/Salvar")]
        public string Post([FromBody]TimeModel value)
        {

            if (value.Id != 0)
            {
                return _servico.Update(value);
            }
            return _servico.Salvar(value);
        }

    }
}
