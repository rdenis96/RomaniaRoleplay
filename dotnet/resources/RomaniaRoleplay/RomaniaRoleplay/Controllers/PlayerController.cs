using GTANetworkAPI;
using RomaniaRoleplay.Constants;

namespace RomaniaRoleplay.Controllers
{
    public partial class RomaniaRoleplayController : Script
    {


        [Command(Commands.GetCoordonates, Alias = Commands.GetCoordonatesAlias)]
        public void GetCoordonates(Player player)
        {
            player.SendChatMessage($"Coordonates: X : {player.Position.X} | Y : {player.Position.Y} | Z : {player.Position.Z}");
        }
    }
}
