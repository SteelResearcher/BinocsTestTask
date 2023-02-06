namespace BinocsTest.Test.DataModels.Resources
{
    public class BaseResourceData
    {
        public string Name { get; set; }
        public double Availability { get; set; }

        public BaseResourceData(string name, double availability)
        {
            Name = name;
            Availability = availability;
        }
    }
}
