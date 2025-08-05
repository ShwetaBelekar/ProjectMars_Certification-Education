using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Project_Mars.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Mars.BaseClass
{
    //public class BaseTest
    //{
    //    protected IWebDriver driver;
    //    protected LoginPage loginPageObj;
    //    protected HomeToEducationPage homeToEducationPageObj;
    //    protected HomeToCertificationsPage homeToCertificationsPageObj;



    //    [OneTimeSetUp]
    //    public void Open()
    //    {
    //        driver = new ChromeDriver();

    //        LoginPage loginPageObj = new LoginPage();
    //        loginPageObj.LoginActions(driver);


    //    }

    //    [OneTimeTearDown]
    //    public void CleanUp()
    //    {


    //        if (TestContext.CurrentContext.Test.Properties["Category"].Contains("Education"))
    //        {
    //            try
    //            {
    //                HomeToEducationPage homeToEducationPageObj = new HomeToEducationPage();
    //                homeToEducationPageObj.NavigateToEducation(driver);


    //                var deleteButtons = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[2]/i"));
    //                for (int i = deleteButtons.Count - 1; i >= 0; i--)
    //                {
    //                    deleteButtons[i].Click();
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                Console.WriteLine($"Error during cleanup: {ex.Message}");
    //            }
    //            finally
    //            {
    //                driver.Quit();
    //            }
    //        }
    //        else if (TestContext.CurrentContext.Test.Properties["Category"].Contains("Certification"))
    //        {
    //            try
    //            {
    //                HomeToCertificationsPage homeToCertificationsPageObj = new HomeToCertificationsPage();
    //                homeToCertificationsPageObj.NavigateToCertifications(driver);


    //                var deleteButtons = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]/i"));
    //                for (int i = deleteButtons.Count - 1; i >= 0; i--)
    //                {
    //                    deleteButtons[i].Click();
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                Console.WriteLine($"Error during cleanup: {ex.Message}");
    //            }
    //            finally
    //            {
    //                driver.Quit();
    //            }
    //        }





    //    }

    //}
    using AventStack.ExtentReports;
    using AventStack.ExtentReports.Model;
    using AventStack.ExtentReports.Reporter;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System;

    public class BaseTest
    {
        protected IWebDriver driver;
        protected LoginPage loginPageObj;
        protected HomeToEducationPage homeToEducationPageObj;
        protected HomeToCertificationsPage homeToCertificationsPageObj;
        //protected ExtentReports extent;
        protected ExtentReports educationReport;
        protected ExtentReports certificationReport;
        protected ExtentTest test;

        [OneTimeSetUp]
        public void Open()
        {
            educationReport = new ExtentReports();
            var educationSpark = new ExtentSparkReporter("education_report.html");
            educationReport.AttachReporter(educationSpark);

            certificationReport = new ExtentReports();
            var certificationSpark = new ExtentSparkReporter("certification_report.html");
            certificationReport.AttachReporter(certificationSpark);
        
        //extent = new ExtentReports();
        //var spark = new ExtentSparkReporter("report.html");
        //extent.AttachReporter(spark);

        driver = new ChromeDriver();
            loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);

            //test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            try
            {
                if (TestContext.CurrentContext.Test.Properties["Category"].Contains("Education"))
                {
                    homeToEducationPageObj = new HomeToEducationPage();
                    homeToEducationPageObj.NavigateToEducation(driver);

                    var deleteButtons = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[2]/i"));
                    for (int i = deleteButtons.Count - 1; i >= 0; i--)
                    {
                        deleteButtons[i].Click();
                        test.Log(Status.Pass, "Deleted education entry");
                    }
                }
                else if (TestContext.CurrentContext.Test.Properties["Category"].Contains("Certification"))
                {
                    homeToCertificationsPageObj = new HomeToCertificationsPage();
                    homeToCertificationsPageObj.NavigateToCertifications(driver);

                    var deleteButtons = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]/i"));
                    for (int i = deleteButtons.Count - 1; i >= 0; i--)
                    {
                        deleteButtons[i].Click();
                        test.Log(Status.Pass, "Deleted certification entry");
                    }
                }
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"Error during cleanup: {ex.Message}");
            }
            finally
            {
                driver.Quit();
                //extent.Flush();
            }
        }

        [TearDown]
        public void TearDown()
        {
            string category = TestContext.CurrentContext.Test.Properties["Category"].ToString();


            ExtentReports report = category.Contains("Education") ? educationReport : certificationReport;
            test = report.CreateTest(TestContext.CurrentContext.Test.Name);

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                test.Log(Status.Fail, "Test failed");
                test.AddScreenCaptureFromPath(GetScreenshot());
            }
            else
            {

                test.Log(Status.Pass, "Test passed");
            }
            report.Flush();

        }

        private string GetScreenshot()
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            var filename = $"screenshot_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.png";
            screenshot.SaveAsFile(filename);
            return filename;
        }

    }
}
