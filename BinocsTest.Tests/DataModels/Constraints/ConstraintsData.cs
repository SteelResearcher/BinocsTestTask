namespace BinocsTest.Test.DataModels.Constraints
{
    public class ConstraintsData
    {
        public string Task2Rule { get; set; }
        public string Task3Rule { get; set; }

        public ConstraintsData(string task2Rule, string task3Rule)
        {
            Task2Rule = task2Rule;
            Task3Rule = task3Rule;
        }
    }
}
