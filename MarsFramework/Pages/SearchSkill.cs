using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[1]/div[1]/input")]
        private IWebElement Searchtextbox { get; set; }
        //Identify the element Allcategories
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[1]/b")]
        private IWebElement Allcategorieslink { get; set; }

        public void searchSkill()
        {
            Searchtextbox.Click();
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SearchSkill");
            Searchtextbox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Search"));
            Allcategorieslink.Click();

        }
     
    }
}
