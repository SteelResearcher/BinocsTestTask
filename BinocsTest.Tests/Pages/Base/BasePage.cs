using BinocsTest.Core.Configuration.Environments;
using BinocsTest.Core.Configuration.WebDriverManager;
using BinocsTest.Core.Utils;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BinocsTest.Test.Pages.Base
{
    public class BasePage
    {
        protected static IWebDriver driver;

        protected const string Environment = "TestEnvironment";
        protected readonly JsonReader JsonReader = new();
        protected Environments Environments;

        [OneTimeSetUp]
        public void BeforeAll()
        {
            Environments = GetEnvironment();
            WebDriverInitializer.InitDriver(Environments);
            driver = WebDriverInitializer.Driver;
        }

        [OneTimeTearDown]
        public void AfterAllUiTests()
        {
            driver.Quit();
        }

        private Environments GetEnvironment()
        {
            return JsonReader.GetFileContent<Environments>(Environment, "environments");
        }
    }
}
