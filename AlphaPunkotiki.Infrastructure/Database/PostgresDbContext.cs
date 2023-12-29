using Microsoft.EntityFrameworkCore;
using AlphaPunkotiki.Domain.Interfaces;
using AlphaPunkotiki.Domain.Entities;
using AlphaPunkotiki.Infrastructure.Interfaces;

namespace AlphaPunkotiki.Infrastructure.Database;

public sealed class PostgresDbContext : DbContext, IAppDbContext
{
    public PostgresDbContext(DbContextOptions<PostgresDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Survey> Surveys { get; set; } = default!;

    public DbSet<Interview> Interviews { get; set; } = default!;

    public DbSet<Question> Questions { get; set; } = default!;

    public DbSet<Answer> Answers { get; set; } = default!;

    public DbSet<InterviewRequest> InterviewRequests { get; set; } = default!;

    public new DbSet<T> Set<T>()
        where T : class, IAggregationRoot
        => base.Set<T>();

    public async Task<int> SaveChangesAsync()
        => await base.SaveChangesAsync().ConfigureAwait(false);
}