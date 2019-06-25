using System;

namespace App.Exceptions
{
    public class UserWithEmailAlreadyExists : Exception
    {
        public string Email { get; }

        public UserWithEmailAlreadyExists(string email) : base($"User with '{email}' is already exists")
        {
            Email = email;
        }
    }
}