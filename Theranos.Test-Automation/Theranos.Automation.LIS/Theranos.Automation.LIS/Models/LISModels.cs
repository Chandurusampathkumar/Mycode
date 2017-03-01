using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.Drawing.Imaging;
using Theranos.Automation.AutoStack.Utility;

//@Author Fangming Lu

namespace Theranos.Automation.LIS.Models
{
    [TestClass]
    public class LISModel : AutoStack.AutoStack
    {
        public TestContext TestContext { get; set; }
        public static string LISAppWindowName = "Theranos.LIS.2.0.QA";
        public const string SmallSpinnerByClass = "SmallSpiner";
        public const string NextByName = "NEXT";
        public const string MenuItemByClass = "MenuItem";
        public const string TextBlockByClass = "TextBlock";
        public const string SaveByName = "SAVE";
        public const string ToolBarByName = "ToolBar";
        public const string ButtonByClass="Button";
        public const string MenuByClass = "Menu";
        public const string ListBoxByClass = "ListBox";
        public const string ListBoxItemByClass = "ListBoxItem";
        public const string TextBoxById = ".TextBox";
        public const string MenuItemById = "Main.TopNavigationMenu.Menu.mnuVisits.MenuItem";
        public const string LableTextById = "LabelText";
        public const string ImageByClass = "Image";
        public const string CancelByName = "CANCEL";
        public const string PopUpWindowOkButtonById = "Common.WPFMessageBox.CustomOk.Button";
        public const string PopUpWindownConfirmCloseById = "Common.WPFMessageBox.CustomYes.Button";
        public static bool IsNanotainerEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["IsNanotainerEnabled"]);
        public static string MenuItemAddPage = "Main.TopNavigationMenu.Menu.AddTab.MenuItem";

        [TestCleanup()]
        public void Cleanup()
        {
            TakeScreenShot();
        }

        public void TakeScreenShot()
        {
            ScreenshotHelper.CaptureScreenToFile( TestContext.TestName+" "+ UtilityClass.GetCurrentDate()+".png", ImageFormat.Png);
        }

        public void TakeScreenShot(string fileName)
        {
            ScreenshotHelper.CaptureScreenToFile(fileName + " " + UtilityClass.GetCurrentDate() + ".png", ImageFormat.Png);
        }
    }
}
