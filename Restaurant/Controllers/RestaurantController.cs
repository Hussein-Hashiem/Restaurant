using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.BLL.ModelVM.Restaurant;

namespace Restaurant.PL.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        //============ Display all restaurants =============
        public IActionResult Index()
        {
            try
            {
                var list = _restaurantService.GetAll();
                var model = list ?? new List<GetAllRestaurantVM>();
                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        // ============Display details for a specific restaurant============
        public IActionResult Details(int id)
        {
            try
            {
                var vm = _restaurantService.GetById(id);
                if (vm == null) return NotFound();
                return View(vm);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        // ==============Handle create form submission===========
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateRestaurantVM model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);

                var result = _restaurantService.Create(model);
                if (!result.Item1)
                {
                    ModelState.AddModelError("", result.Item2 ?? "Create failed");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        // =============Show edit form id ===============
        public IActionResult Edit(int id)
        {
            try
            {
                var vm = _restaurantService.GetById(id);
                if (vm == null) return NotFound();

                var editVm = new UpdateRestaurantVM
                {
                    restaurant_id = vm.restaurant_id,
                    name = vm.name,
                    address = vm.address,
                    num_of_guests = vm.num_of_guests,
                    about = vm.about,
                    recommended = vm.recommended,
                    num_of_vip_customers = vm.num_of_vip_customers
                };

                return View(editVm);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        //================ Handle edit form submission ====================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdateRestaurantVM model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);

                var ok = _restaurantService.Update(model);
                if (!ok)
                {
                    ModelState.AddModelError("", "Update failed");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        // ============Show delete confirmation==============
        public IActionResult Delete(int id)
        {
            try
            {
                var vm = _restaurantService.GetById(id);
                if (vm == null) return NotFound();
                return View(vm);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        // ===========Handle delete confirmation===============
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var ok = _restaurantService.Delete(id);
                if (!ok) return View("Error", "Not Found or could not delete");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
    }
}
