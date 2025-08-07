using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Project_Mars.BaseClass;
using Project_Mars.Pages;
using ProjectMars_Certification_Education.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnupportal2025.Utilities;
using static ProjectMars_Certification_Education.TestData.Certificatetestdata;

namespace Project_Mars.NUnitTests
{
    [Parallelizable]
    [TestFixture]
    [Category("Certification")]

    public class Certification_Tests : BaseTest
    {
        [SetUp]
        public void SetUpSteps()
        {
         
          LoginPage loginPageObj = new LoginPage();
           

            loginPageObj.VerifyUserInHomePage(driver);

            HomeToCertificationsPage homeToCertificationsPageObj = new HomeToCertificationsPage();
            homeToCertificationsPageObj.NavigateToCertifications(driver);
        }
        public static IEnumerable<TestCaseData> GetTestData(string testName)
        {
            var testData = TestDataReader.ReadTestData();
            foreach (var data in testData[testName])
            {
                if (data.NewCertificateAward != null && data.NewCertificateFrom != null && data.NewYear != null)
                {
                    yield return new TestCaseData(data.CertificateAward, data.CertificateFrom, data.Year, data.NewCertificateAward, data.NewCertificateFrom, data.NewYear);
                }
                else if (data.UpdatedCertificateAward != null)
                {
                    yield return new TestCaseData(data.CertificateAward, data.CertificateFrom, data.Year, data.UpdatedCertificateAward);
                }
                else
                {
                    yield return new TestCaseData(data.CertificateAward, data.CertificateFrom, data.Year);
                }
            }
        }
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "CreateValidCertificationRecord" })]
        public void CreateValidCertificationRecord(string certificateAward, string certificateFrom, string year)
        {
            CertificationsPage certificationsPageObj = new CertificationsPage();
            certificationsPageObj.CreateCertificationRecord(driver, certificateAward, certificateFrom, year);
            IWebElement newcertificateaward = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement newcertificatefrom = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[2]"));
            IWebElement newyear = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[3]"));
            if (newcertificateaward.Text == certificateAward && newcertificatefrom.Text == certificateFrom && newyear.Text == year)
            {
                Assert.Pass("record created successfully");
            }
            else
            {
                Assert.Fail("record creation unsuccessful");
            }
        }
        
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "TryToCreateCertificationRecordWithBlankField" })]
        public void TryToCreateCertificationRecordWithBlankField(string certificateaward, string certificatefrom, string year)
        {
            CertificationsPage certificationsPageObj = new CertificationsPage();
            certificationsPageObj.CreateCertificationRecord(driver, certificateaward, certificatefrom, year);
            IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']"));
            
            if (popupAlert.Text == "Please enter Certification Name, Certification From and Certification Year")
            {
                Assert.Pass("Blank field record not accepted and Popup message says Please enter Certification Name, Certification From and Certification Year");
            }
            else
            {
                Assert.Fail("Blank field record is accepted and no popup message appears");
            }

        }

        
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "CreateInvalidCertificationRecord" })]
        public void CreateInvalidCertificationRecord(string certificateaward, string certificatefrom, string year)
        {
            CertificationsPage certificationsPageObj = new CertificationsPage();
            certificationsPageObj.CreateCertificationRecord(driver, certificateaward, certificatefrom, year);
            IWebElement newcertificateaward = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement newcertificatefrom = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[2]"));
          
            if (newcertificateaward.Text == certificateaward && newcertificatefrom.Text == certificatefrom)
            {
                Assert.Pass("Invalid record accepted error in the system");
            }
            else
            {
                Assert.Fail("Invalid record not accepted no error in the system");
            }
        }
        
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "CreateDuplicateCertificationRecord" })]
        public void CreateDuplicateCertificationRecord(string certificateaward, string certificatefrom, string year)

        {
            CertificationsPage certificationsPageObj = new CertificationsPage();
            certificationsPageObj.CreateCertificationRecord(driver, certificateaward, certificatefrom, year);
            IWebElement newcertificateaward = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement newcertificatefrom = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[2]"));
            IWebElement newyear = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[3]"));
            if (newcertificateaward.Text == certificateaward && newcertificatefrom.Text == certificatefrom && newyear.Text == year)
            {
                Console.WriteLine("record created successfully");
            }
            else
            {
                Console.WriteLine("record creation unsuccessful");
            }

            certificationsPageObj.CreateCertificationRecord(driver, certificateaward, certificatefrom, year);
            IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']"));
            if (popupAlert.Text == "This information is already exist.")
            {
                Assert.Pass("Duplicate record not accepted");
            }
            else
            {
                Assert.Fail("Duplicate record accepted");
            }
        }
        
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "EditExistingCertificationRecord" })]
        public void EditExistingCertificationRecord(string certificateaward, string certificatefrom, string year, string newcertificateaward, string newcertificatefrom, string newyear)
        {
            CertificationsPage certificationsPageObj = new CertificationsPage();
            certificationsPageObj.CreateCertificationRecord(driver, certificateaward, certificatefrom, year);
            IWebElement createdcertificateaward = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement createdcertificatefrom = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[2]"));
            IWebElement createdyear = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[3]"));
            if (createdcertificateaward.Text == certificateaward && createdcertificatefrom.Text == certificatefrom && createdyear.Text == year)
            {
                Console.WriteLine("record created successfully");
            }
            else
            {
                Console.WriteLine("record creation unsuccessful");
            }
            
            certificationsPageObj.EditCertificationRecord(driver, newcertificateaward, newcertificatefrom, newyear);
            IWebElement editedcertificateaward = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement editedcertificatefrom = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[2]"));
            IWebElement editedyear = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[3]"));
            if (editedcertificateaward.Text == newcertificateaward &&  editedcertificatefrom.Text == newcertificatefrom && editedyear.Text == newyear)
            {
                Assert.Pass("record edited successfully");
            }
            else
            {
                Assert.Fail("record not edited");
            }
        }
        
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "Cancelinganeditoperationcorrectlydiscardschanges" })]
        public void Cancelinganeditoperationcorrectlydiscardschanges(string certificateaward, string certificatefrom, string year, string updatedcertificateaward)
        {
            CertificationsPage certificationsPageObj = new CertificationsPage();
            certificationsPageObj.CreateCertificationRecord(driver, certificateaward, certificatefrom, year);
            IWebElement newcertificateaward = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement newcertificatefrom = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[2]"));
            IWebElement newyear = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[3]"));
            if (newcertificateaward.Text == certificateaward && newcertificatefrom.Text == certificatefrom && newyear.Text == year)
            {
                Console.WriteLine("record created successfully");
            }
            else
            {
                Console.WriteLine("record creation unsuccessful");
            }
            certificationsPageObj.CancelEditOperation(driver, updatedcertificateaward);
            IWebElement Certificateaward = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]"));
            if (Certificateaward.Text == updatedcertificateaward)
            {
                Assert.Pass("Canceling an edit operation should correctly discards changes and Subsequent edits respect the cancellation and do not save unexpected changes. No system is not doing this");
            }
            else
            {
                Assert.Fail("Canceling an edit operation should correctly discards changes and Subsequent edits respect the cancellation and do not save unexpected changes. Yes system is not doing this");
            }
        }

        [Test, TestCaseSource(nameof(GetTestData), new object[] { "DeleteCertificationRecord" })]
        public void DeleteCertificationRecord(string certificateaward, string certificatefrom, string year)
        {
            CertificationsPage certificationsPageObj = new CertificationsPage();
            certificationsPageObj.CreateCertificationRecord(driver, certificateaward, certificatefrom, year);
            IWebElement newcertificateaward = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement newcertificatefrom = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[2]"));
            IWebElement newyear = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[3]"));
            if (newcertificateaward.Text == certificateaward && newcertificatefrom.Text == certificatefrom && newyear.Text == year)
            {
                Console.WriteLine("record created successfully");
            }
            else
            {
                Console.WriteLine("record creation unsuccessful");
            }
            certificationsPageObj.DeleteCertificationRecord(driver);
            bool testPassed = false;
            try
            {
                Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 4);
                IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
                string alertText = popupAlert.Text;
                Console.WriteLine("Alert text: " + alertText);
                testPassed = true;
               

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
               
            }
            if (testPassed)
            {
                Assert.Pass("Test pass");
            }
            else
            {
                Assert.Fail("Test failed");
            }


            
        }
        
    }
}
