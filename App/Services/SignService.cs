using System;
using App.Entities;
using App.Exceptions;
using App.Extensions;
using App.Interfaces;

namespace App.Services
{
    public class SignService : ISignService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        
        public SignService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }
        
        public User SignUp(string name, string email, string password)
        {
            
            if (_userRepository.EmailIsAlreadyUse(email))
            {
                throw new UserWithEmailAlreadyExists(email);
            }
            
            var user = new User(name, email, _passwordHasher.Hash(password));

            _userRepository.AddUser(user);

            return user;
        }

        public User SignIn(string email, string password)
        {
            var user = _userRepository.FindByEmail(email);

            if (user == null)
            {
                throw new UserNotFoundException(email);
            }

            if (!_passwordHasher.Verify(user.PasswordHash, password))
            {
                throw new PasswordMismatchException(password);
            }
            
            Console.WriteLine($"{user.Name} you are welcome!");

            return user;
        }
    }
}