
using Restaurnat.DAL.Entities;

namespace Restaurnat.DAL.Repo.Apstraction
{
    public interface IItemRepo
    {
        List<Item> GetAll();
        Item GetById(int id);
        (bool, string) Create(Item newItem);
        bool Update(Item newItem);
        bool Delete(int id);
    }
}