
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.BLL.Services.Implementation
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepo menuRepo;
        public MenuService(IMenuRepo menuRepo)
        {
            this.menuRepo = menuRepo;
        }
    }
}
