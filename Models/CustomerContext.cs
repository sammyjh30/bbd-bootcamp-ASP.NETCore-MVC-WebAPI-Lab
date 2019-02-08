using Microsoft.EntityFrameworkCore;
// using CustomerApi.Models;

namespace CustomerApi.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options)
        {
        }

        public DbSet<CustomerItem> CustomerItems { get; set; }

    }
}