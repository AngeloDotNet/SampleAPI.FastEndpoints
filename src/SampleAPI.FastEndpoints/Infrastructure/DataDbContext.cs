using Microsoft.EntityFrameworkCore;
using SampleAPI.FastEndpoints.Entity;

namespace SampleAPI.FastEndpoints.Infrastructure;

public partial class DataDbContext : DbContext
{
    public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
    {
    }

    public virtual DbSet<PersonEntity> People { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PersonEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
        });
    }
}