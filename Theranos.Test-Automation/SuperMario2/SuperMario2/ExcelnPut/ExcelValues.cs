using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario2.Model.ExcelnPut
{

    public class ExcelValues : ReadExcel
    {

        public static List<string> ExcelCollection = new List<string>();
        public static string Physician = string.Empty;
        public static string Provider = string.Empty;
        public static string Location = string.Empty;
        public static string FastingDetails = string.Empty;
        public static string FastingHour = string.Empty;
        public static string StandingOrder = string.Empty;
        public static string ICD = string.Empty;
        public static string CPT = string.Empty;
        public static string UserName = string.Empty;
        public static string Password = string.Empty;





        public static void Excelindexvalue()
        {

            ExcelCollection = ReadrowExcel();

            UserName = ExcelCollection[1].ToString();
            Password = ExcelCollection[2].ToString();
            Physician = ExcelCollection[3].ToString();
            Provider = ExcelCollection[4].ToString();
            Location = ExcelCollection[5].ToString();
            FastingDetails = ExcelCollection[6].ToString();
            FastingHour = ExcelCollection[7].ToString();
            StandingOrder = ExcelCollection[8].ToString();
            ICD = ExcelCollection[9].ToString();
            CPT = ExcelCollection[10].ToString();

        }

        //public  ExcelValues Excelindexvalue()
        //{
        //    ExcelCollection = ReadrowExcel();

        //    UserName = ExcelCollection[1].ToString();
        //    Password = ExcelCollection[2].ToString();
        //    Physician = ExcelCollection[3].ToString();
        //    Provider = ExcelCollection[4].ToString();
        //    Location = ExcelCollection[5].ToString();
        //    FastingDetails = ExcelCollection[6].ToString();
        //    FastingHour = ExcelCollection[7].ToString();
        //    StandingOrder = ExcelCollection[8].ToString();
        //    ICD = ExcelCollection[9].ToString();
        //    CPT = ExcelCollection[10].ToString();

        //    return ExcelCollection;
        //}

    }
}
