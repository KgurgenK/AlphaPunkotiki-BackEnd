using AlphaPunkotiki.Domain.Entities.Base;

namespace AlphaPunkotiki.Domain.Entities;

public class Survey : Offer
{
    protected Survey() { }

    public Survey(
        Guid creatorId,
        string name,
        string description,
        int price,
        bool isLimitedPublicationTime,
        DateTime? publicationTimeLimit,
        bool isLimitedUsages,
        int? usagesLimit,
        bool isLimitedCompletionTime,
        int? completionTimeLimit)
        : base(
            creatorId,
            name,
            description,
            price,
            isLimitedPublicationTime,
            publicationTimeLimit,
            isLimitedUsages,
            usagesLimit,
            isLimitedCompletionTime,
            completionTimeLimit) { }
}
