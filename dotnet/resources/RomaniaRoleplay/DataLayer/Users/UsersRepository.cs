using DataLayer.EntityContexts;
using Domain.Repositories;
using Domain.Users.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Users
{
    public class UsersRepository : IUsersRepository
    {
        public UsersRepository()
        {
        }
        public User GetWrapperByUsername(string username)
        {
            using (var context = new MysqlContext())
            {
                var result = context.Users.FirstOrDefault(x => x.Username == username);
                return result;
            }
        }

        public bool ExistsUser(string username)
        {
            using (var context = new MysqlContext())
            {
                var result = context.Users.Any(x => x.Username == username);
                return result;
            }
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            using (var context = new MysqlContext())
            {
                var result = context.Users.FirstOrDefault(x => x.Username.Equals(username) && x.Password.Equals(password));
                return result;
            }
        }

        public User Create(User entity)
        {
            bool changesSaved = false;
            using (var context = new MysqlContext())
            {
                context.Users.Add(entity);
                changesSaved = context.SaveChanges() > 0;
            }
            return changesSaved ? entity : null;
        }

        public User Update(User entity)
        {
            bool changesSaved = false;
            using (var context = new MysqlContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                changesSaved = context.SaveChanges() > 0;
            }
            return changesSaved ? entity : null;
        }

        public IEnumerable<User> GetAll()
        {
            using (var context = new MysqlContext())
            {
                var result = context.Users.ToList();
                return result ?? new List<User>();
            }
        }

        public bool Delete(User entity)
        {
            bool changesSaved = false;
            using (var context = new MysqlContext())
            {
                context.Entry(entity).State = EntityState.Deleted;
                changesSaved = context.SaveChanges() > 0;
            }
            return changesSaved;
        }

        public User GetById(int id)
        {
            using (var context = new MysqlContext())
            {
                var result = context.Users.Find(id);
                return result;
            }
        }
    }
}
