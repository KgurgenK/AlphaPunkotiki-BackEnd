using AlphaPunkotiki.Domain.Errors.Base;
using Microsoft.AspNetCore.Http;

namespace AlphaPunkotiki.Domain.Errors;

public class UnavailableElementError(string? message = default)
    : Error(StatusCodes.Status403Forbidden, message ?? "The Entity is unavailable.");
