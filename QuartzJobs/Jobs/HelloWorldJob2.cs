//using Microsoft.Extensions.Logging;
//using Quartz;

//namespace QuartzJobs
//{
//    public class HelloWorldJob2 : IJob
//    {
//        private readonly ILogger<HelloWorldJob2> _logger;

//        public HelloWorldJob2()
//        {

//        }

//        public Task Execute(IJobExecutionContext context)
//        {
//            _logger.LogInformation("Hello HelloWorldJob2!");
//            return Task.CompletedTask;
//        }
//    }
//}
using MFA.X.JobScheduler.Base;
using Microsoft.Extensions.Logging;

namespace QuartzJobs
{
    public class HelloWorldJob2 : JobBase<HelloWorldJob2, int>
    {

        public HelloWorldJob2(ILogger<HelloWorldJob2> logger) : base(logger)
        {
            RunMode = RunMode.Parallel;
        }

        public override DoWorkResult DoWork(int id)
        {
            try
            {
                return DoWorkInternal(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Misyon istatistikleri çekilirken hata oluştu: {id} - {ex}");
                return DoWorkResult.Exception;
            }
        }

        private DoWorkResult DoWorkInternal(int id)
        {
            bool succeed = false;
            _logger.LogInformation($"İş yaptım iş bak: {id}");
            return succeed ? DoWorkResult.Success : DoWorkResult.Fail;
        }

        public override ICollection<int> GetData()
        {
            var items = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            return items;
        }

        public override string GetKey(int data)
        {
            return data.ToString();
        }
    }
}
