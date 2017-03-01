//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Firefox;
//using Theranos.Automation.ME.Web;
//using System.Threading;
//using System.Configuration;
//using System.Collections.Generic;
//using Theranos.Automation.ME.Web.Utility;


//using System.Net.Mail;
//namespace Theranos.Automation.ME.Web.WebTestScripts
//{
//    [TestClass]
//    public class Working
//    {
//        [TestMethod]
//        private void button1_Click(object sender, EventArgs e)
//        {
//            string your_id = "kolekar.oms16@gmail.com";
//            string your_password = "Nisarga@248";
//            try
//            {
//                SmtpClient client = new SmtpClient
//                {
//                    Host = "smtp.gmail.com",
//                    Port = 587,
//                    EnableSsl = true,
//                    DeliveryMethod = SmtpDeliveryMethod.Network,
//                    Credentials = new System.Net.NetworkCredential(your_id, your_password),
//                    Timeout = 10000,
//                };
//                MailMessage mm = new MailMessage(your_id, "kolekar.oms16@gmail.com", "subject", "body");
//                client.Send(mm);
//                Console.WriteLine("Email Sent");
//            }
//            catch (Exception e1)
//            {
//                Console.WriteLine("Could not end email\n\n" + e1.ToString());
//            }
//        }
 
//          }

//    }

