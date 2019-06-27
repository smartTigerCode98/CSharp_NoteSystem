using System.Text.RegularExpressions;
using App.Interfaces;

namespace App.Validators
{
    public class PasswordValidator : IPasswordValidator
    {
        private const string Pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,15}$";
        
        public bool Validate(string data)
        {
            return Regex.IsMatch(data, Pattern);
        }
    }
}