using Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Handlers
{
    public partial class TorneioHandlers
    {
        public List<TorneioModel> Listar()
        {
            return TorneioModel.TransformarParaModel(db.Torneios.ToList());

        }
        public TorneioModel Carregar(int Id)
        {
            return TorneioModel.TransformarParaModel(db.Torneios.SingleOrDefault(s => s.Id == Id));

        }
    }
}
