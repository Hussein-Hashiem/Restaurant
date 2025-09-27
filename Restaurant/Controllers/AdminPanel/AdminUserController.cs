using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurnat.BLL.ModelVM.Account;
using Restaurnat.BLL.ModelVM.User;
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.BLL.Services.Implementation;
using Restaurnat.DAL.Entities;

namespace Restaurant.PL.Controllers.AdminPanel
{
    [Authorize(Roles = "Admin")]
    public class AdminUserController : Controller
    {

        private readonly IUserService userService;
        private readonly UserManager<User> userManager;
        public AdminUserController(IUserService userService, UserManager<User> userManager)
        {
            this.userService = userService;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var users = userService.GetAll();
            return View(users);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RegisterVM newuser)
        {
            if (!ModelState.IsValid) return View(newuser);

            var result = await userService.RegisterUserAsync(newuser);

            if (result.Succeeded)
                return RedirectToAction("Index");

            ViewBag.Error = string.Join(", ", result.Errors.Select(e => e.Description));
            return View(newuser);
        }
        [HttpGet]
        public IActionResult Update(string id)
        {
            var user = userService.GetByID(id);
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
        public IActionResult Update(UpdateUserVM updatedUser)
        {
            if (!ModelState.IsValid) return View(updatedUser);

            var result = userService.Update(updatedUser.Id, updatedUser);

            if (result.Item1)
                return RedirectToAction("Index");

            ViewBag.Error = result.Item2;
            return View(updatedUser);
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var user = userService.GetByID(id);
            if (!user.Item1) return NotFound();

            return View(user.Item3);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            var result = userService.Delete(id);

            if (result.Item1)
                return RedirectToAction("Index");

            ViewBag.Error = result.Item2;
            var user = userService.GetByID(id);
            return View("Delete", user);
        }
        [HttpPost]
        public async Task<IActionResult> MakeAdmin(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            var roles = await userManager.GetRolesAsync(user);
            if (!roles.Contains("Admin"))
            {
                var result = await userManager.AddToRoleAsync(user, "Admin");
                if (result.Succeeded)
                    return RedirectToAction("Index");

                ViewBag.Error = string.Join(", ", result.Errors.Select(e => e.Description));
                return RedirectToAction("Index");
            }

            ViewBag.Error = "User is already Admin";
            return RedirectToAction("Index");
        }
    }
}
