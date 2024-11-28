using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
	public class AboutController : Controller
	{
		private readonly IAboutService _aboutService;
		private readonly ITestimonialService _testimonialService;
		public AboutController(IAboutService aboutService, ITestimonialService testimonialService)
		{
			_aboutService = aboutService;
			_testimonialService = testimonialService;
		}

		public IActionResult Index()
		{
			var about = _aboutService.GetAll().Data;
			var testimonial = _testimonialService.GetAll().Data;

			var viewModel = new AboutViewModel()
			{
				About = about,
				Testimonials = testimonial,
			};

			return View(viewModel);
		}
	}
}
