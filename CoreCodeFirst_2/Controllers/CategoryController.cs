using CoreCodeFirst_2.Models.ContextClasses;
using CoreCodeFirst_2.Models.Entities;
using CoreCodeFirst_2.Models.PageVms.Categories;
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

        public IActionResult UpdateCategory(int id)
        {


            Category category = _context.Categories.Find(id);

            UpdateCategoryPageVm updateCategoryPagevm = new()
            {
                Category = category
            };
            return View(updateCategoryPagevm);
        }


        //!!Ödev : UpdateCategory post tarafında kullanıcının müdahale edebilecegi ve sistemi cökertecek bir durum vardır...Bunu engellemenizi istiyorum....Try catch kullanmayın...Bunu engellemekle kalmayın ek bir tablo yaratın..BU tarz süpheli durumları gercekleştiren kisilerin bu durumları hangi tarihte gerçekleştirdigini kaydeden bir sistem olusturun...

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            Category c = _context.Categories.Find(category.Id);
            c.CategoryName =category.CategoryName;
            c.Description = category.Description;
            _context.SaveChanges();
            return RedirectToAction("CategoryList");
        }



        //Delete'i de Update gibi Get ve Post sistemi ile entegre etme ödevi...
        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            Category c = _context.Categories.Find(id);
            _context.Categories.Remove(c);  
            _context.SaveChanges();
            return RedirectToAction("CategoryList");
        }
    }
}
