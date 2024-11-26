using Business.Abstract;
using Entites.TableModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Dashboard.Controllers
{
    [Authorize]
    [Area("Dashboard")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IPositionService _positionService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public TestimonialController(ITestimonialService testimonialService,
            IWebHostEnvironment webHostEnvironment,
            IPositionService positionService)
        {
            _testimonialService = testimonialService;
            _positionService = positionService;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
            var data = _testimonialService.GetAll().Data;

            return View(data);
        }

        public IActionResult Create()
        {
            ViewData["Positions"] = _positionService.GetAll().Data;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Testimonial testimonial, IFormFile imageUrl)
        {
            var result = _testimonialService.Add(testimonial, imageUrl, _webHostEnvironment);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);

                return View(testimonial);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _testimonialService.GetById(id).Data;

            ViewData["Positions"] = _positionService.GetAll().Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Testimonial testimonial, IFormFile imageUrl)
        {
            var result = _testimonialService.Update(testimonial, imageUrl, _webHostEnvironment);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                ViewData["Positions"] = _positionService.GetAll().Data;
                return View(testimonial);
            }

            return RedirectToAction("Index");
        }
    }
}
