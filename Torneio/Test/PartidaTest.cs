using System;
using System.Collections.Generic;
using System.Linq;
using Logic.Handlers;
using Logic.Model;
using Lvmendes.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util;

namespace Test
{
    [TestClass]
    public class PartidaTest
    {
       
        private string url = "http://webapitorneio.gear.host/";




        [TestMethod]
        public void Criar()
        {
            var Partidas = new Comunicacao<PartidaModel>(url).Listar("api/Partida/Listar/3");

            foreach (var item in Partidas)
            {
                item.GolsA = 1;
                item.GolsB = 4;

                var torneioSave = new PartidaHandlers().Update(item);
            }

        }



        [TestMethod]
        public void CriarService()
        {

            var listaTimes = new TimeHandlers().Listar();

            var listaPartidas = new List<PartidaModel>();
            while (listaTimes.Count > 1)
            {
                var timeUm = Parte.GetRandom(listaTimes);
                listaTimes.Remove(timeUm);
                var timedois = Parte.GetRandom(listaTimes);
                listaTimes.Remove(timedois);

                listaPartidas.Add(new PartidaModel
                {
                    TimeA = timeUm.Id,
                    TimeB = timedois.Id,
               
                });
            }


            TorneioModel torneio = new TorneioModel { Nome = "Teste"};
            torneio.Partida = new List<PartidaModel>();
            foreach (var item in listaPartidas)
            {
                torneio.Partida.Add(item);
            }

            var torneioSave = new TorneioHandlers().Salvar(torneio);


        }

    }
}
