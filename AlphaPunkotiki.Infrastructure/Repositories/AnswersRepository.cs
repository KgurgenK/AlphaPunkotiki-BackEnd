using AlphaPunkotiki.Domain.Entities;
using AlphaPunkotiki.Infrastructure.Database.Interfaces;
using AlphaPunkotiki.Infrastructure.Repositories.Base;
using AlphaPunkotiki.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlphaPunkotiki.Infrastructure.Repositories;

public class AnswersRepository(IAppDbContext context) 
    : RepositoryBase<Answer>(context), IAnswersRepository
{
    public async Task AddRangeAsync(ICollection<Answer> entities)
    {
        await DbContext.Set<Answer>().AddRangeAsync(entities);

        await DbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<Answer>> GetManyBySurveyIdAsync(Guid surveyId)
    {
        var questions = DbContext.Set<Question>();

        return await DbContext.Set<Answer>().Where(x => questions.Find(x.QuestionId)!.SurveyId == surveyId)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Answer>> GetManyByQuestionIdAsync(Guid questionId) 
        => await DbContext.Set<Answer>().Where(x => x.QuestionId == questionId).ToListAsync();
}

