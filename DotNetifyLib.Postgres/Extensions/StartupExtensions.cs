using Microsoft.Extensions.DependencyInjection;
 
namespace DotNetify.Postgres
{
    using System.Linq;
    public static class StartupExtensions
    {
        public static IServiceCollection AddDotNetifyPostgres(this IServiceCollection services, PostgresConfiguration config)
        {
            services.AddSingleton(config);
            services.AddSingleton<IPostgresReplicationSubscriber, PostgresReplicationSubscriber>();
            services.AddSingleton<IDbChangeObserver, DbChangeObserver>();
            return services;
        }


        public static IServiceCollection RegisterPostgresReplicationSubscriber(this IServiceCollection services, PostgresConfiguration config)
        {
            return services.AddSingleton<IPostgresReplicationSubscriber>(x =>
             {
                 return new PostgresReplicationSubscriber(config);
             });
        }

        public static IServiceCollection RegisterDbChangeObserver(this IServiceCollection services, string publisherName)
        {
            return services.AddSingleton<IDbChangeObserver>(x =>
            {
                var postgresReplicationSubscribers = x.GetServices<IPostgresReplicationSubscriber>();
                var postgresReplicationSubscriber = postgresReplicationSubscribers.FirstOrDefault(x => x.PublicationName == publisherName);
                return new DbChangeObserver(postgresReplicationSubscriber);
            });
        }

    }
}