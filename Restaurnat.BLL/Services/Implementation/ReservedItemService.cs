
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Entities;
using Restaurnat.DAL.Repo.Apstraction;
using Restaurnat.DAL.Repo.Implementation;

namespace Restaurnat.BLL.Services.Implementation
{
    public class ReservedItemService : IReservedItemService
    {
        private readonly IReservedItemRepo reservedItemRepo;
        public ReservedItemService(IReservedItemRepo reservedItemRepo)
        {
            this.reservedItemRepo = reservedItemRepo;
        }

        public (bool, string) Create(ReservedItem newReservedItem)
        {


            return reservedItemRepo.Create(newReservedItem);
        }

        public bool Delete(int id)
        {
            return (reservedItemRepo.Delete(id));
        }

        public List<ReservedItem> GetAll()
        {
            return reservedItemRepo.GetAll();
        }

        public ReservedItem GetById(int id)
        {
            return reservedItemRepo.GetById(id);
        }

        public bool Update(ReservedItem newReservedItem)
        {
            return reservedItemRepo.Update(newReservedItem);
        }
    }
}
