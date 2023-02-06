using System;
using System.Reflection;
using BinocsTest.Test.DataModels.Jobs;

namespace BinocsTest.Test.Flows.Jobs
{
    // (!) Pages for this flow were not implemented
    public class ScheduledJobsFlow
    {
        public void NavigateToScheduledJobsPage()
        {
            throw new NotImplementedException($"Method '{MethodBase.GetCurrentMethod()}' not implemented");
        }
        public JobData GetScheduledJobData(JobData jobData)
        {
            throw new NotImplementedException($"Method '{MethodBase.GetCurrentMethod()}' not implemented");
        }

        public bool IsJobPresentInTable(JobData jobData)
        {
            return true;
        }
    }
}
