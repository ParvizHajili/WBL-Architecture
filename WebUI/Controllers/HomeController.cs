using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IAboutService _aboutService;
        public HomeController(ITestimonialService testimonialService, IAboutService aboutService)
        {
            _testimonialService = testimonialService;
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            var testimonials = _testimonialService.GetAll().Data;
            var about = _aboutService.GetAll().Data;

            var viewModel = new HomeViewModel()
            {
                Testimonials = testimonials,
                About = about
            };

            return View(viewModel);
        }
    }
}
