using MFA.X.JobScheduler.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using QuartzJobs.Infrastructure;

namespace QuartzJobs
{
    public static class ConfiguredServices
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddSingleton<IJobFactory, JobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            services.AddHostedService<QuartzHostedService>();

            services.AddSingleton<HelloWorldJob1>();
            services.AddSingleton(new JobSchedule(jobType: typeof(HelloWorldJob1), cronExpression: "0/59 * * * * ?"));// 10 saniye

            services.AddSingleton<HelloWorldJob2>();
            services.AddSingleton(new JobSchedule(jobType: typeof(HelloWorldJob2), cronExpression: "0/30 * * * * ?")); // 5 saniye


        }

    }
}
