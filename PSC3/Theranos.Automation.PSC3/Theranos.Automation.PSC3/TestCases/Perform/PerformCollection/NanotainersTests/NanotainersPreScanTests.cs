
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
using System.Collections.Generic;

namespace Theranos.Automation.PSC3.TestCases.Perform.PerformCollection.NanotainersTests
{
    [TestClass]
    public class NanotainersPreScanTests:PrescanNanotainers
    {
        [TestMethod]
        public void MoveToCollectSamples()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, NanotainersPrescanNext_ByID);
            Assert.IsTrue(AutoElement.ExistsById(appWin, NanotainersSampleCollectionTests.SampleCollectionHost_ByID));
        }

        //[TestMethod]
        //public void PreScanNanotainersTest()
        //{
        //    var barcode = PreScanNanotainer();

        //    var a = 1;
        //}

        /// <summary>
        /// Entering general invalid barcode number
        /// </summary>
        [TestMethod]
        public void PreScanInvalidPurpleBarcode1()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var containerList = AutoElement.GetElementCollectionByName(appWin, NanotainersList_ByName);

            for (int i = 0; i < containerList.Count; i++)
            {
                if (AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(NanotainersPrescanNameX_ByID, i)) == NanotainerPurple)
                {
                string barCode;
                do
                {
                    barCode = UtilityClass.GetRandomNumber(0, 9).ToString() + UtilityClass.GetRandomNumber(0, 9).ToString() + UtilityClass.GetRandomNumber(0, 9).ToString();
                } while (barCode=="029"||barCode=="036");
                barCode += UtilityClass.GetRandomNumber(100000, 999999).ToString() + UtilityClass.GetRandomNumber(1000000, 9999999).ToString();
                AutoAction.SetTextById(appWin,UtilityClass.GetListItemId(NanotainersPrescanBarcodeX_ByID,i),barCode);
                Assert.IsTrue(AutoElement.VisibleById(appWin,UtilityClass.GetListItemId(NanotainersPrescanBarcodeErrorX_ByID,i)));
                var errorMessage = AutoElement.GetElementNameById(appWin,UtilityClass.GetListItemId(NanotainersPrescanBarcodeErrorX_ByID,i));
                Assert.AreEqual(errorMessage,NanotainerPurpleInvalidBarCodeErrorMessage);
                }
            }
        }


        /// <summary>
        /// Entering Valid Nanotainer Green Barcode
        /// </summary>
        [TestMethod]
        public void PreScanInvalidPurpleBarCode2()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var containerList = AutoElement.GetElementCollectionByName(appWin, NanotainersList_ByName);
            for (int i = 0; i < containerList.Count; i++)
            {
                if (AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(NanotainersPrescanNameX_ByID, i)) == NanotainerPurple)
                {
                    string barCode;
                    barCode = "036" + UtilityClass.GetRandomNumber(100000, 999999).ToString() + UtilityClass.GetRandomNumber(1000000, 9999999).ToString();
                    AutoAction.SetTextById(appWin, UtilityClass.GetListItemId(NanotainersPrescanBarcodeX_ByID, i), barCode);
                    Assert.IsTrue(AutoElement.VisibleById(appWin, UtilityClass.GetListItemId(NanotainersPrescanBarcodeErrorX_ByID, i)));
                    var errorMessage = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(NanotainersPrescanBarcodeErrorX_ByID, i));
                    Assert.AreEqual(errorMessage, NanotainerPurpleInvalidBarCodeErrorMessage);
                }
            }
        }

        /// <summary>
        /// Entering General Invalid barcode
        /// </summary>
        [TestMethod]
        public void PreScanInvalidGreenBarCode1()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var containerList = AutoElement.GetElementCollectionByName(appWin, NanotainersList_ByName);

            for (int i = 0; i < containerList.Count; i++)
            {
                if (AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(NanotainersPrescanNameX_ByID, i)) == NanotainerGreen)
                {
                    string barCode;
                    do
                    {
                        barCode = UtilityClass.GetRandomNumber(0, 9).ToString() + UtilityClass.GetRandomNumber(0, 9).ToString() + UtilityClass.GetRandomNumber(0, 9).ToString();
                    } while (barCode == "029" || barCode == "036");
                    barCode += UtilityClass.GetRandomNumber(100000, 999999).ToString() + UtilityClass.GetRandomNumber(1000000, 9999999).ToString();
                    AutoAction.SetTextById(appWin, UtilityClass.GetListItemId(NanotainersPrescanBarcodeX_ByID, i), barCode);
                    Assert.IsTrue(AutoElement.VisibleById(appWin, UtilityClass.GetListItemId(NanotainersPrescanBarcodeErrorX_ByID, i)));
                    var errorMessage = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(NanotainersPrescanBarcodeErrorX_ByID, i));
                    Assert.AreEqual(errorMessage, NanotainerGreenInvalidBarCodeErrorMessage);
                }
            }
        }

        /// <summary>
        /// Entering Valid Purple barcode
        /// </summary>
        [TestMethod]
        public void PreScanInvalidGreenBarCode2()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var containerList = AutoElement.GetElementCollectionByName(appWin, NanotainersList_ByName);
            for (int i = 0; i < containerList.Count; i++)
            {
                if (AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(NanotainersPrescanNameX_ByID, i)) == NanotainerGreen)
                {
                    string barCode;
                    barCode = "029" + UtilityClass.GetRandomNumber(100000, 999999).ToString() + UtilityClass.GetRandomNumber(1000000, 9999999).ToString(); AutoAction.SetTextById(appWin, UtilityClass.GetListItemId(NanotainersPrescanBarcodeX_ByID, i), barCode);
                    Assert.IsTrue(AutoElement.VisibleById(appWin, UtilityClass.GetListItemId(NanotainersPrescanBarcodeErrorX_ByID, i)));
                    var errorMessage = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(NanotainersPrescanBarcodeErrorX_ByID, i));
                    Assert.AreEqual(errorMessage, NanotainerGreenInvalidBarCodeErrorMessage);
                }
            }
        }

        //[TestMethod]
        //public void PreScan()
        //{
        //    PreScanNanotainer();
        //}

        public List<string> PreScanNanotainer()
        {
            
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            List<string> barCodes = new List<string>();
            
            var containerList = AutoElement.GetElementCollectionByName(appWin, NanotainersList_ByName);
          
            for (int i = 0; i < containerList.Count; i++)
            {

                if (AutoElement.GetElementNameById(appWin,UtilityClass.GetListItemId(NanotainersPrescanNameX_ByID,i))==NanotainerGreen)
                {
                    
                    string barCode;
                    do
                    {
                       
                        barCode = "036" + UtilityClass.GetRandomNumber(100000, 999999).ToString() + UtilityClass.GetRandomNumber(1000000, 9999999).ToString();
                        AutoAction.SetTextById(appWin, UtilityClass.GetListItemId(NanotainersPrescanBarcodeX_ByID, i), barCode);
                        var displayedBarCode = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(NanotainersPrescanEnteredBarcodeX_ByID, i));
                        Assert.AreEqual(displayedBarCode, barCode);
                       
                    } while (AutoElement.VisibleByIdNoWait(appWin,UtilityClass.GetListItemId(NanotainersPrescanBarcodeErrorX_ByID,i)));
                    barCodes.Add(barCode);
                   
                }
                else if (AutoElement.GetElementNameById(appWin,UtilityClass.GetListItemId(NanotainersPrescanNameX_ByID,i))==NanotainerPurple)
                {
                    
                    string barCode;
                    do
                    {
                        
                        barCode = "029" + UtilityClass.GetRandomNumber(100000, 999999).ToString() + UtilityClass.GetRandomNumber(1000000, 9999999).ToString();
                        AutoAction.SetTextById(appWin, UtilityClass.GetListItemId(NanotainersPrescanBarcodeX_ByID, i), barCode);
                        var displayedBarCode = AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(NanotainersPrescanEnteredBarcodeX_ByID, i));
                        Assert.AreEqual(displayedBarCode, barCode);                       
                        
                    } while (AutoElement.VisibleByIdNoWait(appWin,UtilityClass.GetListItemId(NanotainersPrescanBarcodeErrorX_ByID,i)));
                    barCodes.Add(barCode);
                    
                }
            }
            
            return barCodes;
        }

        public List<string> PreScanNanotainerButtonMandatory()
        {

            var appWin = AutoElement.GetWindowByName(AppWindowName);
            List<string> barCodes = new List<string>();

            var containerList = AutoElement.GetElementCollectionByName(appWin, NanotainersList_ByName);
            var button = AutoElement.GetButtonById(appWin, NanotainersPrescanNext_ByID);
            for (int i = 0; i < containerList.Count; i++)
            {
                Assert.IsFalse(button.Enabled);
                if (AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(NanotainersPrescanNameX_ByID, i)) == NanotainerGreen)
                {

                    string barCode;
                    do
                    {

                        barCode = "036" + UtilityClass.GetRandomNumber(100000, 999999).ToString() + UtilityClass.GetRandomNumber(1000000, 9999999).ToString();
                        AutoAction.SetTextById(appWin, UtilityClass.GetListItemId(NanotainersPrescanBarcodeX_ByID, i), barCode);
                      

                    } while (AutoElement.VisibleByIdNoWait(appWin, UtilityClass.GetListItemId(NanotainersPrescanBarcodeErrorX_ByID, i)));
                    barCodes.Add(barCode);

                }
                else if (AutoElement.GetElementNameById(appWin, UtilityClass.GetListItemId(NanotainersPrescanNameX_ByID, i)) == NanotainerPurple)
                {

                    string barCode;
                    do
                    {

                        barCode = "029" + UtilityClass.GetRandomNumber(100000, 999999).ToString() + UtilityClass.GetRandomNumber(1000000, 9999999).ToString();
                        AutoAction.SetTextById(appWin, UtilityClass.GetListItemId(NanotainersPrescanBarcodeX_ByID, i), barCode);
                        

                    } while (AutoElement.VisibleByIdNoWait(appWin, UtilityClass.GetListItemId(NanotainersPrescanBarcodeErrorX_ByID, i)));
                    barCodes.Add(barCode);

                }

                else
                {
                    Assert.Fail("Other Containers are present");
                }
            }
            Assert.IsTrue(button.Enabled);

            return barCodes;
        }

    }
}
