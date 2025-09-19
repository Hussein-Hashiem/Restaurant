
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.BLL.Services.Implementation
{
    public class ReservedTableService : IReservedTableService
    {
        private readonly IReservedTableRepo reservedTableRepo;
        public ReservedTableService(IReservedTableRepo reservedTableRepo)
        {
            this.reservedTableRepo = reservedTableRepo;
        }
    }
}
