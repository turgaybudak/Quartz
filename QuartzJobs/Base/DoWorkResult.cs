using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MFA.X.JobScheduler.Base
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
