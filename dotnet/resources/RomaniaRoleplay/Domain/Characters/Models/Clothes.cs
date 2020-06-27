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
                   Tops == other.Tops;
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
            return hash.ToHashCode();
        }
    }
}
