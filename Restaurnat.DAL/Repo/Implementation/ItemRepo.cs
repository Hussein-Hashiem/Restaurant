
using Restaurnat.DAL.Database;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.DAL.Repo.Implementation
{
    public class ItemRepo : IItemRepo
    {
        private readonly ApplicationDbContext DB;

        public ItemRepo(ApplicationDbContext DB)
        {
            this.DB = DB;
        }
    }
}
