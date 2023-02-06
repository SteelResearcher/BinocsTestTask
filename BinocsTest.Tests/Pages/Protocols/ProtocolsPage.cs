using BinocsTest.Test.Pages.Base;
using OpenQA.Selenium;

namespace BinocsTest.Test.Pages.Protocols
{
    public class ProtocolsPage : BasePage
    {
        public IWebElement ProtocolsNavigationTab => driver.FindElement(By.ClassName("ProtocolsTab"));
        public IWebElement AddNewProtocolButton => driver.FindElement(By.Id("addProtocolBtn"));
        public IWebElement ProtocolsTableSection => driver.FindElement(By.ClassName("protocolsTable"));
        public IWebElement TableRecordElement(string protocolTitle) => ProtocolsTableSection.FindElement(By.Name(protocolTitle));
    }
}
