using App.Entities;
using App.Interfaces;

namespace App.Services
{
    public class GuardService : IGuardService
    {
        public void StoreUser(User user)
        {
            User = user;
        }

        public void RemoveUser()
        {
            User = null;
        }

        public User User { get; private set; }
        
        public bool SignedIn => User != null;
    }
}