using BinocsTest.Test.Pages.Base;
using OpenQA.Selenium;

namespace BinocsTest.Test.Pages.Resources
{
    public class AddNewEquipmentPopup : AddNewResourceBasePopup
    {
        public override IWebElement ResourceTitleField => driver.FindElement(By.Id("equip title"));
        public override IWebElement ResourceAvailabilityField => driver.FindElement(By.CssSelector("input #hours"));
        public override IWebElement SaveResourceButton => driver.FindElement(By.CssSelector("button #save"));
    }
}
