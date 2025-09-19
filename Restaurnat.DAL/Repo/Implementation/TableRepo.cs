
using Restaurnat.DAL.Database;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.DAL.Repo.Implementation
{
    public class TableRepo : ITableRepo
    {
        private readonly ApplicationDbContext DB;

        public TableRepo(ApplicationDbContext DB)
        {
            this.DB = DB;
        }
    }
}
