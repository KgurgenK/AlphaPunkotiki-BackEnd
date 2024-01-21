using AlphaPunkotiki.Domain.Entities;

namespace AlphaPunkotiki.Infrastructure.Repositories.Interfaces;

public interface IInterviewRequestsRepository : IRepository<InterviewRequest>
{
    Task<IReadOnlyList<InterviewRequest>> GetManyByCandidateIdAsync(Guid candidateId);

    Task<IReadOnlyList<InterviewRequest>> GetManyByInterviewIdAsync(Guid interviewId);

    Task<IReadOnlyList<InterviewRequest>> GetManyByInterviewerIdAsync(Guid interviewerId);
}
