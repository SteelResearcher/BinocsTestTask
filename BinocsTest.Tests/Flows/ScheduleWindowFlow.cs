using System;
using System.Globalization;
using BinocsTest.Core.Extensions;
using BinocsTest.Test.DataModels;
using BinocsTest.Test.Pages;

namespace BinocsTest.Test.Flows
{
    public class ScheduleWindowFlow
    {
        private ScheduleWindowPage ScheduleWindowPage => new();

        public void NavigateToScheduleWindow()
        {
            ScheduleWindowPage.ScheduleWindowNavigationTab.Click();
        }

        public void InsertScheduleWindowData(ScheduleWindowData data)
        {
            SetWindowStartDate(data.StartDate);
            SetWindowEndDate(data.EndDate);
            ClickSave();
        }

        private void SetWindowStartDate(DateTime startDate)
        {
            ScheduleWindowPage.WindowStartDateField.InsertText(startDate.ToString(CultureInfo.InvariantCulture));
        }

        private void SetWindowEndDate(DateTime endDate)
        {
            ScheduleWindowPage.WindowEndDateField.InsertText(endDate.ToString(CultureInfo.InvariantCulture));
        }

        private void ClickSave()
        {
            ScheduleWindowPage.SaveButton.Click();
        }
    }
}
