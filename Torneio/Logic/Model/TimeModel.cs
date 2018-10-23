using Data;
using System.Collections.Generic;

namespace Logic.Model
{
    public  class TimeModel
    {

        public string Nome { get; set; }
        public int Id { get; set; }


        public static TimeModel TransformarParaModel(Time ObjetoRecebido)
        {

            return new TimeModel
            {
                Id = ObjetoRecebido.Id,
               Nome = ObjetoRecebido.Nome,

            };
        }

        public static List<TimeModel> TransformarParaModel(List<Time> ObjetoRecebido)
        {

            var lista = new List<TimeModel>();

            ObjetoRecebido.ForEach(s => lista.Add(TransformarParaModel(s)));

            return lista;
        }



        public static Time TransformarParaEntidade(TimeModel ObjetoRecebido)
        {

            return new Time
            {
                Id = ObjetoRecebido.Id,
                Nome = ObjetoRecebido.Nome

            };
        }



        public static List<Time> TransformarParaEntidade(List<TimeModel> ObjetoRecebido)
        {

            var lista = new List<Time>();

            ObjetoRecebido.ForEach(s => lista.Add(TransformarParaEntidade(s)));

            return lista;
        }

    }
}
