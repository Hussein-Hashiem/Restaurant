using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurnat.BLL.ModelVM.User;
using Restaurnat.BLL.Services.Apstraction;

namespace Restaurant.PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var users = _userService.GetAll();
            return View(users);
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserVM newUser)
        {
            if (!ModelState.IsValid) return View(newUser);

            var result = _userService.Create(newUser);
            if (result.Item1) return RedirectToAction("Index");

            ViewBag.Error = result.Item2;
            return View(newUser);
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var user = _userService.GetByID(id);
            if (!user.Item1) return NotFound();

            var updateVM = new UpdateUserVM
            {
                Id = user.Item3.Id,
                first_name = user.Item3.first_name,
                last_name = user.Item3.last_name,
                age = user.Item3.age,
                country = user.Item3.country,
                city = user.Item3.city,
                street = user.Item3.street,
                ExistingImagePath = user.Item3.imagepath
            };

            return View(updateVM);
        }

        [HttpPost]
        public IActionResult EditUser(UpdateUserVM updatedUser)
        {
            if (!ModelState.IsValid) return View(updatedUser);

            var result = _userService.Update(updatedUser.Id, updatedUser);
            if (result.Item1) return RedirectToAction("Index");

            ViewBag.Error = result.Item2;
            return View(updatedUser);
        }

        [HttpGet]
        public IActionResult DeleteUser(int id)
        {
            var user = _userService.GetByID(id);
            if (!user.Item1) return NotFound();

            return View(user.Item3);
        }

        [HttpPost, ActionName("DeleteUser")]
        public IActionResult DeleteUserConfirmed(int id)
        {
            var result = _userService.Delete(id);
            if (result.Item1) return RedirectToAction("Index");

            ViewBag.Error = result.Item2;
            var user = _userService.GetByID(id);
            return View("DeleteUser", user.Item3);
        }
    }
}
