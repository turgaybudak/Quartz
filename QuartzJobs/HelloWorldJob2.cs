using Microsoft.Extensions.Logging;
using Quartz;

namespace QuartzJobs
{
    public class HelloWorldJob2 : IJob
    {
        private readonly ILogger<HelloWorldJob2> _logger;

        public HelloWorldJob2(ILogger<HelloWorldJob2> logger)
        {
            _logger = logger;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Hello HelloWorldJob2!");
            return Task.CompletedTask;
        }
    }
}
