using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurnat.BLL.ModelVM.Menu;
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.BLL.Services.Implementation;
using Restaurnat.DAL.Entities;

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
            return View(menus);

            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }

        }
        [HttpGet]
        public IActionResult GetMenuById(int id)
        {
            try
            {
            var menu = _menuService.GetMenuById(id);
            if (menu.Item1 == null)
            {
                return NotFound("Menu not found");
            }

            return View(menu.Item1);

            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(CreateMenuVM menu)
        {
            try
            {
            if (!ModelState.IsValid)
                return View(menu);

            var result = _menuService.AddMenu(menu);
            if (!result.Item1)
            {
                ViewBag.Error = result.Item2;
                return View(menu);
            }

            return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            try
            {
            var result = _menuService.GetMenuById(id);
            if (result.Item1 == null)
                return View("NotFound");
            return View(result.Item1);

            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, EditMenuVM menu)
        {
            try
            {

            if (!ModelState.IsValid)
                return View(menu);

            var result = _menuService.UpdateMenu(id, menu);

            if (!result.Item1)
            {
                ViewBag.Error = result.Item2;
                return View(menu);
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
            try
            {
            var result = _menuService.GetMenuById(id);
            if (result.Item1 == null)
                return View("NotFound");

            return View(result.Item1);

            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
            var result = _menuService.DeleteMenu(id);

            if (!result.Item1)
            {
                ViewBag.Error = result.Item2;
                return RedirectToAction("Delete", new { id });
            }

            return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
    }
}

