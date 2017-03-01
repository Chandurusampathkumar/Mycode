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
using System.IO;

namespace Theranos.Automation.ME.API.Scenarios
{
    [TestClass]
    public class ProfileScenarios : ProfileScripts
    {
        AccountScripts account = new AccountScripts();
        ProfileScripts profile = new ProfileScripts();

      //  FirstTimeLogin firstTime = new FirstTimeLogin();
/*
        [TestMethod]
        public void getInsuranceCompanies()
        {
            HttpClientHelper.ClearCookies();
            var basicInfo = GetRandomOldUser();
            var loginResponse = account.Login(basicInfo);
            var getInsuranceCompaniesResponse1 = profile.getInsuranceCompanies(loginResponse.AuthToken);
            var getInsuranceCompaniesResponse2 = profile.getInsuranceCompanies(loginResponse.AuthToken, new InsuranceCo("Medicaid"));
            var getInsuranceCompaniesResponse3 = profile.getInsuranceCompanies(loginResponse.AuthToken, new InsuranceCo("Not a valid insurance company"));
        }
*/
  // ------------------------------------------------------------------------------------------------------------ //

/*
        [TestMethod]  // AddressDataSetAPI.csv is required
        public void setBasicPatientInfo()
        {
            HttpClientHelper.ClearCookies();
            var basicInfo = GetRandomOldUser();
            var loginResp = account.Login(basicInfo);
            //var binfo = GetNewMailingAddress();
            var binfo = new PatientBasicInfo(basicInfo);
            var basicPatientInfo = profile.setBasicPatientInfo(ProfileURNs.setBasicPatientInfo, binfo, loginResp.AuthToken);
            Console.WriteLine(basicPatientInfo.Code + basicPatientInfo.Message);
        }
*/
       
//-------------------------------RestSharp----------------------------------------------------//

        [TestMethod]
        public void getInsuranceCompanies()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            // getInsuranceCompanies
            var insurComp = new InsuranceCo();
            insurComp.CompanyName = "blue";
            object getInsuCompJson = new { authToken = AuthToken, insuranceCompany = insurComp };
            var getInsuranceCompaniesResp = profile.getInsuranceCompanies(client, getInsuCompJson);
        }


        [TestMethod]
        public void getEmergencyContacts()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken=new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            // GetEmergencyContacts
            var getEmergencyContactsResp = profile.getEmergencyContacts(client, authToken);
       }

        [TestMethod]
        public void getPatientData()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
           
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
        }

        [TestMethod]
        public void getDoctorList()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
        
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // getDoctorList
            var doctInfo = new Doctor();
            doctInfo.Zip = "85206";
            object getdoctorListJson = new { authToken = AuthToken, doctorInfo=doctInfo };
            var getDoctorListResp = profile.getDoctorList(client, getdoctorListJson);
        }

        [TestMethod]
        public void getGuardianInfo()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            // getGuardianInfo
            var getGuardianInfoResp = profile.getGuardianInfo(client, authToken);
        }

        [TestMethod]
        public void getPatientDoctors()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            //GetPatientDoctors
            var GetPatientDoctorsResp = profile.getPatientDoctors(client, authToken);
        }

        [TestMethod]
        public void getMedicalHistory()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            //getMedicalHistory
            var getMedicalHistoryResp = profile.getMedicalHistory(client, authToken);
        }

        [TestMethod]
        public void deleteEmergencyContact()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object tokenJson = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, tokenJson);
            // GetEmergencyContacts
            var EMcontact = profile.getEmergencyContacts(client, tokenJson);
            if (EMcontact.EmergencyContacts.Count == 0)
            {
                Console.WriteLine(" No. of Emergency Contacts : 0 ");
                Assert.Inconclusive(" Patient profile doesn't have any Emergency Contacts ");
            }
            var singleEMcontact = EMcontact.EmergencyContacts.ElementAt(0);
            // deleteEmergencyContact
            var emergencyContactsList = new List<EmergencyContact>();
            emergencyContactsList.Add(singleEMcontact);
            object delEmegContJson = new { authToken = AuthToken, emergencyContacts = emergencyContactsList };
            var deleteEmergencyContact = profile.deleteEmergencyContact(client, delEmegContJson);
        }

        [TestMethod]
        public void DeletePatientGuardianInfo()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
           
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            // getGuardianInfo
            var getGuardianInfoResp = profile.getGuardianInfo(client, authToken);
            if (getGuardianInfoResp.Guardians.Count == 0)
            {
                Console.WriteLine(" No. of Patient Guardians : 0 ");
                Assert.Inconclusive(" Patient profile doesn't have any Guardians ");
            }
            var guardian = getGuardianInfoResp.Guardians.ElementAt(0);
            //DeletePatientGuardianInfo
            var guardianInfoCollection = new List<GuardianInfo>();
            guardianInfoCollection.Add(guardian);
            object mnc = new { authToken = AuthToken, guardians = guardianInfoCollection };
            var deleteGuardianResp=profile.DeletePatientGuardianInfo(client,mnc);
        }

       
        [TestMethod]
        public void validateZipCode()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            // validateZipCode
            object validateZipcodeJson = new { zipCode = "85220", authToken = AuthToken };
            var validateZipCodeResp = profile.validateZipCode(client, validateZipcodeJson);
        }

        [TestMethod]
        public void getPatientInsurances()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
           
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            // getPatientInsurances
            var patientInsurancesResp = profile.getPatientInsurances(client, authToken);
        }

        [TestMethod]
        public void updatePatientEmailAddress()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken

            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            string oldEmail = getPatientDataResult.BasicInfo.EmailAddress;
            // updatePatientEmailAddress
            Console.WriteLine(" UpdatePatientEmailAddress service initiated");
            Console.WriteLine(" Old Email address : " + oldEmail);
            string newEmail="oneasdnew@grr.la";
            object updPatEmailAddJson = new { authToken = AuthToken, oldEmailAddress = oldEmail, newEmailAddress=newEmail };
            var updatePatEmailAddResp = profile.updatePatientEmailAddress(client, updPatEmailAddJson);
           // Get updated Email address
            var getPatientData = profile.GetPatientData(client, authToken);
            string returnedEmail = getPatientData.BasicInfo.EmailAddress;
            Console.WriteLine(" Updated Email address : " + returnedEmail);
            // setBack old email Address
            object updPatEmailAddJson1 = new { authToken = AuthToken, oldEmailAddress = "oneasdnew@grr.la", newEmailAddress = "oneasd@grr.la" };
            var updatePatEmailAddResp1 = profile.updatePatientEmailAddress(client, updPatEmailAddJson1);
            if(newEmail==returnedEmail)
            {
                Console.WriteLine(" Email updated successfully ");
            }
            else
            {
                string errMsg = "Email Address not updated as expected. Service : \"updatePatientEmailAddress\" Failed ";
                throw ( new Exception (errMsg));
            }
         }

        [TestMethod]         // Same Doctor can be added again and again
        public void setPatientDoctor()
        {
           
                ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
                var client = initializeClient();
                CookieContainer CC = new CookieContainer();
                client.CookieContainer = CC;
                // Login for AuthToken
                
                object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
                var loginResult = account.loginForAuthToken(client, loginJson);
                var AuthToken = loginResult.AuthToken;
                // GetPatientData
                object authToken = new { authToken = AuthToken };
                var getPatientDataResult = profile.GetPatientData(client, authToken);
                // getDoctorList
                var doctInfo = new Doctor();
                doctInfo.Zip = "85205";
                object getdoctorListJson = new { authToken = AuthToken, doctorInfo = doctInfo };
                var getDoctorListResp = profile.getDoctorList(client, getdoctorListJson);
                var doctor = getDoctorListResp.Doctors.ElementAt(2);
                List<Doctor> DoctorAsList = new List<Doctor>();
                DoctorAsList.Add(doctor);
                // setPatientDoctor
                var setPatDoctorJson = new { authToken = AuthToken, Doctors = DoctorAsList };
                var setPatientDoctorResp = profile.setPatientDoctor(client, setPatDoctorJson);
                // GetPatientData
                var getPatientDataResult1 = profile.GetPatientData(client, authToken);
                account.logout(client, authToken);
                Thread.Sleep(300);
        }

        [TestMethod]
        public void setPatientEmergencyContacts()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
           
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            // setPatientEmergencyContacts
            var EmContactsList = ReadCsv<SetEmergencyContactData>("EmergencyContactDataSetAPI.csv");
            var singleContact=EmContactsList.ElementAt(0);
            var EmcontactAsList=new List<SetEmergencyContactData>();
            EmcontactAsList.Add(singleContact);
            object setPatEmContactJson = new { authToken = AuthToken, EmergencyContacts = EmcontactAsList };
            var setPatEmContactResp = profile.setPatientEmergencyContacts(client, setPatEmContactJson);
        }

        [TestMethod]
        public void setPatientGuardianInfo()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            // setPatientGuardianInfo
            var guardInfo = ReadCsv<SetGuardianInfoData>("GuardianInfoDataSetAPI.csv");
            var singleGuardian = guardInfo.ElementAt(0);
            var gaurdInfoList = new List<SetGuardianInfoData>();
            gaurdInfoList.Add(singleGuardian);
            Console.WriteLine(" Single Guardian : " + singleGuardian.firstName + " DOB : " + singleGuardian.dob);
            object setGuarInfoJson = new { authToken = AuthToken, Guardians = gaurdInfoList };
            var setPatientGuardianInfoResp = profile.setPatientGuardianInfo(client, setGuarInfoJson);
        }

        [TestMethod]
        public void deletePatientDoctor()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            //GetPatientDoctors
            var GetPatientDoctorsResp = profile.getPatientDoctors(client, authToken);
            Console.WriteLine(" Patient Doctors Count : " + GetPatientDoctorsResp.Doctors.Count);
         
            if (GetPatientDoctorsResp.Doctors.Count == 0)
            {
                Console.WriteLine(" No. of Patient Doctors : 0 ");
                Assert.Inconclusive(" Patient profile doesn't have any Doctor info ");
            }

            // deletePatientDoctor
            var Doctors = new List<Doctor>();
            var singleDoctor = GetPatientDoctorsResp.Doctors.ElementAt(0);
            Doctors.Add(singleDoctor);
            object delPatDoctJson = new { authToken = AuthToken, doctors=Doctors };
            var deletePatientDoctorResp = profile.deletePatientDoctor(client, delPatDoctJson);
            // GetPatientDoctors
            var GetPatientDoctorsRespNew = profile.getPatientDoctors(client, authToken);
            Console.WriteLine(" Patient Doctors Count : " + GetPatientDoctorsRespNew.Doctors.Count);
        }

        [TestMethod]
        public void setPatientInsurance()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
          
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            // getInsuranceCompanies
            var insurComp = new InsuranceCo();
            insurComp.CompanyName = "blue";
            object getInsuCompJson = new { authToken = AuthToken, insuranceCompany = insurComp };
            var getInsuranceCompaniesResp = profile.getInsuranceCompanies(client, getInsuCompJson);
            // getPatientInsurances
            var getPatInsuResp = profile.getPatientInsurances(client, authToken);
            Console.WriteLine("No of Insurences : "+getPatInsuResp.Insurances.Count);
            // setPatientInsurance
            var insuCollection = new List<PatientInsurance>();
            var singleInsu = new PatientInsurance();
            singleInsu.CompanyId = getInsuranceCompaniesResp.Companies.ElementAt(1).CompanyId;
            singleInsu.InsuranceName = getInsuranceCompaniesResp.Companies.ElementAt(1).CompanyName;
            singleInsu.InsuredFirstName = "InsuredFirstNameAA";
            singleInsu.InsuredLastName = "InsuredLastNameZZ";
            singleInsu.PlanId = (new Random().Next(11,99))+"PlanId" + (new Random().Next(111, 999));
            insuCollection.Add(singleInsu);
            object setPatInsuJson = new { authToken = AuthToken, insurances = insuCollection };
            var setPatientInsuranceResp = profile.setPatientInsurance(client, setPatInsuJson);
            // getPatientInsurances
            var getPatInsResp = profile.getPatientInsurances(client, authToken);
            Console.WriteLine("No of Insurences : " + getPatInsResp.Insurances.Count);
        }


        [TestMethod]
        public void setBasicPatientInfo() 
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
                var client = initializeClient();
                CookieContainer CC = new CookieContainer();
                client.CookieContainer = CC;
                // Login for AuthToken
                object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
                var loginResult = account.loginForAuthToken(client, loginJson);
                var Token = loginResult.AuthToken;
                //getAccountEmailAddress
                object getAccEmailAddRespJson = new { authToken = Token };
                var getAccountEmailAddressResp = account.getAccountEmailAddress(client, getAccEmailAddRespJson);
                // setBasicPatientInfo
                var patInfo = new PatientBasicInfo();
                patInfo.FirstName = ExcelValues.FirstName;
                patInfo.LastName = ExcelValues.LastName;
                patInfo.Sex = "M";
                patInfo.MobilePhoneNo = "9875644214";
                patInfo.DOB = pstTimeZoneDateTime().AddYears(-20);
                patInfo.Addresses = new List<PatientAddressInfo>();

                var addr = new PatientAddressInfo();
                addr.IsBillingAddress = true;
                addr.IsMailingAddress = true;
                addr.Address1 = "addresas";
                addr.Address2 = "localadd";
                addr.City = "Arizona";
                addr.State = "AZ";
                addr.Zip = "90023";
                patInfo.Addresses.Add(addr);

                object setBasInfoJson = new { basicInfo = patInfo, AuthToken = Token };
                var jsonString = JsonConvert.SerializeObject(setBasInfoJson);
                Console.WriteLine(jsonString);
                var setBasicInfoResp = profile.setBasicPatientInfo(client, setBasInfoJson);
                Thread.Sleep(1000);
        }

        [TestMethod]
        public void setPatientInsuranceImage()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            // getInsuranceCompanies
            var insurComp = new InsuranceCo();
            insurComp.CompanyName = "blue";
            object getInsuCompJson = new { authToken = AuthToken, insuranceCompany = insurComp };
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
            object setPatInsuJson = new { authToken = AuthToken, insurances = insuCollection };
            var setPatientInsuranceResp = profile.setPatientInsurance(client, setPatInsuJson);
            var insuId = setPatientInsuranceResp.InsuranceIds.ElementAt(0).Key;
            //var insuName = setPatientInsuranceResp.InsuranceIds.ElementAt(0).Value;
            //Console.WriteLine("Key : {0}, Value : {1}", insuId, insuName);
            // setPatientInsuranceImage
            string imgData = getImageData("InsuranceImage.jpg");
            object setPatInsImgJson = new { authToken = AuthToken, imageType = "INS_F", ImageContent = imgData, InsuranceId = insuId };
            var setPatientInsuranceImageResp = profile.setPatientInsuranceImage(client, setPatInsImgJson);
        }

        [TestMethod]
        public void getPatientInsuranceImage()
        {
            ExcelValues.Excelindexvalue(userAccountsExcel, 1, "");
            var client = initializeClient();
            CookieContainer CC = new CookieContainer();
            client.CookieContainer = CC;
            // Login for AuthToken
          
            object loginJson = new { username = ExcelValues.UserName, password = ExcelValues.Password };
            var loginResult = account.loginForAuthToken(client, loginJson);
            var AuthToken = loginResult.AuthToken;
            // GetPatientData
            object authToken = new { authToken = AuthToken };
            var getPatientDataResult = profile.GetPatientData(client, authToken);
            // getPatientInsurances
            var patientInsurancesResp = profile.getPatientInsurances(client, authToken);
            int downloadableInsuId=0;
            string imgType = null;
            for(int i=0;i<patientInsurancesResp.Insurances.Count;i++)
            {
                imgType=patientInsurancesResp.Insurances.ElementAt(i).InsuranceImageInfoes.ElementAt(0).ImageType;
                if (imgType.Equals("INS_F"))
                {
                    downloadableInsuId = patientInsurancesResp.Insurances.ElementAt(i).InsuranceId;
                    Console.WriteLine("Downloadable insueance id: " + downloadableInsuId);
                    break;
                }
            }

            // getPatientInsuranceImage
            var getPatInsuImgJson = new { insuranceId = downloadableInsuId, imageType = imgType, AuthToken = AuthToken };
            var getPatientInsuranceImageResp = profile.getPatientInsuranceImage(client, getPatInsuImgJson);
            var ImgData = getPatientInsuranceImageResp.ImageContent;
            var testResultLocation = getTestResultLocation();
            using (FileStream stream = System.IO.File.Create(testResultLocation + (DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg")))
            {
                byte[] byteArray = Convert.FromBase64String(ImgData);
                stream.Write(byteArray, 0, byteArray.Length);
                Console.WriteLine("Completed");
            }
        }

        [TestInitialize]
        public void testInitialize()
        {
            Thread.Sleep(5000);
        }
    }  
}
