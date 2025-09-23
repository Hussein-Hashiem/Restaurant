
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
                var NewMenu = new Menu(
                    menu.name,
                    menu.Description,
                    menu.num_of_items,
                    menu.restaurant_id,
                    "sieef",
                    DateTime.Now,
                    null,
                    null,
                    null,
                    null,
                    false
                    );
                var result = DB.Add(NewMenu);
                if (result != null)
                    return (true, "Added");
                return (false, "failed to add");

            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public IEnumerable<Menu> GetAll()
        {
            try
            {
                return DB.Menus.Where(m => !m.IsDeleted).ToList();
            }
            catch
            {
                return new List<Menu>();
            }
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
                var oldMenu = DB.Menus.FirstOrDefault(m => m.menu_id == menu.menu_id && !m.IsDeleted);

                if (oldMenu == null)
                    return (false, " Menu not found");

                oldMenu.Update(menu.name, menu.Description, menu.num_of_items, menu.restaurant_id, "sieef");

                DB.Menus.Update(oldMenu);
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
            var DeletedMenu = DB.Menus.FirstOrDefault(m => m.menu_id == id && !m.IsDeleted);
            try
            {
                var menu = DB.Menus.FirstOrDefault(m => m.menu_id == id && !m.IsDeleted);

                if (menu == null)
                    return (false, " Menu not found");

                menu.Delete("sieef");

                DB.Menus.Update(menu);
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

