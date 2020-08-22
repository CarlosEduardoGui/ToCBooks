using Microsoft.Extensions.DependencyInjection;
using ToCBooks.App.Data.Context;

namespace ToCBooks.App.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ToCBooksContext>();

            return services;
        }
    }
}