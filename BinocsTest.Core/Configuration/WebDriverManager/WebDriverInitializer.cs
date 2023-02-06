using System;
using BinocsTest.Core.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BinocsTest.Core.Configuration.WebDriverManager
{
    public static class WebDriverInitializer
    {
        public static IWebDriver Driver { get; private set; }
        
        public static void InitDriver(Environments.Environments environment)
        {
            Driver = new ChromeDriver(DriverPathGetter.GetChromedriverPath());
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Driver.Navigate().GoToUrl(environment.WebUrl);
        }
    }
}
