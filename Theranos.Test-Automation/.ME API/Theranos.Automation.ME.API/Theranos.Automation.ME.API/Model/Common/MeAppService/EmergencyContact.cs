﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.ME.API.Model.Common.MeAppService
{
    /// <summary>
    /// http://alpha:1212/api/v4/Help/ResourceModel?modelName=Theranos.ME.Library.Common.MeAppService.EmergencyContact
    /// </summary>
    public class EmergencyContact
    {
        public string EmailAddress { get; set; }
        public Guid EmergencyContactId { get; set; }
        public string FirstName { get; set; }
        public string HomePhoneNo { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string MobilePhoneNo { get; set; }
        public string Relationship { get; set; }
        public string WorkPhoneNo { get; set; }
    }
}
