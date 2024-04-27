using AlphaPunkotiki.Domain.Entities.Base;

namespace AlphaPunkotiki.Domain.Entities;

public class Respondent : User
{
    public Passport? Passport { get; private set; }

    protected Respondent() { }

    public Respondent(string name, string email, string? phoneNumber, Passport? passport)
        : base(name, email, phoneNumber)
    {
        Passport = passport;
    }
}
