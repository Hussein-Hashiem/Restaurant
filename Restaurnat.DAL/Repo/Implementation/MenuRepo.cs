
using Restaurnat.DAL.Database;
using Restaurnat.DAL.Entities;
using Restaurnat.DAL.Repo.Apstraction;

namespace Restaurnat.DAL.Repo.Implementation
{
    public class MenuRepo : IMenuRepo
    {
        private readonly ApplicationDbContext DB;

        public MenuRepo(ApplicationDbContext DB)
        {
            this.DB = DB;
        }
        public (bool, string) Add(Menu menu)
        {
            try
            {
                DB.Menus.Add(menu);
                DB.SaveChanges();
                return (true, " Added successfully");
            }
            catch (Exception e) { return (false, e.Message); }
        }
        public List<Menu> GetAll()
        {
            try
            {
                var result = DB.Menus.ToList();
                return result;
            }
            catch (Exception) { throw; }
        }
        public Menu? GetById(int id)
        {
            try
            {
                return DB.Menus.FirstOrDefault(m => m.menu_id == id && !m.IsDeleted);
            }
            catch
            {
                return null;
            }
        }
        public (bool, string) Update(Menu menu)
        {
            try
            {
                var oldMenu = DB.Menus.FirstOrDefault(m => m.menu_id == menu.menu_id);
                if (oldMenu == null)
                    return (false, " Menu not found");
                oldMenu.Update(menu.name, menu.Description, menu.num_of_items);
                DB.SaveChanges();
                return (true, " Updated successfully");

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
                var DeletedMenu = DB.Menus.FirstOrDefault(m => m.menu_id == id);
                if (DeletedMenu == null)
                    return (false, " Menu not found");
                DB.Menus.Remove(DeletedMenu);
                DB.SaveChanges();
                return (true, " Deleted successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

    }
}

