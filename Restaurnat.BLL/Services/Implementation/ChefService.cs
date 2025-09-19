
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.BLL.Services.Implementation
{
    public class ChefService : IChefService
    {
        private readonly IChefRepo chefRepo;
        public ChefService(IChefRepo chefRepo)
        {
            this.chefRepo = chefRepo;
        }
    }
}
