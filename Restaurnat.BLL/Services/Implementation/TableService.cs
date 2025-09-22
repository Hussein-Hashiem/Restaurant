using Restaurnat.DAL.Entities;
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.BLL.Services.Implementation
{
    public class TableService : ITableService
    {
        private readonly ITableRepo tableRepo;
        public TableService(ITableRepo _tableRepo)
        {
            this.tableRepo = _tableRepo;
        }

        public (bool, string) Create(Table newTable)
        {
            if (newTable.capacity <= 0)
            {
                return (false, "Capacity must be greater than zero");
            }
            return tableRepo.Create(newTable);
        }

        public bool Delete(int id)
        {
            return tableRepo.Delete(id);
        }

        public List<Table> GetAll()
        {
            return tableRepo.GetAll();
        }

        public Table GetById(int id)
        {
            return tableRepo.GetById(id);
        }

        public bool Update(Table newTable)
        {
            return tableRepo.Update(newTable);
        }
    }
}
