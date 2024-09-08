using System.Reflection;
using FluentValidation;

namespace ClinicManagementSystem.API.Services;

public static class ServiceExtensions
{
    public static void ConfigureApplicationApp(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}