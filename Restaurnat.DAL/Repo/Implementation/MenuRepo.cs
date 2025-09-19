
using Restaurnat.DAL.Database;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.DAL.Repo.Implementation
{
    public class MenuRepo : IMenuRepo
    {
        private readonly ApplicationDbContext DB;

        public MenuRepo(ApplicationDbContext DB)
        {
            this.DB = DB;
        }
    }
}
