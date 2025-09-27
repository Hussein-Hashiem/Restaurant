
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Entities;
using Restaurnat.DAL.Repo.Apstraction;
using Restaurnat.BLL.ModelVM.Menu;
using AutoMapper;
namespace Restaurnat.BLL.Services.Implementation
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepo menuRepo;
        private readonly IMapper mapper;
        public MenuService(IMenuRepo menuRepo, IMapper mapper)
        {
            this.menuRepo = menuRepo;
            this.mapper = mapper;
        }

        public (bool, string) AddMenu(CreateMenuVM menu)
        {
            try
            {
                var newmenu = new Menu(menu.name, menu.Description);
                var result = menuRepo.Add(newmenu);
                if (!result.Item1)
                    return (false, "Failed to add menu");
                return (true, "Menu added successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public (List<GetMenuVM>, string) GetAllMenus()
        {
            try
            {
                var menus = menuRepo.GetAll();
                var menusDto = mapper.Map<List<GetMenuVM>>(menus);
                return (menusDto, "Fetched successfully");
            }
            catch (Exception) { throw; }
        }

        public (GetMenuVM, string) GetMenuById(int id)
        {
            try
            {
                var menu = menuRepo.GetById(id);
                if (menu == null)
                    return (null, "Menu not found");
                var menuDto = mapper.Map<GetMenuVM>(menu);
                return (menuDto, "Fetched successfully");
            }
            catch (Exception) { throw; }
        }

        public (bool, string) UpdateMenu(int id, EditMenuVM dto)
        {
            try
            {
                var menu = menuRepo.GetById(id);
                if (menu == null)
                    return (false, "Menu not found");
                menu.Update(dto.name, dto.Description);
                var result = menuRepo.Update(menu);
                if (!result.Item1)
                    return (false, "Failed to update menu");
                return (true, "Menu updated successfully");
            }
            catch (Exception) { throw; }
        }

        public (bool, string) DeleteMenu(int id)
        {
            try
            {
                var result = menuRepo.Delete(id);
                if (!result.Item1)
                    return (false, "Failed to delete menu");
                return (true, "Menu deleted successfully");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
