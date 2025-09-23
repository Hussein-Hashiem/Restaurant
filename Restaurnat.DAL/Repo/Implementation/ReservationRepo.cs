
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
                DB.Reservations.Add(reservation);
                DB.SaveChanges();
                return (true, "Reservation added successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public List<Reservation> GetAll()
        {
            try
            {
                var result = DB.Reservations.ToList();
                return result;
            }
            catch (Exception) { throw; }
        }

        public Reservation GetById(int id)
        {
            try
            {
                var result = DB.Reservations.FirstOrDefault(m => m.reservation_id == id);
                return result;
            }
            catch (Exception) { throw; }
        }

        public (bool, string) Update(Reservation reservation)
        {
            try
            {
                var existingReservation = DB.Reservations.FirstOrDefault(m => m.reservation_id == reservation.reservation_id);
                if (existingReservation == null) return (false, "Reservation not found");
                existingReservation.Update(reservation.reservation_date, reservation.duration, reservation.number_of_people, reservation.fees, reservation.total_money);
                DB.SaveChanges();
                return (true, "Reservation updated successfully");
            }
            catch (Exception ex) { return (false, ex.Message); }
        }
        public (bool, string) Delete(int id)
        {
            try
            { 
                var reservation = DB.Reservations.FirstOrDefault(m => m.reservation_id == id);
                if (reservation == null)
                {
                    return (false, "Reservation not found");
                }
                else
                {
                    DB.Reservations.Remove(reservation);
                    DB.SaveChanges();
                    return (true, "Reservation deleted successfully");
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}