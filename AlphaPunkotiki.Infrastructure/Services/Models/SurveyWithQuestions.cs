using AlphaPunkotiki.Domain.Entities;

namespace AlphaPunkotiki.Infrastructure.Services.Models;

public record SurveyWithQuestions(Survey Survey, IReadOnlyList<Question> Questions);
