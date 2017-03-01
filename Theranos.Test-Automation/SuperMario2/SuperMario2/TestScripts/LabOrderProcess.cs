using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperMario2.Model;
using SuperMario2.Model.ExcelnPut;
using SuperMario2.TestStackMethod;
using System;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo;
using Theranos.Automation.AutoStack;
using System.Globalization;
using System.Threading;
using Theranos.Automation.ME.Android.Model;

namespace SuperMario2
{
    [TestClass]
    public class LabOrderProcess : TestStackWhite
    {
        public Window theranos = null;

        [TestMethod]
        public void L4ScanBucket()
        {
            theranos = GetwindowByTitle(LabOrder.Theranoswindow);
            Loading_Isvisible(theranos);
            ClickButtonByAutoid(theranos, LabOrder.Scan_bucket_ByA);
            Loading_Isvisible(theranos);

        }

        public void L4UseruploadBucket()
        {
            if (ExcelValues.UserName == string.Empty)
            {
                ExcelValues.Excelindexvalue();
            }
            theranos = GetwindowByTitle(LabOrder.Theranoswindow);
            Loading_Isvisible(theranos);
            ClickButtonByAutoid(theranos, LabOrder.UploadBucket_ById);
            Loading_Isvisible(theranos);
        }

        public Collectionpro LabOrderSubmit()
        {
            if (ExcelValues.UserName == string.Empty)
            {
                ExcelValues.Excelindexvalue();
            }
            Collectionpro _collect = new Collectionpro
            {
                CPT = ExcelValues.CPT,
                FastingDetails = ExcelValues.FastingDetails,
                FastingHour = ExcelValues.FastingHour,
                ICD = ExcelValues.ICD,
                Location = ExcelValues.Location,
                Provider = ExcelValues.Provider,
                Physician = ExcelValues.Physician,
                StandingOrder = ExcelValues.StandingOrder
            };
            //theranos = GetwindowByTitle(LabOrder.Theranoswindow);
            //WaitTillBtnAppearByAutoid(theranos, LabOrder.Doctor_button_ByA);
            //ClickButtonByAutoid(theranos, LabOrder.Doctor_button_ByA);
            //ClickButtonByAutoid(theranos, LabOrder.Quick_button_ByA);
            WaitTillTBAppearByAutoid(theranos, LabOrder.Physician_Note_ByA);
            SettextByAutoId(theranos, ExcelValues.Physician, LabOrder.physician_DD_ByA);
            // GetListBox_ByAutoid(theranos, Laborder_id.Physician_ListBox_ByA);
            ClickListItem_ByClassName(theranos, LabOrder.Physician_ListBoxItem_ByC);
            SettextByAutoId(theranos, ExcelValues.Location, LabOrder.PhysicianLocation_ById);
            ClickListItem_ByClassName(theranos, LabOrder.Physician_ListBoxItem_ByC);
            ClickCheckBox_ByAutoid(theranos, LabOrder.NoOrderdate_checkbox_ByA);
            ClickButtonByName(theranos, LabOrder.Next_Button_ByT);
            try
            {
                var Popup = theranos.GetElement(SearchCriteria.ByAutomationId("2"));
                if (Popup != null)
                {
                    do
                    {
                        if (theranos.Get<Button>(SearchCriteria.ByAutomationId("2")) != null)
                        {
                            ClickButtonByAutoid(theranos, LabOrder.Mulpti_Page_okBtn_ByA);
                            ClickImgBtnByAutoid(theranos, LabOrder.Mulpti_Page_Btn_ByA);
                            ClickButtonByName(theranos, LabOrder.Next_Button_ByT);
                        }
                    } while (theranos.GetElement(SearchCriteria.ByAutomationId("2")) != null);

                }

                WaitTillRadioBtnAppearByAutoid(theranos, LabOrder.Nofasting_radioBtn_ByA);
                if (ExcelValues.FastingDetails == "Yes")
                {

                }
                else
                {
                    ClickRadioBtnByAutoid(theranos, LabOrder.Nofasting_radioBtn_ByA);

                }
                if (ExcelValues.StandingOrder == "Yes")
                {

                }
                else
                {
                    ClickRadioBtnByName(theranos, LabOrder.OneTime_ByT);
                }
                SettextByAutoId(theranos, ExcelValues.ICD, LabOrder.Icd_code_ByA);

                ClickListItem_ByClassName(theranos, LabOrder.Physician_ListBoxItem_ByC);
                SettextByAutoId(theranos, ExcelValues.CPT, LabOrder.CPT_Code_ByA);

                ClickListItem_ByClassName(theranos, LabOrder.Physician_ListBoxItem_ByC);
                // System.Threading.Thread.Sleep(1000);
                SettextByAutoId(theranos, "Gsr Automation", LabOrder.PhysicianNote2_ById);
                ClickButtonByName(theranos, LabOrder.Next_Button_ByT);
                WaitTillBtnAppearByAutoid(theranos, LabOrder.SubmitBtn_ById);
                ClickButtonByAutoid(theranos, LabOrder.SubmitBtn_ById);
                var MockPopUp = theranos.ModalWindow(SearchCriteria.ByFramework("Win32"));
                if (MockPopUp.IsCurrentlyActive)
                {
                    var MockWindow = theranos.ModalWindow(SearchCriteria.ByFramework("Win32"));
                    ClickButtonByName(MockWindow, LabOrder.OkBtn_ByName);
                }
            }

            catch (Exception ex)
            {
                if (typeof(AutomationException) == ex.GetType())
                {

                }
            }
            return _collect;
        }


        [TestMethod]
        public void SampleDirect()
        {
            DirectLabOrderSubmit();
        }

        public Collectionpro DirectLabOrderSubmit()
        {
            //if (ExcelValues.UserName == string.Empty)
            //{
            //    ExcelValues.Excelindexvalue();
            //}
            Collectionpro _collect = new Collectionpro
            {
                CPT = ExcelValues.CPT,
                FastingDetails = ExcelValues.FastingDetails,
                FastingHour = ExcelValues.FastingHour,
                ICD = ExcelValues.ICD,
                Location = ExcelValues.Location,
                Provider = ExcelValues.Provider,
                Physician = ExcelValues.Physician,
                StandingOrder = ExcelValues.StandingOrder
            };
            theranos = GetwindowByTitle(LabOrder.Theranoswindow);
            WaitTillTBAppearByAutoid(theranos, LabOrder.CPT_Code_ByA);
            SettextByAutoId(theranos, ExcelValues.CPT, LabOrder.CPT_Code_ByA);
            //SettextByAutoId(theranos, "82340", LabOrder.CPT_Code_ByA);
            ClickListItem_ByClassName(theranos, LabOrder.Physician_ListBoxItem_ByC);
            ClickButtonByName(theranos, LabOrder.Next_Button_ByT);

            WaitTillBtnAppearByAutoid(theranos, LabOrder.SubmitBtn_ById);
            ClickButtonByAutoid(theranos, LabOrder.SubmitBtn_ById);

            return _collect;

 
        }


        [TestMethod]
        public void GuestName()
        {
            BasicInfoModel BasicModel = new BasicInfoModel();
            MELoginModel guest = new MELoginModel();
            BasicModel.FirstName = "benI";
            BasicModel.LastName = "aqz";
            BasicModel.DOB = "01011990";
            guest.FirstName = "Auto";
            guest.LastName = "AAAAA";
            //CheckScanBucketGuestName(BasicModel);
            //CheckUserUploadGuestName(BasicModel);
            //ScanBucketDirectOrder(BasicModel);
            CheckUserUploadGuestName(guest);

        }

        public void CheckScanBucketGuestName(BasicInfoModel GuestDetails)
        {
        Label:

            L4ScanBucket();
            //var BasicInfoDOB = dateformat(GuestDetails.DOB);
            var GuestInfo = GuestDetails.LastName + ", " + GuestDetails.FirstName;
            theranos = GetwindowByTitle(LabOrder.Theranoswindow);
            WaitTillBtnAppearByAutoid(theranos, LabOrder.Doctor_button_ByA);
            var GuestHost = AutoElement.GetElementByClassName(theranos, LabOrder.GuestHost_classname);
            var guest = AutoElement.GetAllChilderen(GuestHost);
            var guestname = guest[2].Current.Name.Substring(0,11) ;
            if (GuestInfo == guestname)
            {
                WaitTillBtnAppearByAutoid(theranos, LabOrder.Doctor_button_ByA);
                ClickButtonByAutoid(theranos, LabOrder.Doctor_button_ByA);
                ClickButtonByAutoid(theranos, LabOrder.Quick_button_ByA);

            }
            else
            {
                WaitTillBtnAppearByAutoid(theranos, LabOrder.Doctor_button_ByA);
                ClickButtonByAutoid(theranos, LabOrder.Doctor_button_ByA);
                try
                {
                    AutoAction.ClickUIItemById(theranos, LabOrder.RejectionBtn_Byid);
                    WaitTillBtnAppearByName(theranos, LabOrder.Realese_Btn_ByN);
                    ClickButtonByName(theranos, LabOrder.Realese_Btn_ByN);
                  
                }
                catch
                {

                    WaitTillBtnAppearByName(theranos, LabOrder.Realese_Btn_ByN);
                    ClickButtonByName(theranos, LabOrder.Realese_Btn_ByN);
                }
                WaitTillBtnAppearByAutoid(theranos, SM2LoginModel.LogOut_ById);
                goto Label;
            }

        }

        public void ScanBucketDirectOrder(BasicInfoModel GuestDetails)
        {
            Label:
            L4ScanBucket();
            //var BasicInfoDOB = dateformat(GuestDetails.DOB);
            var GuestInfo = GuestDetails.LastName + ", " + GuestDetails.FirstName;
            theranos = GetwindowByTitle(LabOrder.Theranoswindow);
            WaitTillBtnAppearByAutoid(theranos, LabOrder.Patient_button_ByID);
            var GuestHost = AutoElement.GetElementByClassName(theranos, LabOrder.GuestHost_classname);
            var guest = AutoElement.GetAllChilderen(GuestHost);
            var guestname = guest[2].Current.Name.Substring(0, 11);
            if (GuestInfo == guestname)
            {
                WaitTillBtnAppearByAutoid(theranos, LabOrder.Patient_button_ByID);
                ClickButtonByAutoid(theranos, LabOrder.Patient_button_ByID);
                ClickButtonByAutoid(theranos, LabOrder.Quick_button_ByA);

            }
            else
            {
                WaitTillBtnAppearByAutoid(theranos, LabOrder.Patient_button_ByID);
                ClickButtonByAutoid(theranos, LabOrder.Patient_button_ByID);
                try
                {
                    AutoAction.ClickUIItemById(theranos, LabOrder.RejectionBtn_Byid);
                    WaitTillBtnAppearByName(theranos, LabOrder.Realese_Btn_ByN);
                    ClickButtonByName(theranos, LabOrder.Realese_Btn_ByN);

                }
                catch
                {

                    WaitTillBtnAppearByName(theranos, LabOrder.Realese_Btn_ByN);
                    ClickButtonByName(theranos, LabOrder.Realese_Btn_ByN);
                }
                WaitTillBtnAppearByAutoid(theranos, SM2LoginModel.LogOut_ById);
                goto Label;
            }

        }

        public string CheckUserUploadGuestName(MELoginModel GuestDetails)
        {
        
            Label:
            //L4UseruploadBucket();
            //var BasicInfoDOB = dateformat(GuestDetails.DOB);
            var GuestInfo = GuestDetails.LastName + ", " + GuestDetails.FirstName;
            theranos = GetwindowByTitle(LabOrder.Theranoswindow);
            WaitTillBtnAppearByAutoid(theranos, LabOrder.Doctor_button_ByA);
            var GuestHost = AutoElement.GetElementByClassName(theranos, LabOrder.GuestHost_classname);
            var guest = AutoElement.GetAllChilderen(GuestHost);
            var details = guest[2].Current.Name.Length;
            var guestname = guest[2].Current.Name.Substring(0,11);
            var dob = guest[2].Current.Name.Substring(12);
            if (GuestInfo == guestname)
            {
                WaitTillBtnAppearByAutoid(theranos, LabOrder.Doctor_button_ByA);
                ClickButtonByAutoid(theranos, LabOrder.Doctor_button_ByA);
                ClickButtonByAutoid(theranos, LabOrder.Quick_button_ByA);

            }
            else
            {
                WaitTillBtnAppearByAutoid(theranos, LabOrder.Doctor_button_ByA);
                ClickButtonByAutoid(theranos, LabOrder.Doctor_button_ByA);
                ClickButtonByAutoid(theranos, LabOrder.Quick_button_ByA);
                WaitTillBtnAppearByAutoid(theranos, LabOrder.Delay_Btn_ByA);
                ClickButtonByAutoid(theranos, LabOrder.Delay_Btn_ByA);
                WaitTillBtnAppearByName(theranos, LabOrder.Realese_Btn_ByN);
                ClickButtonByName(theranos, LabOrder.Realese_Btn_ByN);
                WaitTillBtnAppearByAutoid(theranos, SM2LoginModel.LogOut_ById);
                goto Label;
            }
            return dob;

        }

        public void SM2LogOut()
        {
            WaitTillBtnAppearByAutoid(theranos, SM2LoginModel.LogOut_ById);
            ClickButtonByAutoid(theranos, SM2LoginModel.LogOut_ById);

        }
        public void CheckUserLogin()
        {
            var ResetUserSession = theranos.ModalWindow(SearchCriteria.ByClassName(LabOrder.ResetUserWindow_ByClassName));
            if (theranos == ResetUserSession)
            {
                ClickButtonByName(ResetUserSession, "No");
            }
        }

        public string dateformat(string DOB)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            string dateString = DOB;
            string format = "MMddyyyy";
            DateTime result = DateTime.ParseExact(dateString, format, provider);
            var test = result.ToString();
            var date = test.Substring(0, 10);
            return date;
        }

    }
}