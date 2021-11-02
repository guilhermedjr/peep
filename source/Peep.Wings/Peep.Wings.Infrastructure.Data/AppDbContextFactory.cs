using Microsoft.EntityFrameworkCore.Design;

namespace Peep.Wings.Infrastructure.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    { 
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql("Server=localhost;Port=4001;Uid=root;Pwd=root;Database=peepwingsdb");

        return new AppDbContext(optionsBuilder.Options);
    }
}

