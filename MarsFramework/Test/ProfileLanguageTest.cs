using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Test
{
    internal class ProfileLanguageTest
    {
        [TestFixture]
        //[Category("Sprint2")]
        class User : Global.Base
        {
            [Test, Order(1)]
            public void ProfileLanguagecreate()
            {
              
                test = extent.StartTest(" ProfileLanguage  ", "Create ");
                ProfileLanguage profileLanguageObj = new ProfileLanguage();
                profileLanguageObj.CreateNewLanguage();
                string actualmessage = profileLanguageObj.validatecreatedLanguage();
                string expectedlanguage = GlobalDefinitions.ExcelLib.ReadData(2, "Language");
                string expectedmessage = expectedlanguage + " has been added to your languages";
                Assert.AreEqual(expectedmessage, actualmessage);
                test.Log(LogStatus.Pass, "Test Passed, Language created");
              
                
            }
            [Test,Order(2)]
            public void ProfileLanguageEdit()
            {
                test = extent.StartTest(" ProfileLanguage  ", "Edit ");
                ProfileLanguage profileLanguageObj = new ProfileLanguage();
                profileLanguageObj.UpdateLanguage();
                string actualmessage = profileLanguageObj.validatecreatedLanguage();
                string expectedlanguage = GlobalDefinitions.ExcelLib.ReadData(3, "Language");
                string expectedmessage = expectedlanguage + " has been updated to your languages";
                Assert.AreEqual(expectedmessage, actualmessage);
                test.Log(LogStatus.Pass, "Test Passed, Language Updated");

            }
            [Test,Order(3)]
            public void ProfileLanguageDelete()
            {
                test = extent.StartTest(" ProfileLanguage  ", "Edit ");
                ProfileLanguage profileLanguageObj = new ProfileLanguage();
                profileLanguageObj.DeleteLanguage();
                string actualdeletedmessage = profileLanguageObj.ValidateDeletedRecord();
                string expectedlanguage = GlobalDefinitions.ExcelLib.ReadData(3, "Language");
                string expectedmessage = expectedlanguage + " has been deleted from your languages";
                Assert.AreEqual(expectedmessage, actualdeletedmessage);
                test.Log(LogStatus.Pass, "Test Passed, Language Deleted");


            }

        }
    }
}
