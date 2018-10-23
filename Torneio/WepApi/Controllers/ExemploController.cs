using Logic.Handlers;
using Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace WepApi.Controllers
{
    [RoutePrefix("api/Exemplo")]
    public class ExemploController : ApiController
    {

        /// <summary>
        /// Register a new user on application
        /// </summary>
        /// <param name="user">New user to register</param>
        /// <remarks>Adds new user to application and grant access</remarks>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [AllowAnonymous]
        [Route("Register")]
        [ResponseType(typeof(ExemploModel))]
        [HttpPost]
        public IHttpActionResult Register(ExemploModel user)
        {
            var handlers = new ExemploHandlers();

            return Ok(handlers.Salvar(user));
        }
    }
}
