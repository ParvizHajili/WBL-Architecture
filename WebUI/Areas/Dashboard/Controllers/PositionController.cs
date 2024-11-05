using Business.Abstract;
using Business.Concrete;
using Entites.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class PositionController : Controller
    {
        IPositionService _positionService = new PositionManager();

        public IActionResult Index()
        {
            var positions = _positionService.GetAll();

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
            _positionService.Add(position);

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
