using Microsoft.AspNetCore.Mvc.Filters;

namespace majed_asp_mvc.Filters
{
    public class SessionAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var email = context.HttpContext.Session.GetString("UserEmail");
            if (email == null)
            {
                // إعادة التوجيه إلى صفحة تسجيل الدخول
                context.HttpContext.Response.Redirect("/Account/Login");
            }


            base.OnActionExecuting(context);

        }
    }
}
