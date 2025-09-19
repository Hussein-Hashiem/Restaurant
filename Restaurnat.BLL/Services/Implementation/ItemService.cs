
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.BLL.Services.Implementation
{
    public class ItemService : IItemService
    {
        private readonly IItemRepo itemRepo;
        public ItemService(IItemRepo itemRepo)
        {
            this.itemRepo = itemRepo;
        }
    }
}
