using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Handlers
{
   public partial class TorneioHandlers
    {
        private DB_TorneioDataContext db;

        public TorneioHandlers()
        {
            if (db == null)
            {
                db = new DB_TorneioDataContext();
            }

        }
    }
}
