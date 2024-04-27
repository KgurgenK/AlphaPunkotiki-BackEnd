using AlphaPunkotiki.Domain.Entities.Base;

namespace AlphaPunkotiki.Domain.Entities;

public class SuperUser : User
{
    protected SuperUser() { }

    public SuperUser(string name, string email, string? phoneNumber) : base(name, email, phoneNumber) { }
}
