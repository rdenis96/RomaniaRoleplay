using Domain.Characters.Models;

namespace RomaniaRoleplay.Models.CharacterSelection
{
    public class CharacterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public long Money { get; set; }
        public long BankMoney { get; set; }
        public Skin Skin { get; set; }
    }
}
