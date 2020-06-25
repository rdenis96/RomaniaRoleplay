using Domain.Characters.Models;
using System;

namespace Helper.Characters
{
    public static class CharactersHelper
    {
        public static Character GenerateDefaultCharacter(string name, int skinId)
        {
            var character = new Character
            {
                Name = name,
                NameTag = name,
                BankMoney = 50000,
                Money = 10000,
                Level = 1,
                SkinId = skinId,
                LastActiveDate = DateTime.UtcNow
            };
            return character;
        }

    }
}

