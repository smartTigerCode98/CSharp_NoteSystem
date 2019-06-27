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
        private readonly IGuardService _guardService;
        private readonly IEmailValidator _emailValidator;
        private readonly IPasswordValidator _passwordValidator;
        
        public SignController(ISignService signService, IGuardService guardService,
                              IEmailValidator emailValidator,
                              IPasswordValidator passwordValidator)
        {
            _signService = signService;
            _guardService = guardService;
            _emailValidator = emailValidator;
            _passwordValidator = passwordValidator;
        }
        
        public void Run()
        {
            while (!_guardService.SignedIn)
            {
                var commandString = RequestPrompt("Sign in(in) : Sign up(up)");
                
                if (!System.Enum.TryParse(commandString, true, out SignCommand command))
                {
                    Console.WriteLine("Invalid command. Please try again");
                    continue;
                }
                
                switch (command)
                {
                    case SignCommand.In:
                        SignIn();
                        break;
                    case SignCommand.Up:
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
                _guardService.StoreUser(_signService.SignIn(email, password));
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