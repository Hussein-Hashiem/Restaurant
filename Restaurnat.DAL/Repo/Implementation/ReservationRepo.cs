
using Restaurnat.DAL.Database;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.DAL.Repo.Implementation
{
    public class ReservationRepo : IReservationRepo
    {
        private readonly ApplicationDbContext DB;

        public ReservationRepo(ApplicationDbContext DB)
        {
            this.DB = DB;
        }
    }
}
