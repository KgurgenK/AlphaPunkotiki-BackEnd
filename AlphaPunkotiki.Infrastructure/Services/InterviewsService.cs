using AlphaPunkotiki.Domain.Dto;
using AlphaPunkotiki.Domain.Entities;
using AlphaPunkotiki.Domain.Enums;
using AlphaPunkotiki.Domain.Errors;
using AlphaPunkotiki.Domain.Errors.Base;
using AlphaPunkotiki.Infrastructure.Repositories.Interfaces;
using AlphaPunkotiki.Infrastructure.Services.Interfaces;
using Kontur.Results;

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

    public async Task<Result<UnavailableElementError>> TryCreateInterviewRequestAsync(Guid userId, Guid interviewId)
    {
        var interview = await interviewsRepository.FindAsync(interviewId);

        if (!interview!.IsAvailable)
            return new UnavailableElementError($"{nameof(interview)} with id '{interviewId}'");

        await interviewRequestRepository.AddAsync(new InterviewRequest(interview, userId));

        return Result.Succeed();
    }

    public async Task DeleteInterviewRequestAsync(Guid interviewRequestId)
    {
        var interviewRequest = await interviewRequestRepository.FindAsync(interviewRequestId);

        if (interviewRequest is not null)
            await interviewRequestRepository.DeleteAsync(interviewRequest);
    }

    public async Task<IReadOnlyList<Interview>> GetAllAvailableInterviewsAsync()
    {
        var surveys = await interviewsRepository.GetManyAsync();

        return await Task.Run(() => surveys.Where(x => x.IsAvailable).ToList());
    }

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

    public async Task<Result<Error>> TryChangeInterviewRequestStatusAsync(Guid interviewRequestId, InterviewRequestStatus newStatus,
        string message)
    {
        var interviewRequest = await interviewRequestRepository.FindAsync(interviewRequestId);

        if (interviewRequest == null)
            return new NotFoundError($"{nameof(interviewRequest)} with id '{interviewRequestId}' was not found.");

        if (newStatus == InterviewRequestStatus.Approved)
        {
            if (!interviewRequest.Interview.Use())
                return new UnavailableElementError(
                    $"{nameof(interviewRequest.Interview)} with id '{interviewRequest.Interview}' is not available.");
            await interviewsRepository.UpdateAsync(interviewRequest.Interview);
        }

        interviewRequest.ChangeStatus(InterviewRequestStatus.Approved, message);
        await interviewRequestRepository.UpdateAsync(interviewRequest);

        return Result.Succeed();
    }
}
