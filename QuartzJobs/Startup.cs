using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace QuartzJobs
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IJobFactory, JobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            services.AddHostedService<QuartzHostedService>();

            services.AddSingleton<HelloWorldJob1>();
            services.AddSingleton(new JobSchedule(jobType: typeof(HelloWorldJob1), cronExpression: "0/10 * * * * ?"));// 10 saniye

            services.AddSingleton<HelloWorldJob2>();
            services.AddSingleton(new JobSchedule(jobType: typeof(HelloWorldJob2), cronExpression: "0/5 * * * * ?")); // 5 saniye

        }

    }
}
