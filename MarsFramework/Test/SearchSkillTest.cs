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
    internal class SearchSkillTest
    {
        [TestFixture]
        //[Category("Sprint3")]
        class User : Global.Base
        {
            [Test, Order(1)]
            public void editProfiledetails()
            {
                test = extent.StartTest("Search Skill", "Search Skill");
                SearchSkill searchSkill = new SearchSkill();
                Assert.IsTrue(searchSkill.GetSearchSkilllist());
                test.Log(LogStatus.Pass, "Test Passed,SearchSkill - Searched Skill successfully");

            }

        }
    }
}
