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
    internal class Chat
    {
        public Chat()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
        }
        //Identify the element chat
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/a[1]")]
        private IWebElement chatbutton { get; set; }
        
        //Identify the element chat textbox
        [FindsBy(How = How.XPath, Using = "//*[@id='chatTextBox']")]
        private IWebElement chatextbox { get; set; }

        //Identify the send button
        [FindsBy(How = How.XPath, Using = "//*[@id='btnSend']")]
        private IWebElement sendbutton { get; set; }

        //Identify the last chat been sent
        [FindsBy(How = How.XPath, Using = "//*[@id='left']/div/span")]
        private IWebElement searchchat { get; set; }

        public string sendmessage()
        {
            GlobalDefinitions.WaitforElement(3);
            chatbutton.Click();
            GlobalDefinitions.WaitforElement(3);
            chatextbox.Click();
            chatextbox.SendKeys("Hello");
            sendbutton.Click();
            string lastchatmessage = searchchat.Text;
            return lastchatmessage;


        }
    }
}
