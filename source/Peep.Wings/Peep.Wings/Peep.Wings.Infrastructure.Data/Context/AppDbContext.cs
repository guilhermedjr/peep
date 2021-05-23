using System;
using System.Collections.Generic;
using System.Text;
using Peep.Wings.Domain.Entities;
using Peep.Wings.Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Peep.Wings.Infrastructure.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);
        }
    }
}
