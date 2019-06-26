using System;
using App.Controllers;
using App.Interfaces;
using App.Repositories;
using App.Services;
using App.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace App
{
    class Program
    {
        private static readonly IServiceProvider ServiceProvider;

        static Program()
        {
            var containerBuilder = new ServiceCollection();
            containerBuilder.AddSingleton<IPasswordHasher, HashingService>()
                .AddScoped<IEmailValidator, EmailValidator>()
                .AddScoped<IPasswordValidator, PasswordValidator>()
                .AddSingleton<IUserRepository, LocalUserRepository>()
                .AddSingleton<INoteRepository, LocalNoteRepository>()
                .AddSingleton<ISignService, SignService>()
                .AddSingleton<INoteService, NoteService>()
                .AddScoped<SignController>()
                .AddScoped<NoteController>()
                .AddScoped<AppController>();
            
            ServiceProvider = containerBuilder.BuildServiceProvider();
        }
        
        static void Main(string[] args)
        {
            var controller = ServiceProvider.GetRequiredService<AppController>();
            
            controller.Run();
        }
    }
}
