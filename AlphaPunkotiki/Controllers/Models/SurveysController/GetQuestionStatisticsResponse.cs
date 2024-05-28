using AlphaPunkotiki.Domain.Dto;

namespace AlphaPunkotiki.WebApi.Controllers.Models.SurveysController;

public record GetQuestionStatisticsResponse(IReadOnlyDictionary<string, AnswerItemStatisticsDto> Statistics);
