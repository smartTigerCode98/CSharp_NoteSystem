using System;

namespace App.Exceptions
{
    public class PasswordMismatchException : Exception
    {
        public string Password { get; }

        public PasswordMismatchException(string password) : base("Invalid password")
        {
            Password = password;
        }
    }
}