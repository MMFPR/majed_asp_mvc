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
    public class EmployeesController : Controller
    {

        ////private readonly ApplicationDbContext _context;
        //private readonly IEmployeeRepo _employeeRepo;
        //private readonly IRepository<Department> _departmentRepo;
        //private readonly IRepository<Job> _jobRepo;
        //private readonly IRepository<Nationality> _nationalityRepo;


        //public EmployeesController(IEmployeeRepo employeeRepo, IRepository<Department> departmentRepo, IRepository<Job> jobRepo, IRepository<Nationality> nationalityRepo)
        //{
        //    //_context = context;
        //    _employeeRepo = employeeRepo;
        //    _departmentRepo = departmentRepo;
        //    _jobRepo = jobRepo;
        //    _nationalityRepo = nationalityRepo;
        //}


        private readonly IUnitOfWork _unitOfWork;
        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        //----------------------------------------------------


        public IActionResult Index()
        {
            try
            {
                //IEnumerable<Employee> emp = _context.Employees
                //    .Include(e => e.Department)
                //    .Include(j => j.Job)
                //    .Include(n => n.Nationality)
                //    .ToList();

                IEnumerable<Employee> emp = _unitOfWork._employeeRepo.GetEmployeesWithDepartmentAndJob();


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
            //IEnumerable<Department> dapts = _context.Departments.ToList();
            IEnumerable<Department> dapts = _unitOfWork._departmentRepo.GetAll();
            SelectList selectListItems = new SelectList(dapts, "Id", "Name");
            ViewBag.Departments = selectListItems;
        }

        private void SetNationalityViewBag()
        {
            //IEnumerable<Nationality> nationality = _context.Nationalities.ToList();
            IEnumerable<Nationality> nationality = _unitOfWork._nationalityRepo.GetAll();
            SelectList selectListItems = new SelectList(nationality, "Id", "Name");
            ViewBag.Nationalities = selectListItems;
        }

        private void SetJobViewBag()
        {
            //IEnumerable<Job> job = _context.Jobs.ToList();
            IEnumerable<Job> job = _unitOfWork._jobRepo.GetAll();
            SelectList selectListItems = new SelectList(job, "Id", "Name");
            ViewBag.Jobs = selectListItems;
        }


        //------------------------


        [HttpGet]
        public IActionResult Create()
        {
            SetNationalityViewBag();
            SetJobViewBag();
            SetDeptViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee emp)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(emp);
                }

                //_context.Employees.Add(emp);
                //_context.SaveChanges();

                _unitOfWork._employeeRepo.Add(emp);
                _unitOfWork.Save();
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
            //var emp = _context.Employees.Find(Id);
            var emp = _unitOfWork._employeeRepo.GetById(Id);
            SetNationalityViewBag();
            SetJobViewBag();
            SetDeptViewBag();
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee emp)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    SetNationalityViewBag();
                    SetJobViewBag();
                    SetDeptViewBag();
                    return View(emp);
                }

                //_context.Employees.Update(emp);
                //_context.SaveChanges();

                _unitOfWork._employeeRepo.Update(emp);
                _unitOfWork.Save();

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
            //var emp = _context.Employees.Find(Id);
            var emp = _unitOfWork._employeeRepo.GetById(Id);
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employee emp)
        {
            try
            {
                //_context.Employees.Remove(emp);
                //_context.SaveChanges();

                _unitOfWork._employeeRepo.Delete(emp.Id);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }








    }
}
