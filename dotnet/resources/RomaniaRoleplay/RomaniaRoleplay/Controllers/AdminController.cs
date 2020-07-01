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
        [Command(Commands.SpawnVehicle, Alias = Commands.SpawnVehicleAlias)]
        public void SpawnVehicle(Player player, long vehicleId)
        {
            try
            {
                _realtimeHelper.ExecuteActionOnSelf(player, (user, character) =>
                {
                    if (character.AdminLevel >= 5)
                    {
                        var vehiclePosition = new Vector3(player.Position.X, player.Position.Y + 10, player.Position.Z);
                        var vehicle = NAPI.Vehicle.CreateVehicle((VehicleHash)vehicleId, vehiclePosition, 0, 141, 122, "RomaniaRP");
                        NAPI.Player.SetPlayerIntoVehicle(player, vehicle, 0);
                    }
                    else
                    {
                        player.SendChatMessage($"{ChatHelper.GetChatColor(ChatColors.Red)}Nu esti autorizat sa folosesti aceasta comanda!");
                    }
                });
            }
            catch (Exception ex)
            {
                player.SendChatMessage("/spawnveh <vehicle id>");
            }

        }

        [Command(Commands.Fly, Alias = Commands.FlyAlias)]
        public void Fly(Player player)
        {
            _realtimeHelper.ExecuteActionOnSelf(player, (user, character) =>
            {
                if (character.AdminLevel >= 6)
                {
                    player.TriggerEvent("activateNoClip");
                }
                else
                {
                    player.SendChatMessage($"{ChatHelper.GetChatColor(ChatColors.Red)}Nu esti autorizat sa folosesti aceasta comanda!");
                }
            });

        }

        [Command(Commands.AdminChat, Alias = Commands.AdminChatAlias, GreedyArg = true)]
        public void AdminChat(Player player, string message)
        {
            _realtimeHelper.ExecuteActionOnSelf(player, (user, character) =>
            {
                if (character.AdminLevel >= 1)
                {
                    var onlineAdmins = _realtimeHelper.GetAllOnlineClientAdmins();
                    Parallel.ForEach(onlineAdmins, new ParallelOptions { MaxDegreeOfParallelism = 2 }, (admin) =>
                     {
                         admin.SendChatMessage($"{ChatHelper.GetChatColor(ChatColors.ChatAdminsColor)}[Admin {character.AdminLevel}] {player.Name}", $"{ChatHelper.GetChatColor(ChatColors.None)}{message}");
                     });
                }
                else
                {
                    player.SendChatMessage($"{ChatHelper.GetChatColor(ChatColors.Red)}Nu esti autorizat sa folosesti aceasta comanda!");
                }
            });
        }

        [Command(Commands.Freeze, Alias = Commands.FreezeAlias, Description = "/freeze <id/name>")]
        public void Freeze(Player player, string target)
        {
            try
            {
                var character = _realtimeHelper.GetCharacterByPlayerId(player.Id);
                if (character != null && character.AdminLevel >= 1)
                {
                    _realtimeHelper.ExecuteActionOnPlayer(player, target, (targetPlayer, targetUser, targetCharacter) =>
                    {
                        targetPlayer.SetData("isFreezed", true);
                        targetPlayer.TriggerEvent("freeze", true);

                        var playerMessage = $"{ChatHelper.GetChatColor(ChatColors.Orange)}Administratorul {player.Name} {ChatHelper.GetChatColor(ChatColors.None)}te-a blocat pe loc!";
                        targetPlayer.SendChatMessage(playerMessage);

                        var adminMessage = $"{ChatHelper.GetChatColor(ChatColors.Orange)}Administratorul {player.Name} {ChatHelper.GetChatColor(ChatColors.None)}l-a blocat pe loc pe jucatorul {ChatHelper.GetChatColor(ChatColors.Orange)}{targetPlayer.Name}{ChatHelper.GetChatColor(ChatColors.None)}!";
                        var onlineAdmins = _realtimeHelper.GetAllOnlineClientAdmins();
                        Parallel.ForEach(onlineAdmins, new ParallelOptions { MaxDegreeOfParallelism = 2 }, (admin) =>
                        {
                            admin.SendChatMessage(adminMessage);
                        });
                    });
                }
                else
                {
                    player.SendChatMessage($"{ChatHelper.GetChatColor(ChatColors.Red)}Nu esti autorizat sa folosesti aceasta comanda!");
                }
            }
            catch (Exception ex)
            {
                player.SendChatMessage("/freeze <id/name>");
            }
        }

        [Command(Commands.UnFreeze, Alias = Commands.UnFreezeAlias, Description = "/unfreeze <id/name>")]
        public void UnFreeze(Player player, string target)
        {
            try
            {
                var character = _realtimeHelper.GetCharacterByPlayerId(player.Id);
                if (character != null && character.AdminLevel >= 1)
                {
                    _realtimeHelper.ExecuteActionOnPlayer(player, target, (targetPlayer, targetUser, targetCharacter) =>
                    {
                        if (targetPlayer.GetData<bool>("isFreezed"))
                        {
                            targetPlayer.SetData("isFreezed", false);
                            targetPlayer.TriggerEvent("freeze", false);

                            var playerMessage = $"{ChatHelper.GetChatColor(ChatColors.Orange)}Administratorul {player.Name} {ChatHelper.GetChatColor(ChatColors.None)}te-a deblocat de pe loc!";
                            targetPlayer.SendChatMessage(playerMessage);

                            var adminMessage = $"{ChatHelper.GetChatColor(ChatColors.Orange)}Administratorul {player.Name} {ChatHelper.GetChatColor(ChatColors.None)}l-a deblocat de pe loc pe jucatorul {ChatHelper.GetChatColor(ChatColors.Orange)}{targetPlayer.Name}{ChatHelper.GetChatColor(ChatColors.None)}!";
                            var onlineAdmins = _realtimeHelper.GetAllOnlineClientAdmins();
                            Parallel.ForEach(onlineAdmins, new ParallelOptions { MaxDegreeOfParallelism = 2 }, (admin) =>
                            {
                                admin.SendChatMessage(adminMessage);
                            });
                        }
                        else
                        {
                            player.SendChatMessage($"Jucatorul {ChatHelper.GetChatColor(ChatColors.Orange)}{targetPlayer} {ChatHelper.GetChatColor(ChatColors.None)}nu este blocat!");
                        }
                    });
                }
                else
                {
                    player.SendChatMessage($"{ChatHelper.GetChatColor(ChatColors.Red)}Nu esti autorizat sa folosesti aceasta comanda!");
                }
            }
            catch (Exception ex)
            {
                player.SendChatMessage("/unfreeze <id/name>");
            }
        }

        [Command(Commands.Mute, Alias = Commands.MuteAlias, GreedyArg = true)]
        public void Mute(Player player, string target, int minutes, string reason)
        {
            try
            {
                var character = _realtimeHelper.GetCharacterByPlayerId(player.Id);
                if (character != null && character.AdminLevel >= 1)
                {
                    _realtimeHelper.ExecuteActionOnPlayer(player, target, (targetPlayer, targetUser, targetCharacter) =>
                    {
                        targetCharacter.Mute.IsMuted = true;
                        targetCharacter.Mute.ExpirationTime = DateTime.UtcNow.AddMinutes(minutes);
                        targetCharacter.Mute.Reason = reason;
                        PlayerInfoUpdate?.Invoke(null, targetCharacter);

                        var playerMessage = $@"{ChatHelper.GetChatColor(ChatColors.Orange)}Administratorul {player.Name} 
                                                {ChatHelper.GetChatColor(ChatColors.None)}ti-a dat mute cu motivul: 
                                                {ChatHelper.GetChatColor(ChatColors.Orange)}{reason} 
                                                {ChatHelper.GetChatColor(ChatColors.None)}pana la data de 
                                                {ChatHelper.GetChatColor(ChatColors.Orange)} {targetCharacter.Mute.ExpirationTime}!";
                        targetPlayer.SendChatMessage(playerMessage);

                        var adminMessage = $@"{ChatHelper.GetChatColor(ChatColors.Orange)}Administratorul {player.Name} 
                                                {ChatHelper.GetChatColor(ChatColors.None)}i-a dat mute jucatorului 
                                                {ChatHelper.GetChatColor(ChatColors.Orange)}{targetPlayer.Name} 
                                                {ChatHelper.GetChatColor(ChatColors.None)}cu motivul 
                                                {ChatHelper.GetChatColor(ChatColors.Orange)}{reason} 
                                                {ChatHelper.GetChatColor(ChatColors.None)}pana la data de 
                                                {ChatHelper.GetChatColor(ChatColors.Orange)} {targetCharacter.Mute.ExpirationTime}!";
                        var onlineAdmins = _realtimeHelper.GetAllOnlineClientAdmins();
                        Parallel.ForEach(onlineAdmins, new ParallelOptions { MaxDegreeOfParallelism = 2 }, (admin) =>
                        {
                            admin.SendChatMessage(adminMessage);
                        });
                    });
                }
                else
                {
                    player.SendChatMessage($"{ChatHelper.GetChatColor(ChatColors.Red)}Nu esti autorizat sa folosesti aceasta comanda!");
                }
            }
            catch (Exception ex)
            {
                player.SendChatMessage("/mute <id/name> <minutes> <reason>");
            }
        }

        [Command(Commands.UnMute, Alias = Commands.UnMuteAlias, GreedyArg = true)]
        public void UnMute(Player player, string target)
        {
            try
            {
                var character = _realtimeHelper.GetCharacterByPlayerId(player.Id);
                if (character != null && character.AdminLevel >= 1)
                {
                    _realtimeHelper.ExecuteActionOnPlayer(player, target, (targetPlayer, targetUser, targetCharacter) =>
                    {
                        if (targetCharacter.Mute.IsMuted == true)
                        {
                            targetCharacter.Mute.IsMuted = false;
                            targetCharacter.Mute.ExpirationTime = DateTime.UtcNow;
                            targetCharacter.Mute.Reason = string.Empty;
                            PlayerInfoUpdate?.Invoke(null, targetCharacter);

                            var playerMessage = $"{ChatHelper.GetChatColor(ChatColors.Orange)}Administratorul {player.Name} {ChatHelper.GetChatColor(ChatColors.None)}ti-a scos mute-ul!";
                            targetPlayer.SendChatMessage(playerMessage);

                            var adminMessage = $"{ChatHelper.GetChatColor(ChatColors.Orange)}Administratorul {player.Name} {ChatHelper.GetChatColor(ChatColors.None)}i-a scos mute-ul jucatorului {ChatHelper.GetChatColor(ChatColors.Orange)}{targetPlayer.Name}{ChatHelper.GetChatColor(ChatColors.None)}!";
                            var onlineAdmins = _realtimeHelper.GetAllOnlineClientAdmins();
                            Parallel.ForEach(onlineAdmins, new ParallelOptions { MaxDegreeOfParallelism = 2 }, (admin) =>
                            {
                                admin.SendChatMessage(adminMessage);
                            });
                        }
                        else
                        {
                            player.SendChatMessage($"Jucatorul {ChatHelper.GetChatColor(ChatColors.Orange)}{targetPlayer} {ChatHelper.GetChatColor(ChatColors.None)}nu are mute!");
                        }
                    });
                }
                else
                {
                    player.SendChatMessage($"{ChatHelper.GetChatColor(ChatColors.Red)}Nu esti autorizat sa folosesti aceasta comanda!");
                }
            }
            catch (Exception ex)
            {
                player.SendChatMessage("/unmute <id/name>");
            }
        }
    }
}
