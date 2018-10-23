using Data;
using Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Handlers
{
   public partial class PartidaHandlers
    {
        public string Salvar(PartidaModel model)
        {


            db.Partidas.InsertOnSubmit(
                                PartidaModel.TransformarParaEntidade(model)
                                   );
            db.SubmitChanges();
            return "Ok";
        }

        public string Update(PartidaModel model)
        {
            Partida objeto = db.Partidas.SingleOrDefault(s => s.Id == model.Id);

            objeto.GolsTimeA = model.GolsA;
            objeto.GolsTimeB = model.GolsB;
            objeto.Realizado = 1;
            db.SubmitChanges();





            return "Ok";
        }
    }
}
