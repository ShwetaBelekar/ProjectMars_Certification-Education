using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi;
using OpenQA.Selenium.Chrome;
using Project_Mars.BaseClass;
using Project_Mars.Pages;
using Project_Mars.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnupportal2025.Utilities;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using static ProjectMars_Certification_Education.TestData.Educationtestdata;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project_Mars.NUnitTests
{
    [Parallelizable]
    [TestFixture]
    [Category("Education")]
    public class Education_Tests : BaseTest
    {

        [SetUp]
        public void SetUpSteps()
        {
            LoginPage loginPageObj = new LoginPage();
           

            loginPageObj.VerifyUserInHomePage(driver);

            HomeToEducationPage homeToEducationPageObj = new HomeToEducationPage();
            homeToEducationPageObj.NavigateToEducation(driver);
        }
        public static IEnumerable<TestCaseData> GetTestData(string testName)
        {
            var testData = TestDataReader.ReadTestData();
            foreach (var data in testData[testName])
            {
                if (data.NewCollegeUniversityName != null && data.NewCountryOfCollegeUniversity != null && data.NewTitle != null && data.NewDegree != null && data.NewYearOfGraduation != null)
                {
                    yield return new TestCaseData(data.CollegeUniversityName, data.CountryOfCollegeUniversity, data.Title, data.Degree, data.YearOfGraduation, data.NewCollegeUniversityName, data.NewCountryOfCollegeUniversity, data.NewTitle, data.NewDegree, data.NewYearOfGraduation);
                }
                else if (data.NewTitle != null)
                {
                    yield return new TestCaseData(data.CollegeUniversityName, data.CountryOfCollegeUniversity, data.Title, data.Degree, data.YearOfGraduation, data.NewTitle);
                }
                else
                {
                    yield return new TestCaseData(data.CollegeUniversityName, data.CountryOfCollegeUniversity, data.Title, data.Degree, data.YearOfGraduation);
                }
            }
        }
        
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "CreateValidEducationRecord" })]
        public void CreateValidEducationRecord(string collegeUniversityName, string countryOfCollegeUniversity, string title, string degree, string yearOfGraduation)
        {
            EducationPage educationPageObj = new EducationPage();
            educationPageObj.CreateEducationRecord(driver, collegeUniversityName, countryOfCollegeUniversity, title, degree, yearOfGraduation);
            IWebElement newuniversity = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
            IWebElement newcountry = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement newtitle = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[3]"));
            IWebElement newdegree = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[4]"));
            IWebElement newgraduationyear = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[5]"));
            if (newuniversity.Text == collegeUniversityName && newcountry.Text == countryOfCollegeUniversity && newtitle.Text == title && newdegree.Text == degree && newgraduationyear.Text == yearOfGraduation)
            {
                Assert.Pass("record created successfully");
            }
            else
            {
                Assert.Fail("record creation unsuccessful");
            }
        }
        
        
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "TryToCreateEducationRecordWithBlankField" })]
        public void TryToCreateEducationRecordWithBlankField(string collegeUniversityName, string countryOfCollegeUniversity, string title, string degree, string yearOfGraduation)
        {
            EducationPage educationPageObj = new EducationPage();
            educationPageObj.CreateEducationRecord(driver, collegeUniversityName, countryOfCollegeUniversity, title, degree, yearOfGraduation);
            IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']"));
            
            if (popupAlert.Text == "Please enter all the fields")
            {
                Assert.Pass("Blank field record not accepted and Popup message says please enter all fields");
            }
            else
            {
                Assert.Fail("Blank field record is accepted and no popup message appears");
            }

        }
       
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "CreateInvalidEducationRecord" })]
        public void CreateInvalidEducationRecord(string collegeUniversityName, string countryOfCollegeUniversity, string title, string degree, string yearOfGraduation)
        {
            EducationPage educationPageObj = new EducationPage();
            educationPageObj.CreateEducationRecord(driver, collegeUniversityName, countryOfCollegeUniversity, title, degree, yearOfGraduation);
            IWebElement newuniversity = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
            IWebElement newdegree = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[4]"));
            if (newuniversity.Text == collegeUniversityName &&  newdegree.Text == degree)
            {
                Assert.Pass("Invalid record accepted error in the system");
            }
            else
            {
                Assert.Fail("Invalid record not accepted no error in the system");
            }
        }
        

        [Test, TestCaseSource(nameof(GetTestData), new object[] { "CreateDuplicateEducationRecord" })]
        public void CreateDuplicateEducationRecord(string collegeUniversityName, string countryOfCollegeUniversity, string title, string degree, string yearOfGraduation)
      
        {
            EducationPage educationPageObj = new EducationPage();
            educationPageObj.CreateEducationRecord(driver, collegeUniversityName, countryOfCollegeUniversity, title, degree, yearOfGraduation);
            IWebElement newuniversity = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
            IWebElement newcountry = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement newtitle = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[3]"));
            IWebElement newdegree = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[4]"));
            IWebElement newgraduationyear = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[5]"));
            
            if (newuniversity.Text == collegeUniversityName && newcountry.Text == countryOfCollegeUniversity && newtitle.Text == title && newdegree.Text == degree && newgraduationyear.Text == yearOfGraduation)
            {
                Console.WriteLine("record created successfully");
            }
            else
            {
                Console.WriteLine("record creation unsuccessful");
            }
            
            educationPageObj.CreateEducationRecord(driver, collegeUniversityName, countryOfCollegeUniversity, title, degree, yearOfGraduation);
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
        [Test]
        public void TitleDropdownButtonNotWorkingAsExpected()
        {
            EducationPage educationPageObj = new EducationPage();
            educationPageObj.CheckTitleDropdownButton(driver);
            IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            if(popupAlert.Text == "Education has been added")
            {
                Console.WriteLine("Record accepted");
            }
            else
            {
                Console.WriteLine("Record not accepted");
            }
            IWebElement title = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[3]"));
            if (title.Text == "0")
            {
                Assert.Pass("system accepts this education record there is a defect in title dropdown button");
            }
            else
            {
                Assert.Fail("system didn't accepts this education record");
            }
        }
        
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "EditExistingEducationRecord" })]
        public void EditExistingEducationRecord(string collegeUniversityName, string countryOfCollegeUniversity, string title, string degree, string yearOfGraduation, string newcollegeUniversityName, string newcountryOfCollegeUniversity, string newtitle, string newdegree, string newyearOfGraduation)
        {
            EducationPage educationPageObj = new EducationPage();
            educationPageObj.CreateEducationRecord(driver, collegeUniversityName, countryOfCollegeUniversity, title, degree, yearOfGraduation);
            IWebElement createduniversity = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
            IWebElement createdcountry = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement createdtitle = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[3]"));
            IWebElement createddegree = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[4]"));
            IWebElement createdgraduationyear = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[5]"));
            if (createduniversity.Text == collegeUniversityName && createdcountry.Text == countryOfCollegeUniversity && createdtitle.Text == title && createddegree.Text == degree && createdgraduationyear.Text == yearOfGraduation)
            {
                Console.WriteLine("record created successfully");
            }
            else
            {
                Console.WriteLine("record creation unsuccessful");
            }
            educationPageObj.EditEducationRecord(driver,newcollegeUniversityName,newcountryOfCollegeUniversity,newtitle,newdegree,newyearOfGraduation);
            IWebElement editeduniversity = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
            IWebElement editedcountry = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement editedtitle = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[3]"));
            IWebElement editeddegree = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[4]"));
            IWebElement editedgraduationyear = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[5]"));
            if (editeduniversity.Text == newcollegeUniversityName && editedcountry.Text == newcountryOfCollegeUniversity && editedtitle.Text == newtitle && editeddegree.Text == newdegree && editedgraduationyear.Text == newyearOfGraduation)
            {
                Assert.Pass("record edited successfully");
            }
            else
            {
                Assert.Fail("record not edited");
            }
        }

        [Test, TestCaseSource(nameof(GetTestData), new object[] { "Cancelinganeditoperationcorrectlydiscardschanges" })]
        public void Cancelinganeditoperationcorrectlydiscardschanges(string collegeUniversityName, string countryOfCollegeUniversity, string title, string degree, string yearOfGraduation,string newtitle) 
        {
            EducationPage educationPageObj = new EducationPage();
            educationPageObj.CreateEducationRecord(driver, collegeUniversityName, countryOfCollegeUniversity, title, degree, yearOfGraduation);
            IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            if(popupAlert.Text == "Education has been added")
            {
                Console.WriteLine("Education record created successfully");
            }
            else
            {
                Console.WriteLine("Education record not created");
            }
                
            IWebElement createduniversity = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
            IWebElement createdcountry = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement createdtitle = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[3]"));
            IWebElement createddegree = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[4]"));
            IWebElement createdgraduationyear = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[5]"));
            if (createduniversity.Text == collegeUniversityName && createdcountry.Text == countryOfCollegeUniversity && createdtitle.Text == title && createddegree.Text == degree && createdgraduationyear.Text == yearOfGraduation)
            {
                Console.WriteLine("record created successfully");
            }
            else
            {
                Console.WriteLine("record creation unsuccessful");
            }
            educationPageObj.CancelEditOperation(driver, newtitle);
            IWebElement Title = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[3]"));
            if (Title.Text == newtitle)
            {
                Assert.Pass("Canceling an edit operation should correctly discards changes and Subsequent edits respect the cancellation and do not save unexpected changes. No system is not doing this");
            }
            else
            {
                Assert.Fail("Canceling an edit operation should correctly discards changes and Subsequent edits respect the cancellation and do not save unexpected changes. Yes system is not doing this");
            }
        }
        
        [Test, TestCaseSource(nameof(GetTestData), new object[] { "DeleteEducationRecord" })]
        public void DeleteEducationRecord(string collegeUniversityName, string countryOfCollegeUniversity, string title, string degree, string yearOfGraduation)
        {
            EducationPage educationPageObj = new EducationPage();
            educationPageObj.CreateEducationRecord(driver, collegeUniversityName, countryOfCollegeUniversity, title, degree, yearOfGraduation);
            IWebElement newuniversity = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
            IWebElement newcountry = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            IWebElement newtitle = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[3]"));
            IWebElement newdegree = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[4]"));
            IWebElement newgraduationyear = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[5]"));
            if (newuniversity.Text == collegeUniversityName && newcountry.Text == countryOfCollegeUniversity && newtitle.Text == title && newdegree.Text == degree && newgraduationyear.Text == yearOfGraduation)
            {
                Console.WriteLine("record created successfully");
            }
            else
            {
                Console.WriteLine("record creation unsuccessful");
            }

            educationPageObj.DeleteEducationRecord(driver);
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']", 2);
            IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
            if(popupAlert.Text == "Education entry successfully removed")
            {
                Assert.Pass("Record deleted successfully");
            }
            else
            {
                Assert.Fail("Record not deleted");
            }
        }
        
    }
}
