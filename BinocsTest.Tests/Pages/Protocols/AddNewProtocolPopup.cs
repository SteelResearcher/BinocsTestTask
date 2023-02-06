using BinocsTest.Test.Pages.Base;
using OpenQA.Selenium;

namespace BinocsTest.Test.Pages.Protocols
{
    public class AddNewProtocolPopup : BasePage
    {
        public IWebElement ProtocolTitleField => driver.FindElement(By.Id("protocol title"));
        public IWebElement TaskNameField => driver.FindElement(By.CssSelector("input #taskName"));
        public IWebElement TaskDurationField => driver.FindElement(By.CssSelector("input #taskDuration"));
        public IWebElement AddNewTaskButton => driver.FindElement(By.CssSelector("button #addTask"));
        public IWebElement SaveProtocolButton => driver.FindElement(By.CssSelector("button #save"));
    }
}
