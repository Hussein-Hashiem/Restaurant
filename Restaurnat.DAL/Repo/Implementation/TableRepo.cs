
using Microsoft.EntityFrameworkCore;
using Restaurnat.DAL.Database;
using Restaurnat.DAL.Entities;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.DAL.Repo.Implementation
{
    public class TableRepo : ITableRepo
    {
        private readonly ApplicationDbContext DB;

        public TableRepo(ApplicationDbContext DB)
        {
            this.DB = DB;
        }

        public (bool, string) Create(Table newTable)
        {
            try
            {
                DB.Add(newTable);
                DB.SaveChanges();
                return (true, "Table created successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public bool Delete(int id)
        {
            var table = DB.Tables.Find(id);
            if (table != null || table.IsDeleted)
            {
                return false;
            }
            table.IsDeleted = true;
            table.DeletedOn = DateTime.Now;
            DB.SaveChanges();
            return true;
        }

        public List<Table> GetAll()
        {
            return DB.Tables
                .Where(t => !t.IsDeleted)
                .Include(t => t.ReservedTables)
                .ToList();
        }

        public Table GetById(int id)
        {
            return DB.Tables
                .Include(t => t.ReservedTables)
                .FirstOrDefault(t => t.table_id == id && !t.IsDeleted);
        }
        public bool Update(Table newTable)
        {
            var existing = DB.Tables.Find(newTable.table_id);
            if (existing != null || existing.IsDeleted)
            {
                return false;
            }
            DB.Entry(existing).CurrentValues.SetValues(newTable);
            DB.SaveChanges();
            return true;

        }
    }
}
