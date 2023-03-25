using Categories_ASP.NET.DataAccess.Data;
using Categories_ASP.NET.DataAccess.Repository.IRepository;
using Categories_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace Categories_ASP.NET.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        public CategoryController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _UnitOfWork.Category.GetAll();
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
                _UnitOfWork.Category.Add(obj);
                _UnitOfWork.Save();
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
            //var CategoryFromDb = _db.categories.Find(id);
            var CategoryFromDbFirst = _UnitOfWork.Category.GetFirstOrDefault(u => u.Id == id);

            if (CategoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(CategoryFromDbFirst);
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
                _UnitOfWork.Category.Update(obj);
                _UnitOfWork.Save();
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
            //var CategoryFromDb = _db.categories.Find(id);
            var CategoryFromDbFirst = _UnitOfWork.Category.GetFirstOrDefault(u => u.Id == id);


            if (CategoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(CategoryFromDbFirst);
        }

        //Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var obj = _db.categories.Find(id);
            var CategoryFromDbFirst = _UnitOfWork.Category.GetFirstOrDefault(u => u.Id == id);

            _UnitOfWork.Category.Remove(CategoryFromDbFirst);
            _UnitOfWork.Save();
            return RedirectToAction("Index");

        }
    }
}
