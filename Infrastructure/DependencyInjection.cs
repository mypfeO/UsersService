using Domain.Reposotires;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryStudent, MongoRepositoryStudent>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
