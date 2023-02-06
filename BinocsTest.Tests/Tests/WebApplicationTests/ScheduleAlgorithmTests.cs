using System;
using System.Collections.Generic;
using System.Linq;
using BinocsTest.Core.Utils;
using BinocsTest.Test.Constants;
using BinocsTest.Test.DataGeneration.Jobs;
using BinocsTest.Test.DataModels;
using BinocsTest.Test.DataModels.Constraints;
using BinocsTest.Test.DataModels.Protocols;
using BinocsTest.Test.DataModels.Resources;
using BinocsTest.Test.Flows;
using BinocsTest.Test.Flows.Constraints;
using BinocsTest.Test.Flows.Jobs;
using BinocsTest.Test.Flows.Protocols;
using BinocsTest.Test.Flows.Resources;
using BinocsTest.Test.Flows.WarmingPopups;
using BinocsTest.Test.Tests.Base;
using FluentAssertions;
using NUnit.Framework;

namespace BinocsTest.Test.Tests.WebApplicationTests
{
    public class ScheduleAlgorithmTests : BaseTest
    {
        private ScheduleWindowFlow ScheduleWindowFlow;
        private ProtocolsFlow ProtocolsFlow;
        private ResourcesPageFlow ResourcesPageFlow;
        private AddNewTeamMemberFlow AddNewTeamMemberFlow;
        private AddNewEquipmentFlow AddNewEquipmentFlow;
        private ConstraintsFlow ConstraintsFlow;
        private JobsToScheduleFlow JobsToScheduleFlow;
        private AlgorithmFlow AlgorithmFlow;
        private ScheduledJobsFlow ScheduledJobsFlow;
        private WarningPopupsFlow WarningPopupsFlow;

        [SetUp]
        public void Setup()
        {
            ScheduleWindowFlow = new ScheduleWindowFlow();
            ProtocolsFlow = new ProtocolsFlow();
            ResourcesPageFlow = new ResourcesPageFlow();
            AddNewTeamMemberFlow = new AddNewTeamMemberFlow();
            AddNewEquipmentFlow = new AddNewEquipmentFlow();
            ConstraintsFlow = new ConstraintsFlow();
            JobsToScheduleFlow = new JobsToScheduleFlow();
            AlgorithmFlow = new AlgorithmFlow();
            ScheduledJobsFlow = new ScheduledJobsFlow();
            WarningPopupsFlow = new WarningPopupsFlow();
        }
        
        [Test]
        public void JobScheduledWithTask2AtLeast1DayAfterTask1AndSameResource_0001()
        {
            var scheduleWindowStartDate = DateTime.Now;
            var scheduleWindowEndDate = scheduleWindowStartDate.AddMonths(1);
            var jobToScheduleEarliestStartDate = DateTime.Now.AddDays(1);
            var jobToScheduleDueDate = DateTime.Now.AddDays(3);
            var algorithmRunningStartDate = DateTime.Now;

            var scheduleWindowData = new ScheduleWindowData(scheduleWindowStartDate, scheduleWindowEndDate);
            var order = OrdersConstants.PredefinedOrder;

            var taskList = new List<ProtocolTaskData>
            {
                new(TaskConstants.TaskName1, 2),
                new(TaskConstants.TaskName2, 6),
                new(TaskConstants.TaskName3, 2)
            };
            var protocolData = new ProtocolData()
                .WithTitle(FakeData.Faker.Random.AlphaNumeric(5))
                .AddTaskList(taskList);

            var teamMemberAData = new TeamMemberData("TM-A", 8);
            var teamMemberBData = new TeamMemberData("TM-B", 8);
            var equipmentAData = new EquipmentData("EQ-A", 8);
            var equipmentBData = new EquipmentData("EQ-B", 8.2);

            var constraintData = new ConstraintsData(
                ConstraintsConstants.HasToHappenAtLeast1DayAfterTask1,
                ConstraintsConstants.Task3NeedsToBeDoneByTheSameResourceAsTask2);

            var jobToScheduleData = JobDataGeneration.DefaultJobData()
                .WithOrder(order)
                .WithProtocol(protocolData)
                .WithEarliestStartDate(jobToScheduleEarliestStartDate)
                .WithDueDate(jobToScheduleDueDate);


            ScheduleWindowFlow.NavigateToScheduleWindow();
            ScheduleWindowFlow.InsertScheduleWindowData(scheduleWindowData);

            ProtocolsFlow.NavigateToProtocolsPage();
            ProtocolsFlow.CreateNewProtocol(protocolData);
            var isProtocolCreated = ProtocolsFlow.IsProtocolPresentInTable(protocolData);
            isProtocolCreated.Should().BeTrue($"Created protocol '{protocolData.Title}' was not fount in the 'Protocols' table");

            AddNewTeamMemberFlow.CreateNewResource(teamMemberAData);
            var isTeamMemberCreated = ResourcesPageFlow.IsTeamMemberPresentInTable(teamMemberAData);
            isTeamMemberCreated.Should().BeTrue($"Team member '{teamMemberAData.Name}' was not fount in the 'Resources' table");

            AddNewTeamMemberFlow.CreateNewResource(teamMemberBData);
            isTeamMemberCreated = ResourcesPageFlow.IsTeamMemberPresentInTable(teamMemberBData);
            isTeamMemberCreated.Should().BeTrue($"Team member '{teamMemberBData.Name}' was not fount in the 'Resources' table");

            AddNewEquipmentFlow.CreateNewResource(equipmentAData);
            var isEquipmentCreated = ResourcesPageFlow.IsEquipmentPresentInTable(equipmentAData);
            isEquipmentCreated.Should().BeTrue($"Equipment '{equipmentAData.Name}' was not fount in the 'Resources' table");

            AddNewEquipmentFlow.CreateNewResource(equipmentBData);
            isEquipmentCreated = ResourcesPageFlow.IsEquipmentPresentInTable(equipmentBData);
            isEquipmentCreated.Should().BeTrue($"Equipment '{equipmentBData.Name}' was not fount in the 'Resources' table");

            ConstraintsFlow.NavigateToConstraintsPage();
            ConstraintsFlow.CreateNewConstraint(constraintData);
            var isConstraintCreated = ConstraintsFlow.IsConstraintPresentInTable(constraintData);
            isConstraintCreated.Should().BeTrue($"Constraint with rules'{constraintData.Task2Rule}' and '{constraintData.Task3Rule}' was not fount in the 'Constraints' table");

            JobsToScheduleFlow.NavigateToJobsToSchedulePage();
            var jobIdToSchedule = JobsToScheduleFlow.CreateNewJob(jobToScheduleData);
            var isJobToScheduleCreated = JobsToScheduleFlow.IsJobPresentInTable(jobToScheduleData);
            isJobToScheduleCreated.Should().BeTrue($"Created Job to schedule '{jobToScheduleData.JobTitle}' was not found in the 'Jobs to schedule' table");

            AlgorithmFlow.NavigateToAlgorithmPage();
            AlgorithmFlow.RunAlgorithmFrom(algorithmRunningStartDate);

            ScheduledJobsFlow.NavigateToScheduledJobsPage();
            ScheduledJobsFlow.IsJobPresentInTable(jobToScheduleData);
            var isScheduledJobPresentInTable = ScheduledJobsFlow.IsJobPresentInTable(jobToScheduleData);
            isScheduledJobPresentInTable.Should().BeTrue($"Scheduled Job '{jobToScheduleData.JobTitle}' was not found in the 'Scheduled Jobs' table");

            var actualScheduledJobData = ScheduledJobsFlow.GetScheduledJobData(jobToScheduleData);
            actualScheduledJobData.JobId.Should().Be(jobIdToSchedule, $"Id of Job to schedule '{jobIdToSchedule}' is not equal to Id of Scheduled Job '{actualScheduledJobData.JobId}'");

            var expectedTaskIdList = protocolData.TaskList.Select(t => t.TaskId).ToList();
            var actualTaskIdList = actualScheduledJobData.ProtocolData.TaskList.Select(t => t.TaskId);
            expectedTaskIdList.Should().Equal(actualTaskIdList, $"Id list of protocol tasks '{protocolData.Title}' is not equal to Id list from Scheduled Job '{actualScheduledJobData.JobTitle}; {actualScheduledJobData.JobId}'");

            var scheduledTask1 = protocolData.TaskList.First(t => t.TaskName == TaskConstants.TaskName1);
            var scheduledTask2 = protocolData.TaskList.First(t => t.TaskName == TaskConstants.TaskName2);
            var scheduledTask3 = protocolData.TaskList.First(t => t.TaskName == TaskConstants.TaskName3);

            scheduledTask2.ScheduledDateTime.Should().BeOnOrAfter(scheduledTask1.ScheduledDateTime.AddDays(1), $"Scheduled Date Time of Task '{scheduledTask2.TaskId}' should be not earlier than 1 day after Scheduled Date Time of Task '{scheduledTask1.TaskId}'");
            scheduledTask2.ScheduledTeamMember.Should().Be(scheduledTask3.ScheduledTeamMember, $"Task 2 '{scheduledTask2.TaskId}' and Task 3 '{scheduledTask3.TaskId}' should have the same scheduled Team Member");
            scheduledTask2.ScheduledEquipment.Should().Be(scheduledTask3.ScheduledEquipment, $"Task 2 '{scheduledTask2.TaskId}' and Task 3 '{scheduledTask3.TaskId}' should have the same scheduled Equipment");

            JobsToScheduleFlow.NavigateToJobsToSchedulePage();
            isJobToScheduleCreated = JobsToScheduleFlow.IsJobPresentInTable(jobToScheduleData);
            isJobToScheduleCreated.Should().BeFalse($"Job to schedule '{jobToScheduleData.JobTitle}' should be deleted from 'Jobs to schedule' table after Scheduling process");
        }

        [Test]
        public void JobCannotBeScheduledIfTeamMemberHasNoAvailability_0004()
        {
            var scheduleWindowStartDate = DateTime.Now;
            var scheduleWindowEndDate = scheduleWindowStartDate.AddMonths(1);
            var jobToScheduleEarliestStartDate = DateTime.Now.AddDays(1);
            var jobToScheduleDueDate = DateTime.Now.AddDays(3);
            var algorithmRunningStartDate = DateTime.Now;
            
            var scheduleWindowData = new ScheduleWindowData(scheduleWindowStartDate, scheduleWindowEndDate);
            var order = OrdersConstants.PredefinedOrder;

            var taskList = new List<ProtocolTaskData>
            {
                new(TaskConstants.TaskName1, 2),
                new(TaskConstants.TaskName2, 6),
                new(TaskConstants.TaskName3, 2)
            };
            var protocolData = new ProtocolData()
                .WithTitle(FakeData.Faker.Random.AlphaNumeric(5))
                .AddTaskList(taskList);

            var teamMemberAData = new TeamMemberData("TM-A", 3);
            var equipmentAData = new EquipmentData("EQ-A", 8);
            
            var constraintData = new ConstraintsData(
                ConstraintsConstants.HasToHappenExactly1DayAfterTask1,
                ConstraintsConstants.Task3NeedsToBeDoneByTheSameResourceAsTask2);

            var jobToScheduleData = JobDataGeneration.DefaultJobData()
                .WithOrder(order)
                .WithProtocol(protocolData)
                .WithEarliestStartDate(jobToScheduleEarliestStartDate)
                .WithDueDate(jobToScheduleDueDate);

            ScheduleWindowFlow.NavigateToScheduleWindow();
            ScheduleWindowFlow.InsertScheduleWindowData(scheduleWindowData);

            ProtocolsFlow.NavigateToProtocolsPage();
            ProtocolsFlow.CreateNewProtocol(protocolData);
            var isProtocolCreated = ProtocolsFlow.IsProtocolPresentInTable(protocolData);
            isProtocolCreated.Should().BeTrue($"Created protocol '{protocolData.Title}' was not fount in the 'Protocols' table");

            AddNewTeamMemberFlow.CreateNewResource(teamMemberAData);
            var isTeamMemberCreated = ResourcesPageFlow.IsTeamMemberPresentInTable(teamMemberAData);
            isTeamMemberCreated.Should().BeTrue($"Team member '{teamMemberAData.Name}' was not fount in the 'Resources' table");

            AddNewEquipmentFlow.CreateNewResource(equipmentAData);
            var isEquipmentCreated = ResourcesPageFlow.IsEquipmentPresentInTable(equipmentAData);
            isEquipmentCreated.Should().BeTrue($"Equipment '{equipmentAData.Name}' was not fount in the 'Resources' table");

            ConstraintsFlow.NavigateToConstraintsPage();
            ConstraintsFlow.CreateNewConstraint(constraintData);
            var isConstraintCreated = ConstraintsFlow.IsConstraintPresentInTable(constraintData);
            isConstraintCreated.Should().BeTrue($"Constraint with rules'{constraintData.Task2Rule}' and '{constraintData.Task3Rule}' was not fount in the 'Constraints' table");

            JobsToScheduleFlow.NavigateToJobsToSchedulePage();
            JobsToScheduleFlow.CreateNewJob(jobToScheduleData);
            var isJobToScheduleCreated = JobsToScheduleFlow.IsJobPresentInTable(jobToScheduleData);
            isJobToScheduleCreated.Should().BeTrue($"Created Job to schedule '{jobToScheduleData.JobTitle}' was not found in the 'Jobs to schedule' table");

            AlgorithmFlow.NavigateToAlgorithmPage();
            AlgorithmFlow.RunAlgorithmFrom(algorithmRunningStartDate);

            var isWarningPopupDisplayed = WarningPopupsFlow.IsWarningPopupDisplayed();
            isWarningPopupDisplayed.Should().BeTrue("Warning popup is expected after attempt to run the Algorithm when Team Member has no Availability");

            var actualPopupMessage = WarningPopupsFlow.GetPopupMessage();
            var expectedPopupMessage = WarningPopupConstants.NoAvailableTeamMembers;
            actualPopupMessage.Should().Be(expectedPopupMessage, $"Actual warning message in popup '{actualPopupMessage}' is not equal to expected one '{expectedPopupMessage}'");

            JobsToScheduleFlow.NavigateToJobsToSchedulePage();
            isJobToScheduleCreated = JobsToScheduleFlow.IsJobPresentInTable(jobToScheduleData);
            isJobToScheduleCreated.Should().BeTrue($"Job to schedule '{jobToScheduleData.JobTitle}' should be present in 'Jobs to schedule', since the Algorithm wasn't run");
        }
    }
}