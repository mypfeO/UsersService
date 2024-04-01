using Application.Services.Auth;
using Application.Services.Iservices;
using Domain.Reposotires;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Common
{
    public static class MediatRExtensions
    {
        public static IServiceCollection AddConfigureHandler(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.Load("Application"));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
