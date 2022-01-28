using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Data;
using WebAPI.Extensions;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.MigrateDbContext<APIDBContext>((context, services) =>
            {
                var logger = services.GetService<ILogger<APIDBContextSeed>>();
                new APIDBContextSeed().SeedAsync(context, logger).Wait();
            });
            host.Run();

            //Call serilog
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
