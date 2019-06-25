using System.Collections.Generic;
using System.Linq;
using App.Entities;
using App.Interfaces;

namespace App.Repositories
{
    public class LocalUserRepository : IUserRepository
    {
        private readonly List<User> _users;
        private int _nextId;
        private int NextId => _nextId++;

        public LocalUserRepository()
        {
            _users = new List<User>();
        }
        
        public User FindByEmail(string email)
        {
            return _users.FirstOrDefault(u => u.Email == email);
        }

        public int AddUser(User user)
        {
            user.Id = NextId;
            _users.Add(user);
            return _nextId;
        }
    }
}