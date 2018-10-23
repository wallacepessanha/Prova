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
        public List<PartidaModel> Listar(int IdTorneio)
        {
            return PartidaModel.TransformarParaModel(db.Partidas.Where(s=>s.TorneioId == IdTorneio) .ToList());

        }
 
        public PartidaModel Carregar(int Id)
        {
            return PartidaModel.TransformarParaModel(db.Partidas.SingleOrDefault(s => s.Id == Id));

        }
    }
}
