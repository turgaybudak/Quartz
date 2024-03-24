using Microsoft.AspNetCore.Hosting;
using QuartzJobs;

namespace QuartzWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureServices((hostContext, services) => {
                ConfiguredServices.Configure(services);
            });
        }
    }
}