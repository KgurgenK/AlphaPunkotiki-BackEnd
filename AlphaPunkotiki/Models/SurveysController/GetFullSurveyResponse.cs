using AlphaPunkotiki.Domain.Entities;

namespace AlphaPunkotiki.WebApi.Models.SurveysController;

public record GetFullSurveyResponse(Survey Survey, IReadOnlyList<Question> Questions);
