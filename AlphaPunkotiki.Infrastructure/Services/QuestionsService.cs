using AlphaPunkotiki.Infrastructure.Repositories.Interfaces;
using AlphaPunkotiki.Infrastructure.Services.Interfaces;

namespace AlphaPunkotiki.Infrastructure.Services;

public class QuestionsService(IAnswersRepository answersRepository) : IQuestionsService
{
    public async Task<IReadOnlyDictionary<string, (int, float)>> GetStatisticsOfQuestion(Guid questionId)
    {
        var answers = await answersRepository.GetManyByQuestionIdAsync(questionId);
        var answersValues = answers.SelectMany(x => x.Values ?? []);
        var valuesCount = answersValues.Count();
        var result = new Dictionary<string, int>();

        foreach (var answersValue in answersValues)
            result[answersValue] = result.TryGetValue(answersValue, out var value) ? value + 1 : 1;

        return result.ToDictionary(x => x.Key, x => (x.Value, (float)x.Value / valuesCount));
    }
}
