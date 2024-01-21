using AlphaPunkotiki.Domain.Entities;

namespace AlphaPunkotiki.WebApi.Models.SurveysController;

public record GetSurveysResponse(IReadOnlyList<Survey> Surveys);
