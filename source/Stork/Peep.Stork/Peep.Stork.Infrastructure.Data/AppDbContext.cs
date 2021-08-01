using System;
using Microsoft.EntityFrameworkCore;
using Peep.Stork.Domain.Entities;

namespace Peep.Stork.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<DirectMessage> DirectMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<DirectMessage>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<DirectMessage>().HasOne(m => m.Sender).WithMany().HasForeignKey(u => u.SenderId);
            modelBuilder.Entity<DirectMessage>().HasOne(m => m.Receiver).WithMany().HasForeignKey(u => u.ReceiverId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
