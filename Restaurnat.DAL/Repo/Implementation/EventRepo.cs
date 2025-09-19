
using Restaurnat.DAL.Database;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.DAL.Repo.Implementation
{
    public class EventRepo : IEventRepo
    {
        private readonly ApplicationDbContext DB;

        public EventRepo(ApplicationDbContext DB)
        {
            this.DB = DB;
        }

    }
}
