using MFA.X.JobScheduler.Base;
using Microsoft.Extensions.Logging;

namespace QuartzJobs
{
    public class HelloWorldJob1 : JobBase<HelloWorldJob1, int>
    {
        public HelloWorldJob1( ILogger<HelloWorldJob1> logger) : base(logger)
        {
            RunMode = RunMode.Serial;

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
