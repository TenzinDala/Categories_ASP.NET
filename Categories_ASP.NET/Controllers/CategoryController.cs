using Categories_ASP.NET.Data;
using Categories_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace Categories_ASP.NET.Controllers
{   
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.categories;
            return View(objCategoryList);
        }
        //Get
        public IActionResult Create()
        { 
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {  
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display order cannot be same as Name");
                TempData["error"] = "Unsuccesful!!!";
            }
            if (ModelState.IsValid)
            { 
            _db.categories.Add(obj);
            _db.SaveChanges();
                TempData["success"] = "Succesfully Created!!!";
            return RedirectToAction("Index");
            }
            return View(obj);
        }
        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            { 
                return NotFound();
            }
            var CategoryFromDb = _db.categories.Find(id);

            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display order cannot be same as Name");
                TempData["error"] = "Unsuccesful!!!";
            }
            if (ModelState.IsValid)
            {
                _db.categories.Update(obj);  
                _db.SaveChanges();
                TempData["success"] = "Succesfully Updated!!!";
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
            var CategoryFromDb = _db.categories.Find(id);

            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }

        //Post
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.categories.Find(id);
            _db.categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
