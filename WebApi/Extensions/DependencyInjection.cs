using Infrastructure.Extensions;


namespace WebApi.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Services da camada Application
            //services.AddApplication();

            // Services da camada Infrastructure
            services.AddInfrastructure(configuration);

            return services;
        }
    }
}
