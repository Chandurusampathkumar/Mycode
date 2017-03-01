using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

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
using Theranos.Mailtemplate.AppStack;


namespace Theranos.Mailtemplate.Report.Mail
{
    [TestClass]
    public class Mailtrigger : Appassembly
    {
        public static string filename;
        public static IWebDriver Driver;
        public static string trxfilepath = @ConfigurationManager.AppSettings["Trxfilepath"];
        public static string destinationPath = @ConfigurationManager.AppSettings["TrxExitedfilepath"];
        public static string Username = @ConfigurationManager.AppSettings["EmailUsername"];
        public static string Password = @ConfigurationManager.AppSettings["Emailpassword"];
        public static string Email_id = @ConfigurationManager.AppSettings["EmailAddresss"];
        public static string MEFile = @ConfigurationManager.AppSettings["MEAndroidTrxfilepath"];
        public static string MEExFile = @ConfigurationManager.AppSettings["MEAndroidTrxExitedfilepath"];
        public string chanduru = "chanduru.sampathkumar@gsr-inc.com";
        public string fangming = "flu@theranos.com";
        public string vimal = "vnair@theranos.com";
        public string Kanchan ="Kjindal@theranos.com";


        public string EmailTemplate()
        {
            List<String> resltval = ActivateLink();
            string EmailFormat =
             "<div>" +
                "<span style='text-align:center; width:100%;'><h3 style='text-align:center; width:100%; color:#00b28c;'>TestCase Execution Details</h3></span><br />" +
                   "<table border=1 width=100% align=left cellpadding=3 style='border:1px solid #00b28c;'>" +
                   "<th style='background-color:#00b28c; Color:#ffffff;'>Type</th>" +
                      "<th style='background-color:#00b28c; Color:#ffffff;'>Pass</th>" +
                      "<th style='background-color:#00b28c; Color:#ffffff;'>Fail</th>" +
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
        public void sendingmail(string toamail,string tobmail,string cc1mail,string cc2mail)
        {
           
            try
            {
                string Template = EmailTemplate();
                SmtpClient MyMail = new SmtpClient();
                MailMessage MyMsg = new MailMessage();
                Appassembly aps = new Appassembly();
                //aps.subjectContent();

                MyMail.Port = 587;
                MyMail.Host = "10.100.2.51";
                MyMail.EnableSsl = true;
                MyMail.UseDefaultCredentials = false;
                NetworkCredential MyCredentials = new NetworkCredential(Username, Password);
                MyMail.Credentials = MyCredentials;

                MyMsg.Priority = MailPriority.High;
                MyMsg.To.Add(new MailAddress(toamail));
                MyMsg.To.Add(new MailAddress(tobmail));
                MyMsg.CC.Add(new MailAddress(cc1mail));
                MyMsg.CC.Add(new MailAddress(cc2mail));
                MyMsg.Subject = MailSubject+" Automation Test Result";
                MyMsg.SubjectEncoding = Encoding.UTF8;
                MyMsg.Body = Template;
                MyMsg.IsBodyHtml = true;

                ServicePointManager.ServerCertificateValidationCallback =
            delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };

                MyMsg.Attachments.Add(new Attachment(appfolderpath + filename + ".html"));
                MyMsg.Attachments.Add(new Attachment(appfolderpath + filename + ".trx"));
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
                UnZipLogFile("Log sendmail" + e1);
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
                Driver.Navigate().GoToUrl("file:///" + appfolderpath + filename + ".html");
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
                UnZipLogFile("Log read the html report" + e);
                String sMessage = e.Message;
                Console.WriteLine("ddddddddd====" + sMessage);
                throw new Exception(sMessage);

            }

        }

        public void convertTRX_HTML()
        {
            try
            {
                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();
                UnZipLogFile("Log start");
                cmd.StandardInput.WriteLine("cd " + appfolderpath);//appfolderpath
                UnZipLogFile("Log start" + appfolderpath);

                cmd.StandardInput.WriteLine("ReportUnit.exe " + filename + ".trx");
                UnZipLogFile("Log stop" + filename);
                //   cmd.StandardInput.WriteLine("echo Oscar");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
                Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            }
            catch (DirectoryNotFoundException e)
            {
                String sMessage = e.Message;
                Console.WriteLine(sMessage);
                throw new Exception(sMessage);

            }
        }
        public static void UnZipLogFile(string Filepath)
        {
            try
            {
                //if (ConfigurationManager.AppSettings["EnableLogFile"].ToString() == "1")
                {
                    //string LogPath = ConfigurationManager.AppSettings["MEAndroidTrxExitedfilepath"].ToString();
                    String LogPath = appfolderpath;
                    string filename = "Log_ThankyouMail" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
                    string filepath = LogPath + filename;
                    if (!File.Exists(filepath))
                    {
                        File.Create(filepath).Close();
                        using (StreamWriter writer = new StreamWriter(filepath, true))
                        {
                            writer.WriteLine(Filepath + " " + DateTime.Now.ToLongTimeString());
                        }
                    }
                    else
                    {
                        using (StreamWriter writer = new StreamWriter(filepath, true))
                        {
                            writer.WriteLine(Filepath + " " + DateTime.Now.ToLongTimeString());
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                //string LogPath = ConfigurationManager.AppSettings["LogDirectory"].ToString();
                string LogPath = appfolderpath;
                string filename = "Log_ThankyouMail" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
                string filepath = LogPath + filename;
                using (StreamWriter writer = new StreamWriter(filepath, true))
                {
                    writer.WriteLine(Filepath + " " + DateTime.Now.ToLongTimeString() + Ex.Message);
                }
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
                System.IO.DirectoryInfo d = new System.IO.DirectoryInfo(appfolderpath);
                FileInfo[] infos = d.GetFiles();
                //trim the space 
                foreach (FileInfo f in infos)
                {
                    string newFileName = Path.GetFileName(f.FullName).Replace(" ", "");
                    string newFilpath = Path.GetDirectoryName(f.FullName);
                    File.Move(f.FullName, Path.Combine(newFilpath, newFileName));
                }
                string[] filePaths = Directory.GetFiles(appfolderpath, "*.trx");
                foreach (string f in filePaths)
                {
                    filename = Path.GetFileNameWithoutExtension(f);
                    Console.WriteLine("kkkkkkkkk========" + filename);
                    UnZipLogFile("Log get filename" + filename);
                }

            }
            catch (DirectoryNotFoundException e1)
            {
                UnZipLogFile("Log getfilename" + e1);
                Console.WriteLine("Could not end email\n\n" + e1.ToString());
            }

        }

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
            setapp_path();
            subjectContent();
            getfilename();
            convertTRX_HTML();
            sendingmail(chanduru, chanduru, chanduru, chanduru);
        }
    }


}
