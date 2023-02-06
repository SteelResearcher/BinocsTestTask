using System;
using System.Globalization;
using BinocsTest.Core.Extensions;
using BinocsTest.Test.Pages;

namespace BinocsTest.Test.Flows
{
    public class AlgorithmFlow
    {
        private AlgorithmPage AlgorithmPage => new();

        public void NavigateToAlgorithmPage()
        {
            AlgorithmPage.AlgorithmNavigationTab.Click();
        }

        public void RunAlgorithmFrom(DateTime dateTime)
        {
            SetRunningStartDate(dateTime);
            ClickRunButton();
        }

        private void SetRunningStartDate(DateTime dateTime)
        {
            AlgorithmPage.RunningStartDateField.InsertText(dateTime.ToString(CultureInfo.InvariantCulture));
        }

        private void ClickRunButton()
        {
            AlgorithmPage.RunAlgorithmButton.Click();
        }
    }
}
