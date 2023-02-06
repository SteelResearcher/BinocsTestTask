using System;
using System.Reflection;
using BinocsTest.Core.Extensions;
using BinocsTest.Test.DataModels.Resources;
using BinocsTest.Test.Pages.Resources;

namespace BinocsTest.Test.Flows.Resources
{
    public class AddNewResourceBaseFlow
    {
        protected virtual AddNewResourceBasePopup AddResourcePage { get; set; }

        public void CreateNewResource(BaseResourceData data)
        {
            ClickAddNewResourceButton();
            InsertResourceTitle(data);
            InsertResourceAvailability(data);
            ClickSaveButton();
        }
        
        protected void InsertResourceTitle(BaseResourceData data)
        {
            AddResourcePage.ResourceTitleField.InsertText(data.Name);
        }

        protected void InsertResourceAvailability(BaseResourceData data)
        {
            AddResourcePage.ResourceTitleField.InsertText(data.Availability.ToString());
        }

        protected void ClickSaveButton()
        {
            AddResourcePage.SaveResourceButton.Click();
        }

        protected virtual void ClickAddNewResourceButton()
        {
            throw new NotImplementedException($"Base method '{MethodBase.GetCurrentMethod()}' not implemented");
        }
    }
}