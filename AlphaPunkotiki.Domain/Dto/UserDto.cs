using AlphaPunkotiki.Domain.Entities;
using AlphaPunkotiki.Domain.Enums;

namespace AlphaPunkotiki.Domain.Dto;

public record UserDto(
    Role Role,
    string Name,
    string Email,
    string? PhoneNumber,
    string? Description);
