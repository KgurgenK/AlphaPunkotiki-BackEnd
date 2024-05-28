using AlphaPunkotiki.Domain.Dto;

namespace AlphaPunkotiki.WebApi.Controllers.Models.SurveysController;

public record CreateSurveyRequest(SurveyDto Survey, IReadOnlyList<QuestionDto> Questions);
