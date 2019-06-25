using System;
using System.Collections.Generic;
using App.Entities;
using App.Exceptions;
using App.Extensions;
using App.Interfaces;

namespace App.Controllers
{
    public class SignController : ISignController
    {
        private readonly ISignService _signService;
        
        private readonly List<string> _commands = new List<string>{"in", "up"};
        public User User { get; set; }

        public SignController(ISignService signService)
        {
            _signService = signService;
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
                if (command == "in")
                    SignIn();
                else if (command == "up") SignUp();
            }
        }

        public void SignUp()
        {
            var name = RequestPrompt("Enter name");
            var email = RequestPrompt("Enter email");
            var password = RequestPrompt("Enter password");
            try
            { 
                _signService.SignUp(name, email, password);
            }
            catch (InvalidEmailException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidPasswordException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (UserWithEmailAlreadyExists e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SignIn()
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