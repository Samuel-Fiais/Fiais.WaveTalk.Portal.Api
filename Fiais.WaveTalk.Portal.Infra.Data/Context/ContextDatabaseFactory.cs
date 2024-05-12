using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Fiais.WaveTalk.Portal.Infra.Data.Context;

public sealed class ContextDatabaseFactory : IDesignTimeDbContextFactory<ContextDatabase>
{
    public ContextDatabase CreateDbContext()
    {
        string[] args = { "" };
        return CreateDbContext(args);
    }

    public ContextDatabase CreateDbContext(string[] args)
    {
        var connection = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? string.Empty;

        var optionsBuilder = new DbContextOptionsBuilder<ContextDatabase>();

        optionsBuilder.UseSqlServer(connection)
            .EnableSensitiveDataLogging(false)
            .EnableDetailedErrors(false);

        return new ContextDatabase(optionsBuilder.Options);
    }
}
