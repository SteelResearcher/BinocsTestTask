using System;
using System.Reflection;
using BinocsTest.Test.DataModels.Jobs;

namespace BinocsTest.Test.Flows.Jobs
{
    // (!) Pages for this flow were not implemented
    public class JobsToScheduleFlow
    {
        public void NavigateToJobsToSchedulePage()
        {
            throw new NotImplementedException($"Method '{MethodBase.GetCurrentMethod()}' not implemented");
        }
        public int CreateNewJob(JobData jobData)
        {
            throw new NotImplementedException($"Method '{MethodBase.GetCurrentMethod()}' not implemented");
            //return JobID;
        }

        public bool IsJobPresentInTable(JobData jobData)
        {
            return true;
        }
    }
}
