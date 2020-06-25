using Domain.Characters.Models;
using Domain.Users.Models;
using GTANetworkAPI;
using Helper.Common;
using Newtonsoft.Json;
using RomaniaRoleplay.Models.CharacterSelection;
using RomaniaRoleplay.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RomaniaRoleplay.Controllers
{
    public partial class RomaniaRoleplayController : Script
    {
        [RemoteEvent("OnUserLoginAttempt")]
        public void OnUserLoginAttempt(Player player, string loginViewModel)
        {
            LoginViewModel loginModel = JsonConvert.DeserializeObject<LoginViewModel>(loginViewModel);

            var encryptedPass = EncryptHelper.ComputeSha512Hash(loginModel.Password);
            List<CharacterViewModel> charactersList = null;

            var user = _usersWorker.GetUserByUsernameAndPassword(loginModel.Username, encryptedPass);
            if (user != null)
            {
                SetUserDetailsOnSignIn(player, user);
                charactersList = GetCharactersByDbPlayerId(user.Id);
            }
            NAPI.Entity.SetEntityTransparency(player, 255);
            player.TriggerEvent("onUserLoginResponse", user, charactersList);

        }

        private void SetUserDetailsOnSignIn(Player player, User user)
        {
            user.LastActiveDate = DateTime.UtcNow;
            PlayerSignedIn?.Invoke(player, user);

            var character = _realtimeHelper.OnlinePlayersCharacter.FirstOrDefault(x => x.Key == user.Id).Value;
            PlayerInfoUpdate?.Invoke(user, character);
        }

        private void UpdateUser(User user, Character character)
        {
            _usersWorker.Update(user);
            _charactersWorker.Update(character);
        }

    }
}
