

using Restaurnat.BLL.ModelVM.Item;

namespace Restaurnat.BLL.Services.Apstraction
{
    public interface IItemService
    {
        List<GetItemVM> GetAll();
        GetItemVM GetById(int id);
        (bool, string) Create(CreateItemVM newItem);
        bool Update(int id, EditItemVM newItem);
        bool Delete(int id);
    }
}
