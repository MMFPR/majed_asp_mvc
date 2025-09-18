using majed_asp_mvc.Data;
using majed_asp_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace majed_asp_mvc.Controllers
{
    public class JobsController : Controller
    {

        private readonly ApplicationDbContext _context;
        public JobsController(ApplicationDbContext context)
        {
            _context = context;
        }


        //----------------------------------------------------


        public IActionResult Index()
        {
            try
            {
                IEnumerable<Job> jobs = _context.Jobs.ToList();
                return View(jobs);
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
        public IActionResult Create(Job jobs)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(jobs);
                }

                _context.Jobs.Add(jobs);
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
            var jobs = _context.Jobs.Find(Id);
            return View(jobs);
        }

        [HttpPost]
        public IActionResult Edit(Job jobs)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(jobs);
                }

                _context.Jobs.Update(jobs);
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
            var jobs = _context.Jobs.Find(Id);
            return View(jobs);
        }

        [HttpPost]
        public IActionResult Delete(Job jobs)
        {
            try
            {
                _context.Jobs.Remove(jobs);
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
