using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models.CheckIn
{
    public class GuestFormsModel:PSC3Model
    {      

        public const string Yes_ByName = "Yes";
        public const string Yes_ByID = "GuestForms.Forms.ListBox.0.Form.HasSigned.CheckBox";

        public const string ActiveOrders_ByClass = "ActiveOrders";

        public const string PrintForms_ByName= "PRINT FORM";
        public const string PrintForms_ByID = "GuestForms.Forms.ListBox.0.Form.Print.Button";
        
        public const string GuestFormsHost_ByClass = "GuestFormsHost";
        public const string GuestFormsHost_ByID = "GuestForms.Screen";

        public const string Next_ByID = "GuestForms.Next.Button";        
        public const string RequiredForms_ByName = "REQUIRED FORMS";
        public const string Back_ByID = "GuestForms.Back.Button";

        public const string  AcknowledgementForm_ById = "GuestForms.Forms.ListBox.0.Form.Label";
    }
}
