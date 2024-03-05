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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "This Display Order Cannot Exactly Match the Name");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Create Successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            Category categoryfromDb=_db.Categories.FirstOrDefault(u=>u.Id==id);
            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Update Successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryfromDb = _db.Categories.FirstOrDefault(u => u.Id == id);
            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category obj = _db.Categories.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["Success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
            
        }
    }
}
