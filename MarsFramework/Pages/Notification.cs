using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    internal class Notification
    {
        public Notification()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
        }
        
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/div")]
        private IWebElement clickNotification { get; set; }

        [FindsBy(How = How.XPath, Using = " //*[@id='account-profile-section']/div/div[1]/div[2]/div/div/div/span/div")]
        private IWebElement notoficationmessage { get; set; }
       
        public string notifications()
        {
            GlobalDefinitions.wait(3);
            clickNotification.Click();
            Thread.Sleep(3000);
            string actualmessage = notoficationmessage.Text;
            return actualmessage;
        }

    }
}
