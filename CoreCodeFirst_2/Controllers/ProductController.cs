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



        //Eger siz FrontEnd View'indan Action'ina post edilirken gönderilen Modeli bir pagevm olarak alıyorsanız yalnız icerisindeki yapıya ulasmak istiyorsanız o yapının property'sine action'inizin parametre ismine birebir aynı vermelisiniz (incasesensitive)

        //Veya Bind prefix sistemini kullanmalısınız..Bu sistem prefix keyword'undeki deger, PageVM gibi bir kapsülleme görevini üstlenmiş yapının icerisindeki Property'e denk düsüyorsa onu parametrenize bind eder

        [HttpPost]
        public IActionResult CreateProduct([Bind(Prefix ="Product")]Product item)
        {
            _context.Products.Add(item);
            _context.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public IActionResult UpdateProduct(int id)
        {
            UpdateProductPageVm upPvm = new()
            {
                Product = _context.Products.Find(id),
                Categories = _context.Categories.ToList()
            };
            return View(upPvm);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            Product p = _context.Products.Find(product.Id);
            p.ProductName = product.ProductName;
            p.UnitPrice = product.UnitPrice;
            p.CategoryId = product.CategoryId;
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
