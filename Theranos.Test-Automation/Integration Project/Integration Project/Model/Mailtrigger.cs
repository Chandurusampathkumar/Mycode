using System;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Theranos.Automation.ME.Web;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;

using System.Net.Mail;
using System.Net;
using System.Text;
using System.IO;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.PhantomJS;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
namespace Integration_Project.Model
{

    [TestClass]
    public class Mailtrigger
    {

        public static IWebDriver Driver;
        //String trxfilepath = @"C:\Users\chanduru.s\Source\Workspaces\Integration Project\TestResults\";

        //String destinationPath = @"C:\Users\chanduru.s\Source\Workspaces\Existed";
        public static string trxfilepath = @ConfigurationManager.AppSettings["Trxfilepath"];
        public static string destinationPath = @ConfigurationManager.AppSettings["TrxExitedfilepath"];
        public static string Username = @ConfigurationManager.AppSettings["EmailUsername"];
        public static string Password = @ConfigurationManager.AppSettings["Emailpassword"];
        public static string Email_id = @ConfigurationManager.AppSettings["EmailAddresss"];

        public static string filename;

        public string EmailTemplate()
        {
            List<String> resltval = ActivateLink();
            string EmailFormat =
             "<div>" +
                "<span><h3>TestCase Execution Details</h3></span><br />" +
                   "<table border=1 width=100% align=left cellpadding=3>" +
                      "<th>Type</th>" +
                      "<th>Pass</th>" +
                      "<th>Fail</th>" +
                          "<tr>" +
                          "<td style=width:50px><strong>" + resltval[0] + "</strong></td>" +
                          "<td style=width:50px><strong>" + resltval[1] + "</strong></td>" +
                          "<td style=width:50px><strong>" + resltval[2] + "</strong></td>" +
                          "</tr>" +
                          "<tr>" +
                          "<td style=width:50px><strong>" + resltval[3] + "</strong></td>" +
                          "<td style=width:50px><strong>" + resltval[4] + "</strong></td>" +
                          "<td style=width:50px><strong>" + resltval[5] + "</strong></td>" +
                          "</tr>" +
                     "</table>" +
               "</div>";

            return EmailFormat;
        }

        [TestMethod]
        public void sendingmail()
        {
            // chanduru.sampathkumar@gsr-inc.com
            //               Account Name: testautomation@theranos.com
            //SMTP Server IP: 10.100.2.51
            //Port: 587

            //Pwdi#mX91$!sYoV

            //string your_id = "testautomation";
            //Username;
            //string your_password = "Pwdi#mX91$!sYoV";
            //Password;
            try
            {
                string Template = EmailTemplate();
                //  string hostname = "10.100.2.51";
                SmtpClient MyMail = new SmtpClient();
                MailMessage MyMsg = new MailMessage();

                MyMail.Port = 587;
                MyMail.Host = "10.100.2.51";
                MyMail.EnableSsl = true;
                MyMail.UseDefaultCredentials = false;
                NetworkCredential MyCredentials = new NetworkCredential(Username, Password);
                MyMail.Credentials = MyCredentials;

                MyMsg.Priority = MailPriority.High;
                MyMsg.To.Add(new MailAddress("chanduru.sampathkumar@gsr-inc.com"));
                MyMsg.To.Add(new MailAddress("flu@theranos.com"));
                MyMsg.CC.Add(new MailAddress("vnair@theranos.com"));

                MyMsg.Subject = "Automation Test Result";
                MyMsg.SubjectEncoding = Encoding.UTF8;
                MyMsg.Body = Template;
                MyMsg.IsBodyHtml = true;

                ServicePointManager.ServerCertificateValidationCallback =
            delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };

                MyMsg.Attachments.Add(new Attachment(trxfilepath + filename + ".html"));
                MyMsg.Attachments.Add(new Attachment(trxfilepath + filename + ".trx"));
                MyMsg.From = new MailAddress(Email_id);
                MyMsg.BodyEncoding = Encoding.UTF8;
                //MyMsg.Body = "Body";

                // MyMail.Credentials = (ICredentialsByHost)CredentialCache.DefaultNetworkCredentials;
                MyMail.Send(MyMsg);
                Console.WriteLine("Email Sent");
                /// MyMsg = null;

            }
            catch (SmtpException e1)
            {
                Console.WriteLine("Could not send email \n\n" + e1.ToString());
            }
        }
        public List<String> ActivateLink()
        {
            try
            {
                List<String> allval = new List<String>();

                Driver = new PhantomJSDriver(@"C:\MailSoftware\Selenium");
                Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
                //go to url 
                Driver.Navigate().GoToUrl("file:///" + trxfilepath + filename + ".html");
                String testtype = Driver.FindElement(By.XPath("html/body/div[2]/div/div[1]/div[2]/div/div[1]")).Text;

                String tcpass = Driver.FindElement(By.XPath("html/body/div[2]/div/div[1]/div[2]/div/div[3]/span/span")).Text;
                String tcfail = Driver.FindElement(By.XPath("html/body/div[2]/div/div[1]/div[2]/div/div[4]/span/span[1]")).Text;

                String suittype = Driver.FindElement(By.XPath("html/body/div[2]/div/div[1]/div[1]/div/div[1]")).Text;

                String suitpass = Driver.FindElement(By.XPath("html/body/div[2]/div/div[1]/div[1]/div/div[3]/span/span")).Text;
                String suitfail = Driver.FindElement(By.XPath("html/body/div[2]/div/div[1]/div[1]/div/div[4]/span/span[1]")).Text;

                allval.Add(testtype);
                allval.Add(tcpass);
                allval.Add(tcfail);
                allval.Add(suittype);
                allval.Add(suitpass);
                allval.Add(suitfail);

                Console.WriteLine("Print---------" + tcpass);

                Console.WriteLine("Print---------" + tcfail);

                Console.WriteLine("Print---------" + suitpass);

                Console.WriteLine("Print---------" + suitfail);

                Driver.Close();
                return allval;
            }

            catch (DirectoryNotFoundException e)
            {
                String sMessage = e.Message;
                Console.WriteLine("ddddddddd====" + sMessage);
                throw new Exception(sMessage);

            }

        }
       
        public void convertTRX_HTML()
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardInput = true;
                p.Start();
                p.StandardInput.WriteLine(@"cd " + trxfilepath);
                p.StandardInput.WriteLine("ReportUnit.exe " + filename + ".trx");

            }
            catch (DirectoryNotFoundException e)
            {
                String sMessage = e.Message;
                Console.WriteLine(sMessage);
                throw new Exception(sMessage);

            }
        }
        
        public void movetrxfiles()
        {
            try
            {
                string[] files = System.IO.Directory.GetFiles(trxfilepath, "*.trx");

                foreach (String file in files)
                {
                    System.IO.File.Move(file, destinationPath + Path.GetFileName(file));
                }

                string[] htmlfiles = System.IO.Directory.GetFiles(trxfilepath, "*.html");

                foreach (String file in htmlfiles)
                {
                    System.IO.File.Move(file, destinationPath + Path.GetFileName(file));
                }
            }
            catch (DirectoryNotFoundException e)
            {
                String sMessage = e.Message;
                Console.WriteLine("ddddddddd====" + sMessage);
                throw new Exception(sMessage);
            }
        }

        public void getfilename()
        {
            try
            {
                System.IO.DirectoryInfo d = new System.IO.DirectoryInfo(trxfilepath);
                FileInfo[] infos = d.GetFiles();
                foreach (FileInfo f in infos)
                {
                    File.Move(f.FullName, f.FullName.ToString().Replace(" ", ""));
                }

                string[] filePaths = Directory.GetFiles(trxfilepath, "*.trx");
                foreach (string f in filePaths)
                {
                    filename = Path.GetFileNameWithoutExtension(f);
                    Console.WriteLine("kkkkkkkkk========" + filename);

                }

            }
            catch (DirectoryNotFoundException e1)
            {
                Console.WriteLine("Could not end email\n\n" + e1.ToString());
            }

        }
        [TestMethod]
        public void moveEmailtrxfile()
        {
            try
            {
                string[] Emailtrxfiles = System.IO.Directory.GetFiles(trxfilepath, "*.trx");

                foreach (String file in Emailtrxfiles)
                {
                    System.IO.File.Move(file, destinationPath + Path.GetFileName(file));
                }

            }
            catch (DirectoryNotFoundException e)
            {
                String sMessage = e.Message;
                Console.WriteLine("ddddddddd====" + sMessage);
                throw new Exception(sMessage);
            }
        }

        [TestMethod]
        public void EmailTriggering()
        {
            //moveEmailtrxfile();
            getfilename();
            convertTRX_HTML();
            sendingmail();
           // movetrxfiles();
            

        }
    }

}
