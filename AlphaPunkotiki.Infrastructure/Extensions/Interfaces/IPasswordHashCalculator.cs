namespace AlphaPunkotiki.Infrastructure.Extensions.Interfaces;

public interface IPasswordHashCalculator
{
    string Calculate(string password);
}
