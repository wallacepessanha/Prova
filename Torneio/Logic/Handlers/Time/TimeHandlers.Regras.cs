using Data;
using Logic.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Handlers
{
    public partial class TimeHandlers
    {

        

        /// <summary>
        /// Regra nome identico
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Regra_NomeIdentico(TimeModel model)
        {
           

            if (db.Times.Count(s => s.Nome == model.Nome) > 0)
                return true;
            else
                return false;

        }
    }
}
