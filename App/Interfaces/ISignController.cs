using App.Entities;

namespace App.Interfaces
{
    public interface ISignController
    {
        User User { get; set; }
        void Run();

        void SignUp();

        void SignIn();
    }
}