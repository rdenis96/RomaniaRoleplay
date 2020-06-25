using DataLayer.Characters;
using Domain.Characters.Models;
using Domain.Repositories;

namespace BusinessLogic.Characters
{
    public class SkinsWorker
    {
        private readonly ISkinsRepository _skinsRepository;
        public SkinsWorker()
        {
            _skinsRepository = new SkinsRepository();
        }

        public Skin Create(Skin entity)
        {
            var result = _skinsRepository.Create(entity);
            return result;
        }
    }
}
