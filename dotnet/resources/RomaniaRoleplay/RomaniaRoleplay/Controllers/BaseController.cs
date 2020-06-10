using BusinessLogic.Users;
using GTANetworkAPI;

namespace RomaniaRoleplay.Controllers
{
    public partial class RomaniaRoleplayController : Script
    {
        private readonly UsersWorker _usersWorker;

        public RomaniaRoleplayController() : base()
        {
            _usersWorker = new UsersWorker();
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
            player.TriggerEvent("onPlayerConnected");
        }

        [ServerEvent(Event.PlayerDisconnected)]
        public void OnPlayerDisconnected(Player player)
        {
        }

        [ServerEvent(Event.PlayerSpawn)]
        public void OnPlayerSpawn(Player player)
        {
        }

        #endregion ServerEvents
    }
}
