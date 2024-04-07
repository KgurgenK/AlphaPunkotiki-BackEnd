using AlphaPunkotiki.Domain.Dto;
using AlphaPunkotiki.Domain.Entities;
using AlphaPunkotiki.Domain.Enums;
using AlphaPunkotiki.Domain.Errors;
using AlphaPunkotiki.Domain.Errors.Base;
using Kontur.Results;

namespace AlphaPunkotiki.Infrastructure.Services.Interfaces;

public interface IInterviewsService
{
    Task CreateInterviewAsync(InterviewDto interviewInfo);

    Task<Result<UnavailableElementError>> TryCreateInterviewRequestAsync(Guid userId, Guid interviewId);

    Task<Interview?> GetInterviewAsync(Guid interviewId);

    Task<IReadOnlyList<Interview>> GetAllAvailableInterviewsAsync();

    Task<IReadOnlyList<Interview>> GetUserInterviewsAsync(Guid userId);

    Task<IReadOnlyList<InterviewRequest>> GetCandidateInterviewRequestsAsync(Guid candidateId);

    Task<IReadOnlyList<InterviewRequest>> GetInterviewerInterviewRequestsAsync(Guid interviewerId);

    Task<IReadOnlyList<InterviewRequest>> GetInterviewRequestsByInterviewAsync(Guid interviewId);

    Task<Result<Error>> TryChangeInterviewRequestStatusAsync(Guid interviewRequestId, InterviewRequestStatus newStatus, string message);

    Task DeleteInterviewRequestAsync(Guid interviewRequestId);
}
