using AlphaPunkotiki.Domain.Enums;

namespace AlphaPunkotiki.Domain.Dto;

public record QuestionDto(QuestionType Type, string Name, string? Tooltip, string[]? Variables, bool IsRequired);
