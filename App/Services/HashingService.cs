using App.Interfaces;

namespace App.Services
{
    public class HashingService : IPasswordHasher
    {
        private const string Salt = "Let's go champ!";
        
        public string Hashing(string password)
        {
            return password.ToUpper() + Salt;
        }

        public bool Verify(string hashPassword, string inputtedPassword)
        {
            return hashPassword == Hashing(inputtedPassword);
        }
    }
}