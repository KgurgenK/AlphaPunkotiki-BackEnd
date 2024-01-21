using AlphaPunkotiki.Domain.Entities;

namespace AlphaPunkotiki.WebApi.Models.InterviewsController;

public record GetInterviewsResponse(IReadOnlyList<Interview> Interviews);
