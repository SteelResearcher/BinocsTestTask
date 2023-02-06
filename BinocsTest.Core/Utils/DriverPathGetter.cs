using System;
using System.IO;

namespace BinocsTest.Core.Utils
{
    public static class DriverPathGetter
    {
        public static string GetChromedriverPath()
        {
            return Path.Combine(Environment.CurrentDirectory, "Drivers", "chromedriver");
        }
    }
}

