using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AMVchallenge.Filters
{
    public class AuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
          
            if (context.HttpContext.Session.GetString("IsAuthenticated") != "true")
            {
                context.Result = new RedirectToActionResult("Login", "Usuario", null);
            }
            base.OnActionExecuting(context);
        }
    }
}
