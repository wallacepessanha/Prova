using Logic.Model;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Handlers
{
    public partial class TimeHandlers
    {

        
        public List<TimeModel> Listar()
        {

            return TimeModel.TransformarParaModel(db.Times.ToList());
                    
        }
        public TimeModel Carregar(int Id)
        {
            return TimeModel.TransformarParaModel(db.Times.SingleOrDefault(s=>s.Id == Id));

        }
    }
}
