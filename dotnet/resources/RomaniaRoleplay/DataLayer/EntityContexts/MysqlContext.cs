using DataLayer.EntityDefinitions;
using Domain.Common.Constants;
using Domain.Users.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.EntityContexts
{
    public class MysqlContext : DbContext
    {
        public MysqlContext() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseMySql(ConnectionStrings.MysqlConnectionDatabase);
            }

            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UserDefinitions.Set(modelBuilder);
        }
    }
}
