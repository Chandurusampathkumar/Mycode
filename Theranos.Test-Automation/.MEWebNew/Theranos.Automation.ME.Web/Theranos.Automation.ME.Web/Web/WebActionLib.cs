using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using System.Drawing.Imaging;

namespace Theranos.Automation.ME.Web
{
    public class WebActionLib : WebME
    {
        public static IWebDriver Driver;
        // ******************************************************************************************************************************************
        /**
         * Function to Login into .ME application
         * 
         * @param slocator
         *            , sValue
         */

        public void screeshotmethodcall(String filename)
        {
            try
            {
                Screenshot ss = ((ITakesScreenshot)Driver).GetScreenshot();
                //  string path =Directory.CreateDirectory(filename + string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}", DateTime.Now));

                ss.SaveAsFile(screenshotpath + filename + string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}", DateTime.Now) + ".png", ImageFormat.Png);

            }
            catch (Exception e)
            {
                String sMessage = e.Message;

            }
        }
        public Boolean Login(String slocator, String sValue, String slocator1, String svalue1)
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
                screeshotmethodcall(slocator);
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }

        }

        // ******************************************************************************************************************************************
        /**   dropdown
         /*** Function to set text in an Theranos Application forms field
			 * @param slocator, sValue 
			 */

        public Boolean SetText(String slocator, String sValue)
        {

            try
            {
                Console.WriteLine("Trying to set text on field :" + slocator + " with value = " + sValue);
                Driver.FindElement(By.XPath(slocator)).SendKeys(sValue);
                Console.WriteLine("Set text on field : " + slocator + " successful");
                return true;
            }
            catch (Exception e)
            {
                screeshotmethodcall(slocator);

                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }

        }
        // ******************************************************************************************************************************************
        /**
         /*** Function to set text in an Theranos Application forms field
			 * @param slocator, sValue 
			 */

        public Boolean SetTextByName(String slocator, String sValue)
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
                screeshotmethodcall(slocator);
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }

        }
        // ******************************************************************************************************************************************
        /**
			 * Function to click an Theranos application forms button
			 * @param slacator, 
			 */

        public Boolean clickButtonbyName(String slocator)
        {

            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                Console.WriteLine("Trying to click the button :" + slocator);
                Driver.FindElement(By.Name(slocator)).Click();
                Console.WriteLine("Click button : " + slocator + " successful");
                return true;
            }
            catch (Exception e)
            {
                screeshotmethodcall(slocator);
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }

        }
        // ******************************************************************************************************************************************
        /**
			 * Function to click an Theranos application forms button
			 * @param slacator, 
			 */

        public Boolean clickbuttonbyxpath(String slocator)
        {

            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                Console.WriteLine("Trying to click the button :" + slocator);
                Driver.FindElement(By.XPath(slocator)).Click();
                Console.WriteLine("Click button : " + slocator + " successful");
                return true;
            }
            catch (Exception e)
            {
                screeshotmethodcall(slocator);
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }

        }
        // ******************************************************************************************************************************************
        /**
			 * Function to select a value from Qbend forms list 
			 * @param slocator, sValue 
			 */

        public Boolean selectListBytext(String slocator, String text)
        {

            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                Console.WriteLine("Trying to select the value :" + text + " from the list: " + slocator);
                SelectElement select = new SelectElement(Driver.FindElement(By.XPath(slocator))); //Locating select list
                select.SelectByText(text);
                Console.WriteLine("Trying to select the value :" + text + " from the list: " + slocator);
                return true;
            }
            catch (Exception e)
            {
                screeshotmethodcall(slocator);
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }

        }

        // ******************************************************************************************************************************************
        /*** Function to get text in forms field
		* @param slocator
		 */

        public Boolean selectListByIndex(String slocator, int indexno)
        {

            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                Console.WriteLine("Trying to select the value :" + indexno + " from the list: " + slocator);
                SelectElement select = new SelectElement(Driver.FindElement(By.XPath(slocator))); //Locating select list
                select.SelectByIndex(indexno);
                Console.WriteLine("Trying to select the value :" + indexno + " from the list: " + slocator);
                return true;
            }
            catch (Exception e)
            {
                screeshotmethodcall(slocator);
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }

        }
        // ******************************************************************************************************************************************
        /*** Function to get text in forms field
		* @param slocator
		 */

        public String getText(String slocator)
        {

            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                Console.WriteLine("Trying to get text on field :" + slocator + " with value = :");
                IWebElement TextElement = Driver.FindElement(By.XPath(slocator));
                String gtext = TextElement.Text;
                Console.WriteLine("get text on field value is : " + gtext);
                return gtext;
            }
            catch (Exception e)
            {
                screeshotmethodcall(slocator);

                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }

        }
        //******************************************************************************************************************************************	
        /**
         * Function to Window maximize
         * @param null
         */

        public Boolean Windowmaximize()
        {
            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
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

        public Boolean RadioB(String slocator)
        {
            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                Console.WriteLine("Trying to select radio button");
                IWebElement Radio = Driver.FindElement(By.XPath(slocator));
                Radio.Click();
                Console.WriteLine("Radio button selected successful");
                return true;
            }
            catch (Exception e)
            {
                screeshotmethodcall(slocator);
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }

        }
        //******************************************************************************************************************************************	
        /**
         * Function to unselect radio button 
         * @param String slocator
         */

        public Boolean Radiounselect(String slocator)
        {
            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
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
                screeshotmethodcall(slocator);
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }

        }
        //******************************************************************************************************************************************	
        /**
         * Function to Explicit wait
         * @param slocator
         */
        public void WaitForElementByXpathTo_Clickable(String xpath, int timeoutInSeconds)
        {
            try
            {
                if (timeoutInSeconds > 0)
                {
                    Console.WriteLine("waiting for element");
                    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                }
            }
            catch (Exception e)
            {
                screeshotmethodcall(xpath);

                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }
        }
        //******************************************************************************************************************************************	
        /**
         * Function to Explicit wait
         * @param slocator
         */
        public void WaitForElementByClassNameTo_Clickable(String classname, int timeoutInSeconds)
        {
            try
            {
                if (timeoutInSeconds > 0)
                {
                    Console.WriteLine("waiting for element");
                    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName(classname)));
                }
            }
            catch (Exception e)
            {
                screeshotmethodcall(classname);
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }
        }
        //******************************************************************************************************************************************	
        /**
         * Function to Explicit wait
         * @param slocator
         */
        public void WaitForElementByIdTo_Clickable(String id, int timeoutInSeconds)
        {
            try
            {
                if (timeoutInSeconds > 0)
                {
                    Console.WriteLine("waiting for element");
                    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(id)));
                }
            }
            catch (Exception e)
            {
                screeshotmethodcall(id);
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }
        }
        //******************************************************************************************************************************************	
        /**
         * Function to Clear text in forms field
         * @param slocator
         */

        public Boolean ClearTextByid(String slocator)
        {
            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                Console.WriteLine("Trying to clear text on field :" + slocator + " with values = :");
                IWebElement Ctext = Driver.FindElement(By.Id(slocator));
                Ctext.Clear();
                Console.WriteLine("get text on field value is : " + Ctext);
                return true;
            }
            catch (Exception e)
            {
                screeshotmethodcall(slocator);
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }
        }
        //******************************************************************************************************************************************	
        /**
         * Function to Clear text in forms field
         * @param slocator
         */

        public Boolean ClearTextByName(String slocator)
        {
            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                Console.WriteLine("Trying to clear text on field :" + slocator + " with values = :");
                IWebElement Ctext = Driver.FindElement(By.Name(slocator));
                Ctext.Clear();
                Console.WriteLine("get text on field value is : " + Ctext);
                return true;
            }
            catch (Exception e)
            {
                screeshotmethodcall(slocator);
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }

        }
        //******************************************************************************************************************************************	
        /**
         * Function to Clear text in forms field
         * @param slocator
         */

        public Boolean ClearTextByClassName(String slocator)
        {
            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                Console.WriteLine("Trying to clear text on field :" + slocator + " with values = :");
                IWebElement Ctext = Driver.FindElement(By.ClassName(slocator));
                Ctext.Clear();
                Console.WriteLine("get text on field value is : " + Ctext);
                return true;
            }
            catch (Exception e)
            {
                screeshotmethodcall(slocator);
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }

        }
        //******************************************************************************************************************************************	
        /**
         * Function to Clear text in forms field
         * @param slocator
         */

        public Boolean ClearTextByxpath(String slocator)
        {
            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                Console.WriteLine("Trying to clear text on field :" + slocator + " with values = :");
                IWebElement Ctext = Driver.FindElement(By.XPath(slocator));
                Ctext.Clear();
                Console.WriteLine("get text on field value is : " + Ctext);
                return true;
            }
            catch (Exception e)
            {
                screeshotmethodcall(slocator);
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }

        }
        //******************************************************************************************************************************************	
        /**
         * Function to Switch between frames using frame id
         * @param slocator
         */

        public void SwitchFrame(string slocator)
        {
            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                Console.WriteLine("Trying to switch frame:" + slocator);
                var Frame = Driver.SwitchTo().Frame(slocator);
                Console.WriteLine("Frame is switch to: " + Frame);

            }
            catch (Exception e)
            {
                screeshotmethodcall(slocator);
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }
        }

        /* -------------------------------------------------------------------------------------------------------------------------------- */

        public void wait()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(15000));
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/



        /* -------------------------------------------------------------------------------------------------------------------------------- */

        /** wait for an ElementByName to load
         * @param=name
        **/
        public void waitForElementByNameTo_Clickable(String name, int timeoutInSeconds)
        {
            try
            {
                if (timeoutInSeconds > 0)
                {
                    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.Name(name)));
                }
            }
            catch (Exception e)
            {
                screeshotmethodcall(name);
                String sMessage = e.Message;
                throw new Exception(" Unable to find Element By Name " + sMessage);
            }
        }

        /* -------------------------------------------------------------------------------------------------------------------------------- */

        /** Click element by Xpath
         * @param xpath
         **/

        public void clickElementByXpath(string xpath)
        {
            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                waitForElement("xpath", xpath, 60);

                Driver.FindElement(By.XPath(xpath)).Click();


            }
            catch (Exception e)
            {
                screeshotmethodcall(xpath);
                String eMessage = e.Message;
                System.Diagnostics.Debug.WriteLine(" Xpath of Element : " + xpath);
                throw new Exception(" Unable to click on ElementByXpath " + eMessage);
            }
        }

        /* -------------------------------------------------------------------------------------------------------------------------------- */

        /** click element by using its class name 
         * @param classname
        **/
        public void clickElementByClassName(string classname)
        {
            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                waitForElement("classname", classname, 60);
                Driver.FindElement(By.ClassName(classname)).Click();
            }
            catch (Exception e)
            {
                screeshotmethodcall(classname);
                string eMessage = e.Message;
                System.Diagnostics.Debug.WriteLine(" Classname of Element : " + classname);
                throw new Exception(" Unable to click on element" + eMessage);
            }
        }


        /* -------------------------------------------------------------------------------------------------------------------------------- */

        /** Click element By using it's Id **/
        public void clickElementById(string id)
        {
            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                waitForElement("id", id, 60);
                Driver.FindElement(By.Id(id)).Click();
            }
            catch (Exception e)
            {
                screeshotmethodcall(id);
                string eMessage = e.Message;
                System.Diagnostics.Debug.WriteLine(" Id of Element : " + id);
                throw new Exception(" Unable to click on elementById" + eMessage);
            }
        }


        /* -------------------------------------------------------------------------------------------------------------------------------- */

        /** Opens link in another tab instead of new window **/

        public void controlClickByXpath(string xpath)
        {
            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                IWebElement ele = Driver.FindElement(By.XPath(xpath));
                Actions builder = new Actions(Driver);
                builder.KeyDown(Keys.Control).KeyDown(Keys.Shift).Click(ele).KeyUp(Keys.Shift).KeyUp(Keys.Control).Build().Perform();
            }
            catch (Exception e)
            {
                screeshotmethodcall(xpath);
                string eMessage = e.Message;
                System.Diagnostics.Debug.WriteLine(" Xpath of Element : " + xpath);
                throw new Exception(" Unable to Control-Click on elementByXpath" + eMessage);
            }
        }

        /* -------------------------------------------------------------------------------------------------------------------------------- */

        public void clickElementByLinkText(string linktext)
        {
            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                waitForElement("linktext", linktext, 60);
                Driver.FindElement(By.LinkText(linktext)).Click();
            }
            catch (Exception e)
            {
                screeshotmethodcall(linktext);
                string eMessage = e.Message;
                System.Diagnostics.Debug.WriteLine(" linktext of Element : " + linktext);
                throw new Exception(" Unable to click on elementBylinktext" + eMessage);
            }
        }
        /* -------------------------------------------------------------------------------------------------------------------------------- */

        /** Clicks on an element By Name.
         * @param=name
        **/
        public void clickElementByName(string name)
        {
            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                waitForElement("name", name, 60);
                Driver.FindElement(By.Name(name)).Click();
            }
            catch (Exception e)
            {
                screeshotmethodcall(name);
                string eMessage = e.Message;
                System.Diagnostics.Debug.WriteLine(" Name of Element : " + name);
                throw new Exception(" Unable to click Element by Name " + eMessage);
            }
        }
        /* -------------------------------------------------------------------------------------------------------------------------------- */

        /** Clicks on an element By xpath.
         * @param=name
        **/
        public void clickElementByJavaScriptXpath(string javascriptxpath)
        {
            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));

                IWebElement element = Driver.FindElement(By.XPath(javascriptxpath));

                IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
                js.ExecuteScript("arguments[0].click();", element);

            }
            catch (Exception e)
            {
                screeshotmethodcall(javascriptxpath);
                string eMessage = e.Message;
                System.Diagnostics.Debug.WriteLine(" Name of Element : " + javascriptxpath);
                throw new Exception(" Unable to click Element by javascriptxpath " + eMessage);
            }
        }

        /* -------------------------------------------------------------------------------------------------------------------------------- */

        /** Clicks on an element By Name.
         * @param=name
        **/
        public void clickElementByJavaScriptName(string javascriptName)
        {
            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));

                IWebElement element = Driver.FindElement(By.Name(javascriptName));

                IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
                js.ExecuteScript("arguments[0].click();", element);

            }
            catch (Exception e)
            {
                screeshotmethodcall(javascriptName);
                string eMessage = e.Message;
                System.Diagnostics.Debug.WriteLine(" Name of Element : " + javascriptName);
                throw new Exception(" Unable to click Element by javascriptName " + eMessage);
            }
        }

        /* -------------------------------------------------------------------------------------------------------------------------------- */

        /** Clicks on an element By Name.
         * @param=name
        **/
        public void clickElementByJavaScriptClassName(string javascriptClassName)
        {
            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));

                IWebElement element = Driver.FindElement(By.ClassName(javascriptClassName));

                IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
                js.ExecuteScript("arguments[0].click();", element);

            }
            catch (Exception e)
            {
                screeshotmethodcall(javascriptClassName);
                string eMessage = e.Message;
                System.Diagnostics.Debug.WriteLine(" Name of Element : " + javascriptClassName);
                throw new Exception(" Unable to click Element by javascriptClassName " + eMessage);
            }
        }
        /* -------------------------------------------------------------------------------------------------------------------------------- */

        /** Clicks on an element By Name.
         * @param=name
        **/
        public void clickElementByJavaScriptId(string javascriptId)
        {
            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));

                IWebElement element = Driver.FindElement(By.ClassName(javascriptId));

                IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
                js.ExecuteScript("arguments[0].click();", element);

            }
            catch (Exception e)
            {
                screeshotmethodcall(javascriptId);
                string eMessage = e.Message;
                System.Diagnostics.Debug.WriteLine(" Name of Element : " + javascriptId);
                throw new Exception(" Unable to click Element by javascriptId " + eMessage);
            }
        }
        /* -------------------------------------------------------------------------------------------------------------------------------- */

        /** Clicks on an element By Name.
         * @param=name
        **/
        public void clickElementByJavaScriptLinkText(string javascriptLinkText)
        {
            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));

                IWebElement element = Driver.FindElement(By.LinkText(javascriptLinkText));

                IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
                js.ExecuteScript("arguments[0].click();", element);

            }
            catch (Exception e)
            {
                screeshotmethodcall(javascriptLinkText);
                string eMessage = e.Message;
                System.Diagnostics.Debug.WriteLine(" Name of Element : " + javascriptLinkText);
                throw new Exception(" Unable to click Element by javascriptLinkText " + eMessage);
            }
        }
        /* -------------------------------------------------------------------------------------------------------------------------------- */
        /** send text to fields by using field element name
         * @param=name
        **/
        public void sendTextByName(string ElementName, string TextToSend)
        {
            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                //  waitForElement("name", ElementName, 60);
                Driver.FindElement(By.Name(ElementName)).Clear();
                Driver.FindElement(By.Name(ElementName)).SendKeys(TextToSend);
            }
            catch (Exception e)
            {
                screeshotmethodcall(ElementName);
                string eMessage = e.Message;
                System.Diagnostics.Debug.WriteLine(" Unable to send text to the element by Name. Name of Element : " + ElementName);
                throw new Exception(" Unable to send text" + eMessage);
            }

        }

        /* -------------------------------------------------------------------------------------------------------------------------------- */

        public void sendTextByXpath(string Elementxpath, string TextToSend)
        {
            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                // waitForElement("xpath", Elementxpath, 60);
                Driver.FindElement(By.XPath(Elementxpath)).Clear();
                Driver.FindElement(By.XPath(Elementxpath)).SendKeys(TextToSend);
            }
            catch (Exception e)
            {
                screeshotmethodcall(Elementxpath);
                string eMessage = e.Message;
                System.Diagnostics.Debug.WriteLine(" Unable to send text to the element by using its xpath. Xpath of Element : " + Elementxpath);
                throw new Exception(" Unable to send text to field by using its xpath" + eMessage);
            }
        }
        /* -------------------------------------------------------------------------------------------------------------------------------- */

        public void sendTextByClassName(string ElementClassName, string TextToSend)
        {
            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                //  waitForElement("classname", ElementClassName, 60);
                Driver.FindElement(By.ClassName(ElementClassName)).Clear();
                Driver.FindElement(By.ClassName(ElementClassName)).SendKeys(TextToSend);
            }
            catch (Exception e)
            {
                screeshotmethodcall(ElementClassName);
                string eMessage = e.Message;
                System.Diagnostics.Debug.WriteLine(" Unable to send text to the element by using its ElementClassName of Element : " + ElementClassName);
                throw new Exception(" Unable to send text to field by using its ElementClassName" + eMessage);
            }
        }
        /* -------------------------------------------------------------------------------------------------------------------------------- */

        public void sendTextById(string Elementid, string TextToSend)
        {
            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                //   waitForElement("id", Elementid, 60);
                Driver.FindElement(By.Id(Elementid)).SendKeys(TextToSend);
            }
            catch (Exception e)
            {
                screeshotmethodcall(Elementid);
                string eMessage = e.Message;
                System.Diagnostics.Debug.WriteLine(" Unable to send text to the element by using its id. id of Element : " + Elementid);
                throw new Exception(" Unable to send text to field by using its id" + eMessage);

            }
        }

        /* -------------------------------------------------------------------------------------------------------------------------------- */

        /** Returns text from element. The element is identified by using its xpath **/
        public string getTextByXpath(string xpath)
        {
            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                waitForElement("xpath", xpath, 60);
                string text = Driver.FindElement(By.XPath(xpath)).Text;
                return text;
            }
            catch (Exception e)
            {

                screeshotmethodcall(xpath);
                string eMessage = e.Message;
                throw new Exception(" Unable to get text by Xpath" + eMessage);

            }
        }

        /* -------------------------------------------------------------------------------------------------------------------------------- */

        /** Returns text from element. The element is identified by using its xpath **/
        public string getTextByID(string id)
        {
            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                waitForElement("id", id, 60);
                string text = Driver.FindElement(By.Id(id)).Text;
                return text;
            }
            catch (Exception e)
            {
                screeshotmethodcall(id);
                string eMessage = e.Message;
                throw new Exception(" Unable to get text by id" + eMessage);
            }
        }
        /* -------------------------------------------------------------------------------------------------------------------------------- */

        /** Returns text from element. The element is identified by using its xpath **/
        public string getTextByName(string name)
        {
            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                waitForElement("name", name, 60);
                string text = Driver.FindElement(By.Name(name)).Text;
                return text;
            }
            catch (Exception e)
            {
                screeshotmethodcall(name);
                string eMessage = e.Message;
                throw new Exception(" Unable to get text by name" + eMessage);
            }
        }

        /* -------------------------------------------------------------------------------------------------------------------------------- */
        public string getAttributeByXpath(string Xpath, string attribute)
        {

            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                waitForElement("xpath", Xpath, 60);
                string aVal = Driver.FindElement(By.XPath(Xpath)).GetAttribute(attribute);
                return aVal;
            }
            catch (Exception e)
            {
                screeshotmethodcall(Xpath);
                string eMessage = e.Message;
                throw new Exception(" Unable to get attribute value " + eMessage + " Attribute used is = " + attribute);
            }
        }


        /* -------------------------------------------------------------------------------------------------------------------------------- */
        /** Switch to a frame by using IWebElement of the frame **/
        public void switchToFrameByElement(IWebElement element)
        {
            try
            {
                Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                wait();
                Driver.SwitchTo().Frame(element);
            }
            catch (Exception e)
            {

                string eMessage = e.Message;
                System.Diagnostics.Debug.WriteLine(" Unable to switch to frame. Frame Element : " + element);
                throw new Exception(" Unable to send text to field by using its id" + eMessage);
            }
        }

        /* -------------------------------------------------------------------------------------------------------------------------------- */

        public string getCurrentPageUrl()
        {
            string url = Driver.Url;
            return url;

        }
        /* -------------------------------------------------------------------------------------------------------------------------------- */

        /** Opens browser of user choice with url 
        * Allowed browser parameters are Ie,Firefox,Chrome or Safari
        *  @param browser,url
       **/

        public void launchBrowserWithChrome(String browser, String url)
        {
            if (browser == "chrome")
            {
                Driver = new ChromeDriver(@"D:\Software\Selenium\chromedriver_win32");
            }
            else
            {
                throw new Exception("The browser you have choosen is not yet available");
            }

            Driver.Navigate().GoToUrl(url);
        }
        /* -------------------------------------------------------------------------------------------------------------------------------- */

        /** Opens browser of user choice with url 
        * Allowed browser parameters are Ie,Firefox,Chrome or Safari
        *  @param browser,url
       **/

        public void launchBrowserWithUrl(String browser, String url)
        {
            try
            {
                switch (browser.ToLower())
                {
                    case "firefox":
                        Driver = new FirefoxDriver();
                        Driver.Navigate().GoToUrl(url);
                        break;

                    case "chrome":
                        Driver = new ChromeDriver(@"D:\Software\Selenium\chromedriver_win32");
                        Driver.Navigate().GoToUrl(url);
                        break;
                 
                    case "htmlunitdriver":
                        var remoteServer = new Uri("http://localhost:4444/wd/hub/");
                        DesiredCapabilities desiredCapabilities = DesiredCapabilities.HtmlUnit();
                        Driver = new RemoteWebDriver(remoteServer, desiredCapabilities);
                        desiredCapabilities.IsJavaScriptEnabled = true;
                        Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
                        Driver.Navigate().GoToUrl(url);
                        break;
                    default:

                        break;
                }

            }
            catch (Exception e)
            {
                throw new Exception("The browser you have choosen is not yet available");
            }

            Driver.Navigate().GoToUrl(url);
        }

        /* -------------------------------------------------------------------------------------------------------------------------------- */

        /** Opens browser of user choice with url 
        * Allowed browser parameters are Ie,Firefox,Chrome or Safari
        *  @param browser,url
       **/

        public void launchHTMLbrowser(String browser, String url)
        {
            if (browser == "htmlunitdriver")
            {

                var remoteServer = new Uri("http://localhost:4444/wd/hub/");
                DesiredCapabilities desiredCapabilities = DesiredCapabilities.HtmlUnit();
                Driver = new RemoteWebDriver(remoteServer, desiredCapabilities);
                desiredCapabilities.IsJavaScriptEnabled = true;
                Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
            }
            else
            {
                throw new Exception("The browser you have choosen is not yet available");
            }

            Driver.Navigate().GoToUrl(url);
        }

        /* -------------------------------------------------------------------------------------------------------------------------------- */

        /** Opens browser of user choice with url 
        * Allowed browser parameters are Ie,Firefox,Chrome or Safari
        *  @param browser,url
       **/

        public void launchGhostbrowser(String browser, String url)
        {
            if (browser == "Ghostdriver")
            {

                Driver = new PhantomJSDriver(@"D:\Software\Selenium");
            }
            else
            {
                throw new Exception("The browser you have choosen is not yet available");
            }

            Driver.Navigate().GoToUrl(url);
        }

        /* -------------------------------------------------------------------------------------------------------------------------------- */
        public void quitWebDriver()
        {
            Driver.Quit();
        }


        /* -------------------------------------------------------------------------------------------------------------------------------- */
        /** Nnew tab will be created and focus will be switched to new one **/
        public void switchToNewTab()
        {
            Actions builder = new Actions(Driver);
            builder.KeyDown(Keys.Control).SendKeys("t").KeyUp(Keys.Control).Build().Perform();
        }
        /* -------------------------------------------------------------------------------------------------------------------------------- */

        /** Maximizes window **/
        public void maximizeWindow()
        {
            Driver.Manage().Window.Maximize();
        }

        /* -------------------------------------------------------------------------------------------------------------------------------- */

        /** Switching is cyclic from currently activated tab. 1->2->3->1->2->3 like that **/
        public void switchToOtherTab()
        {
            Actions builder = new Actions(Driver);
            builder.KeyDown(Keys.Control).SendKeys(Keys.Tab).KeyUp(Keys.Control).Build().Perform();
        }

        /* -------------------------------------------------------------------------------------------------------------------------------- */

        /** closes currently active tab.If only one tab is there entire window will be closed **/

        public void closeCurrentTab()
        {
            Actions builder = new Actions(Driver);
            builder.KeyDown(Keys.Control).SendKeys("w").KeyUp(Keys.Control).Build().Perform();
        }

        /* -------------------------------------------------------------------------------------------------------------------------------- */

        public void clickTab()
        {
            Actions builder = new Actions(Driver);
            builder.SendKeys(Keys.Tab);
        }

        /* -------------------------------------------------------------------------------------------------------------------------------- */
        /** Pass url to addressbar **/
        public void passUrlToAddressBar(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void mousehoverById(string locatorvalue)
        {
            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
            Actions action = new Actions(Driver);
            IWebElement hover = Driver.FindElement(By.Id(locatorvalue));
            action.MoveToElement(hover).Perform();
        }

        public void mousehoverByXpath(string locatorvalue)
        {
            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
            Actions action = new Actions(Driver);
            IWebElement hover = Driver.FindElement(By.XPath(locatorvalue));
            action.MoveToElement(hover).Perform();
        }

        ///*==================================================================================================================================*/
        //Wait for multiple elements
        public void waitForElement(String locator, String locatorvalue, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            try
            {
                if (timeoutInSeconds > 0)
                {
                    switch (locator.ToLower())
                    {
                        case "classname":
                            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                            System.Threading.Thread.Sleep(1000);
                            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(locatorvalue)));
                            break;
                        case "cssselector":
                            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                            System.Threading.Thread.Sleep(1000);
                            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(locatorvalue)));
                            break;
                        case "id":
                            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                            System.Threading.Thread.Sleep(1000);
                            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locatorvalue)));
                            break;
                        case "linktext":
                            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                            System.Threading.Thread.Sleep(1000);
                            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(locatorvalue)));
                            break;
                        case "name":
                            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                            System.Threading.Thread.Sleep(1000);
                            wait.Until(ExpectedConditions.ElementIsVisible(By.Name(locatorvalue)));

                            break;
                        case "partiallinkText":
                            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                            System.Threading.Thread.Sleep(1000);
                            wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(locatorvalue)));
                            break;
                        case "tagname":
                            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                            System.Threading.Thread.Sleep(1000);
                            wait.Until(ExpectedConditions.ElementIsVisible(By.TagName(locatorvalue)));
                            break;
                        case "xpath":
                            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                            System.Threading.Thread.Sleep(1000);
                            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locatorvalue)));
                            break;
                        default:

                            break;
                    }

                }
            }
            catch (Exception e)
            {
                screeshotmethodcall(locator.ToLower());
                String sMessage = e.Message;
                throw new Exception(" Unable to find Element By Name " + sMessage);
            }
        }

        /*==================================================================================================================================*/


    }
}

