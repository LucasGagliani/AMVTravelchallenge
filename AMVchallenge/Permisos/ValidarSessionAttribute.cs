using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AMVchallenge.Permisos
{
    public class ValidarSessionAttribute : ActionFilterAttribute
    {
        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.GetString("Usuario") == null)
            {
                filterContext.Result = new RedirectResult("~/Usuario/Login");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
