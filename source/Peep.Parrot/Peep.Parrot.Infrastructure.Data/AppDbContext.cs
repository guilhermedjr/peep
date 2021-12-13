using Microsoft.EntityFrameworkCore;
using Peep.Parrot.Domain.Entities;

namespace Peep.Parrot.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<ApplicationUser> User { get; set; }
    public DbSet<Domain.Entities.Peep> Peep { get; set; }
    public DbSet<Followship> Followship { get; set; }
    public DbSet<Mute> Mute { get; set; }
    public DbSet<Block> Block { get; set; }

    /*protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        builder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>()
            .HaveColumnType("date");
    }*/

    protected override void OnModelCreating(ModelBuilder builder)
    {
        /*builder.Entity<ApplicationUser>()
            .HasKey(u => u.Id);

        builder.Entity<ApplicationUser>()
            .HasMany(u => u.Peeps)
            .WithOne(p => p.User);

        builder.Entity<Followship>()
            .HasKey(fs => new { fs.FollowerId, fs.FollowedId });

        builder.Entity<Followship>()
            .HasOne(fs => fs.Follower)
            .WithMany(u => u.Followships)
            .HasForeignKey(fs => fs.FollowerId);

        builder.Entity<Mute>()
            .HasKey(m => new { m.MuterId, m.MutedId });

        builder.Entity<Mute>()
            .HasOne(m => m.Muter)
            .WithMany(u => u.Mutes)
            .HasForeignKey(m => m.MuterId);

        builder.Entity<Block>()
            .HasKey(b => new { b.BlockerId, b.BlockedId });

        builder.Entity<Block>()
            .HasOne(b => b.Blocker)
            .WithMany(u => u.Blocks)
            .HasForeignKey(b => b.BlockerId);

        builder.Entity<Domain.Entities.Peep>()
            .Property(p => p.Description)
                .HasMaxLength(280); */    
    }
}

