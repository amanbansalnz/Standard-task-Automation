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
    internal class Certificate
    {
        public Certificate()
        {
            PageFactory.InitElements(GlobalDefinitions.driver,this);
        }

        //Identify the tab Certification
        [FindsBy( How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]")]
        private IWebElement certificationTab { get; set; }

        //Identify the Addnew button
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div")]
        private IWebElement Addnew { get; set; }

        //Identify the textbox Certification
        [FindsBy(How = How.Name, Using = "certificationName")]
        private IWebElement CertificateTextbox { get; set; }

        //Identify the textbox certification from
        [FindsBy(How = How.Name, Using = "certificationFrom")]
        private IWebElement CertificationFrom { get; set; }

        //Identify the element  year from drop down
        [FindsBy(How = How.Name, Using = "certificationYear")]
        private IWebElement Yeardropdown { get; set; }

        //Identify the add button
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]")]
        private IWebElement AddButton { get; set; }

        //Edit certification
        //Certification to edit
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]")]
        private IWebElement CertiToSel { get; set; }

        //Click on edit certification button
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[1]/i")]
        private IWebElement EditCertiBtn { get; set; }

        //Click on update certification
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]")]
        private IWebElement Updatebutton { get; set; }

        //Delete Action
        //Delete Certification
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[2]")]
        private IWebElement DeleteButton { get; set; }//*[@id="account-profile-section"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]/i

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div")]
        private IWebElement message { get; set; }

        public void AddNewCertification(int row)
        {
            GlobalDefinitions.WaitforElement(4);
            certificationTab.Click();
            Addnew.Click();
            Certificationrecord(row);
            AddButton.Click();
            //CertificateTextbox.Click();
            //GlobalDefinitions.WaitforElement(4);
            //GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Certificate");
            //CertificateTextbox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(row, "Certificate"));
            //CertificationFrom.SendKeys(GlobalDefinitions.ExcelLib.ReadData(row, "CertifiedFrom"));
            //SelectElement years = new SelectElement(Yeardropdown);
            //years.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Year"));
            //AddButton.Click();
        }
        public void UpdateCertification(int row)
        {
            GlobalDefinitions.WaitforElement(4);
            certificationTab.Click();
            EditCertiBtn.Click();
            Certificationrecord(row);
            Updatebutton.Click();
        }
        public void Certificationrecord(int row)
        {
            CertificateTextbox.Click();
            GlobalDefinitions.WaitforElement(4);
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Certificate");
            CertificateTextbox.Clear();
            CertificateTextbox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(row, "Certificate"));
            CertificationFrom.Clear();
            CertificationFrom.SendKeys(GlobalDefinitions.ExcelLib.ReadData(row, "CertifiedFrom"));
            SelectElement years = new SelectElement(Yeardropdown);
            years.SelectByText(GlobalDefinitions.ExcelLib.ReadData(row, "Year"));
        }
        public void DeleteCertification()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Certificate");
            GlobalDefinitions.WaitforElement(5);
            certificationTab.Click();
            GlobalDefinitions.WaitforElement(4);
            DeleteButton.Click();
        }
        
           
        public string getcertimessage()
        {
            Thread.Sleep(3000);
            string certificatemessage = message.Text;
            Console.WriteLine(certificatemessage);
            return certificatemessage;
        }


    }

}
