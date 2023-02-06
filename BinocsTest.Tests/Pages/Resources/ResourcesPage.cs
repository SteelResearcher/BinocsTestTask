using BinocsTest.Test.Pages.Base;
using OpenQA.Selenium;

namespace BinocsTest.Test.Pages.Resources
{
    public class ResourcesPage : BasePage
    {
        public IWebElement ResourcesNavigationTab => driver.FindElement(By.ClassName("ResTab"));
        public IWebElement AddNewTeamMemberButton => driver.FindElement(By.Id("addTMBtn"));
        public IWebElement AddNewEquipmentButton => driver.FindElement(By.Id("addEQBtn"));
        public IWebElement TeamMemberTableSection => driver.FindElement(By.Name("TmTable"));
        public IWebElement EquipmentTableSection => driver.FindElement(By.Name("EqTable"));
        public IWebElement TeamMemberTableRecordElement(string protocolTitle) => TeamMemberTableSection.FindElement(By.Name(protocolTitle));
        public IWebElement EquipmentTableRecordElement(string protocolTitle) => EquipmentTableSection.FindElement(By.Name(protocolTitle));

    }
}
