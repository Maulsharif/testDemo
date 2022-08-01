using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using testDemo.Data;
using testDemo.IRepo;
using testDemo.IServices;
using testDemo.Repo;
using testDemo.Services;

namespace testDemo.Config
{
    public static class ServiceRegistration
    {
        public static void Setup(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFlightRepository, FlightRepo>();
            services.AddScoped<IUserRepository, UserRepo>();
            services.AddScoped<IRoleRepository, RoleRepo>();
            services.AddScoped<IFlightFilter, FilterService>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }   
}
