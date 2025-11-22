// استدعاء الملفات الضرورية: قاعدة البيانات، النماذج، وأدوات MVC
using majed_asp_mvc.Filters;
using majed_asp_mvc.Interfaces.IServices;
using majed_asp_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace majed_asp_mvc.Controllers
{
    [SessionAuthorize]
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        // عرض جميع التصنيفات - صفحة Index
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                IEnumerable<Category> categories = _categoryService.GetAll();
                return View(categories);
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            try
            {
                if (!ModelState.IsValid) return View(category);
                _categoryService.Create(category);
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
            var category = _categoryService.GetByUid(Uid);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category, string Uid)
        {
            try
            {
                if (!ModelState.IsValid) return View(category);

                var cate = _categoryService.GetByUid(category.Uid);
                if (cate != null)
                {
                    cate.Name = category.Name;
                    cate.Description = category.Description;

                    _categoryService.Update(Uid, cate);

                    return RedirectToAction("Index");

                }
                return View(category);
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }

        [HttpGet]
        public IActionResult Delete(string Uid)
        {

            var category = _categoryService.GetByUid(Uid);

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {
            try
            {
                var item = _categoryService.GetByUid(category.Uid);
                if (item != null)
                {
                    _categoryService.DeleteByUid(category.Uid);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:اثناء الحذف");
            }
        }






    }
}