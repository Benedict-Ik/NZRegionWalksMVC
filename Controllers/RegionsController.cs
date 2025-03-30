using Microsoft.AspNetCore.Mvc;

namespace NZRegionWalksMVC.Controllers
{
    public class RegionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
