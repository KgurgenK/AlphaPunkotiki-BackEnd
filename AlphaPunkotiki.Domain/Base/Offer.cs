namespace AlphaPunkotiki.Domain.Base;

public abstract class Offer(
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
    : Entity
{
    public Guid CreatorId { get; private set; } = creatorId;

    public string Name { get; private set; } = name;

    public string Description { get; private set; } = description;

    public int Price { get; private set; } = price;

    public bool IsLimitedPublicationTime { get; private set; } = isLimitedPublicationTime;

    public DateTime? PublicationTimeLimit { get; private set; } = publicationTimeLimit;

    public bool IsLimitedUsages { get; private set; } = isLimitedUsages;

    public int? UsagesLimit { get; private set; } = usagesLimit;

    public int Usages { get; private set; } = 0;

    public bool IsLimitedCompletionTime { get; private set; } = isLimitedCompletionTime;

    public DateTime? CompletionTimeLimit { get; private set; } = completionTimeLimit;

    public bool IsAvailable { get; private set; } = true;
}
