
using Restaurnat.BLL.ModelVM.User;
using Restaurnat.DAL.Entities;

namespace Restaurnat.BLL.Services.Apstraction
{
    public interface IMenuService
    {
        (bool, string) AddMenu(Menu menu);
        (List<MenuDto>, string) GetAllMenus();
        (MenuDto?, string) GetMenuById(int id);
        (bool, string) UpdateMenu(MenuDto dto);
        (bool, string) DeleteMenu(int id);
    }
}
