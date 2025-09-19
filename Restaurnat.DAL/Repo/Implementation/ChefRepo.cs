
using Restaurnat.DAL.Database;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.DAL.Repo.Implementation
{
    public class ChefRepo : IChefRepo
    {
        private readonly ApplicationDbContext DB;

        public ChefRepo(ApplicationDbContext DB)
        {
            this.DB = DB;
        }
    }
}
