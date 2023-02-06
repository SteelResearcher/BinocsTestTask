using System;
using BinocsTest.Test.DataModels.Resources;

namespace BinocsTest.Test.DataModels.Protocols
{
    public class ProtocolTaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public double Duration { get; set; }
        public TeamMemberData ScheduledTeamMember { get; set; }
        public EquipmentData ScheduledEquipment { get; set; }
        public DateTime ScheduledDateTime { get; set; } 
        
        public ProtocolTaskData(string taskName, double duration)
        {
            TaskName = taskName;
            Duration = duration;
        }
    }
}
