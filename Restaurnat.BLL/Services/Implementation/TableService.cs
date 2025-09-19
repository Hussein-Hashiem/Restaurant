
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.BLL.Services.Implementation
{
    public class TableService : ITableService
    {
        private readonly ITableRepo tableRepo;
        public TableService(ITableRepo tableRepo)
        {
            this.tableRepo = tableRepo;
        }
    }
}
