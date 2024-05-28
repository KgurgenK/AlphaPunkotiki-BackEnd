using AlphaPunkotiki.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlphaPunkotiki.Infrastructure.Database.Configurations;

public class AccountEntityConfiguration : IEntityTypeConfiguration<Account>
{
    private const string UserId = nameof(Account.User) + nameof(User.Id);

    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder
            .HasIndex(account => account.Login)
            .IsUnique();

        builder
            .HasIndex(UserId)
            .IsUnique();
    }
}