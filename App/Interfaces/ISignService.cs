using App.Entities;

namespace App.Interfaces
{
    public interface ISignService
    {
        User SignUp(string name, string email, string password);
        User SignIn(string email, string password);
    }
}