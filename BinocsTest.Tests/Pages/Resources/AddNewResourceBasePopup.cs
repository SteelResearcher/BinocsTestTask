using BinocsTest.Test.Pages.Base;
using OpenQA.Selenium;

namespace BinocsTest.Test.Pages.Resources
{
    public class AddNewResourceBasePopup : BasePage
    {
        public virtual IWebElement ResourceTitleField => default;
        public virtual IWebElement ResourceAvailabilityField => default;
        public virtual IWebElement SaveResourceButton => default;
    }
}
