using Microsoft.AspNetCore.Mvc;

namespace WebMarket_App.Areas.Customer.Controllers
{
    public class HomeController : Controller
    {
        [Area("Customer")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
