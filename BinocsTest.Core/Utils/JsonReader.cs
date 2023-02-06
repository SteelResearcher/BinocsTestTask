using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace BinocsTest.Core.Utils
{
    public class JsonReader
    {
        private readonly string _directory = Environment.CurrentDirectory;
        private JObject _file;

        public JObject ReadFile(string filename)
        {
            try
            {
                using StreamReader reader = new StreamReader(Path.Combine(_directory, $"Configuration\\Environments\\{filename}.json"));
                var json = reader.ReadToEnd();
                _file = JObject.Parse(json);
                return _file;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Method: {MethodBase.GetCurrentMethod()}; Error: {e.Message}");
                throw;
            }
        }

        public T GetFileContent<T>(string rootObjectName, string filename) where T : class
        {
            _file = ReadFile(filename);
            return _file[rootObjectName]?.ToObject<T>();
        }
    }
}
