using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Mars.Pages
{
    public class HomeToEducationPage
    {
        private IWebDriver driver;
        private By profileTabXPath = By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]");
        private By educationOptionXPath = By.XPath("//a[text()='Education']");
        public void NavigateToEducation(IWebDriver driver)
        {
            this.driver = driver;
            driver.FindElement(profileTabXPath).Click();
            driver.FindElement(educationOptionXPath).Click();
            //Thread.Sleep(2000);
            //IWebElement profileTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]"));
            //profileTab.Click();

            //IWebElement educationOption = driver.FindElement(By.XPath("//a[text()='Education']"));
            //educationOption.Click();
        }
    }
}
