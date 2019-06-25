using System;

namespace App.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public string Password { get; }

        public InvalidPasswordException(string password) :
            base(
                "Your password must be between 6 characters and 15, have chars in upper and lower cases and also have numbers")
        {
            Password = password;
        }

    }
}