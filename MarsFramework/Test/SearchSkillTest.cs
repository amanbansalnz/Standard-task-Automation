using MarsFramework.Pages;
using NUnit.Framework;
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
        //[Category("Sprint2")]
        class User : Global.Base
        {
            [Test, Order(1)]
            public void editProfiledetails()
            {
                test = extent.StartTest("Update Profile", "Updating profile details");
                SearchSkill searchSkill = new SearchSkill();

            }

        }
    }
}
