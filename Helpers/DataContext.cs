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