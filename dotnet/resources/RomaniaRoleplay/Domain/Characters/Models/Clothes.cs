using System;

namespace Domain.Characters.Models
{
    public class Clothes : IEquatable<Clothes>
    {
        public int Torsos { get; set; }
        public int Legs { get; set; }
        public int BagsAndParachutes { get; set; }
        public int Shoes { get; set; }
        public int Accessories { get; set; }
        public int Undershirts { get; set; }
        public int BodyArmors { get; set; }
        public int Decals { get; set; }
        public int Tops { get; set; }

        public int TorsosColor { get; set; }
        public int LegsColor { get; set; }
        public int BagsAndParachutesColor { get; set; }
        public int ShoesColor { get; set; }
        public int AccessoriesColor { get; set; }
        public int UndershirtsColor { get; set; }
        public int BodyArmorsColor { get; set; }
        public int DecalsColor { get; set; }
        public int TopsColor { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Clothes);
        }

        public bool Equals(Clothes other)
        {
            return other != null &&
                   Torsos == other.Torsos &&
                   Legs == other.Legs &&
                   BagsAndParachutes == other.BagsAndParachutes &&
                   Shoes == other.Shoes &&
                   Accessories == other.Accessories &&
                   Undershirts == other.Undershirts &&
                   BodyArmors == other.BodyArmors &&
                   Decals == other.Decals &&
                   Tops == other.Tops &&
                   TorsosColor == other.TorsosColor &&
                   LegsColor == other.LegsColor &&
                   BagsAndParachutesColor == other.BagsAndParachutesColor &&
                   ShoesColor == other.ShoesColor &&
                   AccessoriesColor == other.AccessoriesColor &&
                   UndershirtsColor == other.UndershirtsColor &&
                   BodyArmorsColor == other.BodyArmorsColor &&
                   DecalsColor == other.DecalsColor &&
                   TopsColor == other.TopsColor;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Torsos);
            hash.Add(Legs);
            hash.Add(BagsAndParachutes);
            hash.Add(Shoes);
            hash.Add(Accessories);
            hash.Add(Undershirts);
            hash.Add(BodyArmors);
            hash.Add(Decals);
            hash.Add(Tops);
            hash.Add(TorsosColor);
            hash.Add(LegsColor);
            hash.Add(BagsAndParachutesColor);
            hash.Add(ShoesColor);
            hash.Add(AccessoriesColor);
            hash.Add(UndershirtsColor);
            hash.Add(BodyArmorsColor);
            hash.Add(DecalsColor);
            hash.Add(TopsColor);
            return hash.ToHashCode();
        }
    }
}
