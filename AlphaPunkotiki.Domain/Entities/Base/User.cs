namespace AlphaPunkotiki.Domain.Entities.Base;

public abstract class User : Entity
{
    public string Name { get; private set; }

    public string Email { get; private set; }

    public string? PhoneNumber { get; private set; }

#pragma warning disable CS8618
    protected User() { }
#pragma warning restore CS8618

    protected User(string name, string email, string? phoneNumber)
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
    }
}
