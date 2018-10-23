using Logic.Model;
using Lvmendes.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Util;

namespace Web.Controllers
{
    public class TorneioController : Controller
    {
        private string url = "http://webapitorneio.gear.host/";
       
        // GET: Torneio
        public ActionResult Index(int Id = 0)
        {

            var torneio = new TorneioModel();
            if (Id > 0)
            {
                torneio =  new Comunicacao<TorneioModel>(url).Carregar("api/torneio/"+Id.ToString());
            }
            return View(torneio);
        }


        public ActionResult Listar()
        {
            return View(new Comunicacao<TorneioModel>(url).Listar("api/torneio/Listar"));
        }



        [HttpPost]
        public JsonResult Salvar(TorneioModel model)
        {
            try
            {
                

                new Comunicacao<TorneioModel>(url).Salvar("api/torneio/Salvar", model);
                return Json("Ok", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}