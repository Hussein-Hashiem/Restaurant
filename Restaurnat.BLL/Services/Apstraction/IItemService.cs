
using Restaurnat.DAL.Entities;

namespace Restaurnat.BLL.Services.Apstraction
{
    public interface IItemService
    {
        List<Item> GetAll();
        Item GetById(int id);
        (bool, string) Create(Item newItem);
        bool Update(Item newItem);
        bool Delete(int id);
    }
}
