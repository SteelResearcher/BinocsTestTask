using BinocsTest.Core.Extensions;
using BinocsTest.Test.DataModels.Constraints;
using BinocsTest.Test.Pages.Constraints;

namespace BinocsTest.Test.Flows.Constraints
{
    public class ConstraintsFlow
    {
        private ConstraintsPage ConstraintsPage => new();
        private AddNewConstraintPopup AddNewConstraintPopup => new();

        public void NavigateToConstraintsPage()
        {
            ConstraintsPage.ConstraintsNavigationTab.Click();
        }

        public void CreateNewConstraint(ConstraintsData data)
        {
            ClickAddNewConstraintButton();
            InsertTask2Rule(data);
            InsertTask3Rule(data);
            ClickSaveConstraintButton();
        }

        public bool IsConstraintPresentInTable(ConstraintsData data)
        {
            return ConstraintsPage.TableRecordElement(data.Task2Rule, data.Task3Rule).Displayed;
        }

        private void InsertTask2Rule(ConstraintsData data)
        {
            AddNewConstraintPopup.Task2RuleField.InsertText(data.Task2Rule);
        }

        private void InsertTask3Rule(ConstraintsData data)
        {
            AddNewConstraintPopup.Task2RuleField.InsertText(data.Task3Rule);
        }

        private void ClickSaveConstraintButton()
        {
            AddNewConstraintPopup.SaveConstraintButton.Click();
        }

        private void ClickAddNewConstraintButton()
        {
            ConstraintsPage.AddNewConstraintsButton.Click();
        }
    }
}
