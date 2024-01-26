using AlphaPunkotiki.Domain.Entities.Base;
using AlphaPunkotiki.Domain.Enums;

namespace AlphaPunkotiki.Domain.Entities;

public class Question : Entity
{
    public virtual Survey Survey { get; private set; }

    public QuestionType Type { get; private set; }

    public string Name { get; private set; }

    public string? Tooltip { get; private set; }

    public string[]? Variables { get; private set; }

    public bool IsRequired { get; private set; }

#pragma warning disable CS8618
    protected Question() { }
#pragma warning restore CS8618

    public Question(Survey survey, QuestionType type, string name, string? tooltip, string[]? variables,
        bool isRequired)
    {
        Survey = survey;
        Type = type;
        Name = name;
        Tooltip = tooltip;
        Variables = variables;
        IsRequired = isRequired;
    }
}
