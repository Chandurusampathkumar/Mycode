using CsvHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Automation;

namespace Theranos.Automation.PSC3.Utility
{
    public class CSVHelper
    {
        public static List<T> GetRecords<T>(string filename)
        {
            string pathCSV;
            if (AppSettings.TestEnvironment == AppSettings.ProductionEnvironment)
            {
                pathCSV = Path.Combine(AppSettings.InputDirectoryProd, filename);
                //pathCSV = filename;
            }
            else
            {
                pathCSV = AppSettings.GetInputDirectoryDev() + filename;
            }

            //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), pathCSV);
            var reader = new StreamReader(pathCSV);
            var csvReader = new CsvReader(reader);
            var returnList = csvReader.GetRecords<T>().ToList();
            reader.Close();
            //csvReader.Dispose();
            return returnList;
        }

        public static void UpdateRecords<T>(String oldValue, string newValue, int rowId, string filename)
        {
            var txtRowId = rowId + 1; //While reading via StreamReader directly ColumnName will be an additional row
            string pathCSV;
            if (AppSettings.TestEnvironment == AppSettings.ProductionEnvironment)
            {
                pathCSV = Path.Combine(AppSettings.InputDirectoryProd, filename);
               // pathCSV = filename;
            }
            else
            {
                pathCSV = AppSettings.GetInputDirectoryDev() + filename;
            }
            List<String> lines = new List<String>();

            if (File.Exists(pathCSV))
            {
                using (StreamReader reader = new StreamReader(pathCSV))
                {
                    String line;
                    int lineCount = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (lineCount==txtRowId)
                        {
                            String[] split = line.Split(',');
                            for (int i = 0; i < split.Length; i++)
                            {
                                if (split[i]==oldValue)
                                {
                                    split[i] = newValue;
                                    break;
                                }
                            }
                            line = String.Join(",", split);
                            
                        }
                        lines.Add(line);
                        lineCount++;
                        
                    }
                }

                using (StreamWriter writer = new StreamWriter(pathCSV, false))
                {
                    foreach (String line in lines)
                        writer.WriteLine(line);
                }
            }
            

        }

        public static void WriteRecords<T>(string ReportName,List<T> Records)
        {
            //string path= "D:\\"+ReportName+" "+ DateTime.Now.ToString()+".csv";
            string filename = ReportName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";
            //string pathCSV="D:\\"+filename;
            string pathCSV = AppSettings.GetOutputDirectoryDev() + filename;
            //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), pathCSV);
            var writer = new StreamWriter(pathCSV);
            var csvWriter = new CsvWriter(writer);
            csvWriter.WriteRecords(Records);
            writer.Close();
            //csvWriter.Dispose();

        }
       



    }
}
