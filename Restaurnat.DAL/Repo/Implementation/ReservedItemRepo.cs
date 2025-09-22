
using Microsoft.EntityFrameworkCore;
using Restaurnat.DAL.Database;
using Restaurnat.DAL.Entities;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.DAL.Repo.Implementation
{
    public class ReservedItemRepo : IReservedItemRepo
    {
        private readonly ApplicationDbContext DB;

        public ReservedItemRepo(ApplicationDbContext DB)
        {
            this.DB = DB;
        }

        public (bool, string) Create(ReservedItem newReservedItem)
        {
            try
            {
                DB.ReservedItems.Add(newReservedItem);
                DB.SaveChanges();
                return (true, "ReservedItem created successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public bool Delete(int id)
        {
            var resut = DB.ReservedItems.FirstOrDefault(t => t.ReservationId == id);
            if (resut == null) { return false; }
            DB.ReservedItems.Remove(resut);
            try
            {
                DB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<ReservedItem> GetAll()
        {
            return DB.ReservedItems
                .Include(t => t.Item)
                .Include(t => t.Reservation)
                .ToList();
        }

        public ReservedItem GetById(int id)
        {
            return DB.ReservedItems
                .Include(t => t.Item)
                .Include(t => t.Reservation)
                .FirstOrDefault(t => t.ReservationId == id);
        }

        public bool Update(ReservedItem newReservedItem)
        {
            var result = DB.ReservedItems.FirstOrDefault(t => t.ReservationId == newReservedItem.ReservationId);
            if (result == null) { return false; }
            DB.Entry(result).CurrentValues.SetValues(newReservedItem);
            try
            {
                DB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
