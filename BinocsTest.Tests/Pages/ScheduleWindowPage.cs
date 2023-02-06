using BinocsTest.Test.Pages.Base;
using OpenQA.Selenium;

namespace BinocsTest.Test.Pages
{
    public class ScheduleWindowPage : BasePage
    {
        public IWebElement ScheduleWindowNavigationTab => driver.FindElement(By.ClassName("ScheduleWindowTab"));
        public IWebElement WindowStartDateField => driver.FindElement(By.CssSelector("#windows-start-date"));
        public IWebElement WindowEndDateField => driver.FindElement(By.CssSelector("#windows-end-date .endDate"));
        public IWebElement SaveButton => driver.FindElement(By.XPath("//form/input[@type='submit']"));
    }
}
