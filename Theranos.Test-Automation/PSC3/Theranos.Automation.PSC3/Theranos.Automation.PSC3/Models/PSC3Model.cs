using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.Drawing.Imaging;
using Theranos.Automation.AutoStack.Utility;
namespace Theranos.Automation.PSC3.Models
{
    [TestClass]
    public class PSC3Model:AutoStack.AutoStack
    {
        public TestContext TestContext { get; set; }
        public static string AppWindowName = "Theranos.PSC";
        public const string SmallSpinner_ByClass = "SmallSpiner";
        public const string Next_ByName = "NEXT";
        public const string Popup_ByClass = "Popup";
        public const string TextEditorDropDown_ByID = "PART_Editor";
        public const string TextBlock_ByClass = "TextBlock";
        public const string Save_ByName = "SAVE";
        public const string ScrollViewer_ByClass = "ScrollViewer";

        public const string Button_ByClass="Button";
        public const string BusyBox_ByClass = "BusyBox";
        public const string ListBox_ByClass = "ListBox";
        public const string ListBoxItem_ByClass = "ListBoxItem";
        public const string TextBox_ById = ".TextBox";
        public const string Print_ByName = "Print";
        public const string PrintCancel_ByName = "Cancel";
        public const string XPSDocument_ByName = "Microsoft XPS Document Writer";
        public const string FileName_ByName = "File name:";
        public const string Edit_ByClass = "Edit";
        public const string FileSave_ByName = "Save";
        public const string NavigationBar_ById = "NavigationBar";
        public const string Image_ByClass = "Image";
        public const string Cancel_ByName = "CANCEL";
        public const string CheckBox_ByClass = "CheckBox";

        public const string Yes = "YES";
        public const string No = "NO";

        public static bool IsNanotainerEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["IsNanotainerEnabled"]);

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