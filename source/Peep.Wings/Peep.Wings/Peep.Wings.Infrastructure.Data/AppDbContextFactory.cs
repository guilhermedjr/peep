using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Peep.Wings.Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        /*private readonly IConfiguration _config;

        public AppDbContextFactory(IConfiguration config)
        {
            this._config = config;
        }*/


        public AppDbContext CreateDbContext(string[] args)
        {
            //string mySqlConnection = _config.GetConnectionString("DefaultConnection");
            string mySqlConnection = "server=localhost; port=3306; database=peepwingsdb; user=root; password=root";

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySQL(mySqlConnection);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
