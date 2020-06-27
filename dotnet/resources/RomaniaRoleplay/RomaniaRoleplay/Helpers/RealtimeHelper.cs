using Domain.Characters.Models;
using Domain.Users.Models;
using GTANetworkAPI;
using RomaniaRoleplay.Controllers;
using RomaniaRoleplay.Models.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace RomaniaRoleplay.Helpers
{
    public class RealtimeHelper
    {
        private static RealtimeHelper instance;
        private static object syncRoot = new object();

        public static event OnPlayerInfoUpdate PlayerUpdate;

        public Dictionary<int, User> OnlinePlayersAccount;
        public Dictionary<int, User> OnlineAdminsAccount;

        /// <summary>
        /// Key value from Dictionary represents the Id from Users table
        /// </summary>
        public Dictionary<int, Character> OnlinePlayersCharacter;

        public List<Player> OnlinePlayersClient { get; set; }
        public List<Player> OnlineAdminsClient { get; set; }

        public Dictionary<int, Timer> CharactersPlayedTimeTimers { get; set; }

        private RealtimeHelper()
        {
            OnlinePlayersAccount = new Dictionary<int, User>();
            OnlineAdminsAccount = new Dictionary<int, User>();

            OnlinePlayersCharacter = new Dictionary<int, Character>();

            OnlinePlayersClient = new List<Player>();
            OnlineAdminsClient = new List<Player>();

            CharactersPlayedTimeTimers = new Dictionary<int, Timer>();

            RomaniaRoleplayController.PlayerSignedIn += OnPlayerSignedIn;
            RomaniaRoleplayController.PlayerSignedOut += OnPlayerSignedOut;

            RomaniaRoleplayController.PlayerSelectedCharacter += OnPlayerSelectedCharacter;
        }

        public static RealtimeHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            var temp = new RealtimeHelper();

                            System.Threading.Thread.MemoryBarrier();
                            instance = temp;
                        }
                    }
                }

                return instance;
            }
        }

        public Player GetOnlinePlayer(int playerId)
        {
            var player = OnlinePlayersClient.FirstOrDefault(x => x.Id == playerId);
            return player;
        }

        public User GetOnlineUserInfo(int playerId)
        {
            var player = OnlinePlayersAccount.FirstOrDefault(x => x.Key == playerId);
            return player.Value;
        }

        public void ExecuteActionOnPlayer(Player player, string target, Action<Player, User, Character> func)
        {
            var isTargetOnline = false;
            var isTargetId = int.TryParse(target, out int targetId);
            if (isTargetId)
            {
                isTargetOnline = OnlinePlayersAccount.ContainsKey(targetId);
            }
            else
            {
                isTargetOnline = OnlinePlayersClient.Any(x => x.Name.Equals(target));
            }

            if (isTargetOnline)
            {
                var targetModel = isTargetId ? OnlinePlayersClient.FirstOrDefault(x => x.Id == targetId) : OnlinePlayersClient.FirstOrDefault(x => x.Name == target);
                if (targetModel != null)
                {
                    var targetUserModel = OnlinePlayersAccount.FirstOrDefault(x => x.Key == targetModel.Id).Value;
                    if (targetUserModel != null)
                    {
                        var targetCharacterModel = OnlinePlayersCharacter.FirstOrDefault(x => x.Key == targetUserModel.Id).Value;
                        if (targetCharacterModel != null)
                        {
                            func(targetModel, targetUserModel, targetCharacterModel);
                        }
                    }
                }
            }
            else
            {
                player.SendChatMessage("Jucatorul nu este online sau numele/id-ul e gresit!");
            }
        }

        private void OnPlayerSignedIn(Player player, User user)
        {
            OnlinePlayersAccount.TryAdd(player.Id, user);
            if (OnlinePlayersClient.FirstOrDefault(x => x.Id == player.Id) == null)
            {
                OnlinePlayersClient.Add(player);
            }

            //if (dbPlayer.Admin.AdminLevel > Domain.Enums.Admins.AdminLevels.None)
            //{
            //    OnlineAdminsAccount.Add(player.Id, dbPlayer);
            //    OnlineAdminsClient.Add(player);
            //}

            //StartPlayedTimeCounting(user);
        }

        private void OnPlayerSignedOut(Player player)
        {
            var user = OnlinePlayersAccount.FirstOrDefault(x => x.Key == player.Id).Value;
            if (user != null)
            {
                var character = OnlinePlayersCharacter.FirstOrDefault(x => x.Key == user.Id).Value;
                StopPlayedTimeCounting(character.Id);
                PlayerUpdate?.Invoke(user, character);
            }

            OnlinePlayersAccount.Remove(player.Id);
            var playerToRemove = OnlinePlayersClient.FirstOrDefault(x => x.Id == player.Id);
            if (playerToRemove != null)
            {
                OnlinePlayersClient.Remove(playerToRemove);
            }

            var playerPair = OnlineAdminsAccount.FirstOrDefault(x => x.Key == player.Id);
            if (playerPair.Value != null)
            {
                var dbPlayer = playerPair.Value;
                //if (dbPlayer.Admin.AdminLevel > Domain.Enums.Admins.AdminLevels.None)
                //{
                //    OnlineAdminsAccount.Remove(player.Id);
                //    var adminToRemove = OnlineAdminsClient.FirstOrDefault(x => x.Id == player.Id);
                //    if (adminToRemove != null)
                //    {
                //        OnlineAdminsClient.Remove(adminToRemove);
                //    }
                //}
            }
        }

        private void OnPlayerSelectedCharacter(Player player, Character character)
        {
            var user = OnlinePlayersAccount.FirstOrDefault(x => x.Key == player.Id).Value;
            if (user != null)
            {
                OnlinePlayersCharacter.TryAdd(user.Id, character);
                StartPlayedTimeCounting(character);
            }
        }

        private void StartPlayedTimeCounting(Character character)
        {
            Timer timer = new Timer();
            CharactersPlayedTimeTimers.TryAdd(character.Id, timer);

            timer.Interval = 1000;
            timer.Elapsed += (object source, ElapsedEventArgs e) =>
            {
                character.TimePlayed += 1000;
            };
            timer.Start();
        }

        private void StopPlayedTimeCounting(int characterId)
        {
            bool canGetTimer = CharactersPlayedTimeTimers.TryGetValue(characterId, out Timer timer);
            if (canGetTimer)
            {
                timer.Stop();
            }
        }
    }
}
