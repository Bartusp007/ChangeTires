using Microsoft.Extensions.DependencyInjection;

namespace Hedin.ChangeTires.Infrastructure.Validators
{
    public static class ValidatorsRegistry
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<ICarTypeValidator, CarTypeValidator>();

            return services;
        }
    }
}

