using Business.Abstract;
using Entites.TableModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AboutController(IAboutService aboutService, IWebHostEnvironment  webHostEnvironment)
        {
            _aboutService = aboutService;
            _webHostEnvironment = webHostEnvironment;

        }

        public IActionResult Index()
        {
            var data = _aboutService.GetAll().Data;

            return View(data);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(About about, IFormFile imageUrl)
        {
            var result = _aboutService.Add(about, imageUrl, _webHostEnvironment);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);

                return View(about);
            }

            return RedirectToAction("Index");
        }
    }
}
