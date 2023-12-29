using AlphaPunkotiki.Domain.Base;

namespace AlphaPunkotiki.Domain.Entities;

public class InterviewRequest(Guid surveyId, Guid candidateId, string? message) : Entity
{
    public Guid SurveyId { get; private set; } = surveyId;

    public Guid CandidateId { get; private set; } = candidateId;

    public int Status { get; private set; } = 0;

    public string? Message { get; private set; } = message;
}
