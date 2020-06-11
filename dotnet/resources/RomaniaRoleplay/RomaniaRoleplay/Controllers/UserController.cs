using Domain.Users.Models;
using GTANetworkAPI;
using Helper.Common;
using Newtonsoft.Json;
using RomaniaRoleplay.Models.Login;
using System;

namespace RomaniaRoleplay.Controllers
{
    public partial class RomaniaRoleplayController : Script
    {
        [RemoteEvent("OnUserLoginAttempt")]
        public void OnUserLoginAttempt(Player player, string loginViewModel)
        {
            LoginViewModel loginModel = JsonConvert.DeserializeObject<LoginViewModel>(loginViewModel);

            var encryptedPass = EncryptHelper.ComputeSha512Hash(loginModel.Password);

            var dbPlayer = _usersWorker.GetPlayerInfoByUsernameAndPassword(loginModel.Username, encryptedPass);
            if (dbPlayer != null)
            {
                SetUserDetailsOnSignIn(player, dbPlayer);
                _usersWorker.Update(dbPlayer);

                player.SetSkin(PedHash.Swat01SMY); //for testing, will be removed
                NAPI.Player.SpawnPlayer(player, new Vector3(-1036.755f, -2737.948f, 21.2772f));
            }
            player.TriggerEvent("onUserLoginResponse", dbPlayer);

        }
        private void SetUserDetailsOnSignIn(Player player, User user)
        {
            user.LastActiveDate = DateTime.UtcNow;
        }
    }
}
