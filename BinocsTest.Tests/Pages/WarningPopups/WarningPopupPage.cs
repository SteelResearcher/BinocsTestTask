using BinocsTest.Test.Pages.Base;
using OpenQA.Selenium;

namespace BinocsTest.Test.Pages.WarningPopups
{
    public class WarningPopupPage : BasePage
    {
        public IWebElement PopupContainer => driver.FindElement(By.CssSelector("div #messagePopUp"));
        public IWebElement PopUpMessage => PopupContainer.FindElement(By.ClassName("messageContent"));
    }
}
