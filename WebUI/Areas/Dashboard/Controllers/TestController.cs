using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class TestController : Controller
    {
        public IActionResult Details()
        {
            return View();
        }
    }
}
