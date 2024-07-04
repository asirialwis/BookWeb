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

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("DisplayOrder", "The Displayorder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
            
        }


        

        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var cateforyFromDb = _db.Categories.Find(id);

            if (cateforyFromDb == null)
            {
                return NotFound();
            }
            return View(cateforyFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("DisplayOrder", "The Displayorder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var catID = _db.Categories.Find(id);
            return View(catID);

        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id){
            var obj = _db.Categories.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}