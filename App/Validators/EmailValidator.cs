using System.Text.RegularExpressions;
using App.Interfaces;

namespace App.Validators
{
    public class EmailValidator : IEmailValidator
    {
        private const string Pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        
        public bool Validate(string data)
        {
            return Regex.IsMatch(data, Pattern);
        }
    }
}