using CoreCodeFirst_2.Models.ContextClasses;
using CoreCodeFirst_2.Models.Entities;
using CoreCodeFirst_2.Models.PageVms.Products;
using Microsoft.AspNetCore.Mvc;

namespace CoreCodeFirst_2.Controllers
{
    public class ProductController : Controller
    {
        MyContext _context;
        public ProductController(MyContext context)
        {
            _context = context;
        }

        public IActionResult ProductList()
        {
            return View(_context.Products.ToList());
        }

        public IActionResult CreateProduct()
        {
            CreateProductPageVm cpVm = new()
            {
                Categories = _context.Categories.ToList()
               
            };
            return View(cpVm);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product item)
        {
            _context.Products.Add(item);
            _context.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public IActionResult UpdateProduct(int id)
        {
            return View(_context.Products.Find(id));
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product item)
        {
            Product p = _context.Products.Find(item.Id);
            p.ProductName = item.ProductName;
            p.UnitPrice = item.UnitPrice;   
            _context.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public IActionResult DeleteProduct(int id) 
        {
            _context.Products.Remove(_context.Products.Find(id));
            _context.SaveChanges(); 
            return RedirectToAction("ProductList");
        
        }
    }
}
