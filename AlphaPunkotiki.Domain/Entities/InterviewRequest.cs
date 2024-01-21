using AlphaPunkotiki.Domain.Entities.Base;
using AlphaPunkotiki.Domain.Enums;

namespace AlphaPunkotiki.Domain.Entities;

public class InterviewRequest : Entity
{
    public Guid InterviewId { get; }

    public Guid CandidateId { get; }

    public InterviewRequestStatus Status { get; private set; }

    public string? Message { get; private set; }

    protected InterviewRequest() { }

    public InterviewRequest(Guid interviewId, Guid candidateId)
    {
        InterviewId = interviewId;
        CandidateId = candidateId;
        Status = InterviewRequestStatus.InProcess;
        Message = default;
    }

    public void ChangeStatus(InterviewRequestStatus newStatus, string? message)
    {
        if (Status == newStatus) return;

        Status = newStatus;
        Message = message;
    }
}
