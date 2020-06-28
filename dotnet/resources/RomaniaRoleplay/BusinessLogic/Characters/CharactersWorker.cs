using BusinessLogic.Users;
using DataLayer.Characters;
using Domain.Characters.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Characters
{
    public class CharactersWorker
    {
        private readonly ICharactersRepository _charactersRepository;
        private readonly SkinsWorker _skinsWorker;
        private readonly UsersWorker _usersWorker;
        public CharactersWorker()
        {
            _charactersRepository = new CharactersRepository();
            _skinsWorker = new SkinsWorker();
            _usersWorker = new UsersWorker();
        }

        public List<Character> GetAllByUserId(int userId)
        {
            if (userId < 0)
            {
                return null;
            }
            var result = _charactersRepository.GetAllByUserId(userId);
            return result;
        }

        public Character GetById(int id)
        {
            if (id < 0)
            {
                return null;
            }
            var result = _charactersRepository.GetById(id);
            return result;
        }

        public Character Create(int userId, string name, Skin skin)
        {
            var user = _usersWorker.GetById(userId);
            if (user != null)
            {
                var character = GenerateCharacter(userId, name, skin);
                if (character != null)
                {
                    character = _charactersRepository.Create(character);
                    return character;
                }
            }
            return null;
        }

        public bool Delete(Character character)
        {
            var result = _charactersRepository.Delete(character);
            return result;
        }

        public Character Update(Character character)
        {
            var result = _charactersRepository.Update(character);
            return result;
        }

        private Character GenerateCharacter(int userId, string name, Skin skin)
        {
            var createdSkin = _skinsWorker.Create(skin);
            if (createdSkin != null)
            {
                Character character = new Character
                {
                    UserId = userId,
                    Name = name,
                    NameTag = name,
                    Money = 50000,
                    BankMoney = 100000,
                    SkinId = createdSkin.Id,
                    Level = 1,
                    LastActiveDate = DateTime.MinValue,
                    TimePlayed = 0,
                };
                return character;
            }
            return null;
        }
    }
}
