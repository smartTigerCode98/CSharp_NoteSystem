using App.Entities;

namespace App.Interfaces
{
    public interface IUserRepository
    {
        User FindByEmail(string email);

        int AddUser(User user);
    }
}