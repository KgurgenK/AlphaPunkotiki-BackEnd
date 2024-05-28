using AlphaPunkotiki.Domain.Errors.Base;
using Microsoft.AspNetCore.Http;

namespace AlphaPunkotiki.Domain.Errors;

public class NotFoundError(string? message = default) 
    : Error(StatusCodes.Status404NotFound, message ?? "Entity was not found.");
