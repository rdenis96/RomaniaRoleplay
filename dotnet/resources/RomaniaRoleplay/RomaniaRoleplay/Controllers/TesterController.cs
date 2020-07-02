using GTANetworkAPI;
using Helper.Chat;
using Helper.Chat.Enums;
using RomaniaRoleplay.Constants;
using System.Linq;
using System.Threading.Tasks;

namespace RomaniaRoleplay.Controllers
{
    public partial class RomaniaRoleplayController : Script
    {
        [Command(Commands.TesterChat, Alias = Commands.TesterChatAlias, GreedyArg = true)]
        public void TesterChat(Player player, string message)
        {
            _realtimeHelper.ExecuteActionOnSelf(player, (user, character) =>
            {
                if (character.TesterLevel >= 1 || character.AdminLevel >= 1)
                {
                    var onlineTesters = _realtimeHelper.GetAllOnlineClientTesters();
                    var onlineAdmins = _realtimeHelper.GetAllOnlineClientAdmins();
                    var staff = onlineAdmins.Union(onlineTesters);

                    var sender = $"{ChatHelper.GetChatColor(ChatColors.ChatTestersColor)}[Tester {character.TesterLevel}] {player.Name}";
                    if (character.AdminLevel >= 1)
                    {
                        sender = $"{ChatHelper.GetChatColor(ChatColors.ChatTestersColor)}[Admin {character.AdminLevel}] {player.Name}";
                    }
                    Parallel.ForEach(staff, new ParallelOptions { MaxDegreeOfParallelism = 2 }, (tester) =>
                    {
                        tester.SendChatMessage(sender, $"{ChatHelper.GetChatColor(ChatColors.None)}{message}");
                    });
                }
                else
                {
                    player.SendChatMessage($"{ChatHelper.GetChatColor(ChatColors.Red)}Nu esti autorizat sa folosesti aceasta comanda!");
                }
            });
        }
    }
}
