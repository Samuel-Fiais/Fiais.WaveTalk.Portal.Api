using Fiais.WaveTalk.Portal.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Fiais.WaveTalk.Portal.Infra.Data.Context;

public sealed class ContextDatabase : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<ChatRoom> ChatRooms { get; set; }
    public DbSet<Message> Messages { get; set; }
    
    public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored));

        new ContextDatabaseFactory().CreateDbContext();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextDatabase).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}