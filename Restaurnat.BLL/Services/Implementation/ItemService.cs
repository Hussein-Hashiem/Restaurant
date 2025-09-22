
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Entities;
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

        public (bool, string) Create(Item newItem)
        {
            if (string.IsNullOrWhiteSpace(newItem.name) || string.IsNullOrWhiteSpace(newItem.description) || newItem.price <= 0)
            {
                return (false, "Item is required");
            }
            var result = itemRepo.Create(newItem);
            return result;

        }

        public bool Delete(int id)
        {
            if (id == 0)
            {
                return false;
            }
            return itemRepo.Delete(id);
        }

        public List<Item> GetAll()
        {
            return itemRepo.GetAll();
        }

        public Item GetById(int id)
        {
            return (itemRepo.GetById(id));
        }

        public bool Update(Item newItem)
        {
            return itemRepo != null && itemRepo.Update(newItem);
        }
    }
}
