
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using Theranos.Automation.PSC3.Models;
using Theranos.Automation.PSC3.Models.CheckIn.AddLabOrder;
using Theranos.Automation.AutoStack.Utility;
using Theranos.Automation.AutoStack;

namespace Theranos.Automation.PSC3.TestCases.CheckIn.AddLabOrder
{
    [TestClass]
    public class OrderInstructionsTests:OrderInstructionsModel
    {
        /// <summary>
        /// Verify user is able to update the order instructions.
        /// </summary>
        //[TestCategory(AppSettings.Unit), TestMethod()]
        //public void OrderInstructions()
        //{
        //    var appWin = AutoElement.GetWindowByName(AppWindowName);
        //    var host = AutoElement.GetElementById(appWin, OrderInstructionsHost_ByID);

        //    var records = CSVHelper.GetRecords<OrderInstructionsModel>(InputFileName);
        //    var index = UtilityClass.GetRandomNumber(0,records.Count);
        //    var instruction=records[index];

        //    if (instruction.IsFastingRequired==Yes)
        //    {
        //        //TODO: Create new function in library
        //        var fastingYes=AutoElement.GetRadioButtonById(appWin,FastingRequiredYes_ByID);
        //        //var fastingYes = appWin.Get<RadioButton>(SearchCriteria.ByAutomationId(FastingRequiredYes_ByID));
        //        fastingYes.Select();

        //        var fastingHours = UtilityClass.GetRandomNumber(0, 4);
        //        switch (fastingHours)
        //        {
        //            case 0: AutoAction.ClickButtonById(appWin, FastingHours8_ByID);
        //                break;
        //            case 1: AutoAction.ClickButtonById(appWin, FastingHours10_ByID);
        //                break;
        //            case 2: AutoAction.ClickButtonById(appWin, FastingHours12_ByID);
        //                break;
        //            case 3: AutoAction.ClickButtonById(appWin, FastingHoursCustom_ByID);
        //                AutoAction.SetTextById(appWin, FastingHoursEdit_ByID, instruction.FastingHours);
        //                break;
        //            case 4: AutoAction.ClickCheckBoxById(appWin, FastingUnspecified_ByID);
        //                break;
        //        }

        //        //if (instruction.FastingHours!="")
        //        //{
        //        //    Actions.SetTextByAutomationID(appWin, FastingHours_ByID, instruction.FastingHours);
        //        //}
        //        //else
        //        //{
        //        //    //TODO: Create new function in library
        //        //    var fastingUnspecified = appWin.Get<CheckBox>(SearchCriteria.ByAutomationId(FastingUnspecified_ByID));
        //        //    fastingUnspecified.Select();
        //        //}
        //    }

        //    if (instruction.IsStandingOrder==Yes)
        //    {
        //        //TODO: Create new function in library
        //        var standingYes = AutoElement.GetRadioButtonById(appWin,StandingOrderYes_ByID);
        //        //var standingYes = appWin.Get<RadioButton>(SearchCriteria.ByAutomationId(StandingOrderYes_ByID));
        //        standingYes.Select();

        //        AutoAction.SetTextById(appWin,StandingOrderRecurrence_ByID,instruction.StandingOrderRecurrence);
                
        //        //TODO: Create new function in library
        //        var frequency = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(StandingOrderFrequency_ByID));
        //        frequency.Select(instruction.StandingOrderFrequency);               
        //    }

        //    //if (instruction.CollectionType==Venous)
        //    //{
        //    //    //TODO: SelectRadioButton()
        //    //    var venous = appWin.Get<RadioButton>(SearchCriteria.ByAutomationId(VenousCollection_ByID));
        //    //    venous.Select();
        //    //}
        //    //else if (instruction.CollectionType==Fingerstick)
        //    //{
        //    //    //TODO: SelectRadioButton()
        //    //    var fingerstick = appWin.Get<RadioButton>(SearchCriteria.ByAutomationId(FingerStickCollection_ByID));
        //    //    fingerstick.Select();
        //    //}
        //}

        //CTC-56: Verify user is able to update the order instructions.
        //CTC-100: For clinician test,Verify standing order fields are displayed with "yes" and "no" options.
        [TestMethod]
        public void RandomOrderInstructions()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var host = AutoElement.GetElementById(appWin,OrderInstructionsHost_ByID);
            var i = UtilityClass.GetRandomNumber(1, 24).ToString();
            AutoAction.ClickRadioButtonById(appWin,FastingRequiredYes_ByID);

            var fastingHours = UtilityClass.GetRandomNumber(0,4);
            switch (fastingHours)
            {
                case 0: AutoAction.ClickButtonById(appWin,FastingHours8_ByID);
                    break;
                case 1: AutoAction.ClickButtonById(appWin,FastingHours10_ByID);
                    break;
                case 2: AutoAction.ClickButtonById(appWin,FastingHours12_ByID);
                    break;
                case 3: AutoAction.ClickButtonById(appWin,FastingHoursCustom_ByID);
                    AutoAction.SetTextById(appWin,FastingHoursEdit_ByID,i);
                    break;
                case 4: AutoAction.ClickCheckBoxById(appWin,FastingUnspecified_ByID);
                    break;
            }

            var standingOrder = UtilityClass.GetRandomNumber(0, 1);            
            if (standingOrder == 1)
            {
                AutoAction.ClickRadioButtonById(appWin,StandingOrderYes_ByID);

                var frequency = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(StandingOrderFrequency_ByID));
                var resource = appWin.Get<TextBox>(SearchCriteria.ByAutomationId(StandingOrderRecurrence_ByID));

                var j = UtilityClass.GetRandomNumber(0,2);
                switch (j)
                {
                    case 0: 
                            frequency.Select(Day_ByName);                           
                            resource.SetValue(1);
                            break;
                    case 1: 
                            frequency.Select(Week_ByName);
                            var times1 = UtilityClass.GetRandomNumber(1, 7);
                            resource.SetValue(times1);
                        break;
                    case 2: 
                            frequency.Select(Month_ByName);
                            var times2 = UtilityClass.GetRandomNumber(1, 30);
                            resource.SetValue(times2);
                        break;                    
                }                       
            }
            AutoAction.SendTabKey();
            //var collection = UtilityClass.GetRandomNumber(0, 2);
            //switch (collection)
            //{
            //    case 1: AutoAction.ClickUIItemById(appWin,VenousCollection_ByID);
            //        //var venous = AutoElement.GetRadioButtonById(appWin, VenousCollection_ByID);
            //            //var venous = appWin.Get<RadioButton>(SearchCriteria.ByAutomationId(VenousCollection_ByID));
            //            //venous.Select();
            //            break;
            //    case 2: AutoAction.ClickUIItemById(appWin, FingerStickCollection_ByID);
            //            //var fingerstick = AutoElement.GetRadioButtonById(appWin, FingerStickCollection_ByID);
            //            //var fingerstick = appWin.Get<RadioButton>(SearchCriteria.ByAutomationId(FingerStickCollection_ByID));
            //            //fingerstick.Select();
            //            break;
            //    default: AutoAction.ClickUIItemById(appWin, UnSpecifiedCollection_ByID);
            //            //var unspecified = AutoElement.GetRadioButtonById(appWin, UnSpecifiedCollection_ByID);
            //             //var unspecified = appWin.Get<RadioButton>(SearchCriteria.ByAutomationId(UnSpecifiedCollection_ByID));
            //             //unspecified.Select();
            //             break;
            //}
                 
        }

        [TestMethod]
        public void FastingRequirement()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickRadioButtonById(appWin, FastingRequiredYes_ByID);
            //var hours8 = appWin.Get<Button>(SearchCriteria.ByAutomationId(FastingHours8_ByID));
            //var hours10 = appWin.Get<Button>(SearchCriteria.ByAutomationId(FastingHours10_ByID));
            //var hours12 = appWin.Get<Button>(SearchCriteria.ByAutomationId(FastingHours12_ByID));
            //var custom = appWin.Get<Button>(SearchCriteria.ByAutomationId(FastingHoursCustom_ByID));
            var i = UtilityClass.GetRandomNumber(1, 24).ToString();
            var ch = UtilityClass.GetRandomNumber(0, 3);
            switch (ch)
            {
                case 0: AutoAction.ClickButtonById(appWin, FastingHours8_ByID);
                    //hours8.Click();
                    break;
                case 1: AutoAction.ClickButtonById(appWin, FastingHours10_ByID);
                    //hours10.Click();
                    break;
                case 2: AutoAction.ClickButtonById(appWin, FastingHours12_ByID);
                    //hours12.Click();
                    break;
                case 3: AutoAction.ClickButtonById(appWin, FastingHoursCustom_ByID);
                    AutoAction.SetTextById(appWin, FastingHoursEdit_ByID, i);
                    //custom.Click();
                    //var hours = appWin.Get<TextBox>(SearchCriteria.ByAutomationId(FastingHoursEdit_ByID));
                    //hours.SetValue(i);
                    break;
            }

            Assert.IsTrue(AutoElement.EnabledById(appWin,ClinicianDetailsNextButton_ByID));
            //var next=appWin.Get<Button>(SearchCriteria.ByAutomationId(ClinicianDetailsNextButton_ByID));
            //if (!next.Enabled)
            //{
            //    Assert.Fail("Next button is not enabled");
            //}

            AutoAction.SetTextById(appWin,FastingHoursEdit_ByID,"");
            Assert.IsTrue(AutoElement.EnabledById(appWin, ClinicianDetailsNextButton_ByID));
            //var hour = appWin.Get<TextBox>(SearchCriteria.ByAutomationId(FastingHoursEdit_ByID));
            //hour.SetValue("");
            //if (next.Enabled)
            //{
            //    Assert.Fail("Next button is enabled");
            //}

            AutoAction.SetTextById(appWin, FastingHoursEdit_ByID, "0");
            Assert.IsTrue(AutoElement.EnabledById(appWin, ClinicianDetailsNextButton_ByID));
            //hour.SetValue("0");
            //if (next.Enabled)
            //{
            //    Assert.Fail("Next button is enabled");
            //}
        }

        [TestMethod]
        public void FastingEightHours()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickRadioButtonById(appWin, FastingRequiredYes_ByID);
            AutoAction.ClickButtonById(appWin, FastingHours8_ByID);
            //fastingYes.Select();
            //var hours8 = appWin.Get<Button>(SearchCriteria.ByAutomationId(FastingHours8_ByID));
            //hours8.Click();
        }

        [TestMethod]
        public void FastingTenHours()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickRadioButtonById(appWin, FastingRequiredYes_ByID);
            AutoAction.ClickButtonById(appWin, FastingHours10_ByID);
            //var hours10 = appWin.Get<Button>(SearchCriteria.ByAutomationId(FastingHours10_ByID));
            //hours10.Click();
        }

        [TestMethod]
        public void FastingTwelveHours()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickRadioButtonById(appWin, FastingRequiredYes_ByID);
            AutoAction.ClickButtonById(appWin, FastingHours12_ByID);
            //var hours12 = appWin.Get<Button>(SearchCriteria.ByAutomationId(FastingHours12_ByID));
            //hours12.Click();
        }

        [TestMethod]
        public void FastingUnspecifiedHours()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickRadioButtonById(appWin, FastingRequiredYes_ByID);
            AutoAction.ClickCheckBoxById(appWin, UnspecifiedHours_ByID);
            //var unspecifiedHours = appWin.Get<CheckBox>(SearchCriteria.ByAutomationId(UnspecifiedHours_ByID));
            //unspecifiedHours.Select();
        }


        [TestMethod]
        public void SetFastingHours()
        {
            CustomFastingHours("21");
        }


        //Select Yes for Fasting... select custom... check app allows to enter integer in that field
        public void CustomFastingHours(string hours)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickRadioButtonById(appWin, FastingRequiredYes_ByID);
            AutoAction.ClickButtonById(appWin, FastingHoursCustom_ByID);
            AutoAction.SetTextById(appWin, FastingHoursEdit_ByID, hours);
            AutoAction.SendTabKey();
        }

        //CTC-99: 
        [TestMethod]
        public void RandomCustomFastingHours()
        {

            var hours = UtilityClass.GetRandomNumber(1, 24).ToString();
            CustomFastingHours(hours);
        }

        //CTC-57: To verify "Next" button is NOT enabled under standing requirement in the "per" field on selecting "unknown" option.
        [TestMethod]
        public void StandingOrderUnknown()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickRadioButtonById(appWin, StandingOrderYes_ByID);

            var frequency = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(StandingOrderFrequency_ByID));
            var resource = appWin.Get<TextBox>(SearchCriteria.ByAutomationId(StandingOrderRecurrence_ByID));
            frequency.Select(Unknown_ByName);
            Assert.IsFalse(AutoElement.EnabledById(appWin,ClinicianModel.Next_ByID));
        }

        [TestMethod]
        public void StandingOrderDay()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickRadioButtonById(appWin, StandingOrderYes_ByID);

            var frequency = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(StandingOrderFrequency_ByID));
            var resource = appWin.Get<TextBox>(SearchCriteria.ByAutomationId(StandingOrderRecurrence_ByID));
            frequency.Select(Day_ByName);
            resource.SetValue(1);
            AutoAction.SendTabKey();
        }

        [TestMethod]
        public void StandingOrderWeek()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickRadioButtonById(appWin, StandingOrderYes_ByID);            

            var frequency = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(StandingOrderFrequency_ByID));
            var resource = appWin.Get<TextBox>(SearchCriteria.ByAutomationId(StandingOrderRecurrence_ByID));
            frequency.Select(Week_ByName);
            var times = UtilityClass.GetRandomNumber(1, 7);
            resource.SetValue(times);
            AutoAction.SendTabKey();
        }

        [TestMethod]
        public void StandingOrderMonth()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickRadioButtonById(appWin, StandingOrderYes_ByID);

            var frequency = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(StandingOrderFrequency_ByID));
            var resource = appWin.Get<TextBox>(SearchCriteria.ByAutomationId(StandingOrderRecurrence_ByID));
            frequency.Select(Month_ByName);
            var times = UtilityClass.GetRandomNumber(1, 30);
            resource.SetValue(times);
            AutoAction.SendTabKey();
        }

        [TestMethod]
        public void VerifyForUnspecifiedCheckBox()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickRadioButtonById(appWin, FastingRequiredYes_ByID);
            Assert.IsTrue(!AutoElement.GetCheckBoxStateById(appWin,UnspecifiedHours_ByID));
            Assert.IsTrue(!AutoElement.EnabledById(appWin,ClinicianModel.Next_ByID));

            AutoAction.ClickRadioButtonById(appWin,FastingRequiredNo_ByID);        
        }

        [TestMethod]
        public void NoOrderDateAvailable()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var noOrderDate = appWin.Get<CheckBox>(SearchCriteria.ByText("No order date available"));
            noOrderDate.Select();
            Assert.IsTrue(AutoElement.EnabledById(appWin,ClinicianModel.Next_ByID));
        }

        //[TestMethod]
        //public void CollectionVenous()
        //{
        //    var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
        //    var venous = appWin.Get<RadioButton>(SearchCriteria.ByAutomationId(VenousCollection_ByID));
        //    venous.Select();
        //}

        //[TestMethod]
        //public void CollectionFingerStick()
        //{
        //    var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
        //    var fingerstick = appWin.Get<RadioButton>(SearchCriteria.ByAutomationId(FingerStickCollection_ByID));
        //    fingerstick.Select();
        //}

        //[TestMethod]
        //public void CollectionUnspecified()
        //{
        //    var appWin = Desktop.Instance.Windows().Find(obj => obj.Name.Contains(AppWindowName));
        //    var unspecified = appWin.Get<RadioButton>(SearchCriteria.ByAutomationId(UnSpecifiedCollection_ByID));
        //    unspecified.Select();
        //}

    }
}
