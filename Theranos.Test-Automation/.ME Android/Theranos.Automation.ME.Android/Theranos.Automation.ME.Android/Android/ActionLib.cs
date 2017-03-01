using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Theranos.Automation.ME.Android.TestScripts.Account;
using Theranos.Automation.ME.Android.Utility;

namespace Theranos.Automation.ME.Android.Android
{
    public class ActionLib
    {
        // public static AndroidDriver<AndroidElement> Driver;


        // ******************************************************************************************************************************************
        /**
         * Function to Login into .ME application
         * 
         * @param slocator
         *            , sValue
         */
        public Boolean Login(AndroidDriver<AndroidElement> Driver, String slocator, String sValue, String slocator1, String svalue1)
        {
            try
            {
                Console.WriteLine("Trying to Login Theranos :" + " with username and password = " + sValue);
                Driver.FindElement(By.XPath(slocator)).SendKeys(sValue);
                Driver.FindElement(By.XPath(slocator1)).SendKeys(svalue1);
                Console.WriteLine("Login into the Theranos application with username as:" + sValue + " successful");
                return true;
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);


            }

        }

        // ******************************************************************************************************************************************
        /**
         /*** Function to set text in an Theranos Application forms field
			 * @param slocator, sValue 
			 */

        public Boolean SetText_ById(AndroidDriver<AndroidElement> Driver, String slocator, String sValue)
        {

            try
            {
                Console.WriteLine("Trying to set text on field :" + slocator + " with value = " + sValue);
                Driver.FindElement(By.Id(slocator)).SendKeys(sValue);
                Console.WriteLine("Set text on field : " + slocator + " successful");
                return true;
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }

        }
        /*** Function to set text in an Theranos Application forms field
           * @param slocator, sValue 
           */

        public Boolean SetText_ByName(AndroidDriver<AndroidElement> Driver, String slocator, String sValue)
        {

            try
            {
                Console.WriteLine("Trying to set text on field :" + slocator + " with value = " + sValue);
                Driver.FindElement(By.Name(slocator)).SendKeys(sValue);
                Console.WriteLine("Set text on field : " + slocator + " successful");
                return true;
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }

        }
        // ******************************************************************************************************************************************
        /**
			 * Function to click an Theranos application forms button
			 * @param slacator, 
			 */

        public Boolean clickButton_Byid(AndroidDriver<AndroidElement> Driver, String slocator)
        {

            try
            {
                Console.WriteLine("Trying to click the button :" + slocator);
                Driver.FindElement(By.Id(slocator)).Click();
                Console.WriteLine("Click button : " + slocator + " successful");
                return true;
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }

        }
        // ******************************************************************************************************************************************
        /**
			 * Function to click an Theranos application forms button
			 * @param slacator, 
			 */

        public Boolean clickButton_Byclass(AndroidDriver<AndroidElement> Driver, String slocator)
        {

            try
            {
                Console.WriteLine("Trying to click the button :" + slocator);
                Driver.FindElement(By.ClassName(slocator)).Click();
                Console.WriteLine("Click button : " + slocator + " successful");
                return true;
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }

        }
        // ******************************************************************************************************************************************
        /**
			 * Function to click an Theranos application forms button
			 * @param slacator, 
			 */

        public Boolean clickButton_ByName(AndroidDriver<AndroidElement> Driver, String slocator)
        {

            try
            {
                Console.WriteLine("Trying to click the button :" + slocator);
                Driver.FindElement(By.Name(slocator)).Click();
                Console.WriteLine("Click button : " + slocator + " successful");
                return true;
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }

        }
        // ******************************************************************************************************************************************
        /**
			 * Function to select a value from Qbend forms list 
			 * @param slocator, sValue 
			 */

        public Boolean selectListValue(AndroidDriver<AndroidElement> Driver, String slocator, String sValue)
        {

            try
            {
                Console.WriteLine("Trying to select the value :" + sValue + " from the list: " + slocator);
                SelectElement select = new SelectElement(Driver.FindElement(By.XPath(slocator))); //Locating select list
                select.SelectByText(sValue);
                Console.WriteLine("Trying to select the value :" + sValue + " from the list: " + slocator);
                return true;
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }

        }

        // ******************************************************************************************************************************************
        /*** Function to get text in forms field
		* @param slocator
		 */


        public String getText_byName(AndroidDriver<AndroidElement> Driver, String slocator)
        {

            try
            {
                Console.WriteLine("Trying to get text on field :" + slocator + " with value = :");
                IWebElement TextElement = Driver.FindElement(By.Name(slocator));
                String gtext = TextElement.Text;
                Console.WriteLine("get text on field value is : " + gtext);
                return gtext;
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }

        }
        // ******************************************************************************************************************************************
        /*** Function to get text in forms field
		* @param slocator
		 */


        public String getText_byID(AndroidDriver<AndroidElement> Driver, String slocator1)
        {
            try
            {
                Console.WriteLine("Trying to get text on field :" + slocator1 + " with value = :");
                var TextElement = Driver.FindElement(By.Id(slocator1));
                String gtext = TextElement.Text;
                Console.WriteLine("get text on field value is : " + gtext);
                return gtext;
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }

        }


        //******************************************************************************************************************************************	
        /**
         * Function to Window maximize
         * @param null
         */

        public Boolean Windowmaximize(AndroidDriver<AndroidElement> Driver)
        {
            try
            {
                Console.WriteLine("Trying to maximize the window");
                Driver.Manage().Window.Maximize();
                Console.WriteLine("Window maximize successful");
                return true;
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }

        }
        //******************************************************************************************************************************************	
        /**
         * Function to Radiobutton selection
         * 		 * @param slocator
         */

        public Boolean RadioB(AndroidDriver<AndroidElement> Driver, String slocator)
        {
            try
            {
                Console.WriteLine("Trying to select radio button");
                IWebElement Radio = Driver.FindElement(By.XPath(slocator));
                Radio.Click();
                Console.WriteLine("Radio button selected successful");
                return true;
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }

        }
        //******************************************************************************************************************************************	
        /**
         * Function to unselect radio button 
         * @param String slocator
         */

        public Boolean Radiounselect(AndroidDriver<AndroidElement> Driver, String slocator)
        {
            try
            {
                Console.WriteLine("Trying to un select the  radio button");
                IWebElement Radio = Driver.FindElement(By.XPath(slocator));

                //Checking if already select
                if (Radio.Selected)
                    Radio.Click();
                Console.WriteLine("Radio button selected successful");
                return true;
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }

        }
        //******************************************************************************************************************************************	
        /**
         * Function to Explicit wait
         * @param slocator
         */
        public void WaitForElementLoad_ByName(AndroidDriver<AndroidElement> Driver, String slocator, int timeoutInSeconds)
        {
            try
            {
                if (timeoutInSeconds > 0)
                {
                    Console.WriteLine("waiting for element");
                    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name(slocator)));
                    Console.WriteLine("system executed the script successful ");
                }
            }
            catch (Exception e)
            {

                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }
        }
        //******************************************************************************************************************************************	
        /**
         * Function to Explicit wait
         * @param slocator
         */
        public void WaitForElementLoad_Byid(AndroidDriver<AndroidElement> Driver, String slocator, int timeoutInSeconds)
        {
            try
            {
                if (timeoutInSeconds > 0)
                {
                    Console.WriteLine("waiting for element");
                    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Id(slocator)));
                    Console.WriteLine("system executed the script successful ");
                }
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage + "Waiting for Element : " + slocator);
            }
        }
        //******************************************************************************************************************************************	
        /**
         * Function to Explicit wait
         * @param slocator
         */
        public void WaitForElementLoad_ByClassName(AndroidDriver<AndroidElement> Driver, String slocator, int timeoutInSeconds)
        {
            try
            {
                if (timeoutInSeconds > 0)
                {
                    Console.WriteLine("waiting for element");
                    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(slocator)));
                    Console.WriteLine("system executed the script successful ");
                }
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage + "Waiting for Element : " + slocator);
            }
        }
        //******************************************************************************************************************************************	
        /**
         * Function to Explicit wait
         * @param slocator
         */
        public void ElementClickable_Byid(AndroidDriver<AndroidElement> Driver, String slocator, int timeoutInSeconds)
        {
            try
            {
                if (timeoutInSeconds > 0)
                {
                    Console.WriteLine("waiting for element");
                    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(slocator)));
                    Console.WriteLine("system executed the script successful ");
                }
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }
        }
        //******************************************************************************************************************************************	
        /**
         * Function to Clear text in forms field
         * @param slocator
         */

        public Boolean ClearText(AndroidDriver<AndroidElement> Driver, String slocator)
        {
            try
            {
                Console.WriteLine("Trying to clear text on field :" + slocator + " with values = :");
                IWebElement Ctext = Driver.FindElement(By.XPath(slocator));
                Ctext.Clear();
                Console.WriteLine("get text on field value is : " + Ctext);
                return true;
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }

        }
        //******************************************************************************************************************************************	
        /**
         * Function to Switch between frames using frame id
         * @param slocator
         */

        public void SwitchFrame(AndroidDriver<AndroidElement> Driver, string slocator)
        {
            try
            {
                Console.WriteLine("Trying to switch frame:" + slocator);
                var Frame = Driver.SwitchTo().Frame(slocator);
                Console.WriteLine("Frame is switch to: " + Frame);

            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }
        }

        //public void OpenNewTab(string URL)
        //{
        //   try
        //   {
        //      Actions builder = new Actions(Driver);
        //      builder.KeyDown(Keys.Control).KeyDown("t");
        //      IAction switchTabs = builder.Build();
        //      switchTabs.Perform();

        //   }
        //    catch(Exception e)
        //   {

        //    }

        //}
        public void wait(AndroidDriver<AndroidElement> Driver)
        {
            //WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(40));
            Thread.Sleep(5000);
            //wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(slocator)));
        }

        /*** Function to set text in an Theranos Application forms field
           * @param slocator, sValue 
           */

        public Boolean SetTextAND_ById(AndroidDriver<AndroidElement> Driver, String slocator1, String slocator2, String sValue)
        {

            try
            {
                Console.WriteLine("Trying to set text on field :" + slocator1 + " with value = " + sValue);
                Driver.FindElement(By.Id(slocator1)).FindElement(By.Name(slocator2)).SendKeys(sValue);
                Console.WriteLine("Set text on field : " + slocator1 + " successful");
                return true;
            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }

        }

    }
}