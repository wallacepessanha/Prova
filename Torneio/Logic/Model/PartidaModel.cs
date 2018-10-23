using Data;
using System;
using System.Collections.Generic;

namespace Logic.Model
{
    public  class PartidaModel
    {

     
        public int Id { get; set; }
        public int TimeA { get; set; }
        public virtual TimeModel NomeTimeA { get; set; }
        public int TimeB { get; set; }
        public virtual TimeModel NomeTimeB { get; set; }
        public int GolsA { get; set; }
        public int GolsB { get; set; }
        public int TorneioId { get; set; }
        public int Realizado { get; set; }
        public static PartidaModel TransformarParaModel(Partida ObjetoRecebido)
        {

            return new PartidaModel
            {
                Id = ObjetoRecebido.Id,
                TimeA = ObjetoRecebido.TimeA,
                TimeB = ObjetoRecebido.TimeB,
                GolsA = ObjetoRecebido.GolsTimeA.Value,
                GolsB = ObjetoRecebido.GolsTimeB.Value,
                TorneioId = ObjetoRecebido.TorneioId,
                Realizado = ObjetoRecebido.Realizado.Value
            };
        }

        public static List<PartidaModel> TransformarParaModel(List<Partida> ObjetoRecebido)
        {

            var lista = new List<PartidaModel>();

            ObjetoRecebido.ForEach(s => lista.Add(TransformarParaModel(s)));

            return lista;
        }



        public static Partida TransformarParaEntidade(PartidaModel ObjetoRecebido)
        {

            return new Partida
            {
             
                Id = ObjetoRecebido.Id,
                TimeA = ObjetoRecebido.TimeA,
                TimeB = ObjetoRecebido.TimeB,
                GolsTimeA = ObjetoRecebido.GolsA,
                GolsTimeB = ObjetoRecebido.GolsB,
                TorneioId = ObjetoRecebido.TorneioId,
                Realizado = ObjetoRecebido.Realizado
            };
        }



        public static List<Partida> TransformarParaEntidade(List<PartidaModel> ObjetoRecebido)
        {

            var lista = new List<Partida>();

            ObjetoRecebido.ForEach(s => lista.Add(TransformarParaEntidade(s)));

            return lista;
        }

    }
}
