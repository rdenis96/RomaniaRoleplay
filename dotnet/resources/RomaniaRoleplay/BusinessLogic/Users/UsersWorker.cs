using DataLayer.Users;
using Domain.Repositories;
using Domain.Users.Models;
using System;

namespace BusinessLogic.Users
{
    public class UsersWorker
    {
        private readonly IUsersRepository _usersRepository;
        public UsersWorker()
        {
            _usersRepository = new UsersRepository();
        }

        public bool ExistsUser(string username)
        {
            var result = _usersRepository.ExistsUser(username);
            return result;
        }

        public User GetPlayerInfoByUsernameAndPassword(string username, string password)
        {
            var result = _usersRepository.GetByUsernameAndPassword(username, password);
            return result;
        }

        public User GetWrapperByUsername(string username)
        {
            var result = _usersRepository.GetWrapperByUsername(username);
            return result;
        }

        public User Create(string username, string email, string password)
        {
            var user = GeneratePlayerInfoWrapper(username, email, password);
            var result = _usersRepository.Create(user);
            return result;
        }

        public User Update(User user)
        {
            var result = _usersRepository.Update(user);
            return result;
        }

        private User GeneratePlayerInfoWrapper(string username, string email, string password)
        {
            var currentDate = DateTime.UtcNow;
            var user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                RegisterDate = currentDate,
                LastActiveDate = DateTime.MinValue,
            };
            return user;
        }
    }
}
