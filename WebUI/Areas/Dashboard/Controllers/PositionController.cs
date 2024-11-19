using Business.Abstract;
using Business.Concrete;
using Entites.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;
        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        public IActionResult Index()
        {
            var positions = _positionService.GetAll().Data;

            return View(positions);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Position position)
        {
            var result = _positionService.Add(position);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);

                return View(position);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _positionService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Position position)
        {
            var result = _positionService.Update(position);

            if(!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(position);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _positionService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
