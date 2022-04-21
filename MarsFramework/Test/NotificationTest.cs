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
    internal class NotificationTest
    {
        [TestFixture]
        //[Category("Sprint2")]
        class User : Global.Base
        {
            [Test, Order(1)]
            public void notificationview()
            {
                //Testing for no notification message 
                test = extent.StartTest(" Notification ", "testing Notoficatios ");
                Notification notificationObj = new Notification();
                string message = notificationObj.notifications();
                string expectedMessage = "You have no notifications";
                Assert.AreEqual(expectedMessage, message);
                test.Log(LogStatus.Pass, "Test Passed, You have no notifications!");

            }
        }
    }
}
