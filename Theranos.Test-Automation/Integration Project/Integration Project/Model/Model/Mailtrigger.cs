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
namespace Integration_Project.Model
{
    
    [TestClass]
    public class Mailtrigger
    {

        public static IWebDriver Driver;
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
        public void button1_Click()
        {
            string your_id = "from mailid";
            string your_password = "from password";
            try
            {
                string Template = EmailTemplate();

                SmtpClient MyMail = new SmtpClient();
                MailMessage MyMsg = new MailMessage();

                MyMail.Port = 587;
                MyMail.Host = "smtp.gmail.com";
                MyMail.EnableSsl = true;
                //MyMail.UseDefaultCredentials = false;
                NetworkCredential MyCredentials = new NetworkCredential(your_id, your_password);
                MyMail.Credentials = MyCredentials;

                MyMsg.Priority = MailPriority.High;
                MyMsg.To.Add(new MailAddress("tomailid"));
                MyMsg.Subject = "Subject";
                MyMsg.SubjectEncoding = Encoding.UTF8;
                MyMsg.Body = Template;
                MyMsg.IsBodyHtml = true;
                
                MyMsg.Attachments.Add(new Attachment("C:\\Users\\omkar.krishnamurthy\\Desktop\\Tulips.jpg"));
                //MyMsg.Attachments.Add(new Attachment("C:\\Users\\omkar.krishnamurthy\\Desktop\\Tulips.jpg"));
                MyMsg.From = new MailAddress(your_id);
                MyMsg.BodyEncoding = Encoding.UTF8;
                //MyMsg.Body = "Body";
                MyMail.Send(MyMsg);


                Console.WriteLine("Email Sent");

            }
            catch (SmtpException e1)
            {
                Console.WriteLine("Could not end email\n\n" + e1.ToString());
            }
        }
        public List<String> ActivateLink()
        {
            try
            {
                List<String> allval = new List<String>();

                Driver = new PhantomJSDriver(@"D:\Software\Selenium");
                Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
                //go to url 
                Driver.Navigate().GoToUrl("file:///C:/Users/omkar.krishnamurthy/Desktop/balaji.html");
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
            catch (Exception e)
            {
                String sMessage = e.Message;
                Console.WriteLine("ddddddddd====" + sMessage);
                throw new Exception(sMessage);

            }
            
        }
        
        public void movefile()
        {
            string[] filePaths = Directory.GetFiles(@"C:\File\", "*.trx");
        }
        [TestMethod]
        public void SimpleFileCopy()
        {
            
                string[] filePaths = Directory.GetFiles(@"C:\File\", "*.trx");
                string fileName = "New Text Document.txt";
                string sourcePath = @"C:\File";
                string targetPath = @"C:\File\subfolder";
               

                // Use Path class to manipulate file and directory paths.
                string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                string destFile = System.IO.Path.Combine(targetPath, fileName);

                // To copy a folder's contents to a new location:
                // Create a new target folder, if necessary.
                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }

                // To copy a file to another location and 
                // overwrite the destination file if it already exists.
                System.IO.File.Move(sourceFile, destFile);

                // To copy all the files in one directory to another directory.
                // Get the files in the source folder. (To recursively iterate through
                // all subfolders under the current directory, see
                // "How to: Iterate Through a Directory Tree.")
                // Note: Check for target path was performed previously
                //       in this code example.
                if (System.IO.Directory.Exists(sourcePath))
                {
                    string[] files = System.IO.Directory.GetFiles(sourcePath);

                    // Copy the files and overwrite destination files if they already exist.
                    foreach (string s in files)
                    {
                        // Use static Path methods to extract only the file name from the path.
                        fileName = System.IO.Path.GetFileName(s);
                        destFile = System.IO.Path.Combine(targetPath, fileName);
                        //System.IO.File.Copy(s, destFile, true);
                        System.IO.File.Move(fileName, targetPath);
                        
                    }
                }
                else
                {
                    Console.WriteLine("Source path does not exist!");
                }

                // Keep console window open in debug mode.
                //Console.WriteLine("Press any key to exit.");
                //Console.ReadKey();
                //System.IO.FileInfo fi = new System.IO.FileInfo(@"C:\File\");
                //try
                //{
                //    fi.Delete();
                //}
                //catch (System.IO.IOException e)
                //{
                //    Console.WriteLine(e.Message);
                //}

            }
        }
    public class SimpleFileMove
    {
        static void Main()
        {
            string[] SourcefilePaths = Directory.GetFiles(@"C:\File\", "*.trx");
          
            string sourceFile = @"C:\Users\Public\public\test.txt";
            string destinationFile = @"C:\Users\Public\private\test.txt";

            // To move a file or folder to a new location:
            System.IO.File.Move(sourceFile, destinationFile);

            // To move an entire directory. To programmatically modify or combine
            // path strings, use the System.IO.Path class.
            System.IO.Directory.Move(@"C:\Users\Public\public\test\", @"C:\Users\Public\private");
        }
    }
    }


