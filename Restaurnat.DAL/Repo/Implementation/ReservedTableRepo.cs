
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Restaurnat.DAL.Database;
using Restaurnat.DAL.Entities;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.DAL.Repo.Implementation
{
    public class ReservedTableRepo : IReservedTableRepo
    {
        private readonly ApplicationDbContext DB;

        public ReservedTableRepo(ApplicationDbContext DB)
        {
            this.DB = DB;
        }

        public (bool, string) Create(ReservedTable newReservedTable)
        {
            try
            {
                newReservedTable.CreatedOn = DateTime.Now;
                DB.ReservedTables.Add(newReservedTable);
                DB.SaveChanges();
                return (true, "Reserved table created successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public bool Delete(int id)
        {
            var reservedTable = DB.ReservedTables.FirstOrDefault(rt => rt.TableId == id && !rt.IsDeleted);
            if (reservedTable == null)
            {
                return false;
            }
            reservedTable.IsDeleted = true;
            reservedTable.DeletedOn = DateTime.Now;
            reservedTable.DeletedBy = "System";
            DB.ReservedTables.Update(reservedTable);
            return true;

        }

        public List<ReservedTable> GetAll()
        {
            return DB.ReservedTables
                .Where(rt => !rt.IsDeleted)
                .ToList();

        }

        public ReservedTable GetById(int id)
        {
            return DB.ReservedTables
                .FirstOrDefault(tr => tr.ReservationId == id);
        }

        public bool Update(ReservedTable reservedTable)
        {
            var existing = DB.ReservedTables.FirstOrDefault(rt => rt.TableId == reservedTable.TableId);
            if (existing == null)
            {
                return false;
            }
            existing.TableId = reservedTable.TableId;
            existing.Reservation = reservedTable.Reservation;
            existing.ReservationId = reservedTable.ReservationId;
            existing.ModifiedBy = reservedTable.ModifiedBy;
            existing.ModifiedOn = DateTime.Now;
            DB.ReservedTables.Add(existing);
            DB.SaveChanges();
            return true;
        }
    }
}