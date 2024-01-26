using AlphaPunkotiki.Domain.Entities;
using AlphaPunkotiki.Infrastructure.Database.Interfaces;
using AlphaPunkotiki.Infrastructure.Repositories.Base;
using AlphaPunkotiki.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlphaPunkotiki.Infrastructure.Repositories;

public class QuestionsRepository(IAppDbContext context)
    : QaRepository<Question>(context), IQuestionsRepository
{
    public Task<IReadOnlyList<Question>> GetManyBySurveyIdAsync(Guid surveyId) 
        => GetManyAsync(x => x.Survey.Id == surveyId);
}
