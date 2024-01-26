using AlphaPunkotiki.Domain.Entities;
using AlphaPunkotiki.Infrastructure.Database.Interfaces;
using AlphaPunkotiki.Infrastructure.Repositories.Base;
using AlphaPunkotiki.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlphaPunkotiki.Infrastructure.Repositories;

public class AnswersRepository(IAppDbContext context) 
    : QaRepository<Answer>(context), IAnswersRepository
{
    public Task<IReadOnlyList<Answer>> GetManyBySurveyIdAsync(Guid surveyId) 
        => GetManyAsync(x => x.Question.Survey.Id == surveyId);

    public Task<IReadOnlyList<Answer>> GetManyByQuestionIdAsync(Guid questionId) 
        => GetManyAsync(x => x.Question.Id == questionId);
}
