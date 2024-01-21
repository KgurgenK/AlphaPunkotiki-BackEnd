using AlphaPunkotiki.Domain.Dto;
using AlphaPunkotiki.Domain.Entities;
using AlphaPunkotiki.Domain.Enums;

namespace AlphaPunkotiki.Infrastructure.Services.Interfaces;

public interface IInterviewsService
{
    Task CreateInterviewAsync(InterviewDto interviewInfo);

    Task<bool> CreateInterviewRequestAsync(Guid userId, Guid interviewId);

    Task<Interview?> GetInterviewAsync(Guid interviewId);

    Task<IReadOnlyList<Interview>> GetAllAvailableInterviewsAsync();

    Task<IReadOnlyList<Interview>> GetUserInterviewsAsync(Guid userId);

    Task<IReadOnlyList<InterviewRequest>> GetCandidateInterviewRequestsAsync(Guid candidateId);

    Task<IReadOnlyList<InterviewRequest>> GetInterviewerInterviewRequestsAsync(Guid interviewerId);

    Task<IReadOnlyList<InterviewRequest>> GetInterviewRequestsByInterviewAsync(Guid interviewId);

    Task<bool> ChangeInterviewRequestStatusAsync(Guid interviewRequestId, InterviewRequestStatus newStatus, string message);

    Task DeleteInterviewRequestAsync(Guid interviewRequestId);
}
