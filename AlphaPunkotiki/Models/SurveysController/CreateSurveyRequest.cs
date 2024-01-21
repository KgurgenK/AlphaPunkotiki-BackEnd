using AlphaPunkotiki.Domain.Dto;

namespace AlphaPunkotiki.WebApi.Models.SurveysController;

public record CreateSurveyRequest(SurveyDto Survey, IReadOnlyList<QuestionDto> Questions);
