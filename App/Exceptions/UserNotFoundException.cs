using System;

namespace App.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public string Email { get; }

        public UserNotFoundException(string email) : base($"User with {email} not found")
        {
            Email = email;
        }
    }
}