using AlphaPunkotiki.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AlphaPunkotiki.WebApi.Attributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class AuthorizedRolesAttribute(params Role[]? roles) : AuthorizeAttribute, IAuthorizationFilter
{
    private readonly Role[] _roles = roles ?? [];

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var isUserInRole = _roles.Any(role => context.HttpContext.User.IsInRole(role.ToString())) || _roles.Length == 0;

        if (!isUserInRole)
            context.Result = new JsonResult(new { message = "User with presented token doesn't have access to method." })
                { StatusCode = StatusCodes.Status403Forbidden };
    }
}
