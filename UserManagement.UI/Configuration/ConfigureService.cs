using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.UI.Providers.ApiClients;
using UserManagement.UI.Providers.Contracts;
using UserManagementApplication.Contracts;
using UserManagementApplication.Services;
using UserManagementDataAccess.Contracts;
using UserManagementDataAccess.Repository;

namespace UserManagement.UI.Configuration
{
    public static class ConfigureService
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddHttpClient<IUserApiClient, UserApiClient>(httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://localhost:5001");
                
            });
        }
    }
           
}
