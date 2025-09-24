using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.BLL.ModelVM.Payment;

namespace Restaurant.PL.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        //========== Display all payments================
        public IActionResult Index()
        {
            try
            {
                var list = _paymentService.GetAll();
                var model = list ?? new List<GetAllPaymentVM>();
                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        // ===========Display details for a specific payment================
        public IActionResult Details(int id)
        {
            try
            {
                var vm = _paymentService.GetById(id);
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

        // ==========Handle create form submission=============
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatePaymentVM model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);

                var result = _paymentService.Create(model);
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

        // ==========Show edit form id =============
        public IActionResult Edit(int id)
        {
            try
            {
                var vm = _paymentService.GetById(id);
                if (vm == null) return NotFound();

                var editVm = new UpdatePaymentVM
                {
                    payment_id = vm.payment_id,
                    amount = vm.amount,
                    status = vm.status,
                    PaymentMethod = vm.PaymentMethod
                };

                return View(editVm);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        // ============Handle edit form submission===========
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdatePaymentVM model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);

                var ok = _paymentService.Update(model);
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

        // ========Show delete confirmation=========
        public IActionResult Delete(int id)
        {
            try
            {
                var vm = _paymentService.GetById(id);
                if (vm == null) return NotFound();
                return View(vm);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        // ==========Handle delete confirmation============
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var ok = _paymentService.Delete(id);
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
