using System;

namespace BinocsTest.Test.DataModels
{
    public class ScheduleWindowData
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ScheduleWindowData(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
