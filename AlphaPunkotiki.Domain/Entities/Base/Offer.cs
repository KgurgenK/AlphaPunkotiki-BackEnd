namespace AlphaPunkotiki.Domain.Entities.Base;

public abstract class Offer : Entity
{
    public Guid CreatorId { get; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public int Price { get; private set; }

    public bool IsLimitedPublicationTime { get; }

    public DateTime? PublicationTimeLimit { get; }

    public bool IsLimitedUsages { get; }

    public int? UsagesLimit { get; }

    public int Usages { get; private set; }

    public bool IsLimitedCompletionTime { get; }

    public DateTime? CompletionTimeLimit { get; }

    public bool IsAvailable => (!IsLimitedPublicationTime || DateTime.Now < PublicationTimeLimit) &&
                               (!IsLimitedUsages || Usages < UsagesLimit);

#pragma warning disable CS8618
    protected Offer() { }
#pragma warning restore CS8618

    protected Offer(
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
    {
        CreatorId = creatorId;
        Name = name;
        Description = description;
        Price = price;
        IsLimitedPublicationTime = isLimitedPublicationTime;
        PublicationTimeLimit = publicationTimeLimit;
        IsLimitedUsages = isLimitedUsages;
        UsagesLimit = usagesLimit;
        Usages = 0;
        IsLimitedCompletionTime = isLimitedCompletionTime;
        CompletionTimeLimit = completionTimeLimit;
    }

    public bool Use()
    {
        if (!IsAvailable)
            return false;

        Usages++;

        return true;
    }

    public void ChangeProps(string name, string description, int price)
    {
        Name = name;
        Description = description;
        Price = price;
    }
}
