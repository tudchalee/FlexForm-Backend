namespace FlexForm_Backend.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using FlexForm_Backend.Entities;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{ 
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // authorization
        var user = (Users)context.HttpContext.Items["User"];
        if (user == null)
            context.Result = new JsonResult(new { message = "Unauthorized" }) 
                { StatusCode = StatusCodes.Status401Unauthorized };
    }
}