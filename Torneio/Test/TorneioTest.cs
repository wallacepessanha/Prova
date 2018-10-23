using System;
using System.Collections.Generic;
using Logic.Handlers;
using Logic.Model;
using Lvmendes.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util;

namespace Test
{
    [TestClass]
    public class TorneioTest
    {
        private string url = "http://webapitorneio.gear.host/";

       
        [TestMethod]
        public void Criar()
        {
            var torneio = new TorneioModel { Nome = "Super Copa" };

            var listaTimes = new Comunicacao<TimeModel>(url).Listar("api/times/Listar");

            var listaPartidas = new List<PartidaModel>();
            while (listaTimes.Count > 0)
            {
                var timeUm = Parte.GetRandom(listaTimes);
                listaTimes.Remove(timeUm);
                var timedois = Parte.GetRandom(listaTimes);
                listaTimes.Remove(timedois);

                listaPartidas.Add(new PartidaModel
                {
                    TimeA = timeUm.Id,
                    TimeB = timedois.Id
                });
            }

            torneio.Partida = new List<PartidaModel>();
            foreach (var item in listaPartidas)
            {
                torneio.Partida.Add(item);
            }
            new Comunicacao<TorneioModel>(url).Salvar("api/salvar/", torneio);            
            var resultado = new Comunicacao<TorneioModel>(url).Listar("api/torneio/Listar");
            var partidas = new Comunicacao<PartidaModel>(url).Listar("api/Partida/" + torneio.Id.ToString());

            Assert.AreEqual(resultado.Exists(s=>s.Nome == torneio.Nome), true);
        }

       
    }
}
