using App.Interfaces;

namespace App.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        private const string Salt = "Let's go champ!";
        
        public string Hash(string password)
        {
            return password.ToUpper() + Salt;
        }

        public bool Verify(string hashPassword, string inputtedPassword)
        {
            return hashPassword == Hash(inputtedPassword);
        }
    }
}