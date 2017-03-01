using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.Data
{
    public class BasicInfo:AutoStack.AutoStack
    {
        public const string InputFileName = "BasicInfoDataSetAPI.csv";

        public const string ExistingGuest = "OLD";
        public const string NewGuest = "NEW";
        public const string Male = "M";
        public const string Female = "F";

        //Basic Info
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MI { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string PhoneType { get; set; }
        public string PhoneNo { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Question1 { get; set; }
        public string Answer1 { get; set; }
        public string Question2 { get; set; }
        public string Answer2 { get; set; }
        public string Question3 { get; set; }
        public string Answer3 { get; set; }
        public string Status { get; set; }

        public static void UpdateBasicInfoRecordStatus(BasicInfo basicInfo)
        {
            string pathCSV;
            if (TestEnvironment == ProductionEnvironment)
            {
                pathCSV = Path.Combine(InputDirectoryProd, InputFileName);
                // pathCSV = filename;
            }
            else
            {
                pathCSV = GetInputDirectoryDev() + InputFileName;
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
                        String[] split = line.Split(',');
                        if (split[8] == basicInfo.UserName)
                        {

                            split[16] = ExistingGuest;
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


    }
}
