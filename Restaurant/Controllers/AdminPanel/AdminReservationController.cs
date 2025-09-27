using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurnat.BLL.ModelVM.Menu;
using Restaurnat.BLL.ModelVM.Reservation;
using Restaurnat.BLL.Services.Apstraction;

namespace Restaurant.PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        public AdminReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            try
            {
                var reservations = _reservationService.GetAll();
                return View(reservations.Item1);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                var res = _reservationService.GetById(id);
                if (res.Item1 == null)
                {
                    return NotFound("Reservation not found");
                }
                return View(res.Item1);
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
        public IActionResult Create(CreateReservationVM createReservation)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(createReservation);

                var result = _reservationService.Add(createReservation);
                if (!result.Item1)
                {
                    ViewBag.Error = result.Item2;
                    return View(createReservation);
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
                var result = _reservationService.GetById(id);
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
        public IActionResult Update(int id, EditReservationVM editReservation)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(editReservation);

                var result = _reservationService.Update(id, editReservation);

                if (!result.Item1)
                {
                    ViewBag.Error = result.Item2;
                    return View(editReservation);
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
                var result = _reservationService.GetById(id);
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
                var result = _reservationService.Delete(id);

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
