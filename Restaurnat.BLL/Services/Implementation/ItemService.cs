
using AutoMapper;
using Restaurnat.BLL.Helper;
using Restaurnat.BLL.ModelVM.Item;
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Entities;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.BLL.Services.Implementation
{
    public class ItemService : IItemService
    {
        private readonly IItemRepo itemRepo;
        private readonly IMapper mapper;
        public ItemService(IItemRepo itemRepo, IMapper mapper)
        {
            this.itemRepo = itemRepo;
            this.mapper = mapper;
        }

        public (bool, string) Create(CreateItemVM newItem)
        {
            try {
                var imagepath = Upload.UploadFile("Files", newItem.image);
                var item = new Item(newItem.name, newItem.price, newItem.description, imagepath, newItem.menu_id, newItem.recommended);
                var result = itemRepo.Create(item);
                if (result.Item1) return (true, "Item created successfully");
                else return (false, "Item creation failed");
            }
            catch (Exception ex) { return (false, ex.Message); }
        }

        public bool Delete(int id)
        {
            try {
                return itemRepo.Delete(id);
            }
            catch (Exception) { return false; }
        }

        public List<GetItemVM> GetAll()
        {
            try { 
                var items = itemRepo.GetAll();
                var result = mapper.Map<List<GetItemVM>>(items);
                return result;
            }
            catch (Exception) { throw; }
        }

        public GetItemVM GetById(int id)
        {
            try {
                var item = itemRepo.GetById(id);
                var result = mapper.Map<GetItemVM>(item);
                return result;
            }
            catch (Exception) { throw; }
        }

        public bool Update(int id, EditItemVM newItem)
        {
            try {
                var item = itemRepo.GetById(id);
                if (item == null) return false;
                var imagepath = Upload.UploadFile("Files", newItem.image);
                item.Update(newItem.name, newItem.price, newItem.description, imagepath, newItem.menu_id, newItem.recommended);
                var result = itemRepo.Update(item);
                return result;
            }
            catch (Exception) { return false; }
        }
    }
}
