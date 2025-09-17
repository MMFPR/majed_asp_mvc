using majed_asp_mvc.Data;
using majed_asp_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace majed_asp_mvc.Controllers
{
    public class EmployeesController : Controller
    {

        private readonly ApplicationDbContext _context;
        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }


        //----------------------------------------------------


        public IActionResult Index()
        {
            try
            {
                IEnumerable<Employee> emp = _context.Employees.Include(d => d.Department).ToList();
                return View(emp);
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }


        //---------------------------

        private void SetDeptViewBag()
        {
            IEnumerable<Department> dapts = _context.Departments.ToList();
            SelectList selectListItems = new SelectList(dapts, "Id", "Name");
            ViewBag.Departments = selectListItems;
        }

        private void SetNationalityViewBag()
        {
            IEnumerable<Nationality> nationality = _context.Nationalities.ToList();
            SelectList selectListItems = new SelectList(nationality, "Id", "Name");
            ViewBag.Nationalities = selectListItems;
        }


        //------------------------


        [HttpGet]
        public IActionResult Create()
        {
            SetNationalityViewBag();
            SetDeptViewBag();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(emp);
                }

                _context.Employees.Add(emp);
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
            var dept = _context.Employees.Find(Id);
            SetNationalityViewBag();
            SetDeptViewBag();
            return View(dept);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(emp);
                }

                _context.Employees.Update(emp);
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
            var emp = _context.Employees.Find(Id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Delete(Employee emp)
        {
            try
            {
                _context.Employees.Remove(emp);
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
