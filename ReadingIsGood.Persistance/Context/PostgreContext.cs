using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ReadingIsGood.Domain.Entities;




namespace ReadingIsGood.Persistance.Context
{
    public class PostgreContext:DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Statistics> Statistics { get; set; }
        public DbSet<Order> Orders { get; set; }
        public PostgreContext(DbContextOptions<PostgreContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
