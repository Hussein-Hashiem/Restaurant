
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.BLL.Services.Implementation
{
    public class ReservedItemService : IReservedItemService
    {
        private readonly IReservedItemRepo reservedItemRepo;
        public ReservedItemService(IReservedItemRepo reservedItemRepo)
        {
            this.reservedItemRepo = reservedItemRepo;
        }
    }
}
