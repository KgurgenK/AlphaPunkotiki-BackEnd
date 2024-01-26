using AlphaPunkotiki.Domain.Entities.Base;
using AlphaPunkotiki.Domain.Enums;

namespace AlphaPunkotiki.Domain.Entities;

public class InterviewRequest : Entity
{
    public virtual Interview Interview { get; private set; }

    public Guid CandidateId { get; private set; }

    public InterviewRequestStatus Status { get; private set; }

    public string? Message { get; private set; }

#pragma warning disable CS8618
    protected InterviewRequest() { }
#pragma warning restore CS8618

    public InterviewRequest(Interview interview, Guid candidateId)
    {
        Interview = interview;
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
