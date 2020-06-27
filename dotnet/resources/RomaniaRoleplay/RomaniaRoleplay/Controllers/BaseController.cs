using BusinessLogic.Characters;
using BusinessLogic.Users;
using GTANetworkAPI;
using RomaniaRoleplay.Helpers;
using RomaniaRoleplay.Models.Delegates;

namespace RomaniaRoleplay.Controllers
{
    public partial class RomaniaRoleplayController : Script
    {
        private readonly UsersWorker _usersWorker;
        private readonly RealtimeHelper _realtimeHelper;
        private readonly CharactersWorker _charactersWorker;

        public static event OnPlayerSignedIn PlayerSignedIn;
        public static event OnPlayerSignedOut PlayerSignedOut;
        public static event OnPlayerInfoUpdate PlayerInfoUpdate;
        public static event OnPlayerSelectedCharacter PlayerSelectedCharacter;

        public RomaniaRoleplayController() : base()
        {
            _usersWorker = new UsersWorker();
            _charactersWorker = new CharactersWorker();
            _realtimeHelper = RealtimeHelper.Instance;
            RealtimeHelper.PlayerUpdate += UpdateUser;
            PlayerSelectedCharacter += SetPlayerCharacter;
        }

        #region ServerEvents

        [ServerEvent(Event.ResourceStart)]
        public void OnServerResourceStart()
        {
            NAPI.Server.SetAutoSpawnOnConnect(false);
            NAPI.Server.SetAutoRespawnAfterDeath(true);
        }

        [ServerEvent(Event.PlayerConnected)]
        public void OnPlayerConnected(Player player)
        {
            NAPI.Entity.SetEntityTransparency(player, 0);
            player.Dimension = (uint)(player.Id + 1);
            player.TriggerEvent("onUserConnected");
        }

        [ServerEvent(Event.PlayerDisconnected)]
        public void OnPlayerDisconnected(Player player)
        {
            PlayerSignedOut?.Invoke(player);
        }

        [ServerEvent(Event.PlayerSpawn)]
        public void OnPlayerSpawn(Player player)
        {
        }

        #endregion ServerEvents
    }
}
