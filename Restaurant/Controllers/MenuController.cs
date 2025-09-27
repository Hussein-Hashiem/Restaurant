using Microsoft.AspNetCore.Mvc;
using Restaurnat.BLL.Services.Apstraction;

namespace Restaurant.PL.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var menus = _menuService.GetAllMenus();
                return View(menus.Item1);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var menu = _menuService.GetMenuById(id);
            if (menu.Item1 == null) return NotFound();

            return View(menu.Item1);
        }
    }
}
