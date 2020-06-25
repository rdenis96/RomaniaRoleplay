using Domain.Characters.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.EntityDefinitions
{
    internal static class CharacterDefinitions
    {
        public static void Set(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().HasKey(p => p.Id);
            modelBuilder.Entity<Character>().Property(p => p.UserId).IsRequired();
            modelBuilder.Entity<Character>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Character>().Property(p => p.NameTag).IsRequired();
            modelBuilder.Entity<Character>().Property(p => p.Level).IsRequired();
            modelBuilder.Entity<Character>().HasOne(p => p.Skin).WithMany().HasForeignKey(p => p.SkinId).IsRequired();
            modelBuilder.Entity<Character>().Property(p => p.Money).IsRequired();
            modelBuilder.Entity<Character>().Property(p => p.BankMoney).IsRequired();
            modelBuilder.Entity<Character>().Property(p => p.LastActiveDate).IsRequired().HasColumnType("datetime");
        }
    }
}
