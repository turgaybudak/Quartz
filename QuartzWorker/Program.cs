using Quartz.Logging;
using QuartzJobs;
using LogLevel = Quartz.Logging.LogLevel;

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
            return Host.CreateDefaultBuilder(args).UseWindowsService().ConfigureServices((hostContext, services) =>
            {
                ConfiguredServices.Configure(hostContext, services);
            });
        }



    }

}