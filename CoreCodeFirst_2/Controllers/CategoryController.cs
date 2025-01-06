using CoreCodeFirst_2.Models.ContextClasses;
using CoreCodeFirst_2.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreCodeFirst_2.Controllers
{
    public class CategoryController : Controller
    {
        //readonly keyword'une sahip olan bir field sadece ve sadece constructor icerisinde atama alabilir...

        readonly MyContext _context;

        public CategoryController(MyContext context)
        {
            _context = context;
        }
        public IActionResult CategoryList()
        {
            List<Category> categories = _context.Categories.ToList();
            return View(categories);
        }


        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("CategoryList");
        }
    }
}
