using BinocsTest.Test.DataModels.Resources;
using BinocsTest.Test.Pages.Resources;

namespace BinocsTest.Test.Flows.Resources
{
    public class ResourcesPageFlow
    {
        private ResourcesPage ResourcesPage => new ();

        public void NavigateToResourcesPage()
        {
            ResourcesPage.ResourcesNavigationTab.Click();
        }

        public bool IsTeamMemberPresentInTable(TeamMemberData teamMemberData)
        {
            return ResourcesPage.TeamMemberTableRecordElement(teamMemberData.Name).Displayed;
        }

        public bool IsEquipmentPresentInTable(EquipmentData equipmentData)
        {
            return ResourcesPage.EquipmentTableRecordElement(equipmentData.Name).Displayed;
        }
    }
}
