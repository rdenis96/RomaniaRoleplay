using Domain.Characters.Models;
using Domain.Users.Models;
using GTANetworkAPI;
using Newtonsoft.Json;
using RomaniaRoleplay.Constants;
using RomaniaRoleplay.Helpers;
using RomaniaRoleplay.Models.CharacterCreation;
using RomaniaRoleplay.Models.CharacterSelection;
using System.Collections.Generic;

namespace RomaniaRoleplay.Controllers
{
    public partial class RomaniaRoleplayController : Script
    {
        public List<CharacterViewModel> GetCharactersByDbPlayerId(int userId)
        {
            var characters = GenerateCharacterListForUser(userId);
            return characters;
        }

        [RemoteEvent("OnCreateCharacter")]
        public void CreateCharacter(Player player, string characterJson)
        {
            CharacterCreateViewModel characterCreateViewModel = JsonConvert.DeserializeObject<CharacterCreateViewModel>(characterJson);
            var canGetUser = _realtimeHelper.OnlinePlayersAccount.TryGetValue(player.Id, out User userToUpdate);
            if (canGetUser)
            {
                var character = _charactersWorker.Create(userToUpdate.Id, characterCreateViewModel.Name, characterCreateViewModel.Skin);
                player.TriggerEvent("onCharacterFinishCreate", character);
            }
        }

        [RemoteEvent("OnCharacterSelect")]
        public void CharacterSelect(Player player, int characterId)
        {
            Character character = _charactersWorker.GetById(characterId);
            PlayerSelectedCharacter?.Invoke(player, character);
        }

        private List<CharacterViewModel> GenerateCharacterListForUser(int userId)
        {
            var characters = _charactersWorker.GetAllByUserId(userId);
            if (characters != null)
            {
                List<CharacterViewModel> characterViewModels = new List<CharacterViewModel>();
                characters.ForEach(character => characterViewModels.Add(new CharacterViewModel
                {
                    Id = character.Id,
                    Money = character.Money,
                    BankMoney = character.BankMoney,
                    Level = character.Level,
                    Name = character.Name,
                    Skin = character.Skin
                }));
                return characterViewModels;
            }
            return new List<CharacterViewModel>();
        }

        private void SetPlayerCharacter(Player player, Character character)
        {
            ClientCharacterHelper.SetPlayerCharacter(player, character);
            NAPI.Player.SpawnPlayer(player, new Vector3(-1036.755, -2737.948, 20.2772)); //spawn aeroport for the moment
            player.Dimension = 0;
            player.TriggerEvent("onPlayerCharacterSet", character);
        }

        [Command(Commands.SwitchCharacter, Alias = Commands.SwitchCharacterAlias)]
        public void SwitchCharacter(Player player)
        {
            var user = _realtimeHelper.OnlinePlayersAccount.GetValueOrDefault(player.Id);
            var charactersList = GetCharactersByDbPlayerId(user.Id);
            player.Dimension = (uint)(player.Id + 1);
            player.TriggerEvent("onUserSwitchCharacters", user, charactersList);
        }
    }
}
