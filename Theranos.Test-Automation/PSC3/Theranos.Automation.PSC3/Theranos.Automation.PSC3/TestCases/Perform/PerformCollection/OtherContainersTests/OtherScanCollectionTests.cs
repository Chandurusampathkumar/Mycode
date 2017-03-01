
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
using Theranos.Automation.PSC3.Models.Perform.PerformCollection;
using Theranos.Automation.PSC3.Models.Perform.PerformCollection.OtherContainers;
using System.Collections.Generic;
using TestStack.White.UIItems.ListBoxItems;

namespace Theranos.Automation.PSC3.TestCases.Perform.PerformCollection.OtherContainersTests
{
    [TestClass]
    public class OtherScanCollectionTests:ScanCollection
    {

        //[TestMethod]
        //public void OtherScan()
        //{
        //    ScanBarCodes();
        //}


        public Dictionary<string,bool> ScanBarCodesButtonMandatory()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var containerList = AutoElement.GetElementCollectionByName(appWin, ScanCollectionOtherContainersList_ByName);
            List<string> ReturnContinerEnabled=new List<string>();
            ReturnContinerEnabled.Add(PrepareContainers.ContainerUrineKit);
            ReturnContinerEnabled.Add(PrepareContainers.Container24HourUrineKit);
            ReturnContinerEnabled.Add(PrepareContainers.ContainerSwabKit);
            ReturnContinerEnabled.Add(PrepareContainers.ContainerStoolCard1);
            ReturnContinerEnabled.Add(PrepareContainers.ContainerStoolCard3);
            Dictionary<string,bool> barCodes = new Dictionary<string,bool>();
            string barCode = "";
            bool returnContainerEnabled = false;
            var button = AutoElement.GetButtonById(appWin, OtherContainersScanNextButton_ByID);

            for (int i = 0; i < containerList.Count; i++)
            {
                Assert.IsFalse(button.Enabled);
                do
                {
                    var containerName = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(OtherContainersNameX_ByID,i));
                    //var containerName = containerList[1].Current.Name;
                    barCode = UtilityClass.GetRandomNumber(100, 999).ToString() + UtilityClass.GetRandomNumber(1000000, 9999999).ToString();
                    AutoAction.SetTextById(appWin, UtilityClass.GetListItemId(OtherContainersBarCodeX_ByID, i), barCode);
                    var displayedBarCode = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(OtherContainersEnteredBarcodeX_ByID, i));
                    Assert.AreEqual(displayedBarCode, barCode);

                    if (ReturnContinerEnabled.Contains(containerName))
                    {
                        returnContainerEnabled = true;

                    }
                    else
                    {
                        returnContainerEnabled = false;
                        
                    }
                } while (AutoElement.VisibleByIdNoWait(appWin, UtilityClass.GetListItemId(OtherContainersScanErrorX_ByID, i)));

                barCodes.Add(barCode, returnContainerEnabled);
            }
            Assert.IsTrue(button.Enabled);
            return barCodes;
        }


        public Dictionary<string, bool> ScanBarCodes()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var containerList = AutoElement.GetElementCollectionByName(appWin, ScanCollectionOtherContainersList_ByName);
            List<string> ReturnContinerEnabled = new List<string>();
            ReturnContinerEnabled.Add(PrepareContainers.ContainerUrineKit);
            ReturnContinerEnabled.Add(PrepareContainers.Container24HourUrineKit);
            ReturnContinerEnabled.Add(PrepareContainers.ContainerSwabKit);
            ReturnContinerEnabled.Add(PrepareContainers.ContainerStoolCard1);
            ReturnContinerEnabled.Add(PrepareContainers.ContainerStoolCard3);
            Dictionary<string, bool> barCodes = new Dictionary<string, bool>();            
            string barCode = "";
            bool returnContainerEnabled = false;
            for (int i = 0; i < containerList.Count; i++)
            {
                do
                {
                    var containerName = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(OtherContainersNameX_ByID, i));
                    barCode = UtilityClass.GetRandomNumber(100, 999).ToString()+ UtilityClass.GetRandomNumber(1000000, 9999999).ToString();
                    AutoAction.SetTextById(appWin, UtilityClass.GetListItemId(OtherContainersBarCodeX_ByID, i), barCode);
                    var displayedBarCode = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(OtherContainersEnteredBarcodeX_ByID, i));
                    Assert.AreEqual(displayedBarCode, barCode);

                    if (ReturnContinerEnabled.Contains(containerName))
                    {
                        returnContainerEnabled = true;

                    }
                    else
                    {
                        returnContainerEnabled = false;

                    }
                } while (AutoElement.VisibleByIdNoWait(appWin, UtilityClass.GetListItemId(OtherContainersScanErrorX_ByID, i)));
                barCodes.Add(barCode, returnContainerEnabled);
            }
            return barCodes;
        }

        //try to enter the same barcode for two tests... and check the app behaviour
        [TestMethod]
        public void ScanSameBarCodes()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var containerList = AutoElement.GetElementCollectionByName(appWin, ScanCollectionOtherContainersList_ByName);
            var barCode = "";
            AutomationElement barcodeElement;
            var displayedBarCode = "";
            //generate random barcode and enter for the first test    
            do
            {
                barCode = UtilityClass.GetRandomNumber(100, 999).ToString() + UtilityClass.GetRandomNumber(1000000, 9999999).ToString();
                //AutoAction.SetTextById(appWin, UtilityClass.GetListItemId(VacutainersScanCollectionBarcodeX_ByID, i), barCode);
                barcodeElement = AutoElement.GetElementById(appWin, UtilityClass.GetListItemId(OtherContainersBarCodeX_ByID, 0));
                UIAutoHelper.performTextPattern(barcodeElement, barCode);
                displayedBarCode = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(OtherContainersEnteredBarcodeX_ByID, 0));
                Assert.AreEqual(displayedBarCode, barCode);
            } while (AutoElement.VisibleByIdNoWait(appWin, UtilityClass.GetListItemId(OtherContainersScanErrorX_ByID, 0)));

            //enter the same barcode for the second test too...

            barcodeElement = AutoElement.GetElementById(appWin, UtilityClass.GetListItemId(OtherContainersBarCodeX_ByID, 1));
            UIAutoHelper.performTextPattern(barcodeElement, barCode);
            displayedBarCode = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(OtherContainersEnteredBarcodeX_ByID, 1));
            Assert.AreEqual(displayedBarCode, barCode);

            //Check whether the barcode of first test is cleared or not
            displayedBarCode = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(OtherContainersEnteredBarcodeX_ByID, 0));
            barcodeElement = AutoElement.GetElementById(appWin, UtilityClass.GetListItemId(OtherContainersBarCodeX_ByID, 0));
            if (displayedBarCode != "" || barcodeElement.Current.Name != "")
                Assert.Fail("When we enter the same barcode for two containers, the first one not been deleted");
            Assert.IsTrue(AutoElement.VisibleById(appWin, UtilityClass.GetListItemId(OtherContainersPleaseScanX_ByID, 0)), "please scan label for first containers is not displayed");
        }



        [TestMethod]
        public void OtherContainerScanCollectionInstruction()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var containerList = AutoElement.GetElementCollectionByName(appWin, ScanCollectionOtherContainersList_ByName);

            for (int i = 0; i < containerList.Count; i++)
            {
                var instruction = AutoElement.GetElementNameById(appWin,UtilityClass.GetListItemId(OtherContainersReadyForGuestX_ByID,i));
                Assert.AreEqual(instruction,ReadyForGuest);
            }
        }

        [TestMethod]
        public void OtherContainerUnableToCollect()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var containerList = AutoElement.GetElementCollectionByName(appWin, ScanCollectionOtherContainersList_ByName);

            for (int i = 0; i < containerList.Count; i++)
            {
                AutoAction.ClickButtonById(appWin, UtilityClass.GetListItemId(OtherContainersFlagX_ByID, i));
                AutoAction.ClickButtonById(appWin, UtilityClass.GetListItemId(OtherContainerUnableToCollectButtonX_ByID, i));
                Assert.IsTrue(AutoElement.VisibleById(appWin, UtilityClass.GetListItemId(OtherContainersUnableToCollectX_ByID, i)));
                var expectedName = AutoElement.GetElementById(appWin, UtilityClass.GetListItemId(OtherContainersUnableToCollectX_ByID, i)).Current.Name;
                if (expectedName != UnableToCollect)
                {
                    Assert.Fail("Expected name is not displayed");
                }
            }
            AutoAction.ClickButtonById(appWin, OtherContainersScanNextButton_ByID);
            var reason = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(Reason_ByID));
            reason.Select(UtilityClass.GetRandomNumber(0, 20));
            AutoAction.ClickButtonById(appWin, Yes_ByID);
            AutoAction.ClickButtonById(appWin, Yes_ByID);
            Assert.IsTrue(AutoElement.ExistsById(appWin, DashboardModel.ScanReturnContainerHost_ByID));
        }

        [TestMethod]
        public void CompleteScanCollection()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin,OtherContainersScanNextButton_ByID);
            //var host = AutoElement.GetElementById(appWin, PerformModel.VisitSummaryHost_ByID);
            Assert.IsNotNull(AutoElement.ExistsById(appWin, VisitSummaryModel.VisitSummaryHost_ByID));
        }       
    }
}
