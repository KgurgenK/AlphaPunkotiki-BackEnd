using AlphaPunkotiki.Domain.Entities.Base;
using AlphaPunkotiki.Domain.Enums;

namespace AlphaPunkotiki.Domain.Entities;

public class User : Entity
{
    public Role Role { get; set; }

    public string Name { get; private set; }

    public string Email { get; private set; }

    public string? PhoneNumber { get; private set; }

    public string? Description { get; private set; }

    public virtual Passport? Passport { get; private set; }

#pragma warning disable CS8618
    protected User() { }
#pragma warning restore CS8618

    public User(Role role, string name, string email, string? phoneNumber, string? description)
    {
        Role = role;
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        Description = description;
        Passport = default;
    }
}
