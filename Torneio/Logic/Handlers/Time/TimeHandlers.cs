using Data;

namespace Logic.Handlers
{
    public partial class TimeHandlers
    {
        private DB_TorneioDataContext db;

        public TimeHandlers()
        {
            if (db == null)
            {
                db = new DB_TorneioDataContext();
            }

        }
    }
}
