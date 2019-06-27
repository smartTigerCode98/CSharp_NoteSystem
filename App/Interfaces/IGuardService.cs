using App.Entities;

namespace App.Interfaces
{
    public interface IGuardService
    {
        void StoreUser(User user);
        void RemoveUser();
        User User { get; }
        bool SignedIn { get; }
    }
}