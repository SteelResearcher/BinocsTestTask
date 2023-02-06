using System.Collections.Generic;

namespace BinocsTest.Test.DataModels.Protocols
{
    public class ProtocolData
    {
        public string Title { get; set; }
        public List<ProtocolTaskData> TaskList { get; private set; }

        public ProtocolData AddTaskList(List<ProtocolTaskData> taskList)
        {
            TaskList ??= new List<ProtocolTaskData>();
            TaskList.AddRange(taskList);
            return this;
        }

        public ProtocolData AddTask(ProtocolTaskData taskList)
        {
            TaskList ??= new List<ProtocolTaskData>();
            TaskList.Add(taskList);
            return this;
        }

        public ProtocolData WithTitle(string title)
        {
            Title = title;
            return this;
        }
    }
}
