using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class HotellierContext : DbContext
{
    public DbSet<UserSession> Sessions { get; set; }

    public HotellierContext(DbContextOptions<HotellierContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();
    }
}