using CleanArch.Application;
using CleanArch.Infrastructure;

namespace CleanArch.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiDI(this IServiceCollection service,IConfiguration configuration)
        {
            service.AddApplicationDI()
                .AddInfrastructureDI(configuration);
            return service;
        }
    }
}
