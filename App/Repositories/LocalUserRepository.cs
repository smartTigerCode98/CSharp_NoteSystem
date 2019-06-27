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
            _users = new List<User> { new User("Vladik", "qwe@asd.zxc", "TOPKEKLet's go champ!") };
        }
        
        public User FindByEmail(string email)
        {
            return _users.FirstOrDefault(u => u.Email == email);
        }

        public void AddUser(User user)
        {
            user.Id = NextId;
            _users.Add(user);
        }
    }
}