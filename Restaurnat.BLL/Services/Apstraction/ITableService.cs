
using Restaurnat.DAL.Entities;


namespace Restaurnat.BLL.Services.Apstraction
{
    public interface ITableService
    {
        List<Table> GetAll();
        Table GetById(int id);
        (bool, string) Create(Table newTable);
        bool Update(Table newTable);
        bool Delete(int id);
    }
}
