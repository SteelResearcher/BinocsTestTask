using BinocsTest.Test.Pages.Base;
using OpenQA.Selenium;

namespace BinocsTest.Test.Pages.Constraints
{
    public class ConstraintsPage : BasePage
    {
        public IWebElement ConstraintsNavigationTab => driver.FindElement(By.ClassName("ConstraintsTab"));
        public IWebElement AddNewConstraintsButton => driver.FindElement(By.Id("addConstraintsBtn"));
        public IWebElement ConstraintsTableSection => driver.FindElement(By.ClassName("constraintsTable"));
        public IWebElement TableRecordElement(string task2rule, string task3rule) => ConstraintsTableSection.FindElement(By.XPath($"//div[@id='{task2rule}']/following-sibling::div[@id='{task3rule}']"));
    }
}
