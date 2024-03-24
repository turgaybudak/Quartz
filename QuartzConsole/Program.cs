using QuartzJobs;
using Microsoft.Extensions.Hosting;

namespace QuartzConsole
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
