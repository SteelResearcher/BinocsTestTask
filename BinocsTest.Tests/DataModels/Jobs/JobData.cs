using System;
using BinocsTest.Test.DataModels.Protocols;

namespace BinocsTest.Test.DataModels.Jobs
{
    public class JobData
    {
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public ProtocolData ProtocolData { get; set; }
        public string Order { get; set; }
        public int Priority { get; set; }
        public DateTime EarliestStartDate { get; set; }
        public DateTime DueDate { get; set; }

        public JobData WithProtocol(ProtocolData protocolData)
        {
            ProtocolData = protocolData;
            return this;
        }

        public JobData WithOrder(string order)
        {
            Order = order;
            return this;
        }

        public JobData WithPriority(int priority)
        {
            Priority = priority;
            return this;
        }

        public JobData WithEarliestStartDate(DateTime dateTime)
        {
            EarliestStartDate = dateTime;
            return this;
        }

        public JobData WithDueDate(DateTime dateTime)
        {
            DueDate = dateTime;
            return this;
        }
    }
}
