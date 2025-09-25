using Microsoft.AspNetCore.Mvc;
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.BLL.ModelVM.Payment;
using Restaurnat.BLL.ModelVM.Chef;
using Restaurnat.BLL.Services.Implementation;
using Restaurnat.BLL.ModelVM.User;
using Restaurnat.DAL.Entities;
namespace Restaurant.PL.Controllers
{
    public class ChefController : Controller
    {
        private readonly IChefService cservice;
        public ChefController(IChefService chservice)
        {
            this.cservice = chservice;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveChef(CreateChefVM chef, IFormFile img)
        {
            if (!ModelState.IsValid)
            {
                var result = cservice.Create(chef, img);
                if (result.Item1)
                {
                    return RedirectToAction("GetAll", "Chef");
                }

            }
            return View(chef);
        }
        public IActionResult GetAll()
        {
            var chefs= cservice.GetAll();

            if (chefs.Item2 != null)
            {
                ViewBag.Message(chefs.Item2);
            }
            return View(chefs.Item1);
        }

        public IActionResult Delete(int id)
        {
            var result = cservice.Delete(id);

            if (result.Item2 != null)
            {
                ViewBag.Message(result.Item2);
            }
            return RedirectToAction("GetAll", "Chef");
        }
        public IActionResult GetById(int id)
        {
            var result = cservice.GetById(id);

            if (result.Item2 != null)
            {
                ViewBag.Message(result.Item2);
                return RedirectToAction("GetAll", "Chef");
            }
            return View(result.Item1);
        }
        public IActionResult Edit(EditChefVM chef, IFormFile img)
        {
            var result = cservice.Update(chef, img);

            if (result.Item2 != null)
            {
                ViewBag.Message(result.Item2);
                return RedirectToAction("GetAll", "Chef");
            }
            return View(result.Item1);
        }
    }
}
