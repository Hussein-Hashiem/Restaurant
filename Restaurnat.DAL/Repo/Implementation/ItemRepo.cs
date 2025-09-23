
using Restaurnat.DAL.Database;
using Restaurnat.DAL.Entities;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.DAL.Repo.Implementation
{
    public class ItemRepo : IItemRepo
    {
        private readonly ApplicationDbContext DB;

        public ItemRepo(ApplicationDbContext DB)
        {
            this.DB = DB;
        }

        public (bool, string) Create(Item newItem)
        {
            try
            {
                DB.Items.Add(newItem);
                DB.SaveChanges();
                return (true, "Item created successfully");
            }
            catch (Exception Ex)
            {
                return (false, Ex.Message);
            }
        }

        public bool Delete(int id)
        {
            var result = DB.Items.Where(tr => tr.item_id == id).FirstOrDefault();
            if (result == null) { return false; }
            DB.Remove(result);
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

        public List<Item> GetAll()
        {
            try
            {
                var result = DB.Items.ToList();
                return result;
            }
            catch (Exception) { throw; }

        }

        public Item GetById(int id)
        {
            try
            {
                var result = DB.Items.Where(tr => tr.item_id == id).FirstOrDefault();
                return result;
            }
            catch (Exception) { throw; }
        }

        public bool Update(Item newItem)
        {
            var ExistingItem = DB.Items.FirstOrDefault(t => t.item_id == newItem.item_id);
            if (ExistingItem == null)
            {
                return false;
            }
            DB.Entry(ExistingItem).CurrentValues.SetValues(newItem);
            try
            {
                DB.SaveChanges();
                return true;
            }
            catch { return false; }
        }
    }
}
