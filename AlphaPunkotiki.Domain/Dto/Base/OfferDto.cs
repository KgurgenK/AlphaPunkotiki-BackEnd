namespace AlphaPunkotiki.Domain.Dto.Base;

public abstract record OfferDto
{
    public Guid CreatorId { get; init; }

#pragma warning disable CS8618
    public string Name { get; init; }

    public string Description { get; init; }
#pragma warning restore CS8618

    public int Price { get; init; }

    public bool IsLimitedPublicationTime { get; init; }

    public DateTime? PublicationTimeLimit { get; init; }

    public bool IsLimitedUsages { get; init; }

    public int? UsagesLimit { get; init; }

    public bool IsLimitedCompletionTime { get; init; }

    public DateTime? CompletionTimeLimit { get; init; }
}
