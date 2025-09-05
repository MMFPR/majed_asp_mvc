// استدعاء الملفات الضرورية: قاعدة البيانات، النماذج، وأدوات MVC
using majed_asp_nvc.Data;
using majed_asp_nvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp4_AspMVC.Controllers
{
    // تعريف وحدة التحكم الخاصة بالتصنيفات
    public class CategoryController : Controller
    {
        // تعريف كائن قاعدة البيانات
        private readonly ApplicationDbContext _context;

        // حقن كائن قاعدة البيانات داخل وحدة التحكم
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // عرض جميع التصنيفات - صفحة Index
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                // جلب جميع التصنيفات من قاعدة البيانات
                IEnumerable<Category> categories = _context.Categories.ToList();

                // عرض البيانات داخل صفحة Index
                return View(categories);
            }
            catch (Exception ex)
            {
                // في حال حدوث خطأ، عرض رسالة للمستخدم
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }

        // عرض نموذج إضافة تصنيف جديد
        [HttpGet]
        public IActionResult Create()
        {
            return View(); // عرض صفحة النموذج فقط
        }

        // استقبال البيانات من النموذج وحفظ التصنيف الجديد
        [HttpPost]
        public IActionResult Create(Category category)
        {
            try
            {
                // التحقق من صحة البيانات المدخلة
                if (!ModelState.IsValid)
                {
                    return View(category); // إعادة عرض النموذج مع البيانات
                }

                _context.Categories.Add(category); // جملة الإضافة
                _context.SaveChanges(); // حفظ التغييرات في قاعدة البيانات
                return RedirectToAction("Index"); // إعادة التوجيه إلى صفحة Index
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }

        // عرض نموذج تعديل التصنيف حسب الـ Id
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var category = _context.Categories.Find(Id); // البحث عن التصنيف المطلوب
            return View(category); // عرض النموذج مع بيانات التصنيف
        }

        // استقبال التعديلات وحفظها
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(category); // إعادة عرض النموذج في حال وجود أخطاء
                }

                _context.Categories.Update(category); // تحديث بيانات التصنيف
                _context.SaveChanges(); // حفظ التغييرات
                return RedirectToAction("Index"); // العودة لصفحة التصنيفات
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }

        // عرض صفحة تأكيد الحذف لتصنيف معين
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var category = _context.Categories.Find(Id); // البحث عن التصنيف
            return View(category); // عرض صفحة الحذف
        }

        // تنفيذ عملية الحذف بعد التأكيد
        [HttpPost]
        public IActionResult Delete(Category category)
        {
            try
            {
                _context.Categories.Remove(category); // حذف التصنيف
                _context.SaveChanges(); // حفظ التغييرات
                return RedirectToAction("Index"); // العودة لصفحة التصنيفات
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }
    }
}