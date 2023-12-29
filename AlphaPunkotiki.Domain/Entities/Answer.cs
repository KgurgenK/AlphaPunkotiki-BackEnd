using AlphaPunkotiki.Domain.Base;

namespace AlphaPunkotiki.Domain.Entities;

public class Answer(Guid userId, Guid questionId, string[] values) : Entity
{
    public Guid UserId { get; private set; } = userId;

    public Guid QuestionId { get; private set; } = questionId;

    public string[]? Values { get; private set; } = values;
}
