using AlphaPunkotiki.Domain.Entities.Base;
using AlphaPunkotiki.Domain.Enums;

namespace AlphaPunkotiki.Domain.Entities;

public class Question : Entity
{
    public Guid SurveyId { get; }

    public QuestionType Type { get; }

    public string Name { get; }

    public string? Tooltip { get; }

    public string[] Variables { get; }

    public bool IsRequired { get; }

#pragma warning disable CS8618
    protected Question() { }
#pragma warning restore CS8618

    public Question(Guid surveyId, QuestionType type, string name, string? tooltip, string[] variables,
        bool isRequired)
    {
        SurveyId = surveyId;
        Type = type;
        Name = name;
        Tooltip = tooltip;
        Variables = variables;
        IsRequired = isRequired;
    }
}
