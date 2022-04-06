using NUnit.Framework;
using MarsFramework.Pages;
using System;
using System.Threading.Tasks;
using MarsFramework.Config;

namespace MarsFramework
{
    internal class Profiledetailstest
    {
        [TestFixture]
        //[Category("Sprint2")]
        class User : Global.Base
        {
            [Test,Order(1)]
            public void editProfiledetails()
            {
                test = extent.StartTest("Update Profile", "Updating profile details");
                Profile profile = new Profile();
                profile.EditProfile();
            }

        }




    }
}
