using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Theranos.Automation.ME.API.Library;
using Theranos.Automation.ME.API.Model;
using Theranos.Automation.ME.API.Model.API.Account.Request;
using Theranos.Automation.ME.API.Model.API.Account.Response;
using Theranos.Automation.ME.API.Model.Common.MeAppService;
using Theranos.Automation.ME.API.Model.Common;
using Theranos.Automation.ME.API.Model.EndPoint;
using Theranos.Automation.ME.API.Scripts;
using Theranos.Automation.ME.Web.WebTestScripts;
using Theranos.Automation.ME.API.Model.API.Profile.Response;
using Theranos.Automation.ME.API.Model.SetMethods;
using System.Threading;
using Theranos.Automation.ME.Android.DataInput.Inputpro;
using Theranos.Automation.ME.API.Model.Data;

namespace Theranos.Automation.ME.API.Scenarios
{
    [TestClass]
    public class UserAccountDataPopulator:RestSharpLib
    {
        AccountScripts account = new AccountScripts();
        ProfileScripts profile = new ProfileScripts();
        LocationsScripts location = new LocationsScripts();
        OrdersScripts order = new OrdersScripts();
        TestsScripts tests = new TestsScripts();

        [TestMethod]
        public void userAccDataPapulator()
        {
                ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
                var client = initializeClient();
                CookieContainer CC = new CookieContainer();
                client.CookieContainer = CC;
                // Login for AuthToken
                var acc = new UnitTestsUserAccount();
                object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
                var loginResult = account.loginForAuthToken(client, loginJson);
                var Token = loginResult.AuthToken;
                // GetPatientData
                object authToken = new { authToken = Token };
                var getPatientDataResult = profile.GetPatientData(client, authToken);
                // setPatientEmergencyContacts
                var EmContactsList = ReadCsv<SetEmergencyContactData>("EmergencyContactDataSetAPI.csv");
                var singleContact = EmContactsList.ElementAt(0);
                var EmcontactAsList = new List<SetEmergencyContactData>();
                EmcontactAsList.Add(singleContact);
                object setPatEmContactJson = new { authToken = Token, EmergencyContacts = EmcontactAsList };
                var setPatEmContactResp = profile.setPatientEmergencyContacts(client, setPatEmContactJson);
                // GetPatientData
                profile.GetPatientData(client, authToken);
                // getDoctorList
                var doctInfo = new Doctor();
                doctInfo.Zip = "85205";
                object getdoctorListJson = new { authToken = Token, doctorInfo = doctInfo };
                var getDoctorListResp = profile.getDoctorList(client, getdoctorListJson);
                var doctor = getDoctorListResp.Doctors.ElementAt(0);
                List<Doctor> DoctorAsList = new List<Doctor>();
                DoctorAsList.Add(doctor);
                // setPatientDoctor
                var setPatDoctorJson = new { authToken = Token, Doctors = DoctorAsList };
                var setPatientDoctorResp = profile.setPatientDoctor(client, setPatDoctorJson);
                // GetPatientData
                profile.GetPatientData(client, authToken);
                // getInsuranceCompanies
                var insurComp = new InsuranceCo();
                insurComp.CompanyName = "blue";
                object getInsuCompJson = new { authToken = Token, insuranceCompany = insurComp };
                var getInsuranceCompaniesResp = profile.getInsuranceCompanies(client, getInsuCompJson);
                // setPatientInsurance
                var insuCollection = new List<PatientInsurance>();
                var singleInsu = new PatientInsurance();
                singleInsu.CompanyId = getInsuranceCompaniesResp.Companies.ElementAt(1).CompanyId;
                singleInsu.InsuranceName = getInsuranceCompaniesResp.Companies.ElementAt(1).CompanyName;
                singleInsu.InsuredFirstName = "InsuredFirstNameAA";
                singleInsu.InsuredLastName = "InsuredLastNameZZ";
                singleInsu.PlanId = (new Random().Next(11, 99)) + "PlanId" + (new Random().Next(111, 999));
                insuCollection.Add(singleInsu);
                object setPatInsuJson = new { authToken = Token, insurances = insuCollection };
                var setPatientInsuranceResp = profile.setPatientInsurance(client, setPatInsuJson);
                // GetPatientData
                profile.GetPatientData(client, authToken);
                // setPatientGuardianInfo
                var guardInfo = ReadCsv<SetGuardianInfoData>("GuardianInfoDataSetAPI.csv");
                var singleGuardian = guardInfo.ElementAt(0);
                var gaurdInfoList = new List<SetGuardianInfoData>();
                gaurdInfoList.Add(singleGuardian);
                object setGuarInfoJson = new { authToken = Token, Guardians = gaurdInfoList };
                var setPatientGuardianInfoResp = profile.setPatientGuardianInfo(client, setGuarInfoJson);
                // GetPatientData
                profile.GetPatientData(client, authToken);
                //getStoreLocations
                object stroreLocationsJson = new { Latitude = "32.7558935", Longitude = "-111.67095840000002", MinDistance = "0", MaxDistance = "50" };
                var getStoreLocResp = location.getStoreLocations(client, stroreLocationsJson);
                // setPatientFavoriteLocation
                List<Guid> LocIds = new List<Guid>();
                var locid = getStoreLocResp.locations.ElementAt(new Random().Next(0, 15)).LocationId;
                LocIds.Add(new Guid(locid.ToString()));
                object setPatFavLocJson = new { locationIds = LocIds, authToken = Token };
                var setFavLocResp = location.setPatientFavoriteLocation(client, setPatFavLocJson);
                // GetPatientData
                profile.GetPatientData(client, authToken);
                // getAllTests
                //object jsonWithAuthToken = new { authToken = Token, locationState = "AZ" };
                //var getAlltestsResp = tests.getAllTests(client, jsonWithAuthToken);
                //Random rnd = new Random();
                //int randumIndex = rnd.Next(40, 80); // gets randum index b/w 40to80
                //var cptCodeId = getAlltestsResp.Cpts.ElementAt(randumIndex).CptCodeId;  // collects random CPT CodeId
                //var testName = getAlltestsResp.Cpts.ElementAt(randumIndex).Name;
                //Console.WriteLine("CPT CodeId = " + cptCodeId);
                // submitPatientTests
                var test = new PatientLabTest();
                test.CPTCodeId = 294; // cptCodeId;
                //   test.TestName = testName;
                var ordr = new PatientLabOrder();
                ordr.IsShoppingCart = false;
                ordr.IsSelfOrdered = true;
                ordr.LabOrderName = "Self Order - " + pstTimeZoneDateTime().ToShortDateString();
                ordr.OrderDate = pstTimeZoneDateTime();
               // Console.WriteLine(" Name of the Test :" + testName);
                ordr.LabOrderId = new Guid?();
                ordr.Tests = new List<PatientLabTest>();
                ordr.Tests.Add(test);
                object submitTestJson = new { authToken = Token, labOrder = ordr };
                Console.WriteLine("Json request : " + JsonConvert.SerializeObject(submitTestJson));
                var submitPatientTestsResp = order.submitPatientTests(client, submitTestJson);

                // GetPatientData
                profile.GetPatientData(client, authToken);
                //logout
                object logoutJson = new { authToken = Token };
                var logoutResp = account.logout(client, logoutJson);
                Thread.Sleep(1100);
            }
       
    }
}
