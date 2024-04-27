using AlphaPunkotiki.Domain.Entities.Base;

namespace AlphaPunkotiki.Domain.Entities;

public class Interviewer : User
{
    public string? Description { get; private set; }

    protected Interviewer() { }

    public Interviewer(string name, string email, string? phoneNumber, string? description)
        : base(name, email, phoneNumber)
    {
        Description = description;
    }
}
