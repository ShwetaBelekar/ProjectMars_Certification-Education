using OpenQA.Selenium;
using Project_Mars.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Mars.Pages
{
    public class SigninPage : CommonDriver
    {
       public void ValidSigninAction()
        {
            string EmailId = "moneytony@ymail.com";
            string Password = "Tonymoney@2025";
           
            IWebElement Signin = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            Signin.Click();

            //Enter email
            IWebElement Email = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            Email.Click();
            Email.SendKeys(EmailId);

            //Enter password
            IWebElement Pwd = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
            Pwd.Click();
            Pwd.SendKeys(Password);

            //Click on login button
            IWebElement LoginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            LoginButton.Click();

        }

        public void InValidSigninAction(string email, string password)
        {
            IWebElement Signin = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            Signin.Click();

            //Enter email
            IWebElement Email = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            Email.Click();
            Email.SendKeys(email);

            //Enter password
            IWebElement Password = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
            Password.Click();
            Password.SendKeys(password);

            //Click on login button
            IWebElement LoginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            LoginButton.Click();
        }
        public void EmailFieldBlank()
        {
            IWebElement EmailField = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/div"));

        }

        public void PasswordFieldBlank()
        {
            IWebElement PasswordField = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/div"));

        }
    }
}
