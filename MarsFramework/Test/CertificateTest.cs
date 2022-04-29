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
    internal class CertificateTest
    {
        [TestFixture]
        class User : Global.Base
        {
            [Test, Order(1)]
            public void AddCertification()
            {
                try
                {
                    test = extent.StartTest(" Certification ", "testing  ADD Certification ");
                    Certificate certificateObj = new Certificate();
                    certificateObj.AddNewCertification(2);
                    string actualmessage = certificateObj.getcertimessage();
                    string certificate = GlobalDefinitions.ExcelLib.ReadData(2, "Certificate");
                    string expectedmessage = certificate + " has been added to your certification";
                    Assert.AreEqual(expectedmessage, actualmessage);
                    test.Log(LogStatus.Pass, "Test Passed, Certification created");

                }
                catch (Exception ex)
                {
                    test.Log(LogStatus.Fail, "Test Fail, Certification  not created");
                }
            }
            [Test, Order(2)]
            public void Certificationduplicate()
            {
                try
                {
                    test = extent.StartTest(" Certification ", "testing Certification Duplication  ");
                    Certificate certificateObj = new Certificate();
                    certificateObj.AddNewCertification(2);
                    string actualmessage = certificateObj.getcertimessage();
                    string expectedmessage = "This information is already exist.";
                    Assert.AreEqual(expectedmessage, actualmessage);
                    test.Log(LogStatus.Pass, "Test Passed, Duplicate certification cannot be created");

                }
                catch (Exception ex)
                {
                    test.Log(LogStatus.Fail, "Test Fail,Duplicate data");
                }

            }

            [Test, Order(3)]
            public void CertIncompletevalues()
            {
                try
                {
                    test = extent.StartTest(" Certification ", "testing Certification with Incomplete values  ");
                    Certificate certificateObj = new Certificate();
                    certificateObj.IncompleteCertification(5);
                    string actualmessage = certificateObj.getcertimessage();
                    string expectedmessage = "Please enter Certification Name, Certification From and Certification Year";
                    Assert.AreEqual(expectedmessage, actualmessage);
                    test.Log(LogStatus.Pass, "Test Passed, Certification cannot be created with Incomplete Information");

                }
                catch (Exception ex)
                {
                    test.Log(LogStatus.Fail, "Test Fail");
                }

            }

            [Test, Order(4)]
            public void UpdateCertification()
            {
                try
                {
                    test = extent.StartTest(" Certification ", "testing  ADD Certification ");
                    Certificate certificateObj = new Certificate();
                    certificateObj.UpdateCertification(3);
                    string actualmessage = certificateObj.getcertimessage();
                    string certificate = GlobalDefinitions.ExcelLib.ReadData(3, "Certificate");
                    string expectedmessage = certificate + " has been updated to your certification";
                    Assert.AreEqual(expectedmessage, actualmessage);
                    test.Log(LogStatus.Pass, "Test Passed, Certification Updated");

                }
                catch (Exception ex)
                {
                    test.Log(LogStatus.Fail, "Test Fail, Certification Updated not verified");
                }
            }

            [Test, Order(5)]
            public void DeleteCertification()
            {
                try
                {
                    test = extent.StartTest(" Certification ", "testing Delete Certification ");
                    Certificate certificateObj = new Certificate();
                    certificateObj.DeleteCertification();
                    string actualmessage = certificateObj.getcertimessage();
                    string certificate = GlobalDefinitions.ExcelLib.ReadData(3, "Certificate");
                    string expectedmessage = certificate + " has been deleted from your certification";
                    Assert.AreEqual(expectedmessage, actualmessage);
                    test.Log(LogStatus.Pass, "Test Passed, Certification Deleted");

                }
                catch (Exception ex)
                {
                    test.Log(LogStatus.Fail, "Test Fail, Deletion not verified");
                }

            }


        }

    }
}
