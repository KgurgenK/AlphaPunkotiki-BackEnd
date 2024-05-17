namespace AlphaPunkotiki.Infrastructure.Options;

public record PasswordsSaltOptions
{
    public required string Value { get; init; }
}
