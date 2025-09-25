

using Restaurnat.BLL.ModelVM.Item;
using Restaurnat.DAL.Entities;

namespace Restaurnat.BLL.Services.Apstraction
{
    public interface IItemService
    {
        List<GetItemVM> GetAll();
        GetItemVM GetById(int id);
        (bool, string) Create(Item newItem);
        bool Update( Item newItem);
        bool Delete(int id);
        
    }
}
