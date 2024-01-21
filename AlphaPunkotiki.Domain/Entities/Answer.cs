using AlphaPunkotiki.Domain.Entities.Base;

namespace AlphaPunkotiki.Domain.Entities;

public class Answer : Entity
{
    public Guid UserId { get; }

    public Guid QuestionId { get; }

    public string[]? Values { get; }

    protected Answer() { }

    public Answer(Guid userId, Guid questionId, string[]? values)
    {
        UserId = userId;
        QuestionId = questionId;
        Values = values;
    }
}
