using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookShop.Data
{
    public class BookShopContext: IdentityDbContext<ApplicationUser>
    {
        IConfiguration configuration;
        public BookShopContext(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public DbSet<Category>  categories{ get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<Auther> authers { get; set; }
        public DbSet<VistorRate> vistorRates { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<UserShop> userShops { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DbConnectionString"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
