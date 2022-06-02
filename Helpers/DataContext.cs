using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Entities;

namespace WebApi.Helpers
{

    public class DataContext : DbContext
    {
        public DbSet<User> Report_Users__ { get; set; }

        public DbSet<NOTIFICATION> NOTIFICATION { get; set; }

        public DbSet<NOTIFICATION_ORDER> NOTIFICATION_ORDER { get; set; }

        public DbSet<NOTIFICATION_TYPE> NOTIFICATION_TYPE { get; set; }
        public DbSet<BASE_PRODUCT> BASE_PRODUCT { get; set; }
        public DbSet<CUSTOMER> CUSTOMER { get; set; }

        public DbSet<STOCK> STOCK { get; set; }

        public DbSet<NOTIFICATION_ORDER_STOCK_HISTORY> NOTIFICATION_ORDER_STOCK_HISTORY { get; set; }

       //public DbSet<USER_> USER { get; set; }



//USER_

//NOTIFICATION_ORDER_STOCK_HISTORY

        private readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public void Context(DbContext context_)
        {
            context_.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("ConnString"));


            // in memory database used for simplicity, change to a real db for production applications
            // options.UseInMemoryDatabase("TestDb");

        }

    }
}