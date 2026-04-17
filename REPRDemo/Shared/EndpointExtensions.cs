using System.Reflection;

namespace REPRDemo.Shared
{
    public static class EndpointExtensions
    {
        public static IServiceCollection AddEndpoints(this IServiceCollection services, Assembly assembly)
        {
            var endpointTypes = assembly.GetTypes()
                .Where(t => typeof(IEndpoint).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);
            foreach (var type in endpointTypes)
            {
               services.AddTransient(typeof(IEndpoint), type);
            }
            return services;
        }

        public static IApplicationBuilder MapEndpoints(this WebApplication app)
        {
            var endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();

            foreach (var endpoint in endpoints)
            {
                typeof(IEndpoint)
                    .GetMethod("Map")!
                    .Invoke(endpoint, new object[] { app });
            }

            return app;
        }
    }
}
