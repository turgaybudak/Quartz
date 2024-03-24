using Microsoft.Extensions.Logging;
using Quartz;
using QuartzJobs;

namespace MFA.X.JobScheduler.Base
{
    public abstract class JobBase<TJob, TData> : JobBase where TJob : JobBase<TJob, TData>
    {
        protected readonly ILogger<TJob> _logger;
        public RunMode RunMode { get; set; }



        protected JobBase( ILogger<TJob> logger)
        {
            _logger = logger;
        }


        public override Task Execute(IJobExecutionContext context)
        {
           return Executer(context);
        }

        private Task Executer(IJobExecutionContext context)
        {
            if (RunMode == RunMode.Serial && GetExecutingJobCount(context) > 1)
            {
                _logger.LogInformation("Zaten çalışan job mevcut  [{0}:{1}]", RunMode, context.JobDetail.JobType);
            }

            Initialize();
            var data = GetData();
            if (data != null)
            {
                if (RunMode == RunMode.Parallel)
                {
                    try
                    {
                        Parallel.ForEach(data, item =>
                        {
                            try
                            {
                                DoWork(item);
                            }
                            catch (Exception ex)
                            {
                                _logger.LogInformation("DoWork Sırasında Hata", ex);
                            }
                        });
                    }
                    catch (AggregateException ae)
                    {
                        foreach (var ex in ae.InnerExceptions)
                        {
                            _logger.LogInformation("Parallel.ForEach İçinde Hata", ex);
                        }
                    }
                }
                else if (RunMode == RunMode.Serial)
                {
                    int order = 1;
                    int total = data.Count();
                    foreach (var item in data)
                    {
                        try
                        {
                            DoWork(item);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogInformation("DoWork Sırasında Hata", ex);
                        }

                        _logger.LogInformation($"{order}/{total}");
                        order += 1;
                    }
                }
            }
            Complete();
            return Task.CompletedTask;
        }

        private int GetExecutingJobCount(IJobExecutionContext context)
        {
            var executingJobsTask = context.Scheduler.GetCurrentlyExecutingJobs();
            executingJobsTask.Wait(); // Task tamamlanana kadar bekleyin
            var executingJobs = executingJobsTask.Result;
            var count = executingJobs.Count();
            return count;
        }


        public abstract ICollection<TData> GetData();
        public abstract DoWorkResult DoWork(TData data);
        public abstract string GetKey(TData data);
    }

}
