using System;

namespace Domain.Characters.Models
{
    public class Character : IEquatable<Character>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string NameTag { get; set; }
        public int Level { get; set; }
        public int SkinId { get; set; }
        public Skin Skin { get; set; }
        public long Money { get; set; }
        public long BankMoney { get; set; }
        public DateTime LastActiveDate { get; set; }
        public double TimePlayed { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Character);
        }

        public bool Equals(Character other)
        {
            return other != null &&
                   Id == other.Id &&
                   UserId == other.UserId &&
                   Name == other.Name &&
                   NameTag == other.NameTag &&
                   Level == other.Level &&
                   SkinId == other.SkinId &&
                   Money == other.Money &&
                   BankMoney == other.BankMoney &&
                   LastActiveDate == other.LastActiveDate &&
                   TimePlayed == other.TimePlayed;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(UserId);
            hash.Add(Name);
            hash.Add(NameTag);
            hash.Add(Level);
            hash.Add(SkinId);
            hash.Add(Money);
            hash.Add(BankMoney);
            hash.Add(LastActiveDate);
            hash.Add(TimePlayed);
            return hash.ToHashCode();
        }
    }
}
