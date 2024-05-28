using AlphaPunkotiki.Domain.Entities;

namespace AlphaPunkotiki.WebApi.Controllers.Models.SurveysController;

public record GetFullSurveyResponse(Survey Survey, IReadOnlyList<Question> Questions);
