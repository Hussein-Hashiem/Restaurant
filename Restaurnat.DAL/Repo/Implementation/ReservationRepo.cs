
using System.Reflection.Metadata.Ecma335;
using Restaurnat.DAL.Database;
using Restaurnat.DAL.Entities;
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

        public (bool, string) Add(Reservation reservation)
        {
            try
            {
                var newReservation = new Reservation(
                    reservation.reservation_date,
                    reservation.duration,
                    reservation.number_of_people,
                    reservation.fees,
                    reservation.total_money,
                    reservation.user_id,
                    "sieef"
                );

                var result = DB.Reservations.Add(newReservation);
                DB.SaveChanges();

                if (result != null)
                    return (true, "Reservation Added Successfully");

                return (false, "Failed to add reservation");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public IEnumerable<Reservation> GetAll()
        {
            try
            {
                return DB.Reservations.Where(m => !m.IsDeleted).ToList();
            }
            catch
            {
                return new List<Reservation>();

            }
        }

        public Reservation GetById(int id)
        {
            try
            {
                return DB.Reservations.FirstOrDefault(m => m.reservation_id == id && !m.IsDeleted);
            }
            catch
            {
                return null;
            }
        }

        public (bool, string) Update(Reservation reservation)
        {
            try
            {
                var oldReservation = DB.Reservations.FirstOrDefault(r => r.reservation_id == reservation.reservation_id && !r.IsDeleted);

                if (oldReservation == null)
                    return (false, "Reservation not found");

                oldReservation.Update(
                    reservation.reservation_date,
                    reservation.duration,
                    reservation.number_of_people,
                    reservation.fees,
                    reservation.total_money,
                    "sieef"
                );

                DB.Reservations.Update(oldReservation);
                DB.SaveChanges();

                return (true, "Reservation updated successfully");
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
                var reservation = DB.Reservations.FirstOrDefault(r => r.reservation_id == id && !r.IsDeleted);

                if (reservation == null)
                    return (false, "Reservation not found");

                reservation.Delete("sieef");

                DB.Reservations.Update(reservation);
                DB.SaveChanges();

                return (true, "Reservation deleted successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}