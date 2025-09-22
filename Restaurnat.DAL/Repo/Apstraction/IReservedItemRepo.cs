
using Restaurnat.DAL.Entities;

namespace Restaurnat.DAL.Repo.Apstraction
{
    public interface IReservedItemRepo
    {
        List<ReservedItem> GetAll();
        ReservedItem GetById(int id);
        (bool, string) Create(ReservedItem newReservedItem);
        bool Update(ReservedItem newReservedItem);
        bool Delete(int id);
    }
}