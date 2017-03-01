
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
using Theranos.Automation.PSC3.Models.Perform.PerformCollection.Vacutainers;
using Theranos.Automation.PSC3.Models.Perform.PerformCollection.OtherContainers;
using TestStack.White.UIItems.ListBoxItems;

namespace Theranos.Automation.PSC3.TestCases.Perform.PerformCollection.VacutainersTests
{
    [TestClass]
    public class VacutainersScanCollectionTests : VacutainerScanCollection
    {
        [TestMethod]
        public void ScanBarCodesButtonMandatory()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var containerList = AutoElement.GetElementCollectionByName(appWin, VacutainersScanCollectionList_ByName);
            var button = AutoElement.GetButtonById(appWin, VacutainersScanCollectionNext_ByID);
            for (int i = 0; i < containerList.Count; i++)
            {
                Assert.IsFalse(button.Enabled);
                do
                {
                    var barCode = UtilityClass.GetRandomNumber(100, 999).ToString() + UtilityClass.GetRandomNumber(1000000, 9999999).ToString();
                    AutoAction.SetTextById(appWin, UtilityClass.GetListItemId(VacutainersScanCollectionBarcodeX_ByID, i), barCode);
                    var displayedBarCode = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(VacutainersScanCollectionEnteredBarcodeX_ByID, i));
                    Assert.AreEqual(displayedBarCode, barCode);
                } while (AutoElement.VisibleByIdNoWait(appWin, UtilityClass.GetListItemId(VacutainersScancollectionErrorMessageX_ByID, i)));
            }
            Assert.IsTrue(button.Enabled);
        }



        [TestMethod]
        public void ScanBarCodes()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var containerList = AutoElement.GetElementCollectionByName(appWin, VacutainersScanCollectionList_ByName);

            for (int i = 0; i < containerList.Count; i++)
            {
                do
                {
                    var barCode = UtilityClass.GetRandomNumber(100, 999).ToString() + UtilityClass.GetRandomNumber(1000000, 9999999).ToString();
                    //AutoAction.SetTextById(appWin, UtilityClass.GetListItemId(VacutainersScanCollectionBarcodeX_ByID, i), barCode);
                    var barcodeElement = AutoElement.GetElementById(appWin, UtilityClass.GetListItemId(VacutainersScanCollectionBarcodeX_ByID, i));
                    UIAutoHelper.performTextPattern(barcodeElement, barCode);
                    var displayedBarCode = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(VacutainersScanCollectionEnteredBarcodeX_ByID, i));
                    Assert.AreEqual(displayedBarCode, barCode);
                } while (AutoElement.VisibleByIdNoWait(appWin, UtilityClass.GetListItemId(VacutainersScancollectionErrorMessageX_ByID, i)));
            }
        }

        //try to enter the same barcode for two tests... and check the app behaviour
        [TestMethod]
        public void ScanSameBarCodes()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var containerList = AutoElement.GetElementCollectionByName(appWin, VacutainersScanCollectionList_ByName);
            var barCode = "";
            AutomationElement barcodeElement;
            var displayedBarCode = "";
            //generate random barcode and enter for the first test    
            do
            {
                barCode = UtilityClass.GetRandomNumber(100, 999).ToString() + UtilityClass.GetRandomNumber(1000000, 9999999).ToString();
                //AutoAction.SetTextById(appWin, UtilityClass.GetListItemId(VacutainersScanCollectionBarcodeX_ByID, i), barCode);
                barcodeElement = AutoElement.GetElementById(appWin, UtilityClass.GetListItemId(VacutainersScanCollectionBarcodeX_ByID, 0));
                UIAutoHelper.performTextPattern(barcodeElement, barCode);
                displayedBarCode = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(VacutainersScanCollectionEnteredBarcodeX_ByID, 0));
                Assert.AreEqual(displayedBarCode, barCode);
            } while (AutoElement.VisibleByIdNoWait(appWin, UtilityClass.GetListItemId(VacutainersScancollectionErrorMessageX_ByID, 0)));

            //enter the same barcode for the second test too...

            barcodeElement = AutoElement.GetElementById(appWin, UtilityClass.GetListItemId(VacutainersScanCollectionBarcodeX_ByID, 1));
            UIAutoHelper.performTextPattern(barcodeElement, barCode);
            displayedBarCode = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(VacutainersScanCollectionEnteredBarcodeX_ByID, 1));
            Assert.AreEqual(displayedBarCode, barCode);

            //Check whether the barcode of first test is cleared or not
            displayedBarCode = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(VacutainersScanCollectionEnteredBarcodeX_ByID, 0));
            barcodeElement = AutoElement.GetElementById(appWin, UtilityClass.GetListItemId(VacutainersScanCollectionBarcodeX_ByID, 0));
            if (displayedBarCode != "" || barcodeElement.Current.Name != "")
                Assert.Fail("When we enter the same barcode for two containers, the first one not been deleted");
            Assert.IsTrue(AutoElement.VisibleById(appWin, UtilityClass.GetListItemId(VacutainersScanCollectionPleaseScanX_ByID, 0)), "please scan label for first containers is not displayed");
        }


        [TestMethod]
        public void VacutainerUnableToCollect()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var containerList = AutoElement.GetElementCollectionByName(appWin, VacutainersScanCollectionList_ByName);

            for (int i = 0; i < containerList.Count; i++)
            {
                AutoAction.ClickButtonById(appWin, UtilityClass.GetListItemId(VacutainersScanCollectionFlagButtonX_ByID, i));
                AutoAction.ClickButtonById(appWin, UtilityClass.GetListItemId(VacutainerScanCollectionUnableToCollectX_ByID, i));
                Assert.IsTrue(AutoElement.VisibleById(appWin, UtilityClass.GetListItemId(VacutainersScanCollectionUnableToCollectMessageX_ByID, i)));
                var expectedName = AutoElement.GetElementById(appWin, UtilityClass.GetListItemId(VacutainersScanCollectionUnableToCollectMessageX_ByID, i)).Current.Name;
                if (expectedName != UnableToCollect)
                {
                    Assert.Fail("Expected name is not displayed");
                }
            }
            AutoAction.ClickButtonById(appWin, VacutainersScanCollectionNext_ByID);
            var reason = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(Reason_ByID));
            reason.Select(UtilityClass.GetRandomNumber(0, 20));
            AutoAction.ClickButtonById(appWin, Yes_ByID);
            AutoAction.ClickButtonById(appWin, Yes_ByID);
            Assert.IsTrue(AutoElement.ExistsById(appWin, DashboardModel.ScanReturnContainerHost_ByID));
        }


        [TestMethod]
        public void MoveToOtherContainersWithoutCentrifuge()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, VacutainersScanCollectionNext_ByID);
            Assert.IsNotNull(AutoElement.ExistsById(appWin, PrintAttachLabels.OtherContainersLabelsHost_ByID));
        }

        [TestMethod]
        public void MoveToOtherContainersWithCentrifuge()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, VacutainersScanCollectionNext_ByID);
            AutoAction.ClickButtonById(appWin, VacutainersStartCentrifuge_ByID);
            Assert.IsNotNull(AutoElement.ExistsById(appWin, PrintAttachLabels.OtherContainersLabelsHost_ByID));
        }


        [TestMethod]
        public void MoveToFinishWithoutCentrifuge()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, VacutainersScanCollectionNext_ByID);
            Assert.IsNotNull(AutoElement.ExistsById(appWin, VisitSummaryModel.VisitSummaryHost_ByID));
        }

        [TestMethod]
        public void MoveToFinishWithCentrifuge()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, VacutainersScanCollectionNext_ByID);
            AutoAction.ClickButtonById(appWin, VacutainersStartCentrifuge_ByID);
            Assert.IsNotNull(AutoElement.ExistsById(appWin, VisitSummaryModel.VisitSummaryHost_ByID));
        }

        [TestMethod]
        public void MoveToGlucoseDrink()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, VacutainersScanCollectionNext_ByID);
            Assert.IsTrue(AutoElement.VisibleById(appWin, GlucoseDrinkHost_ByID));
        }

        [TestMethod]
        public void MoveToStartTimer()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, VacutainersScanCollectionNext_ByID);
            Assert.IsTrue(AutoElement.VisibleById(appWin, PerformModel.GTTStarttime_ByID));
        }

        [TestMethod]
        public void VerifyForLightBlueTopScancollectionInstruction()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var host = AutoElement.GetElementByName(appWin, VacutainersScanCollectionList_ByName);
            var items = AutoElement.GetAllChilderen(host);

            var containerName = items[1].Current.Name;
            if (containerName == PrepareContainers.ContainerLightBlueTop)
            {
                var instruction = AutoElement.GetElementNameById(appWin, LightBlueTopScanCollectionInstruction_ByID);
                Assert.AreEqual(StoreInRoomTemprature, instruction, "Expected instruction is not displayed");
            }
        }

        [TestMethod]
        public void VerifyForGoldTopScanCollectionInstruction()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var host = AutoElement.GetElementByName(appWin, VacutainersScanCollectionList_ByName);
            var items = AutoElement.GetAllChilderen(host);

            var containerName = items[1].Current.Name;
            if (containerName == PrepareContainers.ContainerGoldTop)
            {
                var instruction = AutoElement.GetElementNameById(appWin, GoldTopScanCollectionInstruction_ByID);
                Assert.AreEqual(ColtFor15To30Minutes, instruction, "Expected instruction is not displayed");
            }
        }

        [TestMethod]
        public void VerifyForQFTScanCollectionInstruction()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var containerList = AutoElement.GetElementCollectionByName(appWin, VacutainersScanCollectionList_ByName);

            for (int i = 0; i < containerList.Count; i++)
            {
                var containerName = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(VacutainersScanColectionNameX_ByID, i));
                if (containerName == PrepareContainers.ContainerQFTGrey)
                {
                    var instruction = AutoElement.GetElementNameById(appWin,QFTTopScanCollectionInstructionX_ByID);
                    Assert.AreEqual(QFTTubes, instruction, "Expected instruction is not displayed");
                }

                else if (containerName == PrepareContainers.ContainerQFTRed)
                {
                    var instruction1 = AutoElement.GetElementNameById(appWin, QFTTopScanCollectionInstructionX_ByID);
                    Assert.AreEqual(QFTTubes, instruction1, "Expected instruction is not displayed");
                }

                else if (containerName == PrepareContainers.ContainerQFTPurple)
                {
                    var instruction2 = AutoElement.GetElementNameById(appWin, QFTTopScanCollectionInstructionX_ByID);
                    Assert.AreEqual(QFTTubes, instruction2, "Expected instruction is not displayed");
                }
            }
        }

        [TestMethod]
        public void VerifyForLavenderTubeScanCollectionInstruction()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var host = AutoElement.GetElementByName(appWin, VacutainersScanCollectionList_ByName);
            var items = AutoElement.GetAllChilderen(host);

            var containerName = items[1].Current.Name;
            if (containerName == PrepareContainers.ContainerLavender)
            {
                var instruction = AutoElement.GetElementNameById(appWin, LavenderTopScanCollectionInstruction_ByID);
                Assert.AreEqual(PlaceIntoRefrigerator, instruction, "Expected instruction is not displayed");
            }
        }

        [TestMethod]
        public void VerifyForPearlTopScanCollectionInstruction()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var host = AutoElement.GetElementByName(appWin, VacutainersScanCollectionList_ByName);
            var items = AutoElement.GetAllChilderen(host);

            var containerName = items[1].Current.Name;
            if (containerName == PrepareContainers.ContainerPearlTop)
            {
                var instruction = AutoElement.GetElementNameById(appWin, PearlTopScanCollectionInstruction_ByID);
                Assert.AreEqual(PlaceIntoCentrifuge, instruction, "Expected instruction is not displayed");
            }
        }

        [TestMethod]
        public void VerifyForTanTopScanCollectionInstruction()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var host = AutoElement.GetElementByName(appWin, VacutainersScanCollectionList_ByName);
            var items = AutoElement.GetAllChilderen(host);

            var containerName = items[1].Current.Name;
            if (containerName == PrepareContainers.ContainerTanTop)
            {
                var instruction = AutoElement.GetElementNameById(appWin, TanTopScanCollection_ByID);
                Assert.AreEqual(StoreInRoomTemprature, instruction, "Expected instruction is not displayed");
            }
        }

        [TestMethod]
        public void VerifyForTBNKLavenderTopScanCollectionInstruction()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var host = AutoElement.GetElementByName(appWin, VacutainersScanCollectionList_ByName);
            var items = AutoElement.GetAllChilderen(host);

            var containerName = items[1].Current.Name;
            if (containerName == PrepareContainers.ContainerLavender)
            {
                var instruction = AutoElement.GetElementNameById(appWin, LavenderTopTBNKScanCollectionInstruction_ByID);
                Assert.AreEqual(StoreInRoomTemprature, instruction, "Expected instruction is not displayed");
            }
        }
        //verify ...when Current Location is GSR Location3.. Special Handling Msg shall be displayed in Scan collection page
        [TestMethod]
        public void VerifyForSpecialHandling()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var vacCount = AutoElement.GetElementCollectionByName(appWin, VacutainersScanCollectionList_ByName);
            for (int i = 0; i < vacCount.Count; i++)
            {
                if (AutoElement.VisibleById(appWin, UtilityClass.GetListItemId(VacutainersScanCollectionSpecHandlErrMsg_ByID, i)))
                {
                    AutoAction.ClickButtonById(appWin, UtilityClass.GetListItemId(VacutainersScanCollectionSpecHandlErrMsg_ByID, i));
                    if (AutoElement.VisibleByClassName(appWin, SpecialHandlingWind_ByClass))
                    {
                        Assert.IsTrue(true);
                        AutoAction.ClickButtonByName(appWin, "OK");
                    }
                    else
                    {
                        Assert.Fail("Special Handling Message Not displayed");
                        break;
                    }


                }
                else
                {
                    Assert.Fail();
                    break;
                }
            }
        }
    }
}
