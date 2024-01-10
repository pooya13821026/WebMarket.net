using Microsoft.AspNetCore.Mvc;
using WebMarket_DataAccess.Services.Interface;
using WebMarket_Models;


namespace WebMarket_App.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _CategoryServices;

        public CategoryController(ICategoryServices CategoryServices)
        {
            _CategoryServices = CategoryServices;
        }
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Category> CategoryList = _CategoryServices.GetAll();
            return View(CategoryList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _CategoryServices.Add(obj);
                TempData["success"] = "دسته جدید با موفقیت ثبت شد";
                return RedirectToAction("index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.Categories.Find(id);
            var categoryFromDbFirst = _CategoryServices.GetFirstOrDefaulte(i => i.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(i => i.Id == id);
            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(categoryFromDbFirst);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _CategoryServices.Update(obj);
                TempData["success"] = "دسته با موفقیت ویرایش شد";
                return RedirectToAction("index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.Categories.Find(id);
            var categoryFromDbFirst = _CategoryServices.GetFirstOrDefaulte(i => i.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(i => i.Id == id);
            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(categoryFromDbFirst);
        }
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            var obj = _CategoryServices.GetFirstOrDefaulte(i => i.Id == id);
            _CategoryServices.Remove(obj);
            TempData["success"] = "دسته با موفقیت حذف شد";
            return RedirectToAction("index");
        }
    }
}
