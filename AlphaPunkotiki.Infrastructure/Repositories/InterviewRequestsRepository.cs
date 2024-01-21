using AlphaPunkotiki.Domain.Entities;
using AlphaPunkotiki.Infrastructure.Database.Interfaces;
using AlphaPunkotiki.Infrastructure.Repositories.Base;
using AlphaPunkotiki.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlphaPunkotiki.Infrastructure.Repositories;

public class InterviewRequestsRepository(IAppDbContext context)
    : RepositoryBase<InterviewRequest>(context), IInterviewRequestsRepository
{
    public async Task<IReadOnlyList<InterviewRequest>> GetManyByCandidateIdAsync(Guid candidateId) 
        => await DbContext.Set<InterviewRequest>().Where(x => x.CandidateId == candidateId).ToListAsync();

    public async Task<IReadOnlyList<InterviewRequest>> GetManyByInterviewIdAsync(Guid interviewId) 
        => await DbContext.Set<InterviewRequest>().Where(x => x.InterviewId == interviewId).ToListAsync();

    public async Task<IReadOnlyList<InterviewRequest>> GetManyByInterviewerIdAsync(Guid interviewerId)
    {
        var interviews = DbContext.Set<Interview>();

        return await DbContext.Set<InterviewRequest>()
            .Where(x => interviews.Find(x.InterviewId)!.CreatorId == interviewerId).ToListAsync();
    }
}
