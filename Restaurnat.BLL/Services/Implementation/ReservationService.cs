
using Restaurnat.BLL.ModelVM.User;
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Entities;
using Restaurnat.DAL.Repo.Apstraction;
using Restaurnat.DAL.Repo.Implementation;

namespace Restaurnat.BLL.Services.Implementation
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepo reservationRepo;
        public ReservationService(IReservationRepo reservationRepo)
        {
            this.reservationRepo = reservationRepo;
        }

        public (bool, string) Add(ReservationDto dto)
        {
            try
            {
                var reservation = new Reservation(
                    dto.ReservationDate,
                    dto.Duration,
                    dto.NumberOfPeople,
                    dto.Fees,
                    dto.TotalMoney,
                    dto.UserId,
                    "sieef"
                );
                return reservationRepo.Add(reservation);

            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
           
         }
        public (List<ReservationDto>, string) GetAll()
        {
            try
            {
                var result = reservationRepo.GetAll();
                if (result == null || !result.Any())
                    return (new List<ReservationDto>(), "No reservations found");

                var mapped = result.Select(r => new ReservationDto
                {
                    ReservationId= r.reservation_id,
                    ReservationDate = r.reservation_date,
                    Duration = r.duration,
                    NumberOfPeople = r.number_of_people,
                    Fees = r.fees,
                    TotalMoney = r.total_money,
                    UserId = r.user_id
                }).ToList();

                return (mapped, "success");
            }
            catch (Exception ex)
            {
                return (new List<ReservationDto>(), ex.Message);
            }
        }


        public (ReservationDto?, string) GetById(int id)
        {
            try
            {
                var reservation = reservationRepo.GetById(id);
                if (reservation == null)
                    return (null, "Reservation not found");

                var dto = new ReservationDto
                {
                    ReservationId = reservation.reservation_id,
                    ReservationDate = reservation.reservation_date,
                    Duration = reservation.duration,
                    NumberOfPeople = reservation.number_of_people,
                    Fees = reservation.fees,
                    TotalMoney = reservation.total_money,
                    UserId = reservation.user_id
                };

                return (dto, "success");
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }

        public (bool, string) Update(ReservationDto dto)
        {
            try
            {
                var existing = reservationRepo.GetById(dto.ReservationId);
                if (existing == null)
                    return (false, "Menu not found");

                existing.Update(
                   dto.ReservationDate,
                        dto.Duration,
                        dto.NumberOfPeople,
                        dto.Fees,
                        dto.TotalMoney,
                        "system"
                );

                reservationRepo.Update(existing);
                return (true, "Updated successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) Delete(int id)
        {
            try
            {
                var reservation = reservationRepo.GetById(id);
                if (reservation == null)
                    return (false, "reservation not found");

                reservation.Delete("sieef");
                reservationRepo.Update(reservation);

                return (true, "Deleted successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
