using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurnat.BLL.ModelVM.Menu;
using Restaurnat.BLL.Services.Apstraction;

namespace Restaurant.PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMenuController : Controller
    {
        private readonly IMenuService _menuService;

        public AdminMenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

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
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateMenuVM menu)
        {
            if (!ModelState.IsValid) return View(menu);

            var result = _menuService.AddMenu(menu);
            if (!result.Item1)
            {
                ViewBag.Error = result.Item2;
                return View(menu);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            try
            {
                var result = _menuService.GetMenuById(id);
                if (result.Item1 == null)
                    return View("NotFound");

                var editVM = new EditMenuVM
                {
                    menu_id = result.Item1.menu_id,
                    name = result.Item1.name,
                    Description = result.Item1.Description
                };

                return View(editVM);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(EditMenuVM editMenu)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(editMenu);

                var result = _menuService.UpdateMenu(editMenu.menu_id, editMenu);
                if (!result.Item1)
                {
                    ViewBag.Error = result.Item2;
                    return View(editMenu);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var menu = _menuService.GetMenuById(id);
            if (menu.Item1 == null) return View("NotFound");

            return View(menu.Item1);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _menuService.DeleteMenu(id);
            if (!result.Item1)
            {
                ViewBag.Error = result.Item2;
                return RedirectToAction("Delete", new { id });
            }

            return RedirectToAction("Index");
        }
    }
}
