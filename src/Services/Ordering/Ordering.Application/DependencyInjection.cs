using BuildingBlocks.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //services.AddMediatR(config =>
        //{
        //    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
        //    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        //    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
        //});
        return services;
    }
}
