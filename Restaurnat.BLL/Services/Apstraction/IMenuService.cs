
using Restaurnat.BLL.ModelVM.Menu;

namespace Restaurnat.BLL.Services.Apstraction
{
    public interface IMenuService
    {
        (bool, string) AddMenu(CreateMenuVM menu);
        (List<GetMenuVM>, string) GetAllMenus();
        (GetMenuVM, string) GetMenuById(int id);
        (bool, string) UpdateMenu(int id,EditMenuVM dto);
        (bool, string) DeleteMenu(int id);
    }
}
