using AlphaPunkotiki.Domain.Entities.Base;

namespace AlphaPunkotiki.Domain.Entities;

public class Account : Entity
{
    public virtual User User { get; private set; }

    public string Login { get; private set; }

    public string PasswordHash { get; private set; }

#pragma warning disable CS8618
    protected Account() { }
#pragma warning restore CS8618

    public Account(User user, string login, string passwordHash)
    {
        User = user;
        Login = login;
        PasswordHash = passwordHash;
    }
}
