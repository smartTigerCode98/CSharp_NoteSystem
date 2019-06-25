using System;

namespace App.Extensions
{
    public class InvalidEmailException : Exception
    {
        public string Email { get;}

        public InvalidEmailException(string email) : base($"Invalid email format in {email}")
        {
            Email = email;
        }
    }
}