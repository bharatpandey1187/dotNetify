using DotNetify.Console.EDMX;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetify.Console;

public static class Program
{

    internal static IConfiguration Configuration { get; private set; }

    public static async Task Main(string[] args)
    {
        await CreateWebHostBuilder(args).Build().RunAsync();
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
                 services.AddDotNetifyPostgres(new PostgresConfiguration
                 {
                     ConnectionString = Configuration.GetConnectionString("Postgres"),
                     PublicationName = "dotnetify_pub",
                     ReplicationSlotName = "dotnetify_slot"
                 });

                 //services.AddDbContextFactory<UserPIIDbContext>(options =>
                 //   options.UseNpgsql(Configuration.GetConnectionString("Postgres"), options => options.EnableRetryOnFailure(3)));
             });
}