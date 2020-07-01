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
            modelBuilder.Entity<Character>().HasOne(p => p.Skin).WithMany().HasForeignKey(p => p.SkinId).OnDelete(DeleteBehavior.Cascade).IsRequired();
            modelBuilder.Entity<Character>().Property(p => p.Money).IsRequired();
            modelBuilder.Entity<Character>().Property(p => p.BankMoney).IsRequired();
            modelBuilder.Entity<Character>().Property(p => p.AdminLevel).IsRequired();
            modelBuilder.Entity<Character>().Property(p => p.TesterLevel).IsRequired();
            modelBuilder.Entity<Character>().Property(p => p.TimePlayed).IsRequired();
            modelBuilder.Entity<Character>().Property(p => p.LastActiveDate).IsRequired().HasColumnType("datetime");
            modelBuilder.Entity<Character>().OwnsOne(p => p.Mute,
                g =>
                {
                    g.Property(p => p.IsMuted).IsRequired();
                    g.Property(p => p.ExpirationTime).IsRequired();
                    g.Property(p => p.Reason).IsRequired();
                });
        }
    }
}
