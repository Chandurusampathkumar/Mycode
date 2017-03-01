
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
using Theranos.Automation.PSC3.Models.Perform.PerformCollection.Nanotainers;
using Theranos.Automation.PSC3.Models.Perform.PerformCollection.Vacutainers;
using Theranos.Automation.PSC3.Models.Perform.PerformCollection.OtherContainers;
using System.Collections.Generic;
using TestStack.White.UIItems.ListBoxItems;



namespace Theranos.Automation.PSC3.TestCases.Perform.PerformCollection.NanotainersTests
{
    [TestClass]
    public class NanotainersScanCollectionTests : NanotainersScanCollection
    {

        [TestMethod]
        public void MoveToVacutainersWithoutCentrifuge()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, NanotainersPostscanNextButton_ByID);
            //var vacutainerHost = AutoElement.GetElementById(appWin,VacutainersSampleCollection.VacutainersSampleCollectionHost_ByClass);
            Assert.IsNotNull(AutoElement.ExistsById(appWin, VacutainersSampleCollection.VacutainersSampleCollectionHost_ByClass));
        }

        [TestMethod]
        public void MoveToVacutainersWithCentrifuge()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, NanotainersPostscanNextButton_ByID);
            AutoAction.ClickButtonById(appWin, PerformModel.Start_ByID);
            //var vacutainerHost = AutoElement.GetElementById(appWin, VacutainersSampleCollection.VacutainersSampleCollectionHost_ByClass);
            Assert.IsNotNull(AutoElement.ExistsById(appWin, VacutainersSampleCollection.VacutainersSampleCollectionHost_ByClass));
        }

        [TestMethod]
        public void MoveToOtherContainersWithoutCentrifuge()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, NanotainersPostscanNextButton_ByID);
            //var otherContainerHost = AutoElement.GetElementById(appWin,PrintAttachLabels.OtherContainersLabelsHost_ByID);
            Assert.IsNotNull(AutoElement.ExistsById(appWin, PrintAttachLabels.OtherContainersLabelsHost_ByID));
        }

        [TestMethod]
        public void MoveToOtherContainersWithCentrifuge()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, NanotainersPostscanNextButton_ByID);
            AutoAction.ClickButtonById(appWin, PerformModel.Start_ByID);
            //var otherContainerHost = AutoElement.GetElementById(appWin, PrintAttachLabels.OtherContainersLabelsHost_ByID);
            Assert.IsNotNull(AutoElement.ExistsById(appWin, PrintAttachLabels.OtherContainersLabelsHost_ByID));
        }

        [TestMethod]
        public void MoveToFinishWithoutCentrifuge()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, NanotainersPostscanNextButton_ByID);
            //var finishHost = AutoElement.GetElementById(appWin,PerformModel.VisitSummaryHost_ByID);
            Assert.IsNotNull(AutoElement.ExistsById(appWin, VisitSummaryModel.VisitSummaryHost_ByID));
        }

        [TestMethod]
        public void MoveToFinishWithCentrifuge()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, NanotainersPostscanNextButton_ByID);
            AutoAction.ClickButtonById(appWin, PerformModel.Start_ByID);
            //var finishHost = AutoElement.GetElementById(appWin, PerformModel.VisitSummaryHost_ByID);
            Assert.IsNotNull(AutoElement.ExistsById(appWin, VisitSummaryModel.VisitSummaryHost_ByID));
        }

        [TestMethod]
        public void PostScanValidation()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickUIItemByName(appWin, "CONFIRM");
        }


        /// <summary>
        /// Entering General Invalid barcode
        /// </summary>
        [TestMethod]
        public void PostScanInvalidGreenBarCode1()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var containerList = AutoElement.GetElementCollectionByName(appWin, PostscanNanotainersList_ByName);

            for (int i = 0; i < containerList.Count; i++)
            {
                if (AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(NanotainersPostscanNameX_ByID, i)) == PrescanNanotainers.NanotainerGreen)
                {
                    string barCode;
                    do
                    {
                        barCode = UtilityClass.GetRandomNumber(0, 9).ToString() + UtilityClass.GetRandomNumber(0, 9).ToString() + UtilityClass.GetRandomNumber(0, 9).ToString();
                    } while (barCode == "029" || barCode == "036");
                    barCode += UtilityClass.GetRandomNumber(100000, 999999).ToString() + UtilityClass.GetRandomNumber(1000000, 9999999).ToString();
                    AutoAction.SetTextById(appWin, UtilityClass.GetListItemId(NanotainersPostscanBarcodeX_ByID, i), barCode);
                    Assert.IsTrue(AutoElement.VisibleById(appWin, UtilityClass.GetListItemId(NanotainersPostscanErrorMessageX_ByID, i)));
                    var errorMessage = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(NanotainersPostscanErrorMessageX_ByID, i));
                    Assert.AreEqual(errorMessage, PrescanNanotainers.NanotainerGreenInvalidBarCodeErrorMessage);
                }
            }
        }


        /// <summary>
        /// Entering Valid Purple barcode
        /// </summary>
        [TestMethod]
        public void PostScanInvalidGreenBarCode2()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var containerList = AutoElement.GetElementCollectionByName(appWin, PostscanNanotainersList_ByName);
            for (int i = 0; i < containerList.Count; i++)
            {
                if (AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(NanotainersPostscanNameX_ByID, i)) == PrescanNanotainers.NanotainerGreen)
                {
                    string barCode;
                    barCode = "029" + UtilityClass.GetRandomNumber(100000, 999999).ToString() + UtilityClass.GetRandomNumber(1000000, 9999999).ToString(); 
                    AutoAction.SetTextById(appWin, UtilityClass.GetListItemId(NanotainersPostscanBarcodeX_ByID, i), barCode);
                    Assert.IsTrue(AutoElement.VisibleById(appWin, UtilityClass.GetListItemId(NanotainersPostscanErrorMessageX_ByID, i)));
                    var errorMessage = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(NanotainersPostscanErrorMessageX_ByID, i));
                    Assert.AreEqual(errorMessage, PrescanNanotainers.NanotainerGreenInvalidBarCodeErrorMessage);
                }
            }
        }


        /// <summary>
        /// Entering general invalid barcode number
        /// </summary>
        [TestMethod]
        public void PostScanInvalidPurpleBarcode1()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var containerList = AutoElement.GetElementCollectionByName(appWin, PostscanNanotainersList_ByName);

            for (int i = 0; i < containerList.Count; i++)
            {
                if (AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(NanotainersPostscanNameX_ByID, i)) == PrescanNanotainers.NanotainerPurple)
                {
                    string barCode;
                    do
                    {
                        barCode = UtilityClass.GetRandomNumber(0, 9).ToString() + UtilityClass.GetRandomNumber(0, 9).ToString() + UtilityClass.GetRandomNumber(0, 9).ToString();
                    } while (barCode == "029" || barCode == "036");
                    barCode += UtilityClass.GetRandomNumber(100000, 999999).ToString() + UtilityClass.GetRandomNumber(1000000, 9999999).ToString();
                    AutoAction.SetTextById(appWin, UtilityClass.GetListItemId(NanotainersPostscanBarcodeX_ByID, i), barCode);
                    Assert.IsTrue(AutoElement.VisibleById(appWin, UtilityClass.GetListItemId(NanotainersPostscanErrorMessageX_ByID, i)));
                    var errorMessage = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(NanotainersPostscanErrorMessageX_ByID, i));
                    Assert.AreEqual(errorMessage, PrescanNanotainers.NanotainerPurpleInvalidBarCodeErrorMessage);
                }
            }
        }


        /// <summary>
        /// Entering Valid Nanotainer Green Barcode
        /// </summary>
        [TestMethod]
        public void PostScanInvalidPurpleBarCode2()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var containerList = AutoElement.GetElementCollectionByName(appWin, PostscanNanotainersList_ByName);
            for (int i = 0; i < containerList.Count; i++)
            {
                if (AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(NanotainersPostscanNameX_ByID, i)) == PrescanNanotainers.NanotainerPurple)
                {
                    string barCode;
                    barCode = "036" + UtilityClass.GetRandomNumber(100000, 999999).ToString() + UtilityClass.GetRandomNumber(1000000, 9999999).ToString();
                    AutoAction.SetTextById(appWin, UtilityClass.GetListItemId(NanotainersPostscanBarcodeX_ByID, i), barCode);
                    Assert.IsTrue(AutoElement.VisibleById(appWin, UtilityClass.GetListItemId(NanotainersPostscanErrorMessageX_ByID, i)));
                    var errorMessage = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(NanotainersPostscanErrorMessageX_ByID, i));
                    Assert.AreEqual(errorMessage, PrescanNanotainers.NanotainerPurpleInvalidBarCodeErrorMessage);
                }
            }
        }

        //[TestMethod]
        //public void PostScan()
        //{
        //    
        //}

        public void PostScanNanotainerButtonMandatory(List<string> barCodes)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var containerList = AutoElement.GetElementCollectionByName(appWin, PostscanNanotainersList_ByName);
            var button = AutoElement.GetButtonById(appWin, NanotainersPostscanNextButton_ByID);
            for (int i = 0; i < containerList.Count; i++)
            {
                Assert.IsFalse(button.Enabled);
                AutoAction.SetTextById(appWin, UtilityClass.GetListItemId(NanotainersPostscanBarcodeX_ByID, i), barCodes[i]);

            }
            Thread.Sleep(WaitTime);
            Assert.IsTrue(button.Enabled);
        }

        public void PostScanNanotainer(List<string> barCodes)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var containerList = AutoElement.GetElementCollectionByName(appWin, PostscanNanotainersList_ByName);

            for (int i = 0; i < containerList.Count; i++)
            {
                AutoAction.SetTextById(appWin, UtilityClass.GetListItemId(NanotainersPostscanBarcodeX_ByID, i), barCodes[i]);
                
            }
        }

        [TestMethod]
        public void PostScanNanotainer()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var containerList = AutoElement.GetElementCollectionByName(appWin, PostscanNanotainersList_ByName);

            for (int i = 0; i < containerList.Count; i++)
            {

                if (AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(NanotainersPostscanNameX_ByID, i)) == PrescanNanotainers.NanotainerGreen)
                {
                    string barCode = "036" + UtilityClass.GetRandomNumber(100000, 999999).ToString() + UtilityClass.GetRandomNumber(1000000, 9999999).ToString();
                    AutoAction.SetTextById(appWin, UtilityClass.GetListItemId(NanotainersPostscanBarcodeX_ByID, i), barCode);
                    PostScanValidation();
                    
               
                }
                else if (AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(NanotainersPostscanNameX_ByID, i)) == PrescanNanotainers.NanotainerPurple)
                {
                    string barCode = "029" + UtilityClass.GetRandomNumber(100000, 999999).ToString() + UtilityClass.GetRandomNumber(1000000, 9999999).ToString();
                    AutoAction.SetTextById(appWin, UtilityClass.GetListItemId(NanotainersPostscanBarcodeX_ByID, i), barCode);
                    PostScanValidation();
                    
                }
                else
                {
                    Assert.Fail("Other Containers are present");
                }

                //AutoAction.SetTextById(appWin, UtilityClass.GetListItemId(NanotainersPostscanBarcodeX_ByID, i), "");
            }
        }

        [TestMethod]
        public void NanotainerUnableToCollect()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var containerList = AutoElement.GetElementCollectionByName(appWin, PostscanNanotainersList_ByName);
            for (int i = 0; i < containerList.Count; i++)
            {
                AutoAction.ClickButtonById(appWin, UtilityClass.GetListItemId(NanotainersPostscanFlagX_ByID,i));
                Assert.IsTrue(AutoElement.VisibleById(appWin, UtilityClass.GetListItemId(NanotainersPostscanUnableToCollectX_ByID,i)));
                var expectedName = AutoElement.GetElementById(appWin, UtilityClass.GetListItemId(NanotainersPostscanUnableToCollectX_ByID,i)).Current.Name;
                if (expectedName!=UnableToCollect)
                {
                    Assert.Fail("Expected name is not displayed");
                }
            }
            AutoAction.ClickButtonById(appWin,NanotainersPostscanNextButton_ByID);
            var reason = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(Reason_ByID));
            reason.Select(UtilityClass.GetRandomNumber(0, 20));
            AutoAction.ClickButtonById(appWin, Yes_ByID);
            AutoAction.ClickButtonById(appWin, Yes_ByID);
            Assert.IsTrue(AutoElement.ExistsById(appWin, DashboardModel.ScanReturnContainerHost_ByID));
        }

        [TestMethod]
        public void PostScanNanotainerInstruction()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var containerList = AutoElement.GetElementCollectionByName(appWin, PostscanNanotainersList_ByName);
            for (int i = 0; i < containerList.Count; i++)
            {
                if (AutoElement.GetElementNameById(appWin,UtilityClass.GetListItemId(NanotainersPostscanNameX_ByID,i))==PrescanNanotainers.NanotainerGreen)
                {
                    var instruction = AutoElement.GetElementNameById(appWin,UtilityClass.GetListItemId(NanotainersPostscanPlaceintoCentrifugeX_ByID,i));
                    Assert.AreEqual(instruction,PlaceInCentrifuge);
                }
                else if(AutoElement.GetElementNameById(appWin,UtilityClass.GetListItemId(NanotainersPostscanNameX_ByID,i))==PrescanNanotainers.NanotainerPurple)
                {
                    var instruction1= AutoElement.GetElementNameById(appWin,UtilityClass.GetListItemId(NanotainersPostscanPlaceintoRefrigeratorX_ByID,i));
                    Assert.AreEqual(instruction1,PlaceInRefrigerator);
                }
            }
        }
    }
}
