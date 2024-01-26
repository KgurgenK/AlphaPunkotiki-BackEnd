using AlphaPunkotiki.Domain.Dto;
using AlphaPunkotiki.Domain.Entities;
using AlphaPunkotiki.Domain.Enums;
using AlphaPunkotiki.Infrastructure.Repositories.Interfaces;
using AlphaPunkotiki.Infrastructure.Services.Interfaces;

namespace AlphaPunkotiki.Infrastructure.Services;

public class InterviewsService(IInterviewsRepository interviewsRepository, 
    IInterviewRequestsRepository interviewRequestRepository) : IInterviewsService
{
    public Task CreateInterviewAsync(InterviewDto interviewInfo)
        => interviewsRepository.AddAsync(new Interview(
            interviewInfo.CreatorId,
            interviewInfo.Name,
            interviewInfo.Description,
            interviewInfo.Price,
            interviewInfo.IsLimitedPublicationTime,
            interviewInfo.PublicationTimeLimit,
            interviewInfo.IsLimitedUsages,
            interviewInfo.UsagesLimit,
            interviewInfo.IsLimitedCompletionTime,
            interviewInfo.CompletionTimeLimit));

    public async Task<bool> TryCreateInterviewRequestAsync(Guid userId, Guid interviewId)
    {
        var interview = await interviewsRepository.FindAsync(interviewId);

        if (interview == null || !interview.IsAvailable)
            return false;

        await interviewRequestRepository.AddAsync(new InterviewRequest(interview, userId));

        return true;
    }

    public async Task DeleteInterviewRequestAsync(Guid interviewRequestId)
    {
        var interviewRequest = await interviewRequestRepository.FindAsync(interviewRequestId);

        if (interviewRequest is not null)
            await interviewRequestRepository.DeleteAsync(interviewRequest);
    }

    public Task<IReadOnlyList<Interview>> GetAllAvailableInterviewsAsync()
        => interviewsRepository.GetManyAsync(x => x.IsAvailable);

    public Task<IReadOnlyList<InterviewRequest>> GetCandidateInterviewRequestsAsync(Guid candidateId) 
        => interviewRequestRepository.GetManyByCandidateIdAsync(candidateId);

    public Task<Interview?> GetInterviewAsync(Guid interviewId) 
        => interviewsRepository.FindAsync(interviewId);

    public Task<IReadOnlyList<InterviewRequest>> GetInterviewerInterviewRequestsAsync(Guid interviewerId) 
        => interviewRequestRepository.GetManyByInterviewerIdAsync(interviewerId);

    public Task<IReadOnlyList<InterviewRequest>> GetInterviewRequestsByInterviewAsync(Guid interviewId) 
        => interviewRequestRepository.GetManyByInterviewIdAsync(interviewId);

    public Task<IReadOnlyList<Interview>> GetUserInterviewsAsync(Guid userId) 
        => interviewsRepository.GetManyByCreatorIdAsync(userId);

    public async Task<bool> TryChangeInterviewRequestStatusAsync(Guid interviewRequestId, InterviewRequestStatus newStatus,
        string message)
    {
        var interviewRequest = await interviewRequestRepository.FindAsync(interviewRequestId);

        if (interviewRequest == null)
            return false;

        if (newStatus == InterviewRequestStatus.Approved)
        {
            if (!interviewRequest.Interview.Use())
                return false;
            await interviewsRepository.UpdateAsync(interviewRequest.Interview);
        }

        interviewRequest.ChangeStatus(InterviewRequestStatus.Approved, message);
        await interviewRequestRepository.UpdateAsync(interviewRequest);

        return true;
    }
}
