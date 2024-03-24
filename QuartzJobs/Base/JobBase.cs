using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFA.X.JobScheduler.Base
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
