using App.Interfaces;

namespace App.Extensions
{
    public static class UserRepositoryExtension
    {
        public static bool EmailIsAlreadyUse(this IUserRepository userRepository, string email)
        {
            return userRepository.FindByEmail(email) != null;
        }
    }
}