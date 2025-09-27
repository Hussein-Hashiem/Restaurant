using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.BLL.ModelVM.Item;
using AutoMapper;
using Restaurant.Models;

namespace Restaurant.PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminItemController : Controller
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public AdminItemController(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var items = _itemService.GetAll();
            return View(items);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateItemVM item)
        {
            if (!ModelState.IsValid) return View(item);
            var (success, message) = _itemService.Create(item);
            if (!success)
            {
                ModelState.AddModelError("", message);
                return View(item);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var item = _itemService.GetById(id);
            if (item == null) return NotFound();

            var updateVM = new UpdateItemVM
            {
                item_id = id,
                name = item.name,
                price = item.price,
                description = item.description,
                menu_id = item.menu_id,
                recommended = item.recommended,
                ExistingImagePath = item.imagepath
            };

            return View(updateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(UpdateItemVM updatedItem)
        {
            if (!ModelState.IsValid) return View(updatedItem);

            var result = _itemService.Update(updatedItem.item_id, updatedItem);
            if (!result)
            {
                ModelState.AddModelError("", "Update failed");
                return View(updatedItem);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = _itemService.GetById(id);
            if (item == null) return NotFound();
            var vm = _mapper.Map<GetItemVM>(item);
            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _itemService.Delete(id);
            if (!result)
            {
                var item = _itemService.GetById(id);
                var vm = _mapper.Map<GetItemVM>(item);
                ModelState.AddModelError("", "Delete failed");
                return View("Delete", vm);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var item = _itemService.GetById(id);
            if (item == null) return NotFound();
            var vm = _mapper.Map<GetItemVM>(item);
            return View(vm);
        }
    }
}
