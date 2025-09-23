
using Restaurnat.DAL.Entities;

namespace Restaurnat.DAL.Repo.Apstraction
{
    public interface IReservedTableRepo
    {
        List<ReservedTable> GetAll();
        ReservedTable GetById(int id);
        (bool, string) Create(ReservedTable newReservedTable);
        bool Update(ReservedTable reservedTable);
        bool Delete(int id);
    }
}
