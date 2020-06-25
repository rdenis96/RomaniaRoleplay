using DataLayer.EntityContexts;
using Domain.Characters.Models;
using Domain.Repositories;
using System.Collections.Generic;

namespace DataLayer.Characters
{
    public class SkinsRepository : ISkinsRepository
    {
        public Skin Create(Skin entity)
        {
            bool changesSaved = false;
            using (var context = new MysqlContext())
            {
                context.Skins.Add(entity);
                changesSaved = context.SaveChanges() > 0;
            }
            return changesSaved ? entity : null;
        }

        public bool Delete(Skin entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Skin> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Skin GetById(int id)
        {
            using (var context = new MysqlContext())
            {
                var result = context.Skins.Find(id);
                return result;
            }
        }

        public Skin Update(Skin entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
