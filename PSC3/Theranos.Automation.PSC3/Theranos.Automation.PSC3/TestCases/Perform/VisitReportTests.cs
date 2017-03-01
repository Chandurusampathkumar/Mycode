using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems.Finders;
using Theranos.Automation.PSC3.Models;
using Theranos.Automation.AutoStack.Utility;
using TestStack.White.UIItems;
using Theranos.Automation.AutoStack;
using Theranos.Automation.PSC3.Models.Perform;
using TestStack.White.UIItems.ListBoxItems;
using Theranos.Automation.PSC3.TestCases.CheckIn;
using Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo;

namespace Theranos.Automation.PSC3.TestCases.Perform
{
    [TestClass]
    public class VisitReportTests:VisitReportModel
    {

        [TestMethod]
        public void SelectITIssue()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);            
            AutoAction.ClickRadioButtonById(appWin,ITIssuesYes_ByID);
            MouseHelper.MoveToAndClickById(appWin, ITIssueCombobox_ByID);

            var reasons = UtilityClass.GetRandomNumber(0, 6);
            switch (reasons)
            {
                case 0: MouseHelper.MoveToAndClickByName(appWin, ITReason1);
                    break;
                case 1: MouseHelper.MoveToAndClickByName(appWin, ITReason2);
                    break;
                case 2: MouseHelper.MoveToAndClickByName(appWin, ITReason3);
                    break;
                case 3: MouseHelper.MoveToAndClickByName(appWin, ITReason4);
                    break;
                case 4: MouseHelper.MoveToAndClickByName(appWin, ITReason5);
                    break;
                case 5: MouseHelper.MoveToAndClickByName(appWin, ITReason6);
                    break;
                case 6: MouseHelper.MoveToAndClickByName(appWin, ITReason7);
                    if (AutoElement.VisibleById(appWin, ITIssueOtherReason_ById))
                    {
                        AutoAction.SetTextById(appWin, ITIssueOtherReason_ById, "Other reason");
                    }
                    break;
            }           
        }
               
        [TestMethod]
        public void SelectApplicationIssue()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            
            AutoAction.ClickRadioButtonById(appWin,ApplicationIssuesYes_ById);
            MouseHelper.MoveToAndClickById(appWin, ApplicationIssueCombobox_ByID);

            var reasons = UtilityClass.GetRandomNumber(0,6);
            switch (reasons)
            {
                case 0: MouseHelper.MoveToAndClickByName(appWin,AppReason1);
                    break;
                case 1: MouseHelper.MoveToAndClickByName(appWin, AppReason2);
                    break;
                case 2: MouseHelper.MoveToAndClickByName(appWin, AppReason3);
                    break;
                case 3: MouseHelper.MoveToAndClickByName(appWin, AppReason4);
                    break;
                case 4: MouseHelper.MoveToAndClickByName(appWin, AppReason5);
                    break;
                case 5: MouseHelper.MoveToAndClickByName(appWin, AppReason6);
                    break;
                case 6: MouseHelper.MoveToAndClickByName(appWin, AppReason7);
                    if (AutoElement.VisibleById(appWin, ApplicationIssueOtherReason_ByID))
                    {
                        AutoAction.SetTextById(appWin, ApplicationIssueOtherReason_ByID, "Other reason");
                    }
                    break;                   
            }
            
        }

        [TestMethod]
        public void SelectMultipleApplicationIssue()
        {
            SelectApplicationIssue();
            SelectApplicationIssue();
            SelectCustomerSupportIssue();
            SelectCustomerSupportIssue();
        }


        [TestMethod]
        public void SelectCustomerSupportIssue()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickRadioButtonById(appWin, CustomerSupportIssuesYes_ByID);
            MouseHelper.MoveToAndClickById(appWin, CustomerSupportIssueCombobox_ByID);
            var reasons = UtilityClass.GetRandomNumber(0, 4);
            switch (reasons)
            {
                case 0: MouseHelper.MoveToAndClickByName(appWin, CustomerReason1);
                    break;
                case 1: MouseHelper.MoveToAndClickByName(appWin, CustomerReason2);
                    break;
                case 2: MouseHelper.MoveToAndClickByName(appWin, CustomerReason3);
                    break;
                case 3: MouseHelper.MoveToAndClickByName(appWin, CustomerReason4);
                    break;
                case 4: MouseHelper.MoveToAndClickByName(appWin, CustomerReason5);
                    if (AutoElement.VisibleById(appWin, CustomerSupportIssueOtherReason_ByID))
                    {
                        AutoAction.SetTextById(appWin, CustomerSupportIssueOtherReason_ByID, "Other reason");
                    }
                    break;
            }
        }

        [TestMethod]
        public void SelectWaitTimeIssue()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickRadioButtonById(appWin, WaitTimeIssueYes_ByID);
            AutoAction.ClickUIItemById(appWin,WaitTimeIssueCombobox_ByID);
            //MouseHelper.MoveToAndClickById(appWin, WaitTimeIssueCombobox_ByID);
            var reasons = UtilityClass.GetRandomNumber(0, 4);
            switch (reasons)
            {
                case 0: AutoAction.ClickUIItemByName(appWin, WaitReason1); 
                    //MouseHelper.MoveToAndClickByName(appWin, WaitReason1);
                    break;
                case 1: AutoAction.ClickUIItemByName(appWin, WaitReason2); 
                    //MouseHelper.MoveToAndClickByName(appWin, WaitReason2);
                    break;
                case 2: AutoAction.ClickUIItemByName(appWin, WaitReason3); 
                    //MouseHelper.MoveToAndClickByName(appWin, WaitReason3);
                    break;
                case 3: AutoAction.ClickUIItemByName(appWin, WaitReason4); 
                    //MouseHelper.MoveToAndClickByName(appWin, WaitReason4);
                    break;
                case 4: AutoAction.ClickUIItemByName(appWin, WaitReason5); 
                    //MouseHelper.MoveToAndClickByName(appWin, WaitReason5);
                    if (AutoElement.VisibleById(appWin, WaitTimeIssueOtherReason_ByID))
                    {
                        AutoAction.SetTextById(appWin, WaitTimeIssueOtherReason_ByID, "Other reason");
                    }
                    break;
            }
        }

        [TestMethod]
        public void SelectNeedleIssue()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickUIItemById(appWin, "VisitReportHost.NeedleCountIssue.Control.NumberUsed.Combobox");
            //MouseHelper.MoveToAndClickById(appWin, "VisitReportHost.NeedleCountIssue.Control.NumberUsed.Combobox");
            var needlesUsed = UtilityClass.GetRandomNumber(0,4);
            switch (needlesUsed)
            {
                case 0: //AutoAction.ClickUIItemByName(appWin, "1");
                    MouseHelper.MoveToAndClickByName(appWin,"1");
                    break;
                case 1: //AutoAction.ClickUIItemByName(appWin, "2"); 
                    MouseHelper.MoveToAndClickByName(appWin, "2");
                    SelectNeedlesUsedReason();
                    break;
                case 2: //AutoAction.ClickUIItemByName(appWin, "3"); 
                    MouseHelper.MoveToAndClickByName(appWin, "3");
                    SelectNeedlesUsedReason();
                    break;
                case 3: //AutoAction.ClickUIItemByName(appWin, "4"); 
                    MouseHelper.MoveToAndClickByName(appWin, "4");
                    SelectNeedlesUsedReason();
                    break;
                case 4: //AutoAction.ClickUIItemByName(appWin, "5"); 
                    MouseHelper.MoveToAndClickByName(appWin, "5");
                    SelectNeedlesUsedReason();
                    break;

            }
        }

        [TestMethod]
        public void SelectNeedlesUsedReason()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickUIItemById(appWin, NeedlesUsedReasonsCombobox_ById);
            //MouseHelper.MoveToAndClickById(appWin, NeedlesUsedReasonsCombobox_ById);
            var reasons = UtilityClass.GetRandomNumber(0,14);
            switch (reasons)
            {
                case 0: AutoAction.ClickUIItemByName(appWin,NeedleReason1);
                    MouseHelper.MoveToAndClickByName(appWin, NeedleReason1);
                    break;
                case 1: AutoAction.ClickUIItemByName(appWin, NeedleReason2);
                    //MouseHelper.MoveToAndClickByName(appWin, NeedleReason2);
                    break;
                case 2: AutoAction.ClickUIItemByName(appWin, NeedleReason3); 
                    //MouseHelper.MoveToAndClickByName(appWin, NeedleReason3);
                    break;
                case 3: AutoAction.ClickUIItemByName(appWin, NeedleReason4); 
                    //MouseHelper.MoveToAndClickByName(appWin, NeedleReason4);
                    break;
                case 4: AutoAction.ClickUIItemByName(appWin, NeedleReason5); 
                    //MouseHelper.MoveToAndClickByName(appWin, NeedleReason5);
                    break;
                case 5: AutoAction.ClickUIItemByName(appWin, NeedleReason6); 
                    //MouseHelper.MoveToAndClickByName(appWin, NeedleReason6);
                    break;
                case 6: AutoAction.ClickUIItemByName(appWin, NeedleReason7); 
                    //MouseHelper.MoveToAndClickByName(appWin, NeedleReason7);
                    break;
                case 7: AutoAction.ClickUIItemByName(appWin, NeedleReason8); 
                    //MouseHelper.MoveToAndClickByName(appWin, NeedleReason8);
                    break;
                case 8: AutoAction.ClickUIItemByName(appWin, NeedleReason9); 
                    //MouseHelper.MoveToAndClickByName(appWin, NeedleReason9);
                    break;
                case 9: AutoAction.ClickUIItemByName(appWin, NeedleReason10); 
                    //MouseHelper.MoveToAndClickByName(appWin, NeedleReason10);
                    break;
                case 10: AutoAction.ClickUIItemByName(appWin, NeedleReason11); 
                    //MouseHelper.MoveToAndClickByName(appWin, NeedleReason11);
                    break;
                case 11: AutoAction.ClickUIItemByName(appWin, NeedleReason12); 
                    //MouseHelper.MoveToAndClickByName(appWin, NeedleReason12);
                    break;
                case 12: AutoAction.ClickUIItemByName(appWin, NeedleReason13); 
                    //MouseHelper.MoveToAndClickByName(appWin, NeedleReason13);
                    break;
                case 13: AutoAction.ClickUIItemByName(appWin, NeedleReason14); 
                    //MouseHelper.MoveToAndClickByName(appWin, NeedleReason14);
                    break;
                case 14: AutoAction.ClickUIItemByName(appWin, NeedleReason15); 
                    //MouseHelper.MoveToAndClickByName(appWin, NeedleReason15);
                    if (AutoElement.VisibleById(appWin, NeedlesUsedOtherReason_ByID))
                    {
                        AutoAction.SetTextById(appWin, NeedlesUsedOtherReason_ByID, "Other reason");
                    }
                    break;
            }
        }

     
        public void CheckGuestNameVisitReport(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var name = basicInfo.FirstName + " " + basicInfo.LastName;
            var guestName = AutoElement.GetElementNameById(appWin,GuestName_ByID);
            Assert.AreEqual(name,guestName,"Guest name is not matched with completed guest name");
        }

        [TestMethod]
        public void VisitSummary()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            if (AutoElement.VisibleById(appWin,VisitSummary_ByID))
            {
                AutoAction.SetTextById(appWin,VisitSummary_ByID,"Visit summary for the Guest");
            }
        }

        [TestMethod]
        public void SaveAndCompleteVisitReport()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin,Save_ByID);
            if (AutoElement.EnabledById(appWin,Complete_ByID))
            {
                AutoAction.ClickButtonById(appWin,Complete_ByID);
            }
            else
            {
                Assert.Fail("Visit Report details are not completed properly");
            }
        }
    }
}
