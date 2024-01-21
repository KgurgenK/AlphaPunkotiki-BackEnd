namespace AlphaPunkotiki.WebApi.Models.SurveysController;

public record GetQuestionStatisticsResponse(IReadOnlyDictionary<string, (int frequency, float part)> Statistics);
