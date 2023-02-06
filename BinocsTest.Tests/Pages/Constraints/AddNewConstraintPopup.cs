using BinocsTest.Test.Pages.Base;
using OpenQA.Selenium;

namespace BinocsTest.Test.Pages.Constraints
{
    public class AddNewConstraintPopup : BasePage
    {
        public IWebElement Task2RuleField => driver.FindElement(By.Id("task2-rule"));
        public IWebElement Task3RuleField => driver.FindElement(By.Id("task2-rule"));
        public IWebElement SaveConstraintButton => driver.FindElement(By.CssSelector("button #save"));
    }
}
