using AlphaPunkotiki.Domain.Entities;

namespace AlphaPunkotiki.WebApi.Controllers.Models.SurveysController;

public record GetSurveysResponse(IReadOnlyList<Survey> Surveys);
