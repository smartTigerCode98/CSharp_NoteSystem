using System.Text.RegularExpressions;
using App.Interfaces;

namespace App.Validators
{
    public class EmailValidator : IEmailValidator
    {
        private const string Pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        
        public bool Validate(string data)
        {
            var regex = new Regex(Pattern);
            var match = regex.Match(data);
            return match.Success;
        }
    }
}