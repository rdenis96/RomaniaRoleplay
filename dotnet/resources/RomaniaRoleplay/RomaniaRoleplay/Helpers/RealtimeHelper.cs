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

        /// <summary>
        /// Key value from Dictionary represents the Id from Users table
        /// </summary>
        public Dictionary<int, Character> OnlinePlayersCharacter;

        public Dictionary<int, Timer> CharactersPlayedTimeTimers { get; set; }

        private RealtimeHelper()
        {
            OnlinePlayersAccount = new Dictionary<int, User>();

            OnlinePlayersCharacter = new Dictionary<int, Character>();

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

        public Player GetPlayerById(int playerId)
        {
            var result = NAPI.Pools.GetAllPlayers().FirstOrDefault(x => x.Id == playerId);
            return result;
        }

        public User GetOnlineUserInfo(int playerId)
        {
            var player = OnlinePlayersAccount.FirstOrDefault(x => x.Key == playerId);
            return player.Value;
        }

        public Character GetCharacterByPlayerId(int playerId)
        {
            var user = OnlinePlayersAccount.FirstOrDefault(x => x.Key == playerId).Value;
            if (user != null)
            {
                var character = OnlinePlayersCharacter.FirstOrDefault(x => x.Key == user.Id);
                return character.Value;
            }
            return null;
        }

        public List<Player> GetAllOnlineClientAdmins()
        {
            var onlineAdmins = new List<Player>();
            NAPI.Pools.GetAllPlayers().ForEach(player =>
            {
                var playerCharacter = GetCharacterByPlayerId(player.Id);
                if (playerCharacter != null && playerCharacter.AdminLevel > 0)
                {
                    onlineAdmins.Add(player);
                }
            });
            return onlineAdmins;
        }

        public List<Player> GetAllOnlineClientTesters()
        {
            var onlineTesters = new List<Player>();
            NAPI.Pools.GetAllPlayers().ForEach(player =>
            {
                var playerCharacter = GetCharacterByPlayerId(player.Id);
                if (playerCharacter != null && playerCharacter.TesterLevel > 0)
                {
                    onlineTesters.Add(player);
                }
            });
            return onlineTesters;
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
                isTargetOnline = NAPI.Pools.GetAllPlayers().Any(x => x.Name.Equals(target));
            }

            if (isTargetOnline)
            {
                var targetModel = isTargetId ? NAPI.Pools.GetAllPlayers().FirstOrDefault(x => x.Id == targetId) : NAPI.Pools.GetAllPlayers().FirstOrDefault(x => x.Name == target);
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

        public void ExecuteActionOnSelf(Player player, Action<User, Character> func)
        {
            var user = OnlinePlayersAccount.FirstOrDefault(x => x.Key == player.Id).Value;
            if (user != null)
            {
                var character = OnlinePlayersCharacter.FirstOrDefault(x => x.Key == user.Id).Value;
                if (character != null)
                {
                    func(user, character);
                }
            }
        }

        private void OnPlayerSignedIn(Player player, User user)
        {
            OnlinePlayersAccount.TryAdd(player.Id, user);
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
        }

        private void OnPlayerSelectedCharacter(Player player, Character character)
        {
            var user = OnlinePlayersAccount.FirstOrDefault(x => x.Key == player.Id).Value;
            if (user != null)
            {
                OnlinePlayersCharacter.TryAdd(user.Id, character);
                StartPlayedTimeCounting(character);
                character.LastActiveDate = DateTime.UtcNow;
                PlayerUpdate?.Invoke(null, character);
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
