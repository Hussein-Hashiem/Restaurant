
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Entities;
using Restaurnat.DAL.Repo.Apstraction;
using Restaurnat.DAL.Repo.Implementation;
using Restaurnat.BLL.ModelVM.User;
namespace Restaurnat.BLL.Services.Implementation
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepo menuRepo;
        public MenuService(IMenuRepo menuRepo)
        {
            this.menuRepo = menuRepo;
        }

        public (bool, string) AddMenu(Menu menu)
        {
            try
            {
                var newMenu = new Menu(
                    menu.name,
                    menu.Description,
                    menu.num_of_items,
                    menu.restaurant_id,
                    "system",
                    DateTime.Now,
                    null,
                    null,
                    null,
                    null,
                false
                );

                return menuRepo.Add(newMenu);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public (List<MenuDto>, string) GetAllMenus()
        {
            try
            {
                var menus = menuRepo.GetAll().ToList();
                if (menus == null && menus.Count == 0)
                {
                    return (null, "there is no menus");

                }
                var List = menus.Select(m => new MenuDto
                {
                    Id = m.menu_id,
                    Name = m.name,
                    Description = m.Description,
                    NumOfItems = m.num_of_items,
                    RestaurantId = m.restaurant_id
                }).ToList();

                return (List, null);
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }

        public (MenuDto?, string) GetMenuById(int id)
        {
            try
            {
                var menu = menuRepo.GetById(id);
                if (menu == null)
                    return (null, "Menu not found");

                var menuDto = new MenuDto
                {
                    Id = menu.menu_id,
                    Name = menu.name,
                    Description = menu.Description,
                    NumOfItems = menu.num_of_items,
                    RestaurantId = menu.restaurant_id
                };

                return (menuDto, null);
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }

        }

        public (bool, string) UpdateMenu(MenuDto dto)
        {
            try
            {
                var existing = menuRepo.GetById(dto.Id);
                if (existing == null)
                    return (false, "Menu not found");

                existing.Update(
                    dto.Name,
                    dto.Description,
                    dto.NumOfItems,
                    dto.RestaurantId,
                    "System"
                );

                menuRepo.Update(existing);
                return (true, "Updated successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) DeleteMenu(int id)
        {
            try
            {
                var menu = menuRepo.GetById(id);
                if (menu == null)
                    return (false, "Menu not found");

                menu.Delete("sieef");
                menuRepo.Update(menu);

                return (true, "Deleted successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
