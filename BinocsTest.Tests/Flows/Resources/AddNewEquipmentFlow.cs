using BinocsTest.Test.Pages.Resources;

namespace BinocsTest.Test.Flows.Resources
{
    public class AddNewEquipmentFlow : AddNewResourceBaseFlow
    {
        protected override AddNewResourceBasePopup AddResourcePage => new AddNewEquipmentPopup();
        private ResourcesPage ResourcesPage => new ();

        protected override void ClickAddNewResourceButton()
        {
            ResourcesPage.AddNewEquipmentButton.Click();
        }
    }
}
