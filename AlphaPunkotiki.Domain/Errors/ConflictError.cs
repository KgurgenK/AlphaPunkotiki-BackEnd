using AlphaPunkotiki.Domain.Errors.Base;
using Microsoft.AspNetCore.Http;

namespace AlphaPunkotiki.Domain.Errors;

public class ConflictError(string? message = default)
    : Error(StatusCodes.Status409Conflict, message ?? "There are conflicts between entities.");