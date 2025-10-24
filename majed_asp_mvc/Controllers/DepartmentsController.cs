using majed_asp_mvc.Data;
using majed_asp_mvc.Filters;
using majed_asp_mvc.Interfaces;
using majed_asp_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace majed_asp_mvc.Controllers
{

    [SessionAuthorize]

    public class DepartmentsController : Controller
    {

        //private readonly ApplicationDbContext _context;
        private readonly IRepository<Department> _departmentRepository;

        public DepartmentsController(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }



        //public DepartmentsController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}


        //----------------------------------------------------


        public IActionResult Index()
        {
            try
            {
                //IEnumerable<Department> depts = _context.Departments.ToList();
                IEnumerable<Department> depts = _departmentRepository.GetAll();


                return View(depts);
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }


        //---------------------------


        [HttpGet]
        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department dept)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(dept);
                }

                //_context.Departments.Add(dept);
                //_context.SaveChanges(); 

                _departmentRepository.Add(dept);

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
            //var dept = _context.Departments.Find(Id);
            var dept = _departmentRepository.GetByUId(Uid);
            return View(dept);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department dept, string Uid)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(dept); 
                }

                var department = _departmentRepository.GetByUId(Uid);
                if (department != null)
                {
                    department.Name = dept.Name;
                    //_context.Departments.Update(dept); 
                    //_context.SaveChanges();
                    _departmentRepository.Update(department); // تحديث التصنيف عبر المستودع
                    return RedirectToAction("Index"); // العودة لصفحة التصنيفات

                }
                return View(dept);
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }


        [HttpGet]
        public IActionResult Delete(string Uid)
        {
            //var dept = _context.Departments.Find(Id);
            var dept = _departmentRepository.GetByUId(Uid);
            return View(dept);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Department dept)
        {
            try
            {
                // جلب العنصر من قاعدة البيانات باستخدام Uid
                var item = _departmentRepository.GetByUId(dept.Uid);
                if (item != null)
                {
                    // حذف العنصر باستخدام Id الفعلي
                    _departmentRepository.Delete(item.Id);
                }


                //_context.Departments.Remove(dept);
                //_context.SaveChanges(); 

                //_departmentRepository.Delete(dept.Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }










    }



}
