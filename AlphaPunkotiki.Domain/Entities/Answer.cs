using AlphaPunkotiki.Domain.Entities.Base;

namespace AlphaPunkotiki.Domain.Entities;

public class Answer : Entity
{
    public Guid UserId { get; private set; }

    public virtual Question Question { get; private set; }

    public string[]? Values { get; private set; }

#pragma warning disable CS8618
    protected Answer() { }
#pragma warning restore CS8618

    public Answer(Guid userId, Question question, string[]? values)
    {
        UserId = userId;
        Question = question;
        Values = values;
    }
}
