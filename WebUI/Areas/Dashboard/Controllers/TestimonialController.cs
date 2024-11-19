using Business.Abstract;
using Entites.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IPositionService _positionService;
        public TestimonialController(ITestimonialService testimonialService, IPositionService positionService)
        {
            _testimonialService = testimonialService;
            _positionService = positionService;
        }


        public IActionResult Index()
        {
            var data = _testimonialService.GetAll().Data;

            return View(data);
        }

        public IActionResult Create()
        {
            ViewData["Postions"] = _positionService.GetAll().Data;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Testimonial testimonial)
        {
            var result = _testimonialService.Add(testimonial);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);

                return View(testimonial);
            }

            return RedirectToAction("Index");
        }
    }
}
