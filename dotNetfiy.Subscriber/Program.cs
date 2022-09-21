using dotNetfiy.Subscriber.EDMX;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace dotNetfiy.Subscriber;

public static class Program
{

    internal static IConfiguration Configuration { get; private set; }

    public static async Task Main(string[] args)
    {
        var hostBuilder = CreateWebHostBuilder(args).Build();
        using IServiceScope serviceScope = hostBuilder.Services.CreateScope();
        var services = serviceScope.ServiceProvider;
        var userPIIchangeObserver = services.GetRequiredService<UserPIIDbChangeObserver>();
         var userPersonachangeObserver = services.GetRequiredService<UserPersonaDbChangeObserver>();
        await hostBuilder.RunAsync();
    }

    internal static IHostBuilder CreateWebHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
             .ConfigureAppConfiguration(app =>
             {
                 var builder = app.AddJsonFile("appsettings.json", false, true);
                 Configuration = builder.Build();
             })
             .ConfigureServices(services =>
             {
                 services.RegisterPostgresReplicationSubscriber(new PostgresConfiguration
                 {
                     ConnectionString = Configuration.GetConnectionString("UserPIIPostgres"),
                     PublicationName = "poc_logicaldecoding_pub",
                     ReplicationSlotName = "poc_logicaldecoding_slot"
                 });

                 services.RegisterPostgresReplicationSubscriber(new PostgresConfiguration
                 {
                    ConnectionString = Configuration.GetConnectionString("UserPersonaPostgres"),
                    PublicationName = "waltojson_pub_userpersona",
                     ReplicationSlotName = "pgoutput_userpersona_logicaldecoding_slot"
                 });
                 services.RegisterDbChangeObserver("poc_logicaldecoding_pub");
                 services.RegisterDbChangeObserver("waltojson_pub_userpersona");
                 services.AddSingleton<UserPIIDbChangeObserver>();
                  services.AddSingleton<UserPersonaDbChangeObserver>();
                 //services.AddDbContextFactory<UserPIIDbContext>(options =>
                 //  options.UseNpgsql(Configuration.GetConnectionString("Postgres"), options => options.EnableRetryOnFailure(3)));
                 //services.AddDbContextFactory<UserPersonaDbContext>(options =>
                 // options.UseNpgsql(Configuration.GetConnectionString("Postgres"), options => options.EnableRetryOnFailure(3)));
             });
}