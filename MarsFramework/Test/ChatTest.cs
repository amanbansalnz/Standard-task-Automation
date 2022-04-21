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
    internal class ChatTest
    {
        [TestFixture]
        //[Category("Sprint2")]
        class User : Global.Base
        {
            [Test, Order(1)]
            public void editProfiledetails()
            {
                test = extent.StartTest(" Chats ", "testing chat ");
                Chat chatobj = new Chat();
                chatobj.sendmessage();
                test.Log(LogStatus.Pass, "Test Passed, Chats created");

            }

        }
    }
}
