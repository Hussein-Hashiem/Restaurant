
using Restaurnat.DAL.Entities;

namespace Restaurnat.DAL.Repo.Apstraction
{
    public interface ITableRepo
    {
        List<Table> GetAll();
        Table GetById(int id);
        (bool, string) Create(Table newTable);
        bool Update(Table newTable);
        bool Delete(int id);
    }
}
