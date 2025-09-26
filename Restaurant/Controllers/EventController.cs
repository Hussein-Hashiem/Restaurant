using Microsoft.AspNetCore.Mvc;
using Restaurnat.BLL.ModelVM.Chef;
using Restaurnat.BLL.ModelVM.Event;
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.DAL.Entities;

namespace Restaurant.PL.Controllers
{
    public class EventController : Controller
    {

        private readonly IEventService eservice;
        public EventController(IEventService evservice)
        {
            this.eservice = evservice;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveEvent(CreateEventVM ev)
        {
            if (!ModelState.IsValid)
            {
                var result = eservice.Create(ev);
                if (result.Item1)
                {
                    return RedirectToAction("GetAll", "Event");
                }
            }
            return View("Create", ev);
        }
        public IActionResult GetAll()
        {
            var events = eservice.GetAllEvents();

            if (events.Item2 != null)
            {
                ViewBag.Message = events.Item2;
            }
            return View(events.Item1);
        }

        public IActionResult Delete(int id)
        {
            var result = eservice.Delete(id);

            if (result.Item2 != null)
            {
                ViewBag.Message(result.Item2);
            }
            return RedirectToAction("GetAll", "Event");
        }
        public IActionResult GetById(int id)
        {
            var result = eservice.GetById(id);

            if (result.Item2 != null)
            {
                return RedirectToAction("GetAll", "Event");
            }
            return View(result.Item1);
        }

        [HttpGet]
        public IActionResult Edit(int id) //done
        {
            var result = eservice.GetById(id);

            if (result.Item2 != null)
            {
                return RedirectToAction("GetAll", "Event");
            }
            return View(result.Item1);
        }
        [HttpPost]
        public IActionResult Edit(int id, EditEventVM ev)
        {
            ev.event_id = id;
            var result = eservice.Update(ev);
            return RedirectToAction("GetAll", "Event");

        }
        //---------------------------------------------------------------------------------

    }
}
