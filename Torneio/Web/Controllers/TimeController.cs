using Logic.Handlers;
using Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Util;

namespace Web.Controllers
{
    public class TimeController : Controller
    {
        private string url = "http://webapitorneio.gear.host/";

        // GET: Time
        public ActionResult Index(int Id = 0)
        {

            var Time = new TimeModel();
            if (Id > 0)
            {
                Time = new Comunicacao<TimeModel>(url).Carregar("api/times/"+Id.ToString());
            }
            return View(Time);
        }


        public ActionResult Listar()
        {
            return View(new Comunicacao<TimeModel>(url).Listar("api/times/Listar"));
        }



        [HttpPost]
        public JsonResult Salvar(TimeModel model)
        {

            try
            {
                new Comunicacao<TimeModel>(url).Salvar("api/times/Salvar", model);
                return Json("Ok", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }


        }
    }
}