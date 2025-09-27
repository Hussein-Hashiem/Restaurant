using Microsoft.AspNetCore.Mvc;
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.BLL.ModelVM.Item;
using AutoMapper;
using Restaurnat.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Restaurant.Models;


namespace Restaurant.PL.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;
        public ItemController(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }
        [Authorize]
        public IActionResult Index()
        {
            try
            {
                var items = _itemService.GetAll();
                return View(items);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Details(int id)
        {
            try
            {
                var item = _itemService.GetById(id);
                if (item == null)
                    return NotFound();
                var vm = _mapper.Map<GetItemVM>(item);
                return View(vm);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateItemVM item)
        {
            try
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
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
        [Authorize(Roles = "Admin")]
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
            if (!ModelState.IsValid)
                return View(updatedItem);

            var result = _itemService.Update(updatedItem.item_id, updatedItem);

            if (!result)
            {
                ModelState.AddModelError("", "Update failed");
                return View(updatedItem);
            }

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _itemService.GetById(id);
                if (item == null)
                    return NotFound();
                var vm = _mapper.Map<GetItemVM>(item);
                return View(vm);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var result = _itemService.Delete(id);
                if (!result)
                {
                    ModelState.AddModelError("", "Delete failed");
                    var item = _itemService.GetById(id);
                    var vm = _mapper.Map<GetItemVM>(item);
                    return View("Delete", vm);
                }


                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                var errorModel = new ErrorViewModel { RequestId = ex.Message };
                return View("Error", errorModel);
            }
        }

    }
}
