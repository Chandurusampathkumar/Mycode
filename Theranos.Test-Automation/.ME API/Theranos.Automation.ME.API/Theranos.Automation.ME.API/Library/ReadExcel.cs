using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Theranos.Automation.ME.Android.DataInput
{
    public class ReadExcel
    {

        public static List<string> ExcelCollection = new List<string>();
        public static string UserName = string.Empty;
        public static string Password = string.Empty;
        public static string DOB = string.Empty;
        public static string Email = string.Empty;
        public static string FirstName = string.Empty;
        public static string LastName = string.Empty;
        public static string City = string.Empty;
        public static string StreetLine1 = string.Empty;
        public static string StreetLine2 = string.Empty;
        public static string ZipCode = string.Empty;
        public static string Email2 = string.Empty;
        public static string MobileNumber = string.Empty;
        public static string HomeNumber = string.Empty;
        public static string InsureId = string.Empty;
        public static string Year = string.Empty;
        public static string Day = string.Empty;
        public static string Pscdate = string.Empty;
        public static string Question1 = string.Empty;
        public static string Answer1 = string.Empty;
        public static string Question2 = string.Empty;
        public static string Answer2 = string.Empty;
        public static string Question3 = string.Empty;
        public static string Answer3 = string.Empty;


        public static List<string> ReadrowExcel(String filepath, int sheetno, String status)
        {
            string excelfilename = filepath;
            List<string> _cellcollection = new List<string>();
            Excel.Application exapp = new Excel.Application();
            Excel.Workbook exwbk = exapp.Workbooks.Open(excelfilename, 0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, false, false);
            try
            {

                Excel.Sheets sheets = exwbk.Worksheets;
                Excel.Worksheet sheet = (Excel.Worksheet)sheets.get_Item(sheetno);

                // Excel.Worksheet sheet = exwbk.Sheets.[sheetno] as Excel.Worksheet;
                Excel.Range range = sheet.get_Range("A1", System.Reflection.Missing.Value);
                string rg = range.ToString();

                Excel.Range last = sheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                Excel.Range rangeval = sheet.get_Range("A1", last);
                int lastUsedRow = last.Row;

                for (int c = 2; c <= lastUsedRow; c++)
                {
                 //   Excel.Range range3 = sheet.get_Range("A" + c, System.Reflection.Missing.Value);
                    //   String Cellval2 = range3.Text;
                    Excel.Range range4 = sheet.get_Range("A" + c, System.Reflection.Missing.Value);

                    String rg4 = range4.Text;
                    // int Inccell = int.Parse(Cellval2);
                    string value2 = (c).ToString();

                   if (status.Trim().ToLower().Contains(""))
                    {
                        if (rg4.Equals(""))
                        {
                            string cell1 = "A" + value2 + ":" + "Y" + value2;
                            Excel.Range range1 = sheet.get_Range(cell1, System.Reflection.Missing.Value);
                            Excel.Range range2 = sheet.get_Range("A" + value2, System.Reflection.Missing.Value);
                            if (range1 != null)
                                foreach (Excel.Range rg1 in range1)
                                {
                                    string cellval = rg1.Text;
                                    _cellcollection.Add(cellval);
                                }
                            range2.Value = "Old";
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    }
                   else if (status.Trim().ToLower().Contains("Old"))
                   {
                       if (rg4.Equals("Old"))
                       {
                           string cell1 = "A" + value2 + ":" + "Y" + value2;
                           Excel.Range range1 = sheet.get_Range(cell1, System.Reflection.Missing.Value);
                           Excel.Range range2 = sheet.get_Range("A" + value2, System.Reflection.Missing.Value);
                           if (range1 != null)
                               foreach (Excel.Range rg1 in range1)
                               {
                                   string cellval = rg1.Text;
                                   _cellcollection.Add(cellval);
                               }
                           range2.Value = "OldLinked";
                       }
                       else
                       {
                           continue;
                       }
                       break;
                   }
              
                }

                return _cellcollection;
            }

            finally
            {
                exapp.DisplayAlerts = false;
                exwbk.Save();
                exwbk.Close(true, null, null);//SaveChanges:=True, Filename:=CurDir & FileToSave);
                exapp.Quit();

            }

        }
        public static void Excelindexvalue(String filepath, int sheetno,string status)
        {
            ExcelCollection = ReadrowExcel(filepath, sheetno, status);
           UserName = ExcelCollection[1].ToString();
            Password = ExcelCollection[2].ToString();
            DOB = ExcelCollection[3].ToString();
            Email = ExcelCollection[4].ToString();
            FirstName = ExcelCollection[5].ToString();
            LastName = ExcelCollection[6].ToString();
            City = ExcelCollection[7].ToString();
            StreetLine1 = ExcelCollection[8].ToString();
            StreetLine2 = ExcelCollection[9].ToString();
            ZipCode = ExcelCollection[10].ToString();
            Email2 = ExcelCollection[11].ToString();
            MobileNumber = ExcelCollection[12].ToString();
            HomeNumber = ExcelCollection[13].ToString();
            InsureId = ExcelCollection[14].ToString();
            Year = ExcelCollection[15].ToString();
            Day = ExcelCollection[16].ToString();
            Pscdate = ExcelCollection[17].ToString();
            Question1 = ExcelCollection[18].ToString();
            Answer1 = ExcelCollection[19].ToString();
            Question2 = ExcelCollection[20].ToString();
            Answer2 = ExcelCollection[21].ToString();
            Question3 = ExcelCollection[22].ToString();
            Answer3 = ExcelCollection[23].ToString();
        }


        //    public static string TestDataLoc = System.Configuration.ConfigurationManager.AppSettings["TestDataDirectory"];
    //  //  public static string filename = @"C:\csampathkumar\Source\Theranos.Test-Automation\.ME API\Internal\Production\UserAccounts.xlsx";
    //    public static string filename = TestDataLoc + "UserAccounts.xlsx";
    //    public static List<string> ReadrowExcel()
    //    {

    //        //string excelfilename = @"C:\Users\balaji.venkat\Source\Workspaces\Theranos.Test-Automation\.ME Android\Internal\Input\AndroidMEUserinfo.xlsx";
    //        List<string> _cellcollection = new List<string>();
    //        Excel.Application exapp = new Excel.Application();
    //        Excel.Workbook exwbk = exapp.Workbooks.Open(filename, 0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, false, false);
    //        Excel.Worksheet sheet = exwbk.Sheets[1] as Excel.Worksheet;
    //        Excel.Range range = sheet.get_Range("A2", System.Reflection.Missing.Value);
    //        string rg = range.ToString();
    //        for (int c = 2; c < 60; c++)
    //        {
    //            Excel.Range range4 = sheet.get_Range("A" + c, System.Reflection.Missing.Value);
    //            string rg4 = range4.Text;

    //            Excel.Range range3 = sheet.get_Range("B" + c, System.Reflection.Missing.Value);
    //            String Cellval2 = range3.Text;
    //            String Cellval3 = Cellval2;
    //            int Inccell = int.Parse(Cellval3);
    //            string value2 = (Inccell + 1).ToString();

    //            if (rg4 != "Old")
    //            {
    //                string cell1 = "B" + value2 + ":" + "S" + value2;
    //                Excel.Range range1 = sheet.get_Range(cell1, System.Reflection.Missing.Value);
    //                Excel.Range range2 = sheet.get_Range("A" + value2, System.Reflection.Missing.Value);
    //                if (range1 != null)
    //                    foreach (Excel.Range rg1 in range1)
    //                    {
    //                        string cellval = rg1.Text;
    //                        _cellcollection.Add(cellval);
    //                    }
    //                range2.Value = "Old";
    //            }
    //            else
    //            {
    //                continue;
    //            }
    //            break;

    //        }
    //        exapp.DisplayAlerts = false;
    //        exwbk.Save();
    //        exwbk.Close(true, null, null);//SaveChanges:=True, Filename:=CurDir & FileToSave);
    //        exapp.Quit();
    //        return _cellcollection;
    //    }
       
    //    public static List<string> ReadrowExcel(int sheetno)
    //    {
    //        string excelfilename = filename;
    //        List<string> _cellcollection = new List<string>();
    //        Excel.Application exapp = new Excel.Application();
    //        Excel.Workbook exwbk = exapp.Workbooks.Open(excelfilename, 0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, false, false);
    //        try
    //        {
    //            Excel.Sheets sheets = exwbk.Worksheets;
    //            Excel.Worksheet sheet = (Excel.Worksheet)sheets.get_Item(sheetno);

    //            // Excel.Worksheet sheet = exwbk.Sheets.[sheetno] as Excel.Worksheet;
    //            Excel.Range range = sheet.get_Range("A1", System.Reflection.Missing.Value);
    //            string rg = range.ToString();

    //            Excel.Range last = sheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
    //            Excel.Range rangeval = sheet.get_Range("A1", last);
    //            int lastUsedRow = last.Row;

    //            for (int c = 2; c <= lastUsedRow; c++)
    //            {
    //                Excel.Range range3 = sheet.get_Range("A" + c, System.Reflection.Missing.Value);
    //                //   String Cellval2 = range3.Text;
    //                Excel.Range range4 = sheet.get_Range("B" + c, System.Reflection.Missing.Value);

    //                String rg4 = range4.Text;
    //                // int Inccell = int.Parse(Cellval2);
    //                string value2 = (c).ToString();

    //                if (rg4 != "Old")
    //                {
    //                    string cell1 = "B" + value2 + ":" + "N" + value2;
    //                    Excel.Range range1 = sheet.get_Range(cell1, System.Reflection.Missing.Value);
    //                    Excel.Range range2 = sheet.get_Range("B" + value2, System.Reflection.Missing.Value);
    //                    if (range1 != null)
    //                        foreach (Excel.Range rg1 in range1)
    //                        {
    //                            string cellval = rg1.Text;
    //                            _cellcollection.Add(cellval);
    //                        }
    //                    range2.Value = "Old";
    //                }
    //                else
    //                {
    //                    continue;
    //                }
    //                break;
    //            }

    //            return _cellcollection;
    //        }
    //        finally
    //        {
    //            exapp.DisplayAlerts = false;
    //            exwbk.Save();
    //            exwbk.Close(true, null, null);//SaveChanges:=True, Filename:=CurDir & FileToSave);
    //            exapp.Quit();

    //        }

    //    }

    }
}

