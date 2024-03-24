namespace QuartzJobs.JobScheduler.Base
{
    public enum DoWorkResult
    {
        Unknown = 0,
        Success = 10,
        Fail = 20,
        Inconclusive = 30,
        Error = 40,
        Exception = 50,
    }
}
