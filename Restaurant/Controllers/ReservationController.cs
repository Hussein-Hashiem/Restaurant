using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurnat.BLL.ModelVM.Reservation;
using Restaurnat.BLL.Services.Apstraction;

namespace Restaurant.PL.Controllers
{
    [Authorize(Roles = "User")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public IActionResult GetById(int id)
        {
            var res = _reservationService.GetById(id);
            if (res.Item1 == null || res.Item1.user_id != User.Identity.Name)
                return Forbid();

            return View(res.Item1);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateReservationVM createReservation)
        {
            if (!ModelState.IsValid) return View(createReservation);

            var result = _reservationService.Add(createReservation);
            if (!result.Item1)
            {
                ViewBag.Error = result.Item2;
                return View(createReservation);
            }

            return RedirectToAction("MyReservations");
        }

        public IActionResult MyReservations()
        {
            var reservations = _reservationService.GetByUserId(User.Identity.Name);

            return View(reservations);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var res = _reservationService.GetById(id);
            if (res.Item1 == null || res.Item1.user_id != User.Identity.Name)
                return Forbid();

            return View(res.Item1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, EditReservationVM editReservation)
        {
            var res = _reservationService.GetById(id);
            if (res.Item1 == null || res.Item1.user_id != User.Identity.Name)
                return Forbid();

            var result = _reservationService.Update(id, editReservation);
            if (!result.Item1)
            {
                ViewBag.Error = result.Item2;
                return View(editReservation);
            }

            return RedirectToAction("MyReservations");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var res = _reservationService.GetById(id);
            if (res.Item1 == null || res.Item1.user_id != User.Identity.Name)
                return Forbid();

            return View(res.Item1);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var res = _reservationService.GetById(id);
            if (res.Item1 == null || res.Item1.user_id != User.Identity.Name)
                return Forbid();

            _reservationService.Delete(id);
            return RedirectToAction("MyReservations");
        }
    }
}
