
using Restaurnat.DAL.Entities;

namespace Restaurnat.BLL.Services.Apstraction
{
    public interface IReservedItemService
    {
        List<ReservedItem> GetAll();
        ReservedItem GetById(int id);
        (bool, string) Create(ReservedItem newReservedItem);
        bool Update(ReservedItem newReservedItem);
        bool Delete(int id);
    }
}
