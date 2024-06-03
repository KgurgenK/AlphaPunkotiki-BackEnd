namespace AlphaPunkotiki.Domain.Entities.Base;

public abstract class Offer : Entity
{
    public Guid CreatorId { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public int Price { get; private set; }

    public bool IsLimitedPublicationTime { get; private set; }

    public DateTime? PublicationTimeLimit { get; private set; }

    public bool IsLimitedUsages { get; private set; }

    public int? UsagesLimit { get; private set; }

    public int Usages { get; private set; }

    public bool IsLimitedCompletionTime { get; private set; }

    public int? CompletionTimeLimit { get; private set; }

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
        int? completionTimeLimit)
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
