using AlphaPunkotiki.Domain.Base;

namespace AlphaPunkotiki.Domain.Entities;

public class Question(Guid surveyId, int type, string name, string? tooltip, string[] variables, bool isRequired)
    : Entity
{
    public Guid SurveyId { get; private set; } = surveyId;

    public int Type { get; private set; } = type;

    public string Name { get; private set; } = name;

    public string? Tooltip { get; private set; } = tooltip;

    public string[] Variables { get; private set; } = variables;

    public bool IsRequired { get; private set; } = isRequired;
}