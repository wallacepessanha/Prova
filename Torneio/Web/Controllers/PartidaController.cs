using Logic.Handlers;
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
    public class PartidaController : Controller
    {
        private string url = "http://webapitorneio.gear.host/";

        // GET: Torneio
        public ActionResult Index(int Id = 0)
        {


            var torneio = new Comunicacao<TorneioModel>(url).Carregar("api/torneio/"+ Id.ToString());
          
            torneio.Partida = ListarPartidas(Id);



            return View(torneio);
        }


        public IList<PartidaModel> ListarPartidas(int id)
        {
            var Partidas = new Comunicacao<PartidaModel>(url).Listar("api/Partida/Listar/" + id.ToString());

            Partidas = Partidas.Where(s => s.Realizado == 0).ToList();

     var times = ListarTimes();

            Partidas.ForEach(s => {

                s.NomeTimeA = times.Single(d => d.Id == s.TimeA);
                s.NomeTimeB = times.Single(d => d.Id == s.TimeB);
            });


            return Partidas;
        }
        public IList<TimeModel> ListarTimes()
        {
            var Times = new Comunicacao<TimeModel>(url).Listar("api/times/Listar");




            return Times;
        }
        public ActionResult Listar()
        {
            return View(new Comunicacao<TorneioModel>(url).Listar("Listar"));
        }



        [HttpPost]
        public JsonResult Salvar(TorneioModel model)
        {
            try
            {
                new Comunicacao<TorneioModel>(url).Salvar("Salvar", model);
                return Json("Ok", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public JsonResult Resultado(TorneioModel model)
        {
            try
            {

                bool empate = false;

                model.Partida.ToList().ForEach(s => {

                    if (s.GolsA == s.GolsB)
                    {
                        empate = true;
                    }

                });


                if (empate)
                {
                    return Json("Penalts", JsonRequestBehavior.AllowGet);
                }




                foreach (var item in model.Partida)
                {
                    new Comunicacao<PartidaModel>(url).Salvar("api/Partida/Salvar", item);
                }

                var timesVencedores = new List<int>();

                foreach (var item in model.Partida)
                {
                    if (item.GolsA > item.GolsB)
                    {
                        timesVencedores.Add(item.TimeA);
                    }
                    else
                    {
                        timesVencedores.Add(item.TimeB);
                    }
                }
                model.Times = new List<TimeModel>();
                foreach (var item in timesVencedores)
                {
                    model.Times.Add(new TimeModel { Id = item });
                }

                new Comunicacao<TorneioModel>(url).Salvar("api/Torneio/Salvar", model);



                return Json("Ok");
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }


        
    }
}