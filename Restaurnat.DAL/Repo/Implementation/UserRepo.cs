
using Restaurnat.DAL.Database;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.DAL.Repo.Implementation
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext DB;

        public UserRepo(ApplicationDbContext DB)
        {
            this.DB = DB;
        }
    }
}
