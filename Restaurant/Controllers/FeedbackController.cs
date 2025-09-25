using Microsoft.AspNetCore.Mvc;
using Restaurnat.BLL.ModelVM.Feedback;
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.BLL.Services.Implementation;

namespace Restaurant.PL.Controllers
{
	public class FeedbackController : Controller
	{
		private readonly IFeedbackService feedbackService;
		public FeedbackController(IFeedbackService feedbackService)
		{
			this.feedbackService = feedbackService;
		}
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(CreateFeedbackVM feedback)
		{
			if (ModelState.IsValid)
			{
				var result = feedbackService.Create(feedback);
				if (result.Item1) return RedirectToAction("Index", "Home");
			}
			return View(feedback);
		}
		[HttpGet]
		public IActionResult Update(int id)
		{
			var feedback = feedbackService.GetByID(id);
			if (!feedback.Item1) return NotFound();

			var vm = new UpdateFeedbackVM
			{
				feedback_id = feedback.Item3.feedback_id,
				rating = feedback.Item3.rating,
				comment = feedback.Item3.comment
			};

			return View(vm);
		}

		[HttpPost]
		public IActionResult Update(UpdateFeedbackVM feedback)
		{
			if (ModelState.IsValid)
			{
				var result = feedbackService.Update(feedback.feedback_id, feedback);
				if (result.Item1) return RedirectToAction("Index", "Home");
			}
			return View(feedback);
		}
		[HttpGet]
		public IActionResult Delete(int id)
		{
			var result = feedbackService.Delete(id);
			if (result.Item1) return RedirectToAction("Index", "Home");

			return BadRequest(result.Item2);
		}

	}
}
