using Data;
using Logic.Model;
using Lvmendes.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Handlers
{
    public partial class TorneioHandlers
    {
        public string Salvar(TorneioModel model)
        {
            //criar campeonato 
            var entidade = TorneioModel.TransformarParaEntidade(model);
            db.Torneios.InsertOnSubmit(entidade);
            db.SubmitChanges();


            var Times = new TimeHandlers().Listar();
            model.Partida = SortearPartidas(Times);

            foreach (var item in model.Partida)
            {
                var entidadePartida = PartidaModel.TransformarParaEntidade(item);
                entidadePartida.TorneioId = entidade.Id;
                db.Partidas.InsertOnSubmit(entidadePartida);
                db.SubmitChanges();
            }


            return "Ok";
        }

        public string Update(TorneioModel model)
        {
            Torneio objeto = db.Torneios.SingleOrDefault(s => s.Id == model.Id);

            model.Partida = SortearPartidas(model.Times.ToList());

            foreach (var item in model.Partida)
            {
                var entidadePartida = PartidaModel.TransformarParaEntidade(item);
                entidadePartida.TorneioId = objeto.Id;
                db.Partidas.InsertOnSubmit(entidadePartida);
                db.SubmitChanges();
            }



            db.SubmitChanges();
            return "Ok";
        }

        public IList<PartidaModel> SortearPartidas(List<TimeModel> listaTimes)
        {


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
                    TimeB = timedois.Id
                });
            }

            return  listaPartidas;
        }
    }
}
