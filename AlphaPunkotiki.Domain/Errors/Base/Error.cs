using Microsoft.AspNetCore.Mvc;

namespace AlphaPunkotiki.Domain.Errors.Base;

public class Error(int statusCode, string errorMessage)
{
    public ActionResult ThrowResultError(string? message = default) 
        => new ObjectResult(errorMessage + (message == null ? "" : "\n message")) { StatusCode = statusCode };
}
