using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Theranos.Automation.ME.API.Model.Data;

namespace Theranos.Automation.ME.API.Model.API.Account.Request
{
    public class LoginRequest
    {
        public string Date { get; set; }
        public string Mac { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }


        //public LoginRequest()
        //{

        //}

        //public LoginRequest(string uname, string pwd)
        //{
        //    UserName = uname;
        //    Password = pwd;
        //}

        //public LoginRequest(BasicInfo basicInfo)
        //{
        //    UserName = basicInfo.UserName;
        //    Password = basicInfo.Password;
        //}
    }
}
