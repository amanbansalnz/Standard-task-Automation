using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MarsFramework.Pages
{
    class SignIn 
    {
        public SignIn()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign')]")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        internal void LoginSteps()
        {
           
            ////passing the value directly
            //GlobalDefinitions.driver.Navigate().GoToUrl("http://localhost:5000/");
            //SignIntab.Click();
            //Email.SendKeys("abcd@gmail.com");
            //Password.SendKeys("abcd");
            //LoginBtn.Click();

            GlobalDefinitions.driver.Navigate().GoToUrl("http://localhost:5000/");
            SignIntab.Click();
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Username"));
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));
            LoginBtn.Click();

        }
    }
}