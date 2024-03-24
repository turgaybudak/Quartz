using Quartz;

namespace QuartzJobs.JobScheduler.Base
{
    public abstract class JobBase : IJob
    {
      

        public abstract Task Execute(IJobExecutionContext context);
        public virtual void Initialize()
        {
        }
        public virtual void Complete()
        {
        }
       
    }
}
