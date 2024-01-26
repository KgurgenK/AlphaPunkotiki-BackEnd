using AlphaPunkotiki.Domain.Entities;
using AlphaPunkotiki.Infrastructure.Database.Interfaces;
using AlphaPunkotiki.Infrastructure.Repositories.Base;
using AlphaPunkotiki.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlphaPunkotiki.Infrastructure.Repositories;

public class InterviewRequestsRepository(IAppDbContext context)
    : RepositoryBase<InterviewRequest>(context), IInterviewRequestsRepository
{
    public Task<IReadOnlyList<InterviewRequest>> GetManyByCandidateIdAsync(Guid candidateId) 
        => GetManyAsync(x => x.CandidateId == candidateId);

    public Task<IReadOnlyList<InterviewRequest>> GetManyByInterviewIdAsync(Guid interviewId) 
        => GetManyAsync(x => x.Interview.Id == interviewId);

    public Task<IReadOnlyList<InterviewRequest>> GetManyByInterviewerIdAsync(Guid interviewerId) 
        => GetManyAsync(x => x.Interview.CreatorId == interviewerId);
}
