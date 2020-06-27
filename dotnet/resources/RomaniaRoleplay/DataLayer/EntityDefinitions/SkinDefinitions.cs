using Domain.Characters.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.EntityDefinitions
{
    internal static class SkinDefinitions
    {
        public static void Set(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skin>().HasKey(p => p.Id);
            modelBuilder.Entity<Skin>().Property(p => p.Model).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.FirstHeadShape).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.SecondHeadShape).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.FirstSkinTone).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.SecondSkinTone).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.HeadMix).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.SkinMix).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.Hair).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.FirstHairColor).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.SecondHairColor).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.Beard).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.BeardColor).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.Chest).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.ChestColor).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.Blemishes).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.Ageing).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.Complexion).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.Sundamage).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.Freckles).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.EyesColor).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.Eyebrows).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.EyebrowsColor).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.Makeup).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.Blush).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.BlushColor).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.Lipstick).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.LipstickColor).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.NoseWidth).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.NoseHeight).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.NoseBridge).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.NoseTip).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.NoseShift).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.BrowHeight).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.BrowWidth).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.CheekboneHeight).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.CheekboneWidth).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.CheeksWidth).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.Eyes).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.Lips).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.JawWidth).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.JawHeight).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.ChinLength).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.ChinPosition).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.ChinWidth).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.ChinShape).IsRequired();
            modelBuilder.Entity<Skin>().Property(p => p.NeckWidth).IsRequired();
            modelBuilder.Entity<Skin>().OwnsOne(p => p.Clothes,
                g =>
                {
                    g.Property(p => p.Torsos).IsRequired();
                    g.Property(p => p.Legs).IsRequired();
                    g.Property(p => p.BagsAndParachutes).IsRequired();
                    g.Property(p => p.Shoes).IsRequired();
                    g.Property(p => p.Accessories).IsRequired();
                    g.Property(p => p.Undershirts).IsRequired();
                    g.Property(p => p.BodyArmors).IsRequired();
                    g.Property(p => p.Decals).IsRequired();
                    g.Property(p => p.Tops).IsRequired();
                });
        }
    }
}
