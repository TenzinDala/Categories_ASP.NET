using Categories_ASP.NET.DataAccess.Repository.IRepository;
using Categories_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace Categories_ASP.NET.Areas.Admin.Controllers
{
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        public CoverTypeController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<CoverType> objCoverTypeyList = _UnitOfWork.CoverType.GetAll();
            return View(objCoverTypeyList);
        }
        //Get
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _UnitOfWork.CoverType.Add(obj);
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
            var CoverTypeFromDbFirst = _UnitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

            if (CoverTypeFromDbFirst == null)
            {
                return NotFound();
            }
            return View(CoverTypeFromDbFirst);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _UnitOfWork.CoverType.Update(obj);
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
            var CoverTypeFromDbFirst = _UnitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);


            if (CoverTypeFromDbFirst == null)
            {
                return NotFound();
            }
            return View(CoverTypeFromDbFirst);
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
            var CoverTypeFromDbFirst = _UnitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

            _UnitOfWork.CoverType.Remove(CoverTypeFromDbFirst);
            _UnitOfWork.Save();
            return RedirectToAction("Index");

        }
    }
}
