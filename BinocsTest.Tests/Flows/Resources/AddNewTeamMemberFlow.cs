using BinocsTest.Test.Pages.Resources;

namespace BinocsTest.Test.Flows.Resources
{
    public class AddNewTeamMemberFlow : AddNewResourceBaseFlow
    {
        protected override AddNewResourceBasePopup AddResourcePage => new AddNewTeamMemberPopup();
        private ResourcesPage ResourcesPage => new();

        protected override void ClickAddNewResourceButton()
        {
            ResourcesPage.AddNewTeamMemberButton.Click();
        }
    }
}