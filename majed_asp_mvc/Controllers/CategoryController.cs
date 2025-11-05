// استدعاء الملفات الضرورية: قاعدة البيانات، النماذج، وأدوات MVC
using majed_asp_mvc.Data;
using majed_asp_mvc.Filters;
using majed_asp_mvc.Interfaces;
using majed_asp_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace majed_asp_mvc.Controllers
{
    [SessionAuthorize]
    // تعريف وحدة التحكم الخاصة بالتصنيفات
    public class CategoryController : Controller
    {
        // تعريف كائن قاعدة البيانات
        //private readonly ApplicationDbContext _context;
        //private readonly IRepository<Category> _categoryRepository;

        //public CategoryController(IRepository<Category> categoryRepository)
        //{
        //    _categoryRepository = categoryRepository;
        //}

        // حقن كائن قاعدة البيانات داخل وحدة التحكم
        //public CategoryController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}


        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // عرض جميع التصنيفات - صفحة Index
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                // جلب جميع التصنيفات من قاعدة البيانات
                //IEnumerable<Category> categories = _context.Categories.ToList();
                //IEnumerable<Category> categories = _categoryRepository.GetAll();
                IEnumerable<Category> categories = _unitOfWork._repositoryCategory.GetAll();

                ////تحديث التوكن للبيانات القديمة في قاعدة البيانات يستخدم مرة واحدة عند وجود بيانات سابقة لا تحتوي على توكن بعد ذلك يتوقف الكود 
                //foreach (var category in categories)
                //{
                //    if (string.IsNullOrEmpty(category.Uid))
                //    {
                //        category.Uid = Guid.NewGuid().ToString();
                //        category.CreatedAt = DateTime.Now;
                //        _context.Categories.Update(category);
                //        _context.SaveChanges();
                //    }
                //}


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
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            try
            {
                // التحقق من صحة البيانات المدخلة
                if (!ModelState.IsValid)
                {
                    return View(category); // إعادة عرض النموذج مع البيانات
                }

                //_context.Categories.Add(category); // جملة الإضافة
                //_context.SaveChanges(); // حفظ التغييرات في قاعدة البيانات

                //_categoryRepository.Add(category); // إضافة التصنيف الجديد عبر المستودع
                _unitOfWork._repositoryCategory.Add(category);
                _unitOfWork.Save();
                return RedirectToAction("Index"); // إعادة التوجيه إلى صفحة Index
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }

        // عرض نموذج تعديل التصنيف حسب الـ Id
        [HttpGet]
        public IActionResult Edit(string Uid)
        {
            //var category = _context.Categories.AsNoTracking().FirstOrDefault(c => c.Uid == Uid); // البحث عن التصنيف المطلوب
            //var category = _categoryRepository.GetByUId(Uid); // جلب التصنيف عبر المستودع
            var category = _unitOfWork._repositoryCategory.GetByUId(Uid);
            return View(category); // عرض النموذج مع بيانات التصنيف
        }

        // استقبال التعديلات وحفظها
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category,string Uid)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(category); // إعادة عرض النموذج في حال وجود أخطاء
                }

                //var cate= _context.Categories.AsNoTracking().FirstOrDefault(e => e.Uid == category.Uid);
                //var cate= _categoryRepository.GetByUId(Uid);
                var cate= _unitOfWork._repositoryCategory.GetByUId(Uid);
                if (cate != null) 
                {
                    cate.Name = category.Name;
                    cate.Description = category.Description;

                    //_context.Categories.Update(cate); // تحديث بيانات التصنيف
                    //_context.SaveChanges(); // حفظ التغييرات

                    //_categoryRepository.Update(cate); // تحديث التصنيف عبر المستودع
                    _unitOfWork._repositoryCategory.Update(cate);
                    _unitOfWork.Save();

                    return RedirectToAction("Index"); // العودة لصفحة التصنيفات

                }

                return View(category);


                
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }

        // عرض صفحة تأكيد الحذف لتصنيف معين
        [HttpGet]
        public IActionResult Delete(string Uid)
        {
            //var category = _context.Categories.AsNoTracking().FirstOrDefault(c => c.Uid == Uid); // البحث عن التصنيف المطلوب
            //var category = _categoryRepository.GetByUId(Uid);
            var category = _unitOfWork._repositoryCategory.GetByUId(Uid);

            return View(category); // عرض صفحة الحذف
        }

        // تنفيذ عملية الحذف بعد التأكيد
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {
            try
            {
                // جلب العنصر من قاعدة البيانات باستخدام Uid
                //var item = _categoryRepository.GetByUId(category.Uid);
                var item = _unitOfWork._repositoryCategory.GetByUId(category.Uid);
                if (item != null)
                {
                    // حذف العنصر باستخدام Id الفعلي
                    //_categoryRepository.Delete(item.Id);
                    _unitOfWork._repositoryCategory.Delete(item.Id);
                    _unitOfWork.Save();

                }
                //_context.Categories.Remove(category); // حذف التصنيف
                //_context.SaveChanges(); // حفظ التغييرات

                return RedirectToAction("Index"); // العودة لصفحة التصنيفات
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:اثناء الحذف");
            }
        }






    }
}