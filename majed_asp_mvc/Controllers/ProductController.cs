using majed_asp_mvc.Data;
using majed_asp_mvc.Filters;
using majed_asp_mvc.Interfaces;
using majed_asp_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace majed_asp_mvc.Controllers
{
    [SessionAuthorize]
    public class ProductController : Controller
    {
        //private readonly ApplicationDbContext _context;

        private readonly IProductRepo _productRepo;
        private readonly IRepository<Category> _categoryRepo;

        public ProductController(IProductRepo productRepo, IRepository<Category> categoryRepo)
        {
            //_context = context;
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }
        public IActionResult Index()
        {
            try 
            {
                //IEnumerable<Product> Products = _context.Products.Include(c => c.Category).ToList();
                IEnumerable<Product> Products = _productRepo.GetProductsWithCategory();

                ////تحديث التوكن للبيانات القديمة في قاعدة البيانات يستخدم مرة واحدة عند وجود بيانات سابقة لا تحتوي على توكن بعد ذلك يتوقف الكود 
                //foreach (var item in Products)
                //{
                //    if (string.IsNullOrEmpty(item.Uid))
                //    {
                //        item.Uid = Guid.NewGuid().ToString();
                //        _context.Products.Update(item);
                //        _context.SaveChanges();
                //    }
                //}
                return View(Products);


            } 
            
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
            
        }

        //------------------------

        // تجهيز قائمة التصنيفات وإرسالها إلى ViewBag لعرضها في القائمة المنسدلة داخل النموذج
        private void SetCategoryViewBag()
        {
            //IEnumerable<Category> categories = _context.Categories.ToList();
            IEnumerable<Category> categories = _categoryRepo.GetAll();
            ViewBag.Categories = categories;
        }


        //------------------------


        [HttpGet]
        public IActionResult Create()
        {
            SetCategoryViewBag();
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }

                //_context.Products.Add(product);
                //_context.SaveChanges();

                _productRepo.Add(product);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }

       
        [HttpGet]
        public IActionResult Edit(string Uid)
        {
            //var products = _context.Products.AsNoTracking().FirstOrDefault(e => e.Uid == Uid);
            var products = _productRepo.GetByUId(Uid);
            SetCategoryViewBag();
            return View(products);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(product); 
                }

                //var prod = _context.Products.AsNoTracking().FirstOrDefault(e => e.Uid == product.Uid);
                var prod = _productRepo.GetByUId(product.Uid);
                if (prod != null) 
                {
                    prod.Name = product.Name;
                    prod.Price = product.Price;
                    prod.Description = product.Description;
                    prod.CategoryId = product.CategoryId;

                    //_context.Products.Update(prod);
                    //_context.SaveChanges();

                    _productRepo.Update(prod);

                    return RedirectToAction("Index");


                }
                return View(product);


            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }

        
        [HttpGet]
        public IActionResult Delete(string Uid)
        {
            //var products = _context.Products.AsNoTracking().FirstOrDefault(e => e.Uid == Uid);
            var products = _productRepo.GetByUId(Uid);
            if (products == null)
            {
                return NotFound();
            }

            return View(products); 
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Product product)
        {
            try
            {
                //_context.Products.Remove(product);
                //_context.SaveChanges();

                _productRepo.Delete(product.Uid);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }





    }
}