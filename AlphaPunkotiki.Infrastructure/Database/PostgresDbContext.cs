﻿using Microsoft.EntityFrameworkCore;
using AlphaPunkotiki.Domain.Entities;
using AlphaPunkotiki.Domain.Entities.Interfaces;
using AlphaPunkotiki.Infrastructure.Database.Interfaces;
using AlphaPunkotiki.Domain.Enums;

namespace AlphaPunkotiki.Infrastructure.Database;

public sealed class PostgresDbContext : DbContext, IAppDbContext
{
    public PostgresDbContext(DbContextOptions<PostgresDbContext> options)
        : base(options)
    {
        //Database.EnsureDeleted();
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<InterviewRequestStatus>();
        modelBuilder.HasPostgresEnum<QuestionType>();
    }
}