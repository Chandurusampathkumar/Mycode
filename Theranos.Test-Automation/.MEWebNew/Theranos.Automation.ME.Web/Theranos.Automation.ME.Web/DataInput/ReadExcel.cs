        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using Excel = Microsoft.Office.Interop.Excel;
        using Excel1 = Microsoft.Office.Interop.Excel.Range;
        using Theranos.Automation.ME.Web.ExcelReader;
        using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
        namespace Theranos.Automation.ME.Web.ExcelReader
        {
            public class ReadExcel
            {
                public static List<string> ExcelCollection = new List<string>();

               // public static string LinkingEmail = string.Empty;
                public static string NewUserName = string.Empty;
                public static string Email = string.Empty;
                public static string Question1 = string.Empty;
                public static string Question2 = string.Empty;
                public static string Question3 = string.Empty;
                public static string FirstName = string.Empty;
                public static string LastName = string.Empty;
                public static string Dateofbirth = string.Empty;
                public static string Gender = string.Empty;
                public static string specialchar = string.Empty;
                public static string numerics = string.Empty;
                public static string morethanfifty = string.Empty;

                public static List<string> ReadrowExcel(String filepath, int sheetno, Boolean flagvalue, String status)
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
                            Excel.Range range3 = sheet.get_Range("A" + c, System.Reflection.Missing.Value);
                         //   String Cellval2 = range3.Text;
                            Excel.Range range4 = sheet.get_Range("B" + c, System.Reflection.Missing.Value);

                            String rg4 = range4.Text;
                           // int Inccell = int.Parse(Cellval2);
                            string value2 = (c).ToString();

                            if (flagvalue == true)
                            {
                                if (!rg4.Trim().ToLower().Contains("old") || rg4.Equals("new"))
                                {
                                    string cell1 = "B" + value2 + ":" + "N" + value2;
                                    Excel.Range range1 = sheet.get_Range(cell1, System.Reflection.Missing.Value);
                                    Excel.Range range2 = sheet.get_Range("B" + value2, System.Reflection.Missing.Value);
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

                            else if (flagvalue == false)
                            {
                                if (rg4.Trim().ToLower().Equals("old") && status.ToLower().Equals("old"))
                                {
                                    string cell1 = "B" + value2 + ":" + "N" + value2;
                                    Excel.Range range1 = sheet.get_Range(cell1, System.Reflection.Missing.Value);
                                    Excel.Range range2 = sheet.get_Range("B" + value2, System.Reflection.Missing.Value);
                                    if (range1 != null)
                                        foreach (Excel.Range rg1 in range1)
                                        {
                                            string cellval = rg1.Text;
                                            _cellcollection.Add(cellval);
                                        }
                                    range2.Value = "OldLInked";
                                }
                                else if (rg4.Trim().ToLower().Equals("oldlinked") && status.ToLower().Equals("oldlinked"))
                                {
                                    string cell1 = "B" + value2 + ":" + "N" + value2;
                                    Excel.Range range1 = sheet.get_Range(cell1, System.Reflection.Missing.Value);
                                    Excel.Range range2 = sheet.get_Range("B" + value2, System.Reflection.Missing.Value);
                                    if (range1 != null)
                                        foreach (Excel.Range rg1 in range1)
                                        {
                                            string cellval = rg1.Text;
                                            _cellcollection.Add(cellval);
                                        }
                                    // range2.Value = "OldLInked";
                                    else
                                    {
                                        continue;
                                    }
                                    break;
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
                public static void Excelindexvalue(String filepath, int sheetno, Boolean flagvalue, string status)
                {
                    ExcelCollection = ReadrowExcel(filepath, sheetno, flagvalue, status);
                    Email = ExcelCollection[1].ToString();
                    NewUserName = ExcelCollection[2].ToString();
                  //  LinkingEmail = ExcelCollection[3].ToString();
                    Question1 = ExcelCollection[3].ToString();
                    Question2 = ExcelCollection[4].ToString();
                    Question3 = ExcelCollection[5].ToString();
                    FirstName = ExcelCollection[6].ToString();
                    LastName = ExcelCollection[7].ToString();
                    Dateofbirth = ExcelCollection[8].ToString();

                    Gender = ExcelCollection[9].ToString();
                    specialchar = ExcelCollection[10].ToString();
                    numerics = ExcelCollection[11].ToString();
                    morethanfifty = ExcelCollection[12].ToString();
                }
            }

        }
