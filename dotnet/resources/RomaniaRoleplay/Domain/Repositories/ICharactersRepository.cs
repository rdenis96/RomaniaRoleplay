using Domain.Characters.Models;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface ICharactersRepository : IRepository<Character>
    {
        public List<Character> GetAllByUserId(int userId);
    }
}
