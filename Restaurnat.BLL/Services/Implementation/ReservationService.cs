
using AutoMapper;
using Restaurnat.BLL.ModelVM.Reservation;
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Entities;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.BLL.Services.Implementation
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepo reservationRepo;
        private readonly IMapper mapper;
        public ReservationService(IReservationRepo reservationRepo, IMapper mapper)
        {
            this.reservationRepo = reservationRepo;
            this.mapper = mapper;
        }

        public (bool, string) Add(CreateReservationVM dto)
        {
            try
            {
                var reservation = new Reservation(dto.reservation_date, dto.duration, dto.number_of_people, dto.fees, dto.total_money, dto.user_id);
                var result = reservationRepo.Add(reservation);
                if (result.Item1) return (true, "Reservation added successfully");
                return (false, "Failed to add reservation");
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
                var result = reservationRepo.Delete(id);
                if (!result.Item1) return (false, "Not Found");
                return (true, "Deleted Successfully");
            }
            catch (Exception ex) { return (false, ex.Message); }
        }

        public (List<GetReservationVM>, string) GetAll()
        {
            try
            {
                var reservation = reservationRepo.GetAll();
                var result = mapper.Map<List<GetReservationVM>>(reservation);
                return (result, "Success");
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public (GetReservationVM, string) GetById(int id)
        {
            try
            {
                var reservation = reservationRepo.GetById(id);
                if (reservation == null) return (null, "Not Found");
                var result = mapper.Map<GetReservationVM>(reservation);
                return (result, "Success");
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public (bool, string) Update(int id, EditReservationVM dto)
        {
            try {
                var reservation = reservationRepo.GetById(id);
                if (reservation == null) return (false, "Not Found");
                reservation.Update(dto.reservation_date, dto.duration, dto.number_of_people, dto.fees, dto.total_money);
                var isUpdated = reservationRepo.Update(reservation);
                if (!isUpdated.Item1) return (false, "Update Failed");
                return (true, "Updated Successfully");
            }
            catch (Exception ex) { return (false, ex.Message); }
        }
    }
}
