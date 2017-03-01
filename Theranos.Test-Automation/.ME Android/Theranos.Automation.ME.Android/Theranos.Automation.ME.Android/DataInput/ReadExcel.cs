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

        public static List<string> ReadrowExcel()
        {


            string excelfilename = @"C:\csampathkumar\Source\Theranos.Test-Automation\.ME Android\Internal\Input\AndroidMEUserinfo.xlsx";
            List<string> _cellcollection = new List<string>();
            Excel.Application exapp = new Excel.Application();
            Excel.Workbook exwbk = exapp.Workbooks.Open(excelfilename, 0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, false, false);
            Excel.Worksheet sheet = exwbk.Sheets[1] as Excel.Worksheet;
            Excel.Range range = sheet.get_Range("A2", System.Reflection.Missing.Value);
            string rg = range.ToString();



            for (int c = 2; c < 60; c++)
            {
                Excel.Range range4 = sheet.get_Range("A" + c, System.Reflection.Missing.Value);
                string rg4 = range4.Text;

                Excel.Range range3 = sheet.get_Range("B" + c, System.Reflection.Missing.Value);
                String Cellval2 = range3.Text;
                String Cellval3 = Cellval2;
                int Inccell = int.Parse(Cellval3);
                string value2 = (Inccell + 1).ToString();

                if (rg4 != "Old")
                {
                    string cell1 = "B" + value2 + ":" + "Q" + value2;
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
            exapp.DisplayAlerts = false;
            exwbk.Save();
            exwbk.Close(true, null, null);//SaveChanges:=True, Filename:=CurDir & FileToSave);
            exapp.Quit();


            return _cellcollection;
        }
        
    
    }

}
