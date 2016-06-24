using System.Data.Entity.Core;
using System.Web.Mvc;

namespace CodeChallange.UI.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            ViewResult result = new ViewResult();
            result.ViewName = "Error";
            result.ViewBag.Message = "An error occurred while processing your request";

            if (filterContext.Exception.GetType() == typeof(EntityException))
            {
                result.ViewBag.Message = "Database Connection Error,please try again !";
            }

            filterContext.Result = result;

            base.OnException(filterContext);
        }
    }
}