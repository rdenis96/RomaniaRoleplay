using GTANetworkAPI;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RomaniaRoleplay.Helpers
{
    public static class AdminHelper
    {
        public static void SendMessageToAdmins(string message, List<Player> admins, string sender = null)
        {
            if (sender != null)
            {
                Parallel.ForEach(admins, new ParallelOptions { MaxDegreeOfParallelism = 2 }, (admin) =>
                {
                    admin.SendChatMessage(message);
                });
            }
            else
            {
                Parallel.ForEach(admins, new ParallelOptions { MaxDegreeOfParallelism = 2 }, (admin) =>
                {
                    admin.SendChatMessage(sender, message);
                });
            }
        }
    }
}
