using BinocsTest.Test.Pages.Base;
using OpenQA.Selenium;

namespace BinocsTest.Test.Pages
{
    public class AlgorithmPage : BasePage
    {
        public IWebElement AlgorithmNavigationTab => driver.FindElement(By.ClassName("AlgorithmTab"));
        public IWebElement RunningStartDateField => driver.FindElement(By.CssSelector("div.start-date"));
        public IWebElement RunAlgorithmButton => driver.FindElement(By.Id("run-algorithm"));
    }
}
