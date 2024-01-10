using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebMarket_DataAccess.Services.Interface;
using WebMarket_Models;
using WebMarket_Models.ViewModels;


namespace WebMarket_App.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductServices _ProductServices;
        private readonly ICategoryServices _CategoryServices;
        private readonly IWebHostEnvironment _WebHostEnviroment;

        public ProductController(IProductServices ProductServices, ICategoryServices CategoryServices, IWebHostEnvironment WebHostEnviroment)
        {
            _ProductServices = ProductServices;
            _CategoryServices = CategoryServices;
            _WebHostEnviroment = WebHostEnviroment;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> ProductList = _ProductServices.GetAll();
            return View(ProductList);
        }
        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new()
            {
                Product = new(),
                CategoryList = _CategoryServices.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString(),
                })
            };
            if (id == null || id == 0)
            {
                return View(productVM);
            }
            else
            {
                productVM.Product = _ProductServices.GetFirstOrDefaulte(u => u.Id == id);
                return View(productVM);
            }
            return View(productVM);
        }

        [HttpPost]
        public IActionResult Upsert(ProductVM obj, IFormFile? file)
        {
            string wwwrootPath = _WebHostEnviroment.WebRootPath;
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string FileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwrootPath, @"img");
                    var extention = Path.GetExtension(file.FileName);

                    if (obj.Product.Img != null)
                    {
                        var oldImgPath = Path.Combine(wwwrootPath, obj.Product.Img.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImgPath))
                        {
                            System.IO.File.Delete(oldImgPath);
                        }
                    }
                    using (var FileStream = new FileStream(Path.Combine(uploads, FileName + extention), FileMode.Create))
                    {
                        file.CopyTo(FileStream);
                    }
                    obj.Product.Img = @"img/" + FileName + extention;
                }
                if (obj.Product.Id == 0)
                {
                    _ProductServices.Add(obj);
                    TempData["success"] = "محصول با موفقیت ایجاد شد";
                    return RedirectToAction("index");
                }
                else
                {
                    _ProductServices.Update(obj.Product);
                    TempData["success"] = "محصول با موفقیت ویرایش شد";
                    return RedirectToAction("index");
                }
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var ProductFromDb = _db.Categories.Find(id);
            var ProductFromDbFirst = _ProductServices.GetFirstOrDefaulte(i => i.Id == id);
            //var ProductFromDbSingle = _db.Categories.SingleOrDefault(i => i.Id == id);
            if (ProductFromDbFirst == null)
            {
                return NotFound();
            }
            return View(ProductFromDbFirst);
        }
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            var obj = _ProductServices.GetFirstOrDefaulte(i => i.Id == id);
            string wwwrootPath = _WebHostEnviroment.WebRootPath;
            if (obj.Img != null)
            {
                var oldImgPath = Path.Combine(wwwrootPath, obj.Img.TrimStart('\\'));
                if (System.IO.File.Exists(oldImgPath))
                {
                    System.IO.File.Delete(oldImgPath);
                }
            }
            _ProductServices.Remove(obj);
            TempData["success"] = "محصول با موفقیت حذف شد";
            return RedirectToAction("index");
        }
    }
}
