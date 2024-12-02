using AuthForm.Application.Services;
using AuthForm.Application.Services.Interfaces;
using AuthForm.Infrastucture.Repositories;
using AuthForm.Infrastucture.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthForm.Application
{
    public static class ServicesRegistration
    {
        public static void RegistrationLogger(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var loggerUser = serviceProvider.GetRequiredService<ILogger<UserService>>();
            services.AddSingleton(typeof(ILogger), loggerUser);
        }
        public static void RegistrationRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();

        }
        public static void RegistrationServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
        }

    }
}
