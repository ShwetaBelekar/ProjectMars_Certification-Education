using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Mars.Pages
{
    public class HomeToCertificationsPage
    {
        private IWebDriver driver;
        private By profileTabXPath = By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]");
        private By certificationOptionXPath = By.XPath("//a[text()='Certifications']");
        public void NavigateToCertifications(IWebDriver driver)
        {
            this.driver = driver;
            driver.FindElement(profileTabXPath).Click();
            driver.FindElement(certificationOptionXPath).Click();
            //Thread.Sleep(2000);
            //IWebElement profileTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]"));
            //profileTab.Click();

            //IWebElement certificationOption = driver.FindElement(By.XPath("//a[text()='Certifications']"));
        }
    }
}
