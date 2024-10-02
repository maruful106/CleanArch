using CleanArch.Application;
using CleanArch.Infrastructure;

namespace CleanArch.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiDI(this IServiceCollection service)
        {
            service.AddApplicationDI()
                .AddInfrastructureDI();
            return service;
        }
    }
}
