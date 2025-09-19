
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.BLL.Services.Implementation
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepo reservationRepo;
        public ReservationService(IReservationRepo reservationRepo)
        {
            this.reservationRepo = reservationRepo;
        }
    }
}
