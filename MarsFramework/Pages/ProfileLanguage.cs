using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    internal class ProfileLanguage
    {
        public ProfileLanguage()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
        }
        //Identify the element addlanguage button
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")]
        private  IWebElement addNewLanguage { get; set; }

        //Identify the textbox addlanguage
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")]
        private IWebElement addlanguagetextbox { get; set; }

        //Identify the dropdown Chooselanguagelevel
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select")]
        private IWebElement languageleveldropdown { get; set; }

        //Identify the element add button after inputing values
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")]
        private IWebElement Clickadd { get; set; }

        //Identify the total tablerows
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody")]
        private IWebElement rowelements { get; set; }

        //Identify the created message
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div")]
        private IWebElement message { get; set; }

        //Identify the user profile tab
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span")]
        private IWebElement userprofile { get; set; }
        
        //Identify the edit button
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]")]
        private IWebElement editbutton { get; set; }

        //Identify the record to edit
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[1]/input")]
        private IWebElement firstrecord { get; set; }

        //Identify the language level dropdown
        [FindsBy(How = How.XPath, Using = "//*[@name='level']")]
        private IWebElement chooselanguagelevel { get; set; }
 
        //Identify the update button
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]")]
        private IWebElement updatebutton { get; set; }

        //Identify the delete button
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i")]
        private IWebElement deletebutton { get; set; }

        //Deleted message
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div")]
        private IWebElement deletedmessage { get; set; }


        public void CreateNewLanguage()
        {
            try
            {
                // GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                GlobalDefinitions.WaitforElement(20);       
                addNewLanguage.Click();
                addlanguagetextbox.Click();
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfileLanguage");
                addlanguagetextbox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Language"));
                languageleveldropdown.Click();
                SelectElement levels = new SelectElement(languageleveldropdown);
                levels.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Level"));
                Clickadd.Click();
            }
            catch (Exception e)
            {
               Base.test.Log(LogStatus.Fail, "Test Failed-catch", e.Message);
            }
            
        }
        public string validatecreatedLanguage()
        {
            Thread.Sleep(2000);
            string successmessage = message.Text;
            return successmessage;
        }
        public void UpdateLanguage()
        {
            GlobalDefinitions.WaitforElement(20);
            userprofile.Click();
            GlobalDefinitions.WaitforElement(20);
            editbutton.Click();
            GlobalDefinitions.WaitforElement(20);
            firstrecord.Clear();
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfileLanguage");
            firstrecord.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Language"));
            SelectElement level = new SelectElement(chooselanguagelevel);
            level.SelectByText(GlobalDefinitions.ExcelLib.ReadData(3,"Level"));
            updatebutton.Click();
        }
        public void DeleteLanguage()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfileLanguage");
            GlobalDefinitions.WaitforElement(20);
            deletebutton.Click();
        }
        public string ValidateDeletedRecord()
        {
            Thread.Sleep(2000); 
            //GlobalDefinitions.WaitToBeVisible(GlobalDefinitions.driver, "XPath", "/html/body/div[1]/div", 10000);
            string deletemessage = deletedmessage.Text;
            Console.WriteLine(deletemessage);
            return deletemessage;

        }

    }
}
