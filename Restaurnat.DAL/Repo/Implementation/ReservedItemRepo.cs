
using Restaurnat.DAL.Database;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.DAL.Repo.Implementation
{
    public class ReservedItemRepo : IReservedItemRepo
    {
        private readonly ApplicationDbContext DB;

        public ReservedItemRepo(ApplicationDbContext DB)
        {
            this.DB = DB;
        }
    }
}
