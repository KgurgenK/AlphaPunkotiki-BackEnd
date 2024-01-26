using AlphaPunkotiki.Domain.Dto;

namespace AlphaPunkotiki.WebApi.Models.SurveysController;

public record GetQuestionStatisticsResponse(IReadOnlyDictionary<string, AnswerItemStatisticsDto> Statistics);
