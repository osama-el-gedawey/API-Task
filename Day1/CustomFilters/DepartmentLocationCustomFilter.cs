using Day1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Day1.CustomFilters
{
    public class DepartmentLocationCustomFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Department dept = (Department)context.ActionArguments["dept"];
            if (!(dept.Location == "eg" || dept.Location == "usa"))
            {
                context.Result = new BadRequestObjectResult("Department Location must be eg or usa");
            }
            //base.OnActionExecuting(context);
        }
    }
}
