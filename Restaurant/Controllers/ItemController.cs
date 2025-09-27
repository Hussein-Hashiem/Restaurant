using Microsoft.AspNetCore.Mvc;
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.BLL.ModelVM.Item;
using AutoMapper;
using Restaurnat.DAL.Entities;
using Microsoft.AspNetCore.Authorization;


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
            try
            {
                var item = _itemService.GetById(id);
                if (item == null)
                    return NotFound();
                var vm = _mapper.Map<UpdateItemVM>(item);
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
        public IActionResult Update(UpdateItemVM item)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(item);
                var result = _itemService.Update(item.id,item);
                if (!result)
                {
                    ModelState.AddModelError("", "Update failed");
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
                    return View("Error", "Delete failed");
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
    }
}
