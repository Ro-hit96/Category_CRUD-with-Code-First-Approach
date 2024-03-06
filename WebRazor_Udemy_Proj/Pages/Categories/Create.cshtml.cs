using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazor_Udemy_Proj.Data;
using WebRazor_Udemy_Proj.Model;

namespace WebRazor_Udemy_Proj.Pages.Categories
{
    [BindProperties]//Explictly bind poperties
    public class CreateModel : PageModel
    {
        
        private readonly ApplicationDbContext _db;
        
        public Category Category { get; set;}
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(Category obj)
        {
            _db.Categories.Add(Category);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
