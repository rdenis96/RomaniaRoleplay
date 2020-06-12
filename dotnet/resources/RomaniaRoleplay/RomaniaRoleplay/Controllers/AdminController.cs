using GTANetworkAPI;
using RomaniaRoleplay.Constants;

namespace RomaniaRoleplay.Controllers
{
    public partial class RomaniaRoleplayController : Script
    {
        [Command(Commands.CreateVehicle, Alias = Commands.CreateVehicleAlias)]
        public void CreateVehicle(Player player, object vehicleId)
        {
            var vehiclePosition = new Vector3(player.Position.X, player.Position.Y + 10, player.Position.Z);
            var vehicle = NAPI.Vehicle.CreateVehicle((VehicleHash)vehicleId, vehiclePosition, 0, 141, 122, "RomaniaRP");
            NAPI.Player.SetPlayerIntoVehicle(player, vehicle, 0);

        }

        [Command(Commands.Fly, Alias = Commands.FlyAlias)]
        public void Fly(Player player)
        {
            player.TriggerEvent("activateNoClip");
        }
    }
}
