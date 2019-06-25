namespace App.Interfaces
{
    public interface IPasswordHasher
    {
        string Hashing(string password);

        bool Verify(string hashPassword, string inputtedPassword);
    }
}