using System;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using PscSoapApiAutomation.PSC3API;
using PscSoapApiAutomation.Scripts;

//@Author Fangming Lu

namespace PscSoapApiAutomation.Scenarios
{

    //[TestFixture]
    [TestClass]
    public class TestScenarios : TestBase
    {
        IPscService _client;
        private VisitHelper _helper;
        private PscSoapApiAutomationTest _testScripts;

        //[SetUp]
        [TestInitialize]
        public override void Setup()
        {
            base.Setup();
            _client = PscService;
            _helper = new VisitHelper(_client);
            _testScripts = new PscSoapApiAutomationTest(_client, _helper);
        }

        //[Test, TestCaseSource("DivideCases")]
        [TestMethod]
        public void TestPsc3DirectModeWithNewUser()
        {
            var guestId = _helper.GetNewGuestId();
            var visitId = _helper.GetNewVisitId(guestId);
            var labId = _helper.GetLabOrderIdFromNewGuest(guestId, true);
            //var cptcode = _helper.ReadSingleCptCodeFromExcelFile(row);
            var cptcodes = _helper.ReadCptCodeFromExcelFile();
            var numberOfBarcodes = cptcodes.Length;
           // var numberOfBarcodes = 1;
            var accessionNumber = 0;
            var labOrderTranscription = _helper.GetGuestLabOrderTranscription(cptcodes);
            //var labOrderTranscription = _helper.GetGuestLabOrderTranscriptionWithSingleCptCode(cptcode);
            _testScripts.SubmitDirectModeLabOrderWithExcelPrice(visitId, guestId, labId, labOrderTranscription);
            //FinishCheckInFlow(guestId, labId, visitId, "5.76", true, 2);
            var visitState = _helper.GetNewGuestVisitState();
            _testScripts.FinishCheckInFlow(visitState, guestId, labId, visitId, true, numberOfBarcodes, accessionNumber);
            _testScripts.FinishPerformFlow(visitState, visitId, true);

        }
        //static object[] DivideCases =
        //{
        //  new object[] { 1 },
        //  new object[] { 2 },
        //  new object[] { 3 }
        //};


        [TestMethod]
        public void TestPsc3PhysicianModeWithNewUser(int row)
        {
            var guestId = _helper.GetNewGuestId();
            var visitId = _helper.GetNewVisitId(guestId);
            var labId = _helper.GetLabOrderIdFromNewGuest(guestId, false);
            var doctorId = _helper.GetDoctorId("tom");
            var providerId = _helper.GetProviderId();
            var locationId = _helper.GetLocationId(providerId);
            var cptcodes = _helper.ReadCptCodeFromExcelFile();
            var accessionNumber = 0;
            _client.SaveVisitLogTime(visitId, DateTimeOffset.Now, VisitTimeLogType.CheckinStartTime);
            var transcription = _helper.GetPhysicianLabOrderTranscription(doctorId, locationId, providerId);
            var numberOfBarcodes = cptcodes.Length;
            transcription.CptCodes = _helper.GetCptCodeFastingHours(cptcodes);
            var visitState = _helper.GetNewGuestVisitState();
            _testScripts.SubmitPhysicianModeLabOrderWithExcelPrice(guestId, visitId, labId, doctorId, providerId, locationId,
                transcription);
            _testScripts.FinishCheckInFlow(visitState, guestId, labId, visitId, false, numberOfBarcodes,accessionNumber);
            _testScripts.FinishPerformFlow(visitState, visitId, false);
            
        }
    }
}
