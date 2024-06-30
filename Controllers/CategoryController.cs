using BookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using NameSpace.Data;

namespace BookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly dbConfig _db;

        public CategoryController(dbConfig db) {

            _db = db;
        }
        public IActionResult Index()
        {
             IEnumerable<Category> objCategeoryList = _db.Categories;
            return View(objCategeoryList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
            
        }
        
    }
}