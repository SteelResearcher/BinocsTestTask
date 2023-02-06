using System;
using BinocsTest.Core.Utils;
using BinocsTest.Test.DataModels.Jobs;

namespace BinocsTest.Test.DataGeneration.Jobs
{
    public static class JobDataGeneration
    {
        public static JobData DefaultJobData()
        {
            return new JobData()
            {
                JobTitle = FakeData.Faker.Random.AlphaNumeric(5),
                Priority = FakeData.Faker.Random.Number(0, 100),
                EarliestStartDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(1)
            }
        }
    }
}
