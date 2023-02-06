using OpenQA.Selenium;

namespace BinocsTest.Test.Pages.Resources
{
    public class AddNewTeamMemberPopup : AddNewResourceBasePopup
    {
        public override IWebElement ResourceTitleField => driver.FindElement(By.Id("team-member title"));
        public override IWebElement ResourceAvailabilityField => driver.FindElement(By.CssSelector("input #hours"));
        public override IWebElement SaveResourceButton => driver.FindElement(By.CssSelector("button #save"));
    }
}
