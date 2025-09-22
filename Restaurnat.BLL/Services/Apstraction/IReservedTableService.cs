
using Restaurnat.DAL.Entities;

namespace Restaurnat.BLL.Services.Apstraction
{
    public interface IReservedTableService
    {
        List<ReservedTable> GetAll();
        ReservedTable GetById(int id);
        (bool, string) Create(ReservedTable newReservedTable);
        bool Update(ReservedTable reservedTable);
        bool Delete(int id);
    }
}
