using Microsoft.AspNetCore.Mvc;
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.BLL.ModelVM.Payment;
using Restaurnat.BLL.ModelVM.Chef;
using Restaurnat.BLL.Services.Implementation;
using Restaurnat.BLL.ModelVM.User;
using Restaurnat.DAL.Entities;
using Restaurnat.BLL.ModelVM.Email;
namespace Restaurant.PL.Controllers
{
    public class ChefController : Controller
    {
        private readonly EmailService _emailService;
        private readonly IChefService cservice;
        public ChefController(IChefService chservice, EmailService _emailService)
        {
            this.cservice = chservice;
            this._emailService = _emailService;
        }
        public ActionResult Index() 
        {
            var chefs = cservice.GetAll();

            if (!string.IsNullOrEmpty(chefs.Item2))
            {
                ViewBag.Message = chefs.Item2;
            }
            return View(chefs.Item1);
        }

        [HttpGet]
        public ActionResult Create() //done
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SaveChef(CreateChefVM chef, IFormFile img) //done
        {
            if (!ModelState.IsValid)
            {
                var result = cservice.Create(chef, img);
                if (result.Item1)
                {
                    var emailModel = new EmailSendVM
                    {
                        ToEmail = "ahmednoran200475@gmail.com",
                        Subject = "New Chef Created",
                        Message = $"Chef {chef.name} has been added successfully!"
                    };
                    await _emailService.SendEmailAsync(emailModel.ToEmail, emailModel.Subject, emailModel.Message);
                    return RedirectToAction("GetAll", "Chef");
                }
            }
            return View("Create", chef);
        }
        public IActionResult GetAll() //done
        {
            var chefs = cservice.GetAll();

            if (!string.IsNullOrEmpty(chefs.Item2))
            {
                ViewBag.Message = chefs.Item2;
            }
            return View(chefs.Item1);
        }
        
        public IActionResult Delete(int id) //done
        {
            var result = cservice.Delete(id);

            if (result.Item2 != null)
            {
                ViewBag.Message(result.Item2);
            }
            return RedirectToAction("GetAll", "Chef");
        }
        public IActionResult Restore(int id) 
        {
            var result = cservice.Restore(id);

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
                return RedirectToAction("GetAll", "Chef");
            }
            return View(result.Item1);
        }
        [HttpGet]
        public IActionResult Edit(int id) //done
        {
            var result = cservice.GetById(id);

            if (result.Item2 != null)
            {
                return RedirectToAction("GetAll", "Chef");
            }
            return View(result.Item1);
        }

        [HttpPost]
        public IActionResult Edit(int id, EditChefVM chef, IFormFile img) //done
        {
            chef.chef_id = id;
            var result = cservice.Update(chef, img);
            return RedirectToAction("GetAll", "Chef");
        }
    }
}
