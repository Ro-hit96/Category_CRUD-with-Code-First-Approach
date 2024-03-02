using Category_U_CRUD.Data;
using Category_U_CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace Category_U_CRUD.Controllers
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
            List<Category> objCategoryList=_db.Categories.ToList();

            return View(objCategoryList);
        }
    }
}
