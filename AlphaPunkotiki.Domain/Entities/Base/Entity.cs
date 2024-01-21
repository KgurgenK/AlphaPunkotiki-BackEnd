using AlphaPunkotiki.Domain.Entities.Interfaces;

namespace AlphaPunkotiki.Domain.Entities.Base;

public abstract class Entity : IAggregationRoot
{
    public Guid Id { get; private set; } = Guid.NewGuid();
}