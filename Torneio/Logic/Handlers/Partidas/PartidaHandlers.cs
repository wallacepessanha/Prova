using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Handlers
{
   public partial class PartidaHandlers
    {
        private DB_TorneioDataContext db;

        public PartidaHandlers()
        {
            if (db == null)
            {
                db = new DB_TorneioDataContext();
            }

        }
    }
}
