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
    }
}