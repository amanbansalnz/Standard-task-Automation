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
    internal class SearchSkill
    {
        public SearchSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Identify the element search box
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[1]/i")]
        private IWebElement Searchbutton { get; set; }
        //Identify the search textbox
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[2]/input")]
        private IWebElement Searchtextbox { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id=service-search-section']/div[2]/div/section/div/div[1]/div[2]/i")]
        private IWebElement Searchbuttonno2 { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[1]/div[1]")]
        //private IWebElement Searchtextbox1 { get; set; }


        //Identify the element Allcategories
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[1]/b")]
        private IWebElement Allcategorieslink { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div")]
        private IWebElement SearchResults { get; set; }//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]
        //Search results
        //[FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div/label/em")]
        //private IWebElement SearchResults { get; set; }

        public bool GetSearchSkilllist()
        {
            Thread.Sleep(5000);
            //WaitForElement(Driver.driver, By.XPath(“//a[contains(.,’Room Settings’)]”), 20);
            //GlobalDefinitions.WaitToBeVisible(GlobalDefinitions.driver, "XPath" ,"//*[@id='account-profile-section']/div/div[1]/div[1]/input", 3);
            Searchbutton.Click();
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SearchSkill");
            Thread.Sleep(2000);
            Searchtextbox.Click();
            Searchtextbox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Search"));
            Searchtextbox.SendKeys(Keys.Enter);
            //Allcategorieslink.Click();
            //String bodyText = driver.FindElement(By.TagName("body")).Text;
            //Assert.True(bodyText.Contains(F1), "Text not found!");
            //Thread.Sleep(3000);
            GlobalDefinitions.wait(3);
            //GlobalDefinitions.WaitToBeVisible(GlobalDefinitions.driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div", 3);
            string bodytext = SearchResults.Text;
            if (bodytext.Contains(GlobalDefinitions.ExcelLib.ReadData(2, "Search")))
            { 
                return true;
            }
            else
            {
                return false;
            }
            
            
            
        }
     
    }
}
