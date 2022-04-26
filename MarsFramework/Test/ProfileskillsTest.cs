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
    internal class ProfileskillsTest
    {
        [TestFixture]
        //[Category("Sprint2")]
        class User : Global.Base
        {
            [Test, Order(1)]
            public void Addnewskills()
            {
                //Test for adding a  new skill successfully
                test = extent.StartTest(" Add new Skill ", "testing Skills ");
                ProfileSkills profileSkillobj = new ProfileSkills();
                profileSkillobj.AddSkill();
                string actualskillmessage = profileSkillobj.skillmessage();
                string expectedSkill = GlobalDefinitions.ExcelLib.ReadData(2, "Skill");
                string expectedSkillmessage = expectedSkill + " has been added to your skills";
                Assert.AreEqual(expectedSkillmessage, actualskillmessage);
                test.Log(LogStatus.Pass, "Test Passed, Skills created");
            }
            [Test, Order(2)]
            public void Addskills()
            {
                //Test for message when adding an existing skill
                test = extent.StartTest(" Add new Skill ", "testing Skills ");
                ProfileSkills profileSkillobj = new ProfileSkills();
                profileSkillobj.AddSkill();
                string actualskillmessage = profileSkillobj.skillmessage();
                string expectedSkillmessage = "This skill is already exist in your skill list.";
                Assert.AreEqual(expectedSkillmessage, actualskillmessage);
                test.Log(LogStatus.Pass, "Test Passed, Skills Already Exists message");
            }


        }
    }
}
