using Microsoft.AspNetCore.Mvc;
using WebMarket_DataAccess.Services.Interface;

namespace WebMarket_App.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IProductServices _productServices;

        public HomeController(IProductServices productServices)
        {
            _productServices = productServices;
        }
        public IActionResult Index()
        {
            var products = _productServices.GetAll();
            return View(products);
        }
    }
}
