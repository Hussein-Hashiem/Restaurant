using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurnat.BLL.ModelVM.Account;
using Restaurnat.DAL.Entities;

namespace Restaurant.PL.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<User> userManager;
		private readonly SignInManager<User> signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
			this.userManager = userManager;
			this.signInManager = signInManager;
        }
        [HttpGet]
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginVM loginVM)
		{
			var result = await signInManager.PasswordSignInAsync(loginVM.UserName, loginVM.password, true, false);

			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Home");
			}
			else
			{
				ModelState.AddModelError("", "Invalid UserName Or Password");

			}
			return View();
		}
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterVM registerVM)
		{
            if (!ModelState.IsValid)
                return View(registerVM);
			var user = new User(registerVM.first_name, registerVM.last_name, registerVM.age, registerVM.country, registerVM.city, registerVM.street);
            user.Email = registerVM.email;
			user.UserName = registerVM.UserName;
			var result = await userManager.CreateAsync(user, registerVM.password);

			if (result.Succeeded)
			{
				return RedirectToAction("Login");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError("Password", item.Description);
				}
			}
			return View();
		}
		public async Task<IActionResult> LogOff()
		{
			await signInManager.SignOutAsync();
			return RedirectToAction("Login");
		}
	}
}
