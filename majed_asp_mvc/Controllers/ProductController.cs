using majed_asp_mvc.Data;
using majed_asp_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace majed_asp_mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> Products = _context.Products.Include(c => c.Category).ToList();
            return View(Products);
        }

        //------------------------

        // تجهيز قائمة التصنيفات وإرسالها إلى ViewBag لعرضها في القائمة المنسدلة داخل النموذج
        private void SetCategoryViewBag()
        {
            IEnumerable<Category> categories = _context.Categories.ToList();
            SelectList selectListItems = new SelectList(categories, "Id", "Name");
            ViewBag.Categories = selectListItems;
        }


        //------------------------


        [HttpGet]
        public IActionResult Create()
        {
            SetCategoryViewBag();
            return View(); 
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }

                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }

       
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var products = _context.Products.Find(Id);
            SetCategoryViewBag();
            return View(products);
        }

     
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(product); 
                }

                _context.Products.Update(product);
                _context.SaveChanges(); 
                return RedirectToAction("Index"); 
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }

        
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var products = _context.Products.Find(Id); 
            return View(products); 
        }


        [HttpPost]
        public IActionResult Delete(Product product)
        {
            try
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }





    }
}