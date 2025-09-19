
using Restaurnat.DAL.Database;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.DAL.Repo.Implementation
{
    public class ReservedTableRepo : IReservedTableRepo
    {
        private readonly ApplicationDbContext DB;

        public ReservedTableRepo(ApplicationDbContext DB)
        {
            this.DB = DB;
        }
    }
}