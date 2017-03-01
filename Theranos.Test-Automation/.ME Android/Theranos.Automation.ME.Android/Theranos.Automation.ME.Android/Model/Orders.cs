using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Theranos.Automation.ME.Android.Model
{
    public class Orders
    {
        public static string MenuButton_ByClass = "android.widget.ImageButton";
        public static string MenuOrderBtn_ByName = "Orders";
        public static string AddBtn_byId = "com.theranos.me:id/lab_orders_new_button";

        public static string OrdersMsg_ByName = "You don't currently have any orders. Upload a paper order or place a new order.";
        public static string Orders_Msg_ById = "com.theranos.me:id/empty_view_message";

        public static string Add_SelectFromMenu_ByName = "Order from Test Menu";
        public static string Add_Upload_ByName = "Upload Paper Lab Order";
        public static string UploadCameraTitle_ById = "com.theranos.me:id/camera_preview_title";

        public static string TestMenu_ByName = "Test Menu";
        public static string SearchImage_ById = "com.theranos.me:id/search";
        public static string SearchCode_ByName = "Search by name or code";
        public static string Orderadding_ByClassName = "android.widget.RelativeLayout";
        public static string CptTest_ByName = "87799";

        public static string Add_ById = "com.theranos.me:id/add";
        public static string AddToCart_ById = "com.theranos.me:id/test_menu_clipboard";
        public static string AddToCartCount_ById = "com.theranos.me:id/order_summary_cart_layout_counter";
        public static string AddedCpt_ById = "com.theranos.me:id/shop_add_button";

        public static string FastingHour_ById = "com.theranos.me:id/fasting_text";
        public static string FastingHour_ByName = "Fasting: 8 Hours";
        public static string FastingHourHeader_ById = "com.theranos.me:id/fasting_info_header";
        public static string FastingHourHeader_ByName = "Fasting: 8 Hours";
        public static string FastingHourBody_ById = "com.theranos.me:id/fasting_info_body";
        public static string FastingHourBody_ByName = "It is recommended that you have no foods or liquids, other than water, for at least the number of hours indicated. If fasting is recommended and you have not fasted, you may continue your visit, but it will be at your discretion. Ensure that you are comfortable with and capable of completing the fasting requirements before your visit.";


        public static string Button_Container_ById = "com.theranos.me:id/buttonPanel";
        public static string Button_No_ById = "android:id/button2";
        public static string No_ByName = "No";
        public static string Ok_ByName = "OK";
        public static string Button_Yes_ById = "android:id/button1";//same id is used for ok button 

        public static string Pro_FirstName_ByName = "First Name";//use same id for retieve code
        public static string pro_LastName_ByName = "Last Name";//use same id for retieve code

        public static string Pro_DOB_ByName = "Date of Birth";//use same id for retieve code
        public static string Pro_Done_Byid = "android:id/button1";
        public static string Pro_Gender_ByName = "Gender";
        public static string Pro_Submit_ById = "com.theranos.me:id/submit_btn";

        public static string Pro_Female_ByName = "Female";
        public static string Pro_Male_ByName = "Male";
        public static string Pro_SaveBtn_ByName = "Save";

        public static string LinkAcc_ByName = "Link Account";
        public static string LinkACC_code_ByName = "Enter Visit Code";
        public static string LinkACC_RetrieveCode_ById = "com.theranos.me:id/resend_code_link";
        public static string LinkACC_FirstName_ByName = "First Initial";
        public static string LinkACC_LastName_ByName = "Last Initial";
        public static string LinkACC_DOB_ByName = "Date of Birth";
        public static string LinkAcc_SubmitBtn_ById = "com.theranos.me:id/submit_btn"; //use same id for retieve code
        public static string LinkAccValidMsg = "Your account has been successfully linked! You can now track and view your results as they become available.";
        public static string LinkAccValidMsg_ById = "com.theranos.me:id/tk_message";

        public static string RetrieveVisitCode_ByName = "Retrieve Visit Code";

        public static string MyOrder_ByName = "My Order";
        public static string SelectDropDown_ById = "com.theranos.me:id/order_summary_state_selection_text";
        public static string Item_ByName = "Arizona";
        public static string Item_ByID = "com.theranos.me:id/cv_inputbase_inputfield";
        public static string CreateOrderBtn_ById = "com.theranos.me:id/order_summary_button";
        public static string OrderCreated_ByName = "Order Created!";
        public static string RemoveOrde_ById = "com.theranos.me:id/order_summary_remove_icon";
        public static string OrderMsg = "Start ordering your own tests.";
        public static string CartTestDetails_ByName = "com.theranos.me:id/order_summary_test_name";
        public static string CartTestPrice_ByName = "com.theranos.me:id/order_summary_test_price";

        public static string Completed_ByName = "Completed";

        public static string Active_ByName = "Active";
        public static string ActiveOrderDate_ById = "com.theranos.me:id/date";
        public static string ActiveOrderSelf_ById = "com.theranos.me:id/test_self_order_footer";

        public static string Result_ByName = "Results";
        public static string ResultPending_ByName = "Results Pending";

        public static string RelativeLayOut_ByClass = "android.widget.RelativeLayout";

        public static string TestName = "Calcium";       
        public static string TestCpt_ByName = "CAL1, CPT: 82310";
        public static string TestAvaliable = "Available for Direct Testing in AZ";
        public static string TestPrice = "$3.51";

        public static string FastingTest_ByName = "Glucose";
        public static string FastingTestCpt_ByName = "GLU1, CPT: 82947";
        public static string FastingTestAvaliable = "Available for Direct Testing in AZ";
        public static string FastingTestPrice = "$2.67";

        public static string TestName_ById = "com.theranos.me:id/name";
        public static string TestCpt_ById = "com.theranos.me:id/panel_code";
        public static string TestAvailable_ById = "com.theranos.me:id/state_availability";
        public static string TestPrice_ById = "com.theranos.me:id/price";

        public static string ActiveTestName_ById = "com.theranos.me:id/text";
        public static string ActiveTotalPrice_ById = "com.theranos.me:id/total_price";
        public static string ActiveDelete_Byclass = "android.support.v7.widget.LinearLayoutCompat";
        public static string ActiveDelete_ByName = "Delete Order";

        public static string FindCenter_ById = "com.theranos.me:id/bottom_button_text";
        public static string FindCenter_ByName = "Find a Center";

        public static string DashBoardToLinkAcc = "com.theranos.me:id/dashboard_link_account";

        public static string LinearlayOut_ByClass = "android.widget.LinearLayout";

        public static string CameraTakePicture_ById = "com.theranos.me:id/camera_control_take_picture";
        public static string CameraRetake_ById = "com.theranos.me:id/cancel_btn";
        public static string CameraUsePhoto_ById = "com.theranos.me:id/confirm_btn";
        public static string CameraDone_ById = "com.theranos.me:id/camera_control_done";
        public static string CameraRetake_ByName = "Retake";
        public static string PopUploadSubmitBtn_ById = "android:id/button1";
        public static string PopUploadCancelBtn_ById = "android:id/button2";

        public static string PendingOrder_ByName = "Order Pending";

        public static string BMP_ByName = "Basic Metabolic Panel (BMP)";
        public static string Calcium_ByName = "Calcium";
        public static string CarbonDioxide_ByName = "Carbon Dioxide";
        public static string Chloride_ByName = "Chloride";
        public static string Creatinine_ByName = "Creatinine";
        public static string Glucose_ByName = "Glucose";
        public static string Potassium_ByName = "Potassium";
        public static string Sodium_ByName = "Sodium";
        public static string BloodUreaNitrogen_ByName = "Blood Urea Nitrogen (BUN)";


    }
}
