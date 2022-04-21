using MarsFramework.Config;
using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;
using static NUnit.Core.NUnitFramework;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
       
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
            
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }
        //[FindsBy(How = How.XPath, Using = "//*[@id=service-detail-section']/section[1]/div/a[3]")]
        //private IWebElement manageListingsLink { get; set; }

        //View the listing                 
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[1]/i")]
        private IWebElement view { get; set; }

        //view firstrecord
        [FindsBy(How = How.XPath, Using = "(//i[@class='skill-title'])[1]")]
        private IWebElement firstRecord { get; set; }

        ////Firstskilltitle
        //[FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[1]/div/div/div/div")]
        //private IWebElement firstSkilltitle{ get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//table[1]/tbody[1]")]
        private IWebElement delete { get; set; }

        //Delete button of the first record in the Listing
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i")]
        private IWebElement deletetherecord { get; set; } 

        //YES button to delete
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[3]/button[2]")]
        private IWebElement yes { get; set; }    


        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }
        // first title
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[3]")]
        private IWebElement firstSkilltitle { get; set; }

        internal void viewListings()
        {
            GlobalDefinitions.wait(2);
            //Click on ManageListing tab
            manageListingsLink.Click();
            GlobalDefinitions.wait(3);
            Thread.Sleep(2000);
            view.Click();            
        }
        public string getfirsttitle()
        {
            manageListingsLink.Click();
            //GlobalDefinitions.wait(3);
            //view.Click();
            //GlobalDefinitions.wait(3);
            ////firstSkilltitle.Click();
            //return firstSkilltitle.Text;
            //*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[3]
            //*[@id="listing-management-section"]/div[2]/div[1]/div[1]/table/tbody/tr/td[3]
            Thread.Sleep(2000);
            Console.WriteLine("Actual title" + firstSkilltitle.Text);
            return firstSkilltitle.Text;
           
        }
        public void editListings()
        {
            Thread.Sleep(2000);
            manageListingsLink.Click();
            //GlobalDefinitions.wait(2);
            Thread.Sleep(2000);
            edit.Click();
            ShareSkill shareSkill = new ShareSkill();
            shareSkill.EditShareSkill();
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "EditShareSkill");
            GlobalDefinitions.wait(2);

            //string expectedtitle = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
            //Console.WriteLine("Expected Title" + expectedtitle);
           // return firstSkilltitle.Text;
           

        }
        public string deleteListings()
        {
            GlobalDefinitions.wait(2);
            manageListingsLink.Click();
            GlobalDefinitions.wait(2);
            deletetherecord.Click();
            yes.Click();
            GlobalDefinitions.wait(2);
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "EditShareSkill");
            //GlobalDefinitions.wait(1);
            GlobalDefinitions.wait(2);
            string expectedtitle = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
            string expectedmessage = expectedtitle + " has been deleted";
            return expectedmessage;

        }
        public string getpopupmessage()
        {
            //Deleted message
            String message = GlobalDefinitions.driver.FindElement(By.XPath(@"//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']")).Text;
            return message;
        }
    }
}


