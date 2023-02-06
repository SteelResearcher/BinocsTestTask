using BinocsTest.Test.Pages.WarningPopups;

namespace BinocsTest.Test.Flows.WarmingPopups
{
    public class WarningPopupsFlow
    {
        private WarningPopupPage WarningPopupPage => new();

        public bool IsWarningPopupDisplayed()
        {
            return WarningPopupPage.PopupContainer.Displayed;
        }

        public string GetPopupMessage()
        {
            return WarningPopupPage.PopUpMessage.Text;
        }
    }
}
