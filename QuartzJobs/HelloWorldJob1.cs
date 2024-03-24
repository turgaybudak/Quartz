using Microsoft.Extensions.Logging;
using Quartz;

namespace QuartzJobs
{
    public class HelloWorldJob1 : IJob
    {
        private readonly ILogger<HelloWorldJob1> _logger;

        public HelloWorldJob1(ILogger<HelloWorldJob1> logger)
        {
            _logger = logger;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Hello HelloWorldJob1!");
            return Task.CompletedTask;
        }
    }
}
