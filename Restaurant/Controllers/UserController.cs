using Microsoft.AspNetCore.Mvc;
using Restaurnat.BLL.ModelVM.User;
using Restaurnat.BLL.Services.Apstraction;

namespace Restaurant.PL.Controllers
{
	public class UserController : Controller
	{
		private readonly IUserService userService;
		public UserController(IUserService userService)
		{
			this.userService = userService;
		}
		public IActionResult Index()
		{
			var users = userService.GetAll();
			return View(users);
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

			return View(user);
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
	}
}
