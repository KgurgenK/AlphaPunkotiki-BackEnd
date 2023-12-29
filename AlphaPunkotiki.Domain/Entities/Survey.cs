using AlphaPunkotiki.Domain.Base;

namespace AlphaPunkotiki.Domain.Entities;

public class Survey(
    Guid creatorId,
    string name,
    string description,
    int price,
    bool isLimitedPublicationTime,
    DateTime? publicationTimeLimit,
    bool isLimitedUsages,
    int? usagesLimit,
    bool isLimitedCompletionTime,
    DateTime? completionTimeLimit)
    : Offer(
        creatorId,
        name,
        description,
        price,
        isLimitedPublicationTime,
        publicationTimeLimit,
        isLimitedUsages,
        usagesLimit,
        isLimitedCompletionTime,
        completionTimeLimit);
