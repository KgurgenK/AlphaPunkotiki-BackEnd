using AlphaPunkotiki.Domain.Entities;

namespace AlphaPunkotiki.WebApi.Controllers.Models.InterviewsController;

public record GetInterviewsResponse(IReadOnlyList<Interview> Interviews);
