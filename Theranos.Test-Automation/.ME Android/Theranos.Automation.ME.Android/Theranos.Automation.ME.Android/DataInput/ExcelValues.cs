using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Theranos.Automation.ME.Android.DataInput;
using System.Collections.Generic;


namespace Theranos.Automation.ME.Android.DataInput.Inputpro
{
    [TestClass]
    public class ExcelValues : ReadExcel
    {

        public static List<string> ExcelCollection = new List<string>();
        public static string NewUserName = string.Empty;
        public static string Linkusername = string.Empty;
        public static string FirstName = string.Empty;
        public static string LastName = string.Empty;
        public static string City = string.Empty;
        public static string StreetLine1 = string.Empty;
        public static string StreetLine2 = string.Empty;
        public static string ZipCode = string.Empty;
        public static string Email = string.Empty;
        public static string MobileNumber = string.Empty;
        public static string HomeNumber = string.Empty;
        public static string InsureId = string.Empty;
        public static string unlinkedacc = string.Empty;
        public static string Year = string.Empty;
        public static string Day = string.Empty;  



        
        public static void Excelindexvalue()
        {

            ExcelCollection = ReadrowExcel();
            
            NewUserName = ExcelCollection[1].ToString();
            unlinkedacc = ExcelCollection[2].ToString();
            Linkusername = ExcelCollection[3].ToString();
            FirstName = ExcelCollection[4].ToString();
            LastName = ExcelCollection[5].ToString();
            City = ExcelCollection[6].ToString();
            StreetLine1 = ExcelCollection[7].ToString();
            StreetLine2 = ExcelCollection[8].ToString();
            ZipCode = ExcelCollection[9].ToString();
            Email = ExcelCollection[10].ToString();
            MobileNumber = ExcelCollection[11].ToString();
            HomeNumber = ExcelCollection[12].ToString();
            InsureId = ExcelCollection[13].ToString();
            Year = ExcelCollection[14].ToString();
            Day = ExcelCollection[15].ToString();
        }
    }
}
