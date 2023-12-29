using AlphaPunkotiki.Domain.Interfaces;

namespace AlphaPunkotiki.Domain.Base;

public abstract class Entity : IAggregationRoot
{
    public Guid Id { get; private set; } = Guid.NewGuid();
}