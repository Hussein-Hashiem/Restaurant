using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurnat.DAL.Entities;

namespace Restaurant.PL.Controllers
{
	public class ProfileController : Controller
	{
        private readonly UserManager<User> _userManager;
        public ProfileController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(currentUser);
        }
    }
}
