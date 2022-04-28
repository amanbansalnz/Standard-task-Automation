using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    internal class ProfileSkills
    {
        public ProfileSkills()
        {
            PageFactory.InitElements(GlobalDefinitions.driver,this);
        }

        //Identify Skills Tab
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")]
        private IWebElement SkillsTab { get; set; }

        //Identify AddNew button on Skills Tab
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")]
        private IWebElement AddNewSkillBtn { get; set; }

        //Identify  SkillTextBox
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input")]
        private IWebElement SkillTextBox { get; set; }

        //Identify SkillLevel Dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select")]
        private IWebElement SkillLevel { get; set; }

        //Identify Add button on Skill Tab
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]")]
        private IWebElement AddSkillButton { get; set; }

        //Identify Skill from the table list
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]")]
        private IWebElement FirstSkill { get; set; }


        //Identify  SkillLevel 
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[2]")]
        private IWebElement FirstSkillLevel { get; set; }

        //Identify the message
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div")]
        private IWebElement Skillsaddedmeesage { get; set; }

        public void AddSkill()
        {
            Thread.Sleep(3000);
            SkillsTab.Click();
            AddNewSkillBtn.Click();

            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Skills");

            //ReadData fromExcelsheet
            SkillTextBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill"));

            //Readdata from excelsheet for dropdown skilllevel
            SelectElement skilllevels = new SelectElement(SkillLevel);
            skilllevels.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Level"));
            AddSkillButton.Click();
        }
        public string skillmessage()
        {
            Thread.Sleep(2000);
            Console.WriteLine(Skillsaddedmeesage.Text);
            return Skillsaddedmeesage.Text;
        }
        public string GetSkill()
        {
            Thread.Sleep(1000);
            return FirstSkill.Text;
        }

        public string GetSkillLevel()
        {
            Thread.Sleep(1000);
            return FirstSkillLevel.Text;
        }

    }
}
