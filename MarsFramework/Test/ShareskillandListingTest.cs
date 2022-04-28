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
    internal class ShareskillandListingTest
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {

            [Test, Order(1)]
            public void a_TestAddShareSkill()
            {

                test = extent.StartTest("Create ShareSkill", "Shareskill");
                ShareSkill shareSkill = new ShareSkill();
                shareSkill.EnterShareSkill();
                Base.test.Log(LogStatus.Pass, "Test Passed,Create - Created the Shareskill successfully");

            }
            [Test, Order(2)]
            public void b_ViewManageShareSkill()
            {
                test = extent.StartTest("View ShareSkill", "Shareskill");
                ManageListings manageListing = new ManageListings();
                manageListing.viewListings();
                string firstskilltitle = manageListing.getfirsttitle();
                Assert.AreEqual(firstskilltitle, "Selenium");
                Base.test.Log(LogStatus.Pass, "TestPassed, Created Shareskill exists to view");
            }

            [Test, Order(3)]
            public void c_editManageShareskill()
            {
                test = extent.StartTest("Update ShareSkill", "Shareskill");
                ManageListings managelistings = new ManageListings();
                managelistings.editListings();
                string firstskilltitle = managelistings.getfirsttitle();
                string expectedtitle = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
                Console.WriteLine("Expected Title" + expectedtitle);
                Assert.AreEqual(expectedtitle, firstskilltitle);
                test.Log(LogStatus.Pass, "Test Passed,Updated the Shareskill Successfully");
            }


            [Test, Order(4)]
            public void d_deleteListings()
            {
                test = extent.StartTest("Delete ShareSkill", "Shareskill");
                ManageListings managelistings = new ManageListings();
                string message = managelistings.deleteListings();
                string actualmessage = managelistings.getpopupmessage();
                Assert.AreEqual(message, actualmessage);
                test.Log(LogStatus.Pass, "Test Passed,Deleted the Shareskill Successfully");
            }
        }
    }
}
