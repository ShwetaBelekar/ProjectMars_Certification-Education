using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnupportal2025.Utilities;

namespace Project_Mars.Pages
{
    public class LoginPage
    {
        public void LoginActions(IWebDriver driver)
        {

            //driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5003/Home");
            driver.Manage().Window.Maximize();
            Thread.Sleep(3000);

            IWebElement signinButton = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            signinButton.Click();
            Thread.Sleep(2000);

            IWebElement emailAddressTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            emailAddressTextbox.SendKeys("moneytony@ymail.com");

            IWebElement passwordTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
            passwordTextbox.SendKeys("Tonymoney@2025");

            IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            loginButton.Click();
            Thread.Sleep(5000);
        }

        public void VerifyUserInHomePage(IWebDriver driver)
        {

            IWebElement hitony = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span"));

            if (hitony.Text == "Hi Tony")
            {
                Console.WriteLine("User has logged in successfully. Test Passed!");
            }
            else
            {
                Console.WriteLine("User has not logged in. Test Failed!");
            }




        }
    }
}
