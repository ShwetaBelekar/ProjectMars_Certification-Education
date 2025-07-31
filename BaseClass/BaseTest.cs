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
    public class BaseTest
    {
        protected IWebDriver driver;
        protected LoginPage loginPageObj;
        protected HomeToEducationPage homeToEducationPageObj;
        protected HomeToCertificationsPage homeToCertificationsPageObj;

       

        [OneTimeSetUp]
        public void Open()
        {
            driver = new ChromeDriver();

            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);

            //loginPageObj.VerifyUserInHomePage(driver);

            //HomeToEducationPage homeToEducationPageObj = new HomeToEducationPage();
            //homeToEducationPageObj.NavigateToEducation(driver);
        }
        //public void Open()
        //{
        //    //driver = new ChromeDriver();
        //}
        [OneTimeTearDown]
        public void CleanUp()
        {
            //IWebDriver driver = new ChromeDriver();
            //LoginPage loginPageObj = new LoginPage();
            //loginPageObj.LoginActions(driver);

            if (TestContext.CurrentContext.Test.Properties["Category"].Contains("Education"))
            {
                try
                {
                    HomeToEducationPage homeToEducationPageObj = new HomeToEducationPage();
                    homeToEducationPageObj.NavigateToEducation(driver);

                    // Delete languages logic here
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
                finally
                {
                    driver.Quit();
                }
            }
            else if (TestContext.CurrentContext.Test.Properties["Category"].Contains("Certification"))
            {
                try
                {
                    HomeToCertificationsPage homeToCertificationsPageObj = new HomeToCertificationsPage();
                    homeToCertificationsPageObj.NavigateToCertifications(driver);

                    // Delete languages logic here
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
                finally
                {
                    driver.Quit();
                }
            }
            



          
        }

    }
}
