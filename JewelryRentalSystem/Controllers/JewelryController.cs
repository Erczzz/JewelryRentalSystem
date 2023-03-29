using Microsoft.AspNetCore.Mvc;

namespace JewelryRentalSystem.Controllers
{
    public class JewelryController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
