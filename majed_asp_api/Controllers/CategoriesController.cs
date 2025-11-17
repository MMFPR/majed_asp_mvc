using majed_asp_mvc.Dtos;
using majed_asp_mvc.Interfaces.IServices;
using majed_asp_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace majed_asp_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetAll()
        {
            try
            {
                IEnumerable<Category> categories = _categoryService.GetAll();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return Content("حدث خطا غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }


        [HttpGet("{uid}")]
        public ActionResult<Category> GetByUid(string uid)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(uid))
                {
                    return BadRequest("Uid is Required");
                }
                var category = _categoryService.GetByUid(uid);
                if (category == null)
                {
                    return NotFound("لا توجد فئة بهذا الرقم"); //404
                }

                return Ok(category); //200
            }
            catch (Exception ex)
            {
                var message = ex.Message.ToString();
                return BadRequest($"{message} حدث خطأ غير متوقع ");
            }
        }

        [HttpPost]
        public ActionResult Create(CategoryDto categorydto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var category = new Category();

                category.Name = categorydto.Name;
                category.Description = categorydto.Description;

                var isCreated = _categoryService.Create(category);
                if (isCreated)
                {
                    //return CreatedAtAction(nameof(GetByUid), new { uid = category.Uid }, category);
                    return Ok("تم إنشاء الفئة بنجاح"); //200
                }

                return BadRequest("لم يتم إنشاء الفئة بنجاح"); //400
            }
            catch (Exception ex)
            {
                var message = ex.Message.ToString();
                return BadRequest($"{message} حدث خطأ غير متوقع ");
            }

        }



        [HttpPut("{uid}")]
        public IActionResult Update(string uid, [FromBody] CategoryUpdateDto category)
        {
            if (string.IsNullOrWhiteSpace(uid)) return BadRequest("Uid is Required");
            if (category == null) return BadRequest("Category data is required");
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var exists = _categoryService.GetByUid(uid);
            if (exists == null) return NotFound("لا توجد فئة بهذا الرقم"); //404

            var newCategory = new Category
            {
                Uid = category.Uid,
                Name = category.Name,
                Description = category.Description
            };

            _categoryService.Update(uid, newCategory);
            return Ok("تم تحديث الفئة بنجاح"); //200
        }

        [HttpDelete("{uid}")]
        public IActionResult Delete(string uid)
        {
            if (string.IsNullOrWhiteSpace(uid)) return BadRequest("Uid is Required");
            var exists = _categoryService.GetByUid(uid);
            if (exists == null) return NotFound("لا توجد فئة بهذا الرقم"); //404
            _categoryService.DeleteByUid(uid);
            return Ok("تم حذف الفئة بنجاح"); //200

        }





    }
}
