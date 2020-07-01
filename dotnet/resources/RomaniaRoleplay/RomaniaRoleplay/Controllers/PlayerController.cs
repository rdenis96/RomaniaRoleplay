using GTANetworkAPI;
using Helper.Chat;
using Helper.Chat.Enums;
using RomaniaRoleplay.Constants;
using System;
using System.Threading.Tasks;

namespace RomaniaRoleplay.Controllers
{
    public partial class RomaniaRoleplayController : Script
    {
        #region Commands
        [Command(Commands.GetCoordonates, Alias = Commands.GetCoordonatesAlias)]
        public void GetCoordonates(Player player)
        {
            player.SendChatMessage($"Coordonates: X : {player.Position.X} | Y : {player.Position.Y} | Z : {player.Position.Z}");
        }

        [Command(Commands.Stats, Alias = Commands.StatsAlias)]
        public void Stats(Player player)
        {
            var character = _realtimeHelper.GetCharacterByPlayerId(player.Id);
            player.SendChatMessage($"{ChatHelper.GetChatColor(ChatColors.Green)}|__________________________{player.Name}[{DateTime.Now}]__________________________|");

            player.SendChatMessage($"{ChatHelper.GetChatColor(ChatColors.None)}Level: {character.Level} | Job:Trucker | Money: {character.Money} | BankMoney: {character.BankMoney} | SkinId: {character.SkinId} |");
            player.SendChatMessage($"{ChatHelper.GetChatColor(ChatColors.None)}TimePlayed: {TimeSpan.FromMilliseconds(character.TimePlayed)} |");

            player.SendChatMessage($"{ChatHelper.GetChatColor(ChatColors.Green)}|__________________________{player.Name}[{DateTime.Now}]__________________________|");
        }
        #endregion

        #region Remote Events
        [ServerEvent(Event.ChatMessage)]
        public void OnPlayerSendChatMessage(Player player, string message)
        {
            var character = _realtimeHelper.GetCharacterByPlayerId(player.Id);
            if (character.Mute.IsMuted == true)
            {
                if (character.Mute.ExpirationTime > DateTime.UtcNow)
                {
                    player.SendChatMessage($"Nu poti vorbi deoarece ai mute! Motiv: {character.Mute.Reason} | Data de expirare: {character.Mute.ExpirationTime}");
                }
                else
                {
                    Task.Run(() =>
                    {
                        character.Mute.IsMuted = false;
                        character.Mute.Reason = string.Empty;
                        PlayerInfoUpdate?.Invoke(null, character);
                    });
                    SendChatMessage(player, message);
                }
            }
            else
            {
                SendChatMessage(player, message);
            }
        }

        private void SendChatMessage(Player player, string message)
        {
            var onlinePlayers = NAPI.Pools.GetAllPlayers();
            Parallel.ForEach(onlinePlayers, new ParallelOptions { MaxDegreeOfParallelism = 4 }, (clientPlayer) =>
            {
                clientPlayer.SendChatMessage(player.Name, message);
            });
        }
        #endregion
    }
}
