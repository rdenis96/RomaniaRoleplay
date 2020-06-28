using DataLayer.EntityContexts;
using Domain.Characters.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Characters
{
    public class CharactersRepository : ICharactersRepository
    {
        public Character Create(Character entity)
        {
            try
            {
                bool changesSaved = false;
                using (var context = new MysqlContext())
                {
                    context.Characters.Add(entity);
                    changesSaved = context.SaveChanges() > 0;
                }
                return changesSaved ? GetById(entity.Id) : null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Delete(Character entity)
        {
            if (entity == null)
                return false;
            using (var context = new MysqlContext())
            {
                context.Characters.Remove(entity);
                bool changesSaved = context.SaveChanges() > 0;
                if (context.Characters.Contains(entity))
                    return false;
                return changesSaved;
            }
        }

        public IEnumerable<Character> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Character GetById(int id)
        {
            using (var context = new MysqlContext())
            {
                var result = context.Characters.Include(x => x.Skin).Where(x => x.Id == id).FirstOrDefault();
                return result;
            }
        }

        public List<Character> GetAllByUserId(int userId)
        {
            using (var context = new MysqlContext())
            {
                var result = context.Characters.Include(s => s.Skin).Where(x => x.UserId == userId).ToList();
                return result;
            }
        }

        public Character Update(Character entity)
        {
            bool changesSaved = false;
            using (var context = new MysqlContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                changesSaved = context.SaveChanges() > 0;
            }
            return changesSaved ? entity : null;
        }
    }
}
