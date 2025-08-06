using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
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
    public class BaseTest
    {
        protected IWebDriver driver;
        protected LoginPage loginPageObj;
        protected HomeToEducationPage homeToEducationPageObj;
        protected HomeToCertificationsPage homeToCertificationsPageObj;
        protected static ExtentReports extentReport;
        protected ThreadLocal<ExtentTest> test = new ThreadLocal<ExtentTest>();
        //protected ExtentReports extentReport;
        //protected ExtentTest test;

        [OneTimeSetUp]
        public void Open()
        {
            string projectRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", ".."));
            string reportDirectory = Path.Combine(projectRoot, "ExtentReports");
            if (!Directory.Exists(reportDirectory))
            {
                Directory.CreateDirectory(reportDirectory);
            }
            string reportPath = Path.Combine(reportDirectory, "report.html");
            extentReport = new ExtentReports();
            var spark = new ExtentSparkReporter(reportPath);
            extentReport.AttachReporter(spark);
            //extentReport = new ExtentReports();
            //var spark = new ExtentSparkReporter("report.html");
            //extentReport.AttachReporter(spark);


            driver = new ChromeDriver();
            loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);
        }
        [SetUp]
        public void SetUp()
        {
            string category = TestContext.CurrentContext.Test.Properties["Category"].ToString();
            string testName = $"{TestContext.CurrentContext.Test.Name} - {category}";
            test.Value = extentReport.CreateTest(testName);
        }

        [TearDown]
        public void TearDown()
        {

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                test.Value.Log(Status.Fail, "Test failed");
                test.Value.AddScreenCaptureFromPath(GetScreenshot());
            }
            else
            {
                test.Value.Log(Status.Pass, "Test passed");
            }

        }
        private string GetScreenshot()
        {
            string projectRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", ".."));
            string screenshotDirectory = Path.Combine(projectRoot, "Screenshot");
            if (!Directory.Exists(screenshotDirectory))
            {
                Directory.CreateDirectory(screenshotDirectory);
            }
            string filename = $"screenshot_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.png";
            string screenshotPath = Path.Combine(screenshotDirectory, filename);
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(screenshotPath);
            return screenshotPath;
            //var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            //var filename = $"screenshot_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.png";
            //screenshot.SaveAsFile(filename);
            //return filename;
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            if (TestContext.CurrentContext.Test.Properties["Category"].Contains("Education"))
            {
                try
                {
                    HomeToEducationPage homeToEducationPageObj = new HomeToEducationPage();
                    homeToEducationPageObj.NavigateToEducation(driver);

                    var deleteButtons = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[2]/i"));
                    for (int i = deleteButtons.Count - 1; i >= 0; i--)
                    {
                        deleteButtons[i].Click();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error during cleanup: {ex.Message}");
                }
            }
            else if (TestContext.CurrentContext.Test.Properties["Category"].Contains("Certification"))
            {
                try
                {
                    HomeToCertificationsPage homeToCertificationsPageObj = new HomeToCertificationsPage();
                    homeToCertificationsPageObj.NavigateToCertifications(driver);

                    var deleteButtons = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]/i"));
                    for (int i = deleteButtons.Count - 1; i >= 0; i--)
                    {
                        deleteButtons[i].Click();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error during cleanup: {ex.Message}");
                }
            }

            extentReport.Flush();
            driver.Quit();
        }
    }
}
//namespace Project_Mars.BaseClass
//{
//    public class BaseTest
//    {
//        protected IWebDriver driver;
//        protected LoginPage loginPageObj;
//        protected HomeToEducationPage homeToEducationPageObj;
//        protected HomeToCertificationsPage homeToCertificationsPageObj;



//        [OneTimeSetUp]
//        public void Open()
//        {
//            driver = new ChromeDriver();

//            LoginPage loginPageObj = new LoginPage();
//            loginPageObj.LoginActions(driver);


//        }

//        [OneTimeTearDown]
//        public void CleanUp()
//        {


//            if (TestContext.CurrentContext.Test.Properties["Category"].Contains("Education"))
//            {
//                try
//                {
//                    HomeToEducationPage homeToEducationPageObj = new HomeToEducationPage();
//                    homeToEducationPageObj.NavigateToEducation(driver);


//                    var deleteButtons = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[2]/i"));
//                    for (int i = deleteButtons.Count - 1; i >= 0; i--)
//                    {
//                        deleteButtons[i].Click();
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"Error during cleanup: {ex.Message}");
//                }
//                finally
//                {
//                    driver.Quit();
//                }
//            }
//            else if (TestContext.CurrentContext.Test.Properties["Category"].Contains("Certification"))
//            {
//                try
//                {
//                    HomeToCertificationsPage homeToCertificationsPageObj = new HomeToCertificationsPage();
//                    homeToCertificationsPageObj.NavigateToCertifications(driver);


//                    var deleteButtons = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]/i"));
//                    for (int i = deleteButtons.Count - 1; i >= 0; i--)
//                    {
//                        deleteButtons[i].Click();
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"Error during cleanup: {ex.Message}");
//                }
//                finally
//                {
//                    driver.Quit();
//                }
//            }





//        }

//    }

//}
