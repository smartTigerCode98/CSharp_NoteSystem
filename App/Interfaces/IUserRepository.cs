using App.Entities;

namespace App.Interfaces
{
    public interface IUserRepository
    {
        User FindByEmail(string email);

        void AddUser(User user);
    }
}