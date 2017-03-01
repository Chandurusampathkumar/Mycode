using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theranos.Automation.AutoStack.Utility;
using Theranos.Automation.ME.API.Library;
using Theranos.Automation.ME.API.Model.Common.MeAppService;
using Theranos.Automation.ME.API.Model.Data;

namespace Theranos.Automation.ME.API.Scripts
{
    public class Scripts : HttpClientHelper
    {
        public static BasicInfo GetRandomOldUser()
        {
            var records = CSVHelper.GetRecords<BasicInfo>(BasicInfo.InputFileName);
            BasicInfo empty = null;

            foreach (var basicInfo in records)
            {
                if (basicInfo.Status == BasicInfo.ExistingGuest)
                {
                    return basicInfo;
                }
            }
            return empty;

        }

        public static BasicInfo GetNewUser()
        {
            var records = CSVHelper.GetRecords<BasicInfo>(BasicInfo.InputFileName);
            BasicInfo empty = null;

            foreach (var basicInfo in records)
            {
                if (basicInfo.Status == BasicInfo.NewGuest)
                {
                    return basicInfo;
                }
            }
            return empty;

        }

        public static PatientAddressInfo GetNewMailingAddress()
        {
            var records = CSVHelper.GetRecords<PatientAddressInfo>(PatientAddressInfo.InputFileName);
            var random = UtilityClass.GetRandomNumber(0, records.Count);
            records[random].IsBillingAddress=false;
            records[random].IsBillingAddress=true;
            return records[random];
        }

        public static PatientAddressInfo GetNewBillingAddress()
        {
            var records = CSVHelper.GetRecords<PatientAddressInfo>(PatientAddressInfo.InputFileName);
            var random = UtilityClass.GetRandomNumber(0, records.Count);
            records[random].IsBillingAddress = true;
            records[random].IsBillingAddress = false;
            return records[random];
        }


    }
}
