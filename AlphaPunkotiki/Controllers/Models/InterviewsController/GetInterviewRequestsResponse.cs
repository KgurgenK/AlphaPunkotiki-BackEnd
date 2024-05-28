using AlphaPunkotiki.Domain.Entities;

namespace AlphaPunkotiki.WebApi.Controllers.Models.InterviewsController;

public record GetInterviewRequestsResponse(IReadOnlyList<InterviewRequest> InterviewRequests);
