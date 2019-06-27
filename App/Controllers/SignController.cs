using System;
using System.Collections.Generic;
using App.Enum;
using App.Entities;
using App.Exceptions;
using App.Extensions;
using App.Interfaces;

namespace App.Controllers
{
    public class SignController
    {
        private readonly ISignService _signService;
        private readonly IEmailValidator _emailValidator;
        private readonly IPasswordValidator _passwordValidator;

        
        private readonly List<string> _commands = new List<string>{
            SignCommands.SignIn, 
            SignCommands.SignUp
        };
        
        public User User { get; set; }

        public SignController(ISignService signService, IEmailValidator emailValidator,
                              IPasswordValidator passwordValidator)
        {
            _signService = signService;
            _emailValidator = emailValidator;
            _passwordValidator = passwordValidator;
        }
        
        public void Run()
        {
            while (User == null)
            {
                var command = RequestPrompt("Sign in(in) : Sign up(up)");
                if (!_commands.Contains(command))
                {
                    Console.WriteLine("Invalid command. Please try again");
                    continue;
                }
                switch (command)
                {
                    case SignCommands.SignIn:
                        SignIn();
                        break;
                    case SignCommands.SignUp:
                        try
                        {
                            SignUp();   
                        }
                        catch (InvalidEmailException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (InvalidPasswordException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                }
            }
        }

        private void SignUp()
        {
            var name = RequestPrompt("Enter name");
            var email = RequestPrompt("Enter email");
            var password = RequestPrompt("Enter password");
            if (!_emailValidator.Validate(email))
            {
                throw new InvalidEmailException(email);
            }

            if (!_passwordValidator.Validate(password))
            {
                throw new InvalidPasswordException(password);
            }
            try
            { 
                _signService.SignUp(name, email, password);
            }
            catch (UserWithEmailAlreadyExists e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void SignIn()
        {
            var email = RequestPrompt("Enter email");
            var password = RequestPrompt("Enter password");
            try
            {
                User = _signService.SignIn(email, password);
            }
            catch (UserNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (PasswordMismatchException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static string RequestPrompt(string prompt)
        {
            Console.WriteLine($"{prompt}");
            return Console.ReadLine();
        }
    }
}