using Domain.Characters.Models;
using Domain.Users.Models;
using GTANetworkAPI;

namespace RomaniaRoleplay.Models.Delegates
{
    public delegate void OnPlayerSignedIn(Player player, User user);
    public delegate void OnPlayerSignedOut(Player player);
    public delegate void OnPlayerInfoUpdate(User user, Character character);
    public delegate void OnPlayerSelectedCharacter(Player player, Character character);
}
