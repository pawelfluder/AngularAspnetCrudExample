using Microsoft.EntityFrameworkCore;

namespace AspNetWebApi.Data
{
    public class FullStackDbContext : DbContext
    {
        public FullStackDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
