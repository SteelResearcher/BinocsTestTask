using System;
using System.Globalization;
using BinocsTest.Core.Extensions;
using BinocsTest.Test.DataModels.Protocols;
using BinocsTest.Test.Pages.Protocols;

namespace BinocsTest.Test.Flows.Protocols
{
    public class ProtocolsFlow
    {
        private ProtocolsPage ProtocolsPage => new();
        private AddNewProtocolPopup AddNewProtocolPopup => new ();

        public void NavigateToProtocolsPage()
        {
            ProtocolsPage.ProtocolsNavigationTab.Click();
        }

        public void CreateNewProtocol(ProtocolData data)
        {
            ClickAddNewProtocolButton();
            InsertProtocolTitle(data);

            foreach (var taskData in data.TaskList)
            {
                ClickAddNewTaskButton();
                AddNewProtocolTask(taskData);
            }

            ClickSaveProtocolButton();
        }

        public bool IsProtocolPresentInTable(ProtocolData data)
        {
            return ProtocolsPage.TableRecordElement(data.Title).Displayed;
        }

        private void ClickAddNewProtocolButton()
        {
            ProtocolsPage.AddNewProtocolButton.Click();
        }

        private void ClickAddNewTaskButton()
        {
            AddNewProtocolPopup.AddNewTaskButton.Click();
        }

        private void ClickSaveProtocolButton()
        {
            AddNewProtocolPopup.SaveProtocolButton.Click();
        }

        private void InsertProtocolTitle(ProtocolData data)
        {
            AddNewProtocolPopup.ProtocolTitleField.InsertText(data.Title);
        }

        private void AddNewProtocolTask(ProtocolTaskData data)
        {
            AddNewProtocolPopup.TaskNameField.SendKeys(data.TaskName);
            AddNewProtocolPopup.TaskDurationField.SendKeys(Convert.ToString(data.Duration, CultureInfo.InvariantCulture));
        }
    }
}
