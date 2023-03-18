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
    }
}
