using AlphaPunkotiki.Domain.Entities;
using AlphaPunkotiki.Infrastructure.Database.Interfaces;
using AlphaPunkotiki.Infrastructure.Repositories.Base;
using AlphaPunkotiki.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlphaPunkotiki.Infrastructure.Repositories;

public class QuestionsRepository(IAppDbContext context)
    : RepositoryBase<Question>(context), IQuestionsRepository
{
    public async Task AddRangeAsync(ICollection<Question> entities)
    {
        await DbContext.Set<Question>().AddRangeAsync(entities);

        await DbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<Question>> GetManyBySurveyIdAsync(Guid surveyId) 
        => await DbContext.Set<Question>().Where(x => x.SurveyId == surveyId).ToListAsync();
}
