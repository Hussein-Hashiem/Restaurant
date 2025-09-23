
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Entities;
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

        public (bool, string) Create(ReservedTable newReservedTable)
        {
            if (newReservedTable.TableId <= 0 || newReservedTable.ReservationId <= 0)
                return (false, "TableId and ReservationId are required");

            return reservedTableRepo.Create(newReservedTable);
        }

        public bool Delete(int id)
        {
            return reservedTableRepo.Delete(id);
        }

        public List<ReservedTable> GetAll()
        {
            return reservedTableRepo.GetAll();
        }

        public ReservedTable GetById(int id)
        {
            return reservedTableRepo.GetById(id);
        }

        public bool Update(ReservedTable reservedTable)
        {
            return reservedTableRepo.Update(reservedTable);
        }
    }
}
