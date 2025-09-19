
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.BLL.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepo userRepo;
        public UserService(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }
    }
}
