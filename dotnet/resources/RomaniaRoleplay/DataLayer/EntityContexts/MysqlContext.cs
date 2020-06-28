using DataLayer.EntityDefinitions;
using Domain.Characters.Models;
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
        public DbSet<Character> Characters { get; set; }
        public DbSet<Skin> Skins { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UserDefinitions.Set(modelBuilder);
            SkinDefinitions.Set(modelBuilder);
            CharacterDefinitions.Set(modelBuilder);
        }
    }
}
