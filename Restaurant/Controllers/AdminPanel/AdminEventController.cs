using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurnat.BLL.ModelVM.Event;
using Restaurnat.BLL.Services.Apstraction;

namespace Restaurant.PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminEventController : Controller
    {
        private readonly IEventService _eventService;

        public AdminEventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var events = _eventService.GetAllEvents();
            ViewBag.Message = events.Item2;        
            return View(events.Item1);             
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateEventVM ev)
        {
            if (!ModelState.IsValid) return View(ev);

            var result = _eventService.Create(ev);
            if (!result.Item1)
            {
                ViewBag.Error = result.Item2;
                return View(ev);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _eventService.GetById(id);
            if (result.Item2 != null || result.Item1 == null) return RedirectToAction(nameof(Index));

            return View(result.Item1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditEventVM ev)
        {
            ev.event_id = id;
            var result = _eventService.Update(ev);

            if (!result.Item1)
            {
                ViewBag.Error = result.Item2;
                return View(ev);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = _eventService.GetById(id);
            if (result.Item1 == null || result.Item2 != null) return RedirectToAction(nameof(Index));

            return View(result.Item1);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _eventService.Delete(id);

            if (!result.Item1)
            {
                ViewBag.Error = result.Item2;
                return RedirectToAction("Delete", new { id });
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var result = _eventService.GetById(id);
            if (result.Item1 == null || result.Item2 != null) return RedirectToAction(nameof(Index));

            return View(result.Item1);
        }
    }
}
