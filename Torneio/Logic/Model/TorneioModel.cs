using Data;
using System;
using System.Collections.Generic;

namespace Logic.Model
{
    public  class TorneioModel
    {

        public string Nome { get; set; }
        public int Id { get; set; }
        public IList<PartidaModel> Partida { get; set; }
        public IList<TimeModel> Times { get; set; }


        public static TorneioModel TransformarParaModel(Torneio ObjetoRecebido)
        {

            return new TorneioModel
            {
                Id = ObjetoRecebido.Id,
               Nome = ObjetoRecebido.Nome
            };
        }

        public static List<TorneioModel> TransformarParaModel(List<Torneio> ObjetoRecebido)
        {

            var lista = new List<TorneioModel>();

            ObjetoRecebido.ForEach(s => lista.Add(TransformarParaModel(s)));

            return lista;
        }



        public static Torneio TransformarParaEntidade(TorneioModel ObjetoRecebido)
        {

            return new Torneio
            {
                Id = ObjetoRecebido.Id,
                Nome = ObjetoRecebido.Nome
                

            };
        }



        public static List<Torneio> TransformarParaEntidade(List<TorneioModel> ObjetoRecebido)
        {

            var lista = new List<Torneio>();

            ObjetoRecebido.ForEach(s => lista.Add(TransformarParaEntidade(s)));

            return lista;
        }

    }
}
